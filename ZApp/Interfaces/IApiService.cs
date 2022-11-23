using ZApp.Models;

namespace ZApp.Interfaces
{
    public interface IApiService
    {
        Task<ApiResponse<T>> PostAsync<T>(object model, string service) where T : class;
        Task<ApiResponse<T>> GetAsync<T>(string service) where T : class;
    }
}
