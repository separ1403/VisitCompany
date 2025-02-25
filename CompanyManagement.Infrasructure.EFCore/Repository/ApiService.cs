using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.CompanyAgg;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        public ResponseFullInfoApi data { get; set; }
        public CompanyResponse CompanyData { get; set; } // تعریف برای ارسال به ویو

        public List<string> Error { get; set; } = new List<string>();
        public CompanyDetailsViewModel CompanyDetails { get; set; }

        public async Task<CompanyResponse> GetCompanyDetailsAsync(string companyId)
        {
            if (string.IsNullOrEmpty(companyId))
            {
                Error.Add("لطفا شناسه ملی شرکت را وارد کنید");
                _logger.LogWarning("National Code is missing.");
                return null;
            }

            try
            {
                _httpClient.BaseAddress = new Uri("https://api.rasm.io/api/");
                _httpClient.Timeout = TimeSpan.FromSeconds(200); // افزایش زمان انتظار
                _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                _httpClient.DefaultRequestHeaders.Add("X-Key", "ccdb6d41-3478-4296-b21d-ac18d0d38319");

                HttpResponseMessage response = await _httpClient.GetAsync($"Company/{companyId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    CompanyData = JsonConvert.DeserializeObject<CompanyResponse>(responseData);

                    return CompanyData;
                }
                else
                {
                    Error.Add($"خطا: {response.StatusCode}");
                    _logger.LogWarning($"Failed to fetch company details: {response.StatusCode}");
                }
            }
            catch (TaskCanceledException ex)
            {
                Error.Add("درخواست لغو شد یا زمان آن به پایان رسید.");
                _logger.LogError(ex, $"Request canceled or timed out for companyId: {companyId}. Exception: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
            catch (HttpRequestException ex)
            {
                Error.Add("لطفا وضعیت اینترنت خود را بررسی کنید");
                _logger.LogError(ex, "خطا در اتصال به API");
            }
            catch (Exception ex)
            {
                Error.Add("یک خطای غیرمنتظره رخ داده است");
                _logger.LogError(ex, "یک خطای غیرمنتظره رخ داده است");
            }

            return null;
        }





    }

}
