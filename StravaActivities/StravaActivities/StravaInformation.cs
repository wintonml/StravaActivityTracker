using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace StravaActivities
{
    class StravaInformation
    {
        private readonly string _accessToken;

        public StravaInformation(string accessToken)
        {
            _accessToken = accessToken;
        }

        private async Task<T> GetStravaData<T>(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            string result = await reader.ReadToEndAsync();
                            return JsonConvert.DeserializeObject<T>(result);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (WebResponse errorResponse = ex.Response)
                {
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                        {
                            string errorText = reader.ReadToEnd();
                        }
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Athlete> GetAthlete()
        {
            string url = $"https://www.strava.com/api/v3/athlete?access_token={_accessToken}&per_page=200";
            return await this.GetStravaData<Athlete>(url);
        }
    }
}

