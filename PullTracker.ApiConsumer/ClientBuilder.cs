using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PullTracker.ApiConsumer
{
    /// <summary>
    /// This class build the http client object to make the stash API request
    /// </summary>
    public class ClientBuilder
    {
        private readonly ConfigurationRepository.ConfigurationRepository configurationInstance =
            ConfigurationRepository.ConfigurationRepository.ConfigurationInstance;

        public ClientBuilder()
        {
            configurationInstance.RefreshAppSection();
        }

        /// <summary>
        /// This emthod builds the http client
        /// </summary>
        /// <returns></returns>
        public HttpClient BuildHttpClient()
        {

            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(configurationInstance.NetworkUserName.ToString(CultureInfo.InvariantCulture),configurationInstance.Password.ToString(CultureInfo.InvariantCulture)),
                CookieContainer = new CookieContainer { }
            };
            var httpClient = new HttpClient(handler);

            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(configurationInstance.Username+":"+configurationInstance.Password));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            httpClient.BaseAddress = new Uri(configurationInstance.UrlDomain);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
