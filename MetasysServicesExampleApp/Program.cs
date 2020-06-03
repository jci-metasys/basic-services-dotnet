using System;
using JohnsonControls.Metasys.BasicServices;
using MetasysServicesExampleApp.FeaturesDemo;


namespace MetasysServicesExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LogInitializer(typeof(Program));
            string connectionDetails;
            try
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Please enter in your credentials in this format: {username} {password} {hostname} or as an alternative you can specify just the Credential Manager target and the hostname in this way {credmantarget} {hostname}." +
                        "\nRefer to the metasys-server/basic-services-dotnet README if you need help getting started.");
                    connectionDetails = Console.ReadLine();
                    args = connectionDetails.Split(' ');
                }
                string username=null, password=null, hostname=null, credManTarget=null; string version = null;
                if (args.Length > 3)
                {
                    username = args[0];
                    password = args[1];
                    hostname = args[2];
                    version = args[3];
                }
                else
                {                
                     credManTarget= args[0];
                     hostname= args[1];                     
                     version= args[2];                     
                }

                #region Login
                Console.WriteLine("Default culture is en_US. The culture for client translations can be changed in the code.");
                // CultureInfo culture = new CultureInfo("en-US");

                Console.WriteLine("\nLogging in...");
                var apiVersion = (ApiVersion)Enum.Parse(typeof(ApiVersion), version);
                var client = new MetasysClient(hostname,true,apiVersion,logClientErrors:false); // Disable default logging since it is handled in this app.
                // var client = new MetasysClient(hostname, true); // Ignore Certificate Errors
                // var client = new MetasysClient(hostname, false, ApiVersion.v2, culture);

                AccessToken token;
                if (string.IsNullOrWhiteSpace(credManTarget))
                {
                    token = client.TryLogin(username, password);
                }
                else
                {
                    // Read and login using cred managerfrom Credential manager
                    token = client.TryLogin(credManTarget);
                }
                Console.WriteLine($"Access token: {token.Token} expires {token.Expires}.");
                #endregion

                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = MainMenu(client);
                }
            }
            catch(Exception exception)
            {
                log.Logger.Error(string.Format("An error occured while login - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to exit");
                Console.ReadLine();
            }          
        }

        private static bool MainMenu(MetasysClient client)
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Get Object Identifier");
            Console.WriteLine("2) General Demo");
            Console.WriteLine("3) Refresh Token");
            Console.WriteLine("4) Spaces");
            Console.WriteLine("5) Equipment");
            Console.WriteLine("6) Alarms");
            Console.WriteLine("7) Trends");
            Console.WriteLine("8) Audits");
            Console.WriteLine("9) JSON Output");
            Console.WriteLine("10) Exit");
            Console.Write("\r\nSelect an option: ");
            var option = Console.ReadLine();
            Console.WriteLine();
            switch (option)
            {
                case "1":                 
                    new GetObjectIdentifierDemo(client).Run();
                    return true;
                case "2":                
                    new GeneralDemo(client).Run();
                    return true;
                case "3":
                    new RefreshTokenDemo(client).Run();
                    return true;
                case "4":
                    new SpacesDemo(client).Run();
                    return true;
                case "5":
                    new EquipmentDemo(client).Run();
                    return true;
                case "6":
                    new AlarmsDemo(client).Run();
                    return true;
                case "7":
                    new TrendsDemo(client).Run();
                    return true;
                case "8":
                    new AuditsDemo(client).Run();
                    return true;
                case "9":
                    new JsonOutputDemo(client).Run();
                    return true;
                case "10":
                    return false;
                default:
                    return true;
            }
        }
    }
}
