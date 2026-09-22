using System.Globalization;

namespace GiftOfTheGivers.Services
{
    public class CertificateService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public CertificateService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GetCertificateAsync(string donorName, decimal amount, string certificateNumber)
        {
            string baseUrl = _config["CertificateFunction:Url"] ?? "";

            string url = baseUrl +
                "?donorName=" + Uri.EscapeDataString(donorName) +
                "&amount=" + amount.ToString(CultureInfo.InvariantCulture) +
                "&certificateNumber=" + Uri.EscapeDataString(certificateNumber);

            try
            {
                return await _httpClient.GetStringAsync(url);
            }
            catch (Exception)
            {
                return "Your certificate could not be generated right now. Please try again later.";
            }
        }
    }
}