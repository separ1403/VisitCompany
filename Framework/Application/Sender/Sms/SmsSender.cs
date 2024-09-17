using Kavenegar;
using Microsoft.Extensions.Configuration;

namespace Framework.Application.Sender.Sms;

public class SmsSender : ISmsSender
{
    //private readonly HttpClient _httpClient;
    //public SmsSender(HttpClient httpClient) =>
    //    _httpClient = httpClient;
    private readonly IConfiguration _configuration;

    public SmsSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<int> SendByKavenagarAsync(string message, string PhoneNumber)
    {
        try
        {
            //var keys = _configuration.GetSection("SmsApiKeys");
            //var kavenegarKey = keys.GetSection("kavenegar").Value;


            //var kavenegarKey =
            //    "61612F51737A717A734654714E4646344C594E4A31736F764733655435717163772F63565A6653596859633D";

            //var _httpClient = new HttpClient();
            //var httpResponse = await _httpClient.GetAsync($"https://api.kavenegar.com/v1/{kavenegarKey}/sms/send.json?receptor={PhoneNumber}&sender=&message={message}");
            var api = new KavenegarApi(
                "6D37437649366A745A31415350313756456E37654C5635696171474B6F5448796C445467777754644A42413D");
            var sender = "10008663";

            var httpResponse = await api.Send(sender, PhoneNumber, message);
            //var res = await api.VerifyLookup("10008663", PhoneNumber, message);
            //if (httpResponse.StatusCode == HttpStatusCode.OK)
            //    if (httpResponse.Status == 1) 
            //    return 1;
            //else
            //    return 0;
            return httpResponse.Status;
        }
        catch
        {
            return -1;
        }
    }
}