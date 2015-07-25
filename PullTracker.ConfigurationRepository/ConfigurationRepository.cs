using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading;

namespace PullTracker.ConfigurationRepository
{
    /// <summary>
    /// This class is used to access all the config values
    /// </summary>
    public class ConfigurationRepository
    {
        private static readonly ConfigurationRepository configurationInstance = new ConfigurationRepository();
        private readonly ReaderWriterLockSlim syncLock = new ReaderWriterLockSlim();
        private NameValueCollection AppSettings;

        public string Username { get; private set; }
        public string NetworkUserName { get; private set; }
        public string Password { get; private set; }
        public string Repository { get; private set; }
        public string OpenRequest { get; private set; }
        public string MergeRequest { get; private set; }
        public string Branch { get; private set; }
        public string UrlDomain { get; private set; }
        public string SourceBranch { get; private set; }
        public string TargetBranch { get; private set; }
        public string Hooks { get; private set; }

        static ConfigurationRepository()
        {
        }

        public static ConfigurationRepository ConfigurationInstance
        {
            get { return configurationInstance; }
        }

        public void RefreshAppSection()
        {
            syncLock.EnterReadLock();
            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                AppSettings = ConfigurationManager.AppSettings;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (syncLock.IsReadLockHeld) syncLock.ExitReadLock();
            }

            Username = AppSettings["username"];
            NetworkUserName = AppSettings["NetworkUserName"];
            Password = AppSettings["password"];
            Repository = AppSettings["Repository"];
            OpenRequest = AppSettings["OpenRequest"];
            MergeRequest = AppSettings["MergeRequest"];
            Branch = AppSettings["Branch"];
            UrlDomain = AppSettings["UrlDomain"];
            SourceBranch = AppSettings["SourceBranch"];
            TargetBranch = AppSettings["TargetBranch"];
            Hooks = AppSettings["Hooks"];
        }
    }
}
