using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using BusinessEntity;

namespace BusinessLogic
{
    public class BL_SearchResult
    {
        #region "Auxiliary Functions"

        public static int numOccurrencesCharacter(string strSentence, string strChar)
        {
            int count = 0;
            for (int i = 0; i <= strSentence.Length - 1; i++)
            {
                if (strSentence.Substring(i, 1) == strChar) count++;
            }
            return count;
        }


        public static int[] ArrayOccurrencesCharacter(string strSentence, string strChar)
        {
            List<int> arrIndex = new List<int>();
            int count;
            int end;
            int start;
            int pos;

            end = strSentence.Length;
            start = 0;
            pos = 0;
            count = 0;

            while ((start <= end) && (pos > -1))
            {
                count = end - start;
                pos = strSentence.IndexOf(strChar, start, count,StringComparison.Ordinal);
                if (pos == -1) break;
                arrIndex.Add(pos);
                start = pos + 1;
            }

            return arrIndex.ToArray();
        }
        #endregion

        //public string async SearchResult(string searchWords)
        public async Task<string> SearchResult(string searchWords)
        {
            String resultadoFinal = "";
            List<String> lstSentecestoSearch = new List<string>();
            string[] arrSentenses;
            String strCloneSearchW = searchWords;

            if (searchWords.Contains("\""))
            {
                int count = numOccurrencesCharacter(searchWords, "\"");

                if (count % 2 != 0)
                {
                    resultadoFinal = "The group of words with \" are incomplete";
                }
                else
                {
                    //02. Obtener de 2 en dos
                    int[] Indexes = ArrayOccurrencesCharacter(searchWords, "\"");
                    string strFrase;

                    while (Indexes.Length > 0)
                    {
                        int intStart = Indexes[0];
                        int intEnd = Indexes[1];
                        int intSize = intEnd - intStart + 1;

                        //Add to General List of Words to Search per Search Engine
                        lstSentecestoSearch.Add(searchWords.Substring(intStart + 1, intSize - 2));

                        //Delete
                        Indexes = Indexes.Where(val => val != intStart & val != intEnd).ToArray();

                        //Clean general search sentence
                        strFrase = searchWords.Substring(intStart, intSize);
                        strCloneSearchW = strCloneSearchW.Replace(strFrase, String.Empty);
                    }
                }

            }
            lstSentecestoSearch.AddRange(strCloneSearchW.Split(' '));
            lstSentecestoSearch = lstSentecestoSearch.FindAll(s => !s.Equals(""));

            //Get All the Data
            var listTotalSearch = new List<BE_SearchWord>();
            listTotalSearch = await GeneralSearch(lstSentecestoSearch);


            var WGoogle = new BE_SearchWord();
            var WBing = new BE_SearchWord();
            var WTotal = new BE_SearchWord();

            long lgWG = 0;  
            long lgWB = 0;
            long lgWT = 0;

            foreach (BE_SearchWord result in listTotalSearch)
            {
                resultadoFinal = resultadoFinal = result.KeySearch + " : " +
                    HelpConstant.SearchEngine.TypeEngine.Google + ": " + result.totalGoogle + "  " +
                    HelpConstant.SearchEngine.TypeEngine.Bing + ": " + result.totalBing + Environment.NewLine;

                if (result.totalGoogle >= lgWG)
                {
                    lgWG = result.totalGoogle;
                    WGoogle = result;
                }

                if (result.totalBing >= lgWG)
                {
                    lgWB = result.totalBing;
                    WBing = result;

                }
                if (result.totalSearch >= lgWG)
                {
                    lgWT = result.totalSearch;
                    WTotal = result;
                }
            }

            resultadoFinal = resultadoFinal +
                "Google Winner : " + WGoogle.KeySearch + Environment.NewLine +
                "Bing Winner : " + WBing.KeySearch + Environment.NewLine +
                "Total Winner : " + WTotal.KeySearch;

            return resultadoFinal;
        }


        //private List<BE_SearchWord> GeneralSearch(List<String> lstSentences)
        public async Task<List<BE_SearchWord>> GeneralSearch(List<String> lstSentences)
        {
            var list = new List<BE_SearchWord>();
            BL_SearchGoogle blSearchGoogle = new BL_SearchGoogle();
            BL_SearchBing blSearchBing = new BL_SearchBing();

            foreach (string word in lstSentences)
            {
                var strSentence = word.Trim(); 
                var beSearWord = new BE_SearchWord();

                beSearWord.totalGoogle = await blSearchGoogle.GetResultsCountAsync(strSentence);
                beSearWord.totalBing = await blSearchBing.BingSearch(strSentence);//bl bing
                beSearWord.totalSearch = beSearWord.totalGoogle + beSearWord.totalBing;
                beSearWord.KeySearch = strSentence;

                list.Add(beSearWord);

            }
            return list;
        }


    }
}
