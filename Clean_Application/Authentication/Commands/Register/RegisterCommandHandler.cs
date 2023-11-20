using Clean_Application.Authentication.Common;
using Clean_Application.Common.Interfaces.Authentication;
using Clean_Application.Common.Interfaces.Persistance;
using Clean_Domain.Common.Errors;
using Clean_Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clean_Domain.Common.Errors.Errors;
using User = Clean_Domain.Entities.User;

namespace Clean_Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand Command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1. Validate the user doesnt exist 
            if (_userRepository.GetUserByEmail(Command.Email) != null)
            {
                return Errors.User.DuplicateEmail;
            }

            //2.Create user (Generate unique ID) & Persist to DB 
            var user = new User
            {
                FirstName = Command.FirstName,
                LastName = Command.LastName,
                Email = Command.Email,
                Password = Command.Password
            };
            _userRepository.Add(user);

            //3.Create Jwt Token
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult
                (
                user,
                token
                );
        }
    }
}
