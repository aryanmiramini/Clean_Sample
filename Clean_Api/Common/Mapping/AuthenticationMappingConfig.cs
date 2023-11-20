using Clean_Application.Authentication.Commands.Register;
using Clean_Application.Authentication.Common;
using Clean_Application.Authentication.Queries.Login;
using Clean_Contracts.Authentication;
using Mapster;

namespace Clean_Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                 .Map(dest => dest, src => src.User);
        }
    }
}

