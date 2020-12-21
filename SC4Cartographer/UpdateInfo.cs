using System;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Linq;

namespace SC4CartographerUI
{
    public class UpdateInfo
    {
        public bool NewVersionAvailable = false;

        public Version Version = null;
        public string Tag = "";
        public string Name = "";
        public string Description = "";
        public string BrowserDownloadLink = "";
        public string ReleasePageLink = "";

        public UpdateInfo()
        {
            GetVersionInfo();
        }

        public bool IsNewVersionAvailable()
        {
            return NewVersionAvailable;
        }

        private void GetVersionInfo()
        {
            using (var webClient = new System.Net.WebClient())
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2
                webClient.Headers["User-Agent"] = "SC4Cartographer (version_check)"; // Need to specif a valid user agent for github api: https://stackoverflow.com/a/39912696

                try
                {
                    // Fetch latest release info from github api
                    string jsonResult = webClient.DownloadString(
                        $"http://api.github.com/repos/killeroo/sc4cartographer/releases/latest");

                    // Extract version from returned json
                    Regex regex = new Regex(@"""(tag_name)"":""((\\""|[^""])*)""");
                    Match result = regex.Match(jsonResult);
                    if (result.Success)
                    {
                        string matchString = result.Value;
                        Version theirVersion = new Version(matchString.Split(':')[1].Replace("\"", string.Empty).Replace("v", string.Empty));
                        Version ourVersion = Assembly.GetExecutingAssembly().GetName().Version;

                        if (theirVersion > ourVersion)
                        {
                            NewVersionAvailable = true;
                        }

                        Version = theirVersion;

                        // Extract some more info about the release
                        Match releaseBodyMatch = new Regex(@"""(body)"":""((\\""|[^""])*)""").Match(jsonResult);
                        if (releaseBodyMatch.Success)
                        {
                            Description = releaseBodyMatch.Value.Split(':').Last().Replace("\"", "");
                        }

                        Match releaseDownloadLinkMatch = new Regex(@"""(browser_download_url)"":""((\\""|[^""])*)""").Match(jsonResult);
                        if (releaseDownloadLinkMatch.Success)
                        {
                            // The 'https' at the start is a little hack because the split command on the json kind of messes up
                            // urls
                            BrowserDownloadLink = @"https:" + (releaseDownloadLinkMatch.Value.Split(':').Last().Replace("\"", ""));
                        }

                        Match updatePageLinkMatch = new Regex(@"""(html_url)"":""((\\""|[^""])*)""").Match(jsonResult);
                        if (updatePageLinkMatch.Success)
                        {
                            ReleasePageLink = @"https:" + (updatePageLinkMatch.Value.Split(':').Last().Replace("\"", ""));
                        }

                        Match updateTagMatch = new Regex(@"""(tag_name)"":""((\\""|[^""])*)""").Match(jsonResult);
                        if (updateTagMatch.Success)
                        {
                            Tag = updateTagMatch.Value.Split(':').Last().Replace("\"", "");
                        }

                        Match updateNameMatch = new Regex(@"""(name)"":""((\\""|[^""])*)""").Match(jsonResult);
                        if (updateNameMatch.Success)
                        {
                            Name = updateNameMatch.Value.Split(':').Last().Replace("\"", "");
                        }
                    }

                }
                catch (Exception) { } // We just want to blanket catch any exception and silently continue

            }

        }
    }
}
