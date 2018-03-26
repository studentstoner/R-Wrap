using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RWrap
{
    public static class Authenification
    {
        public static string Login(string user, string pass)
        {
            string stats = "";
            byte[] data = Encoding.ASCII.GetBytes("{\"username\":\"" + user + "\",\"password\":\"" + pass + "\"}");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.roblox.com/v2/login");
            req.Method = "POST";
            req.Host = "api.roblox.com";
            req.KeepAlive = true;
            req.Headers.Add("Origin: https://www.roblox.com");
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
            req.Headers.Add(HttpRequestHeader.CacheControl, "private");
            req.Referer = "https://www.roblox.com/Login";
            req.Accept = "application/json";
            req.ContentType = "application/json;charset=UTF-8";
            req.ContentLength = data.Length;
            req.GetRequestStream().Write(data, 0, data.Length);
            var resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            stats = sr.ReadToEnd() + "\r\n\r\n" + resp.Headers;
            return stats;
        }

        public static string Register(string user, string pass, bool male)
        {
            string stats = "";

            string gender = "2";

            if (!male)
            {
                gender = "3";
            }

            byte[] data = Encoding.ASCII.GetBytes($"isEligibleForHideAdsAbTest=False&username={user}&password={pass}&birthday={new Random().Next(1, 25).ToString()}+Sep+2001&gender={gender}&isTosAgreementBoxChecked=true&context=RollerCoasterSignupForm");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.roblox.com/signup/v1");
            req.Method = "POST";
            req.Host = "api.roblox.com";
            req.KeepAlive = true;
            req.Headers.Add("Origin: https://www.roblox.com");
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
            req.Headers.Add(HttpRequestHeader.CacheControl, "private");
            req.Accept = "application/json, text/plain, */*";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;
            req.GetRequestStream().Write(data, 0, data.Length);
            var resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            stats = sr.ReadToEnd() + "\r\n\r\n" + resp.Headers;
            return stats;
        }
    }
}
