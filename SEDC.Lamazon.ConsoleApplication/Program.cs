using System;
using System.Net.Http;

namespace SEDC.Lamazon.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance check started...");
            Console.WriteLine("-----------------------------");
            CheckOrderPerformance();
            Console.ReadLine();
        }

        static void CheckOrderPerformance()
        {
            HttpClient client = new HttpClient();
            string apiUrl = "https://localhost:44366/api/external/performance/getorder";

            int limit = 1000;

            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            string responseBody = response.Content.ReadAsStringAsync().Result;

            if(Convert.ToInt32(responseBody) > limit)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Performance: {responseBody}ms | Limit is: {limit}ms");
        }
    }
}
