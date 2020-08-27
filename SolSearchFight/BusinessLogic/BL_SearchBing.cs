using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using Shared;
using Service;

namespace BusinessLogic
{
    public class BL_SearchBing
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly string bingUrl;

        static BL_SearchBing()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Shared.GeneralConfiguration.BingUrl),
                DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", Shared.GeneralConfiguration.BingKey } }
            };
        }

        public async Task<long> BingSearch(string strSentence)
        {
            if (string.IsNullOrWhiteSpace(strSentence))  throw new ArgumentNullException(nameof(strSentence));

            try
            {
                using (var response = await httpClient.GetAsync($"?q={strSentence}"))
                {
                    if (!response.IsSuccessStatusCode) throw new ExceptionManager("There's been an Error, Please try again later.");

                    var result = await response.Content.ReadAsStringAsync();
                    var bingResponse = result.DeserializeJson<Service.Models.ResponseBing>();
                    return long.Parse(bingResponse.WebPages.TotalEstimatedMatches);
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionManager(ex.Message);
            }
        }


        #region "Help Funntions"

        private string ReplaceCharURL(string word)
        {
            if (word.Contains("#")) word = word.Replace("#", "%23");
            if (word.Contains(" ")) word = word.Replace(" ", "%20");

            return word;

        }

        #endregion

    }
}
