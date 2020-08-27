using System;
using System.Threading.Tasks;
using BusinessLogic;

namespace Executer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            var blSearchResult = new BL_SearchResult();
            string result = "";
            String searchSentence = "";

            try
            {
                while (searchSentence.Trim().Length == 0)
                {
                    Console.WriteLine("Enter queries to search.");
                    searchSentence = Console.ReadLine();

                    if (searchSentence.Trim().Length > 0) break;
                }

                result = await blSearchResult.SearchResult(searchSentence);
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                Console.WriteLine("error: " + ex.TargetSite);
                Console.WriteLine("error: " + ex.StackTrace);
            }
        }
    }
}
