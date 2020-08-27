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
    public class BL_SearchGoogle
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly string googleUrl;

        public BL_SearchGoogle()
        {
            googleUrl = Shared.GeneralConfiguration.GoogleUrl.Replace("{0}", Shared.GeneralConfiguration.GoogleKey).Replace("{1}", Shared.GeneralConfiguration.GoogleCEKey);
            googleUrl = ReplaceCharURL(googleUrl);
        }


        public async Task<long> GetResultsCountAsync(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence)) throw new ArgumentNullException(nameof(sentence));

            try
            {
                using (var response = await httpClient.GetAsync(googleUrl.Replace("{2}", sentence)))
                {
                    if (!response.IsSuccessStatusCode) throw new ExceptionManager("There's been an Error, Please try again later.");

                    var result = await response.Content.ReadAsStringAsync();
                    var googleResponse = result.DeserializeJson<Service.Models.ResponseGoogle>();
                    return long.Parse(googleResponse.SearchInformation.TotalResults);
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
