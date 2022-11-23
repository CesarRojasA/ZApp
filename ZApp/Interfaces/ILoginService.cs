using ZApp.Models;

namespace ZApp.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseModel> postLogin(LoginRequestModel loginModel);
    }
}

