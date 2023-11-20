using Clean_Application.Authentication.Commands.Register;
using Clean_Application.Authentication.Common;
using Clean_Application.Authentication.Queries.Login;
using Clean_Contracts.Authentication;
using Clean_Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapper.Map<RegisterCommand>(registerRequest);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                  authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                  errors => Problem(errors));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var query =_mapper.Map<LoginQuery>(loginRequest);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            ;

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                  authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                  errors => Problem(errors));
        }
    }
}
