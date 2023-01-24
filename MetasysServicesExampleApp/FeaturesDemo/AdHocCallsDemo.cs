using JohnsonControls.Metasys.BasicServices;
using System;
using System.Net.Http;

namespace MetasysServicesExampleApp.FeaturesDemo
{
    public class AdHocCallsDemo
    {
        private MetasysClient client;
        private LogInitializer log;

        public AdHocCallsDemo(MetasysClient client)
        {
            this.client = client;
            log = new LogInitializer(typeof(AdHocCallsDemo));
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("\nEnter the endpoint you want to make the request to (Example: \"https://hostname/api/v5-preview/someController/someAction\"): .");
                string endpoint = Console.ReadLine();
                Console.WriteLine($"\nMaking the call to {endpoint}...");
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, endpoint);

                var response = client.SendAsync(httpRequest).Result;
                var statusCode = ((int)response.StatusCode).ToString();
                if (statusCode.StartsWith("2") || statusCode.StartsWith("3"))
                {
                    Console.WriteLine($"\n \nStatus - {response.StatusCode}");
                    Console.WriteLine("\nResponse content - ");
                    var content = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("\n \n" + content);
                }
                else
                {
                    Console.WriteLine(string.Format("\n \nRequest failed with - {0}", response.StatusCode));
                }
            }
            catch (Exception exception)
            {
                log.Logger.Error(string.Format("An error occured while making the request - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
            }
            Console.ReadLine();
        }
    }
}
