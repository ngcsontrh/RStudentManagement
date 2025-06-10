using RStudentManagement.Core.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Core
{
    internal class NetworkManager
    {
        private readonly ILogger _logger;

        private NetworkManager()
        {
            _logger = LoggerFactory.Instance.GetLogger(AppConfig.LoggerType);
        }

        public static NetworkManager Instance { get; } = new NetworkManager();

        public bool IsInternetAvailable()
        {
            try
            {
                using var httpClient = new System.Net.Http.HttpClient { Timeout = TimeSpan.FromSeconds(3) };
                using var response = httpClient.GetAsync("http://www.google.com").Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while checking the internet connection.", ex);
                return false;
            }
        }
    }
}
