using System;
using System.Net;

namespace SC4CartographerUI
{
    class UpdateChecker
    {
        /// <summary>
        /// Get latest info about latest release on github via an async download string call
        /// </summary>
        /// <param name="handler">callback to be fired when data is downloaded</param>
        public static void GetLatestReleaseInfoAsync(DownloadStringCompletedEventHandler handler)
        {
            // Setup web client
            WebClient client = new WebClient();
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            client.Headers["User-Agent"] = "SC4Cartographer (version_check)";

            // Add callback 
            client.DownloadStringCompleted += (sender, args) => handler(sender, args);
            
            // Kick off async download
            client.DownloadStringAsync(new Uri(@"http://api.github.com/repos/killeroo/sc4cartographer/releases/latest"));
        }

        /// <summary>
        /// Gets info about the latest release from github via a blocking web call
        /// </summary>
        /// <returns>Info about the release</returns>
        public static UpdateInfo GetLatestReleaseInfo()
        {
            WebClient client = new WebClient();

            // Setup our request
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            client.Headers["User-Agent"] = "SC4Cartographer (version_check)";

            // Download string from github api
            string response = client.DownloadString(new Uri(@"http://api.github.com/repos/killeroo/sc4cartographer/releases/latest"));

            // Parse info and store in object
            UpdateInfo info = new UpdateInfo(response);

            return info;
            
        }
    }
}
