using System;

namespace PullTracker.ApiConsumer
{
    /// <summary>
    /// This class behaves as the Stash API Consumer
    /// </summary>
    public class StashCoreApiConsumer : IStashCoreApiConsumer
    {
        ClientBuilder clientBuilder = new ClientBuilder();
        private readonly ConfigurationRepository.ConfigurationRepository configurationInstance =
            ConfigurationRepository.ConfigurationRepository.ConfigurationInstance;

        public StashCoreApiConsumer()
        {
            configurationInstance.RefreshAppSection();
        }

        /// <summary>
        /// This method executes the open pull request api call
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public string GetOpenPullRequests(string repository)
        {
            try
            {
                var httpClient = clientBuilder.BuildHttpClient();

                var response =
                    httpClient.GetAsync(configurationInstance.Repository + repository + configurationInstance.OpenRequest).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This method executes the merge ready pull request api call
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public string GetMergeReadyPullRequests(string repository)
        {
            try
            {
                var httpClient = clientBuilder.BuildHttpClient();

                var response =
                    httpClient.GetAsync(configurationInstance.Repository + repository + configurationInstance.MergeRequest).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This method executes Open Branch request API call
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public string GetOpenBranches(string repository)
        {
            try
            {
                var httpClient = clientBuilder.BuildHttpClient();

                var response =
                    httpClient.GetAsync(configurationInstance.Repository + repository + configurationInstance.Branch).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This method executes Get Hooks API request
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public string GetHooks(string repository)
        {
            try
            {
                var httpClient = clientBuilder.BuildHttpClient();

                var response =
                    httpClient.GetAsync(configurationInstance.Repository + repository + configurationInstance.Hooks).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        /// <summary>
        /// This method gets all projects in the repository
        /// </summary>
        /// <returns></returns>
        public string GetProjectRepos()
        {
            try
            {
                var httpClient = clientBuilder.BuildHttpClient();

                var response = httpClient.GetAsync(configurationInstance.Repository).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
