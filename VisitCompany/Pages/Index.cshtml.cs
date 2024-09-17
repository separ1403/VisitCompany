using CompanyManagement.Application.Contract.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace VisitCompany.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;
        public CompanySearchModel searchModel;
        public string name;

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public ResponseFullInfoApi data { get; set; }
        public List<string> Error { get; set; } = new List<string>();



        public async Task OnGet(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    _httpClient.BaseAddress = new Uri("https://api.rasm.io/api/");
                    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    _httpClient.DefaultRequestHeaders.Add("X-Key", "ccdb6d41-3478-4296-b21d-ac18d0d38319");

                    HttpResponseMessage response = await _httpClient.GetAsync($"search/?term={name}");
                    if (response.IsSuccessStatusCode)
                    {
                        data = JsonConvert.DeserializeObject<ResponseFullInfoApi>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        Error.Add("کد خطا");
                    }
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
            }
            else
            {
                Error.Add("لطفا مقدار مورد نظر را وارد نمایید");
            }
        }

    }
}
