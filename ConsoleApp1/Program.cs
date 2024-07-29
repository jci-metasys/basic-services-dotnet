// See https://aka.ms/new-console-template for more information
using JohnsonControls.Metasys.BasicServices;

Console.WriteLine("Hello, World!");

var client = new MetasysClient("welch12.go.johnsoncontrols.com", false, ApiVersion.v5);

client.TryLoginWithSavedPassword("api");

var result = client.GetNetworkDevices();

Console.Write("Hi");
