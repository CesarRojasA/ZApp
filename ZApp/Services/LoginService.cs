using ZApp.Interfaces;
using ZApp.Models;

namespace ZApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly IApiService _apiService;
        public LoginService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<LoginResponseModel> postLogin(LoginRequestModel loginModel)
        {
            try
            {
                ApiResponse<LoginResponseModel> response = await _apiService.PostAsync<LoginResponseModel>(loginModel, "UserSignIn");
                return response.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
