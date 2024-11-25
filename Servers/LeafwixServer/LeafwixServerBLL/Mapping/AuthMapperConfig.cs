using LeafwixServerBLL.Models;
using LeafwixServerDAL.Entities.Identity;
using Mapster;

namespace LeafwixServerBLL.Mapping
{
    public class AuthMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, UserRegisterInformation>();

            config.NewConfig<User, AuthenticationResponse>()
                 .Map(dest => dest.UserName, src => src.UserName)
                 .Map(dest => dest.Email, src => src.Email);

            config.NewConfig<LoginRequest, UserLoginInformation>();

            config.NewConfig<ForgotPasswordRequest, ForgotPasswordInformation>();

            config.NewConfig<ResetPasswordRequest, ResetPasswordInformation>();

            config.NewConfig<RevokeRefreshTokenRequest, RevokeRefreshTokenInformation>();
        }
    }
}
