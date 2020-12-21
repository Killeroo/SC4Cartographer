using System;
using System.Net;

namespace SC4CartographerUI
{
    class UpdateChecker
    {
        public static void GetLatestReleaseInfoAsync(DownloadStringCompletedEventHandler handler)
        {
            WebClient client = new WebClient();
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            client.Headers["User-Agent"] = "SC4Cartographer (version_check)";
            client.DownloadStringCompleted += (sender, args) => handler(sender, args);
            client.DownloadStringAsync(new Uri(@"http://api.github.com/repos/killeroo/sc4cartographer/releases/latest"));
        }

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
