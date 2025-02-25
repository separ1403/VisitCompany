using CompanyManagement.Application.Contract.Company;
using Framework.Application;
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
        public string companyId;

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public ResponseFullInfoApi data { get; set; }
        public CompanyResponse CompanyData { get; set; } // تعریف برای ارسال به ویو

        public List<string> Error { get; set; } = new List<string>();
        public CompanyDetailsViewModel CompanyDetails { get; set; }



        // کد زیر برای استفاده از ای پی ای مربوط به کمپان یهاس است
        public async Task OnGet(string companyId)
        {

            if (!string.IsNullOrEmpty(companyId))
            {


                try
                {
                    _httpClient.BaseAddress = new Uri("https://api.rasm.io/api/");
                    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    _httpClient.DefaultRequestHeaders.Add("X-Key", "ccdb6d41-3478-4296-b21d-ac18d0d38319");

                    HttpResponseMessage response = await _httpClient.GetAsync($"Company/{companyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync(); // اجرای ای پی آی  , خروجی جی سان
                        CompanyData = JsonConvert.DeserializeObject<CompanyResponse>(responseData); // تبدیل ان  

                        // مدیریت داده‌های شرکت
                        Console.WriteLine($"Company Title: {CompanyData.Title}");
                        Console.WriteLine($"Registration No: {CompanyData.RegistrationNo}");
                    }
                    else
                    {
                        Error.Add($"خطا: {response.StatusCode}");
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
                Error.Add("لطفا شناسه ملی شرکت را وارد کنید");
            }
        }


        //public async Task OnGet(string name)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        try
        //        {
        //            _httpClient.BaseAddress = new Uri("https://api.rasm.io/api/");
        //            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //            _httpClient.DefaultRequestHeaders.Add("X-Key", "ccdb6d41-3478-4296-b21d-ac18d0d38319");

        //            HttpResponseMessage response = await _httpClient.GetAsync($"search/?term={name}");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                data = JsonConvert.DeserializeObject<ResponseFullInfoApi>(await response.Content.ReadAsStringAsync());

        //                // استخراج اطلاعات مهم از پاسخ API
        //                if (data?.hits?.hits != null && data.hits.hits.Any())
        //                {
        //                    var firstResult = data.hits.hits.First()._source;
        //                    CompanyDetails = new CompanyDetailsViewModel
        //                    {
        //                        EstablishmentDate = firstResult.date.ToFarsi(),
        //                        RegistrationNumber = firstResult.registrationNumber,
        //                        EconomicCode = firstResult.economicCode
        //                    };
        //                }
        //            }
        //            else
        //            {
        //                Error.Add("کد خطا");
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Error.Add("لطفا وضعیت اینترنت خود را بررسی کنید");
        //            _logger.LogError(ex, "خطا در اتصال به API");
        //        }
        //        catch (Exception ex)
        //        {
        //            Error.Add("یک خطای غیرمنتظره رخ داده است");
        //            _logger.LogError(ex, "یک خطای غیرمنتظره رخ داده است");
        //        }
        //    }
        //    else
        //    {
        //        Error.Add("لطفا مقدار مورد نظر را وارد نمایید");
        //    }
        //}




        ////کد زیر برای استفاد ه از ای پی ای کلی بود یعنی اولی از مستند ارسالی
        //// کد قبلی برای نمایش به صورت آی فریم

        //public async Task OnGet(string name)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        try
        //        {
        //            _httpClient.BaseAddress = new Uri("https://api.rasm.io/api/");
        //            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //            _httpClient.DefaultRequestHeaders.Add("X-Key", "ccdb6d41-3478-4296-b21d-ac18d0d38319");

        //            HttpResponseMessage response = await _httpClient.GetAsync($"search/?term={name}");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                data = JsonConvert.DeserializeObject<ResponseFullInfoApi>(response.Content.ReadAsStringAsync().Result);
        //            }
        //            else
        //            {
        //                Error.Add("کد خطا");
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Error.Add("لطفا وضعیت اینترنت خود را بررسی کنید");
        //            _logger.LogError(ex, "خطا در اتصال به API");
        //        }
        //        catch (Exception ex)
        //        {
        //            Error.Add("یک خطای غیرمنتظره رخ داده است");
        //            _logger.LogError(ex, "یک خطای غیرمنتظره رخ داده است");
        //        }
        //    }
        //    else
        //    {
        //        Error.Add("لطفا مقدار مورد نظر را وارد نمایید");
        //    }
        //}



    }
}
