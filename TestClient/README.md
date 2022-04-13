# Metasys Basic Services <!-- omit in toc --> <a href="https://www.nuget.org/packages/JohnsonControls.Metasys.BasicServices/" rel="Johnson Controls Metasys BasicServices">![Nuget](https://img.shields.io/nuget/v/JohnsonControls.Metasys.BasicServices)</a>

This project provides a library for accessing the most common services of the Metasys Server API.
The intent is to provide an API that is very similar to the original MSSDA
(Metasys System Secure Data Access) library.

For versioning information see the [changelog](CHANGELOG.md).

## Contents <!-- omit in toc -->

- [Installation](#installation)
  - [Prerequisites](#prerequisites)
  - [.NET](#net)
  - [COM (Component Object Model)](#com-component-object-model)
  - [Excel and Visual Basic for Applications (VBA)](#excel-and-visual-basic-for-applications-vba)
- [Usage (.NET)](#usage-net)
  - [Creating a Client](#creating-a-client)
  - [Login and Access Tokens](#login-and-access-tokens)
  - [Get an Object Id](#get-an-object-id)
  - [Get a Property](#get-a-property)
  - [Write a Property](#write-a-property)
  - [Get and Send Commands](#get-and-send-commands)
  - [Get Network Devices and other Objects](#get-network-devices-and-other-objects)
  - [Localization of Metasys Enumerations](#localization-of-metasys-enumerations)
  - [Spaces and Equipment](#spaces-and-equipment)
  - [Alarms](#alarms)
  - [Trends](#trends)
  - [Audits](#audits)
- [Usage (COM)](#usage-com)
  - [Creating a Client](#creating-a-client-1)
  - [Login and Access Tokens](#login-and-access-tokens-1)
  - [Get an Object Id](#get-an-object-id-1)
  - [Get a Property](#get-a-property-1)
  - [Write a Property](#write-a-property-1)
  - [Send Commands](#send-commands)
  - [Get Network Devices and other Objects](#get-network-devices-and-other-objects-1)
  - [Spaces and Equipment](#spaces-and-equipment-1)
  - [Alarms](#alarms-1)
  - [Trends](#trends-1)
  - [Audits](#audits-1)
- [License](#license)
- [Contributing](#contributing)
- [Additional Information](#additional-information)
  - [Supported Localization Languages](#supported-localization-languages)

## Installation

### Prerequisites

- A method of installing NuGet packages as described by the Microsoft
[Package Consumpion Workflow](https://docs.microsoft.com/en-us/nuget/consume-packages/overview-and-workflow).

### .NET

To use in a .NET application include the following in the target source files:

```csharp
using JohnsonControls.Metasys.BasicServices;
```

Option 1: Consume the package by adding a PackageReference.

1. Add the following to the project's .csproj file:

    ```csharp
    <ItemGroup>
        <PackageReference Include="JohnsonControls.Metasys.BasicServices" Version="<target version>" />
    </ItemGroup>
    ```

Option 2: Consume the package by installing on the command line.
This workflow shows how to use the nuget.exe CLI (command line interface).

1. Open a command line and navigate to your project's main directory.
2. Execute the following command:

    ```cli
    nuget install JohnsonControls.Metasys.BasicServices -OutputDirectory packages
    ```

3. Update all packages with the command:

    ```cli
    nuget restore
    ```

### COM (Component Object Model)

Use the one click setup provided with the release tag to install the required dependencies in your system and register the COM DLL.
Keep in mind that for developing purposes the solution is already configured to register with the COM interop when the project is built. Alternatively, you can manually register or unregister the DLL use the RegCOM.bat and UnregCOM.bat scripts located in the Scripts directory.

To manually register for COM interop you can also use the Regasm.exe (Assembly Registration Tool) or similar tool.
[See more information here](https://docs.microsoft.com/en-us/dotnet/framework/tools/regasm-exe-assembly-registration-tool).

### Excel and Visual Basic for Applications (VBA)

LegacyMetasysClient allows you to interact with your Metasys server from a VBA application using COM interop.
To get start, enable the Developer Tab in Excel from the menu File-->Options-->Customize Ribbon.
[See more information here](https://support.office.com/en-us/article/show-the-developer-tab-e1192344-5e56-4d45-931b-e5fd9bea2d45).
Finally, from the Developer Tab click the Visual Basic button to open the editor and add the reference to the Metasys Services Object Library from the references list.
[See more information here](https://docs.microsoft.com/en-us/office/vba/language/how-to/check-or-add-an-object-library-reference).

## Usage (.NET)

This section demonstrates how to use the MetasysClient to interact with your Metasys server from a .NET application.
There is an example on [Github](https://github.com/metasys-server/basic-services-dotnet/tree/master/MetasysServicesExampleApp) that can be run from the command line and a specific prototype of an API to API integration about a  [Weather Forecast application](https://github.com/metasys-server/basic-services-dotnet/tree/master/WeatherForecastApp).

### Creating a Client

To create a new client and connect to a Metasys server with the default settings use:

```csharp
var client = new MetasysClient("hostname");
```

There are four optional parameters when creating a new client:

- ignoreCertificateErrors: If your server does not have a valid certificate the MetasysClient will not behave as expected and will likely block the connection. Setting the ignoreCertificateErrors = true will ignore this error and make an insecure connection with the server. To avoid this problem ensure the Metasys server has a valid certificate.  
  
  **WARNING: You should not ignore certificate errors on a production site. Doing so puts your server at risk of a man-in-the-middle attack.**  

- apiVersion: If your server is not a current 10.1 Metasys server or later this SDK will not function correctly. The version parameter takes in an ApiVersion enumeration value that defaults to the most current release of Metasys. For Metasys 10.1 the api version is v2, for Metasys 11 the api version is v3, for Metasys 12 the api version is v4.
- cultureInfo: To set the language for localization specify the target culture with a CultureInfo object. The default culture is en-US.
- logClientErrors: Set this flag to false to disable logging of client errors. By default the library logs any communication error with the Metasys Server in this path: "C:\ProgramData\Johnson Controls\Metasys Services\Logs".
  
To create a client that ignores certificate errors for a v12 Metasys server with Italian translations of values:

```csharp
CultureInfo culture = new CultureInfo("it-IT");
var client = new MetasysClient("hostname", true, ApiVersion.v4, culture);
```
In some cases you may want to enrich logs with more specific messages to your application. Typically, you disable internal library logging and catch Metasys Exceptions to be handled in your own logging framework or in use for Log4Net initializer provided by the library. The file log4Net.config allows you to customize settings such as the file path, size, append mode, etc.
To create a client with default settings that does not log errors use:

```csharp
var client = new MetasysClient("hostname", logClientErrors: false);
```

To log your own errors with Log4Net initializer provided by the library use:

```csharp
// Initialize Logger with your context Class
var log = new LogInitializer(typeof(Program));            
try
{
    // Your Try logic here...
}
catch (Exception ex) {
    log.Logger.Error(string.Format("An error occured - {0}", ex.Message));
}
```
See the following examples to change the API version and/or hostname after creating a client, keep in mind that changing one of these properties resets the access token and a new login is required.
```csharp
// Changing Api version after creating a client
var client = new MetasysClient("hostname",version: ApiVersion.v3);
client.Version = ApiVersion.v2;
```

```csharp
// Changing Metasys Server after creating a client
var client = new MetasysClient("hostname");
client.Hostname = "WIN2016-VM2";
```
### Login and Access Tokens

After creating the client, to login use the TryLogin method.
The signature has two overloads: the first uses the Credential Manager target to read the credentials, whilst the second takes a username and password.
Both signatures take an optional parameter to automatically refresh the access token during the client's lifetime. The default token refresh policy is true. See more information [here](https://support.microsoft.com/en-us/help/4026814/windows-accessing-credential-manager) on how to use Credential Manager. If something goes wrong while accessing a Credential Manager target, MetasysClient raises a CredManException. Keep in mind that Credential Manager is available on Windows and is not going to work on other platforms. However, MetasysClient Class could be extended by developers to implement different secure vaults support.

 **Notice: when developing an application that uses a system account always logged without user input, the preferred way to login is to store the username and password in the Credential Manager vault.**

```csharp
// Automatically refresh token using plain credentials
client.TryLogin("username", "password");
// Do not automatically refresh token using plain credentials
client.TryLogin("username", "password", false);

// Read target from Credential Manager and automatically refresh token
client.TryLogin("metasys-energy-app");
// Read target from Credential Manager and do not refresh token
client.TryLogin("metasys-energy-app", false);
```

At any time you want to manually refresh the access token before it expires use the following:

```csharp
client.Refresh();
```

To use the authorization token in an different HttpClient use the AccessToken object returned by these methods or use the GetAccessToken method. A successful token will be in the form "Bearer ...".

```csharp
AccessToken accessToken = client.TryLogin("metasys-energy-app");
Console.WriteLine(accessToken);
/*        
{
    "Issuer": "metasysserver",
    "IssuedTo": "metasysapiuser",
    "Token": "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkJzR0lWelVZcjN0MkI0RGRtT1ljMTdBLVZJOCIsImtpZCI6IkJzR0lWelVZcjN0MkI0RGRtT1ljMTdBLVZJOCJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojk1MDYvQVBJLkF1dGhlbnRpY2F0aW9uU2VydmljZSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6OTUwNi9BUEkuQXV0aGVudGljYXRpb25TZXJ2aWNlL3Jlc291cmNlcyIsImV4cCI6MTU4OTI5MzEzMCwibmJmIjoxNTg5MjkxMzMwLCJjbGllbnRfaWQiOiJtZXRhc3lzX3VpIiwic2NvcGUiOlsibWV0YXN5c19hcGkiLCJvZmZsaW5lX2FjY2VzcyIsIm9wZW5pZCJdLCJzdWIiOiI4ZGE4YjE4Yy1lMTk1LTRlMmMtOGU2Zi0zNTE2Zjc0ZWFhNGIiLCJhdXRoX3RpbWUiOjE1ODkyOTEzMzAsImlkcCI6Imlkc3J2IiwiVXNlcklkIjoiMSIsIlVzZXJOYW1lIjoibWV0YXN5c3N5c2FnZW50IiwiSXNBZG1pbiI6IlRydWUiLCJJc1Bhc3N3b3JkQ2hhbmdlUmVxdWlyZWQiOiJGYWxzZSIsIklzVGVybXNBbmRDb25kaXRpb25zUmVxdWlyZWQiOiJGYWxzZSIsIkxpY2Vuc2VJbmZvIjoie1wiSXNMaWNlbnNlZFwiOnRydWUsXCJMaWNlbnNlVHlwZVwiOlwiZ3JhY2VcIn0iLCJDdWx0dXJlIjoiZW4tVVMiLCJhbXIiOlsicGFzc3dvcmQiXX0.egzw1bs1831pEBWWXbBOYWGU5wFsI3sEnL7RgCIHHbHmcxtpPPqLq54znpoUoLFrMUeymZj5rkrt_mF-CNIpCE3halZNAH-CR1U46LTZi5CMaDfYlP-wHxikAGV5GwFjlHjGNOUaFtd7n4yC5sH08pHQfXXD5gKDm_FVMfUJXAo-E8gmrkU0wMn5U2FRyQyj7Yhq6jaj7MPTF__Xz46sG3WtDr45WK2NmuwiLDv408URZ5fJxlMngRpjSIONHVAIwna_H0AguHiIELkvuRVYcRqIH5kb1YdFt-3fsnTV9xwpozZZ44dh-4I7x466I-UGlLHAnScWILUbPcpRNWm0Uw",
    "Expires": "2020-05-12T14:18:51Z"
}
*/
```

### Get an Object Id

In order to use most of the methods in MetasysClient the id of the target object must be known. This id is in the form of a Guid and can be requested using the following given you know the item reference of the object:

```csharp
Guid objectId = client.GetObjectIdentifier("Win2016-VM2:vNAE2343996/Field Bus MSTP1.VAV-08.ZN-SP");
Console.WriteLine(objectId);
/*        
d5d96cd3-db4a-52e0-affd-8bc3393c30ec
*/
```

### Get a Property

In order to get a property you must know the Guid of the target object. An object called "Variant" is returned when getting a property from an object. Variant contains the property received in many different forms. There is a bit of intuition when handling a Variant since it will not explicitly provide the type of object received by the server. If the server cannot find the target object or attribute on the object this method will throw a MetasysHttpNotFoundException.

```csharp
Variant property = client.ReadProperty(objectId, "presentValue");
Console.WriteLine(property);
/*        
{
    "StringValue": "72",
    "StringValueEnumerationKey": null,
    "NumericValue": 72.0,
    "BooleanValue": true,
    "ArrayValue": null,
    "Attribute": "presentValue",
    "Id": "f1469e25-c46c-5009-b92e-d82603e742a4",
    "Reliability": "Reliable",
    "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
    "Priority": "0 (No Priority)",
    "PriorityEnumerationKey": "writePriorityEnumSet.priorityNone",
    "IsReliable": true
}
*/
```

There is a method to get multiple properties from multiple objects. This can be very useful if the objects all are of the same type or have the same target properties.

```csharp
List<Guid> ids = new List<Guid> { id1, id2 };
List<string> attributes = new List<string> { "name", "description", "presentValue" };
IEnumerable<VariantMultiple> results = client.ReadPropertyMultiple(ids, attributes);
VariantMultiple multiple1 = results.FindById(id1);
Console.WriteLine(multiple1);
/*
{
    "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
    "Variants": [
    {
        "StringValue": "ZN-T",
        "StringValueEnumerationKey": "ZN-T",
        "NumericValue": 0.0,
        "BooleanValue": false,
        "ArrayValue": null,
        "Attribute": "name",
        "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
        "Reliability": "Reliable",
        "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
        "Priority": null,
        "PriorityEnumerationKey": null,
        "IsReliable": true
    },
    {
        "StringValue": "Zone Temperature",
        "StringValueEnumerationKey": "Zone Temperature",
        "NumericValue": 0.0,
        "BooleanValue": false,
        "ArrayValue": null,
        "Attribute": "description",
        "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
        "Reliability": "Reliable",
        "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
        "Priority": null,
        "PriorityEnumerationKey": null,
        "IsReliable": true
    }
    ]
}
*/
Variant multiple1Description = multiple1.FindAttributeByName("description");
```

### Write a Property

In order to write a property you must have the Guid of the object and know the attribute name and type. This method contains an optional priority parameter to specify the write priority of the value. This priority is in the form of an enumeration such as "writePriorityEnumSet.priorityNone". To see more options use the "api/v2/enumSets/1/members" or "api/v2/schemas/enums/writePriorityEnumSet" http requests defined in the [Metasys API](https://metasys-server.github.io/api-landing/api/v2/).

```csharp
Guid id = client.GetObjectIdentifier("siteName:naeName/Folder1.AV1");
client.WriteProperty(id, "description", "This is an AV.");
client.WriteProperty(id, "description", "This is an AV.", "writePriorityEnumSet.priorityNone");
```

To change the same attribute values of many objects use the WritePropertyMultiple method. This method also accepts an optional write priority.

```csharp
List<Guid> ids = new List<Guid> { id1, id2 };
// Write to many attributes values using a list of tuples
List<(string, object)> attributesList = new List<(string, object)> { ("description", "This is an AV.") };
client.WritePropertyMultiple(ids, attributesList);

// Write to many attributes values using a dictionary of attribute/value pairs
Dictionary<string, object> attributesDictionary = new Dictionary<string, object> { { "description", "This is an AV." } };
client.WritePropertyMultiple(ids, attributesDictionary);
```

### Get and Send Commands

To get all available commands on an object use the GetCommands method. This method will return a list of Command objects. The ToString() method is a useful tool to display the available commands and any information associated with it. When sending a command the Command.CommandId attribute is used as the parameter:

```csharp
List<Command> commands = client.GetCommands(objectId).ToList();
Command command = commands.FindById("Adjust");
Console.WriteLine(command);
/*                        
{
    "Title": "Adjust",
    "TitleEnumerationKey": "commandIdEnumSet.adjustCommand",
    "CommandId": "Adjust",
    "Items": [
    {
        "Title": "Value",
        "Type": "number",
        "EnumerationValues": null,
        "Minimum": null,
        "Maximum": null
    }
    ]
}
*/
```

When sending a command there may or may not be a single value or list of values that needs to be sent with the command. The Command.Items property will list all of these values as Items which contains the Title and Type of the value to change. If the type of an Item is "oneOf" this indicates the values is an enumeration and the possible values will be contained in the EnumerationValues list. Keep in mind the values to be sent in the command is the TitleEnumerationKey not the Title. The Title is the user friendly translated value that describes the enumeration. For example, an "AV Mapper" object has the following commands:

- "Adjust" that accepts a number value to adjust the present value.
- "TemporaryOperatorOverride" that accepts the value to adjust the present value, the hours, and the minutes for the temporary adjustment.
- "Release" which accepts two enumeration values for the attribute and new priority level.

The values on the Commands will model the following:

```csharp
Command adjust = commands.FindById("Adjust");
Command operatorOverride = commands.FindById("OperatorOverride");
Command release = commands.FindById("Release"); 
Console.WriteLine(release);
/*                        
{
    "Title": "Release",
    "TitleEnumerationKey": "commandIdEnumSet.releaseCommand",
    "CommandId": "Release",
    "Items": [
    {
        "Title": "oneOf",
        "Type": "enum",
        "EnumerationValues": [
        {
            "Title": "Present Value",
            "TitleEnumerationKey": "attributeEnumSet.presentValue"
        }
        ],
        "Minimum": 1.0,
        "Maximum": 1.0
    },
    {
        "Title": "oneOf",
        "Type": "enum",
        "EnumerationValues": [
        {
            "Title": "0 (No Priority)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityNone"
        },
        {
            "Title": "1 (Manual Life Safety)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityManualEmergency"
        },
        {
            "Title": "2 (Auto Life Safety)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityFireApplications"
        },
        {
            "Title": "3 (Application)",
            "TitleEnumerationKey": "writePriorityEnumSet.priority3"
        },
        {
            "Title": "4 (Application)",
            "TitleEnumerationKey": "writePriorityEnumSet.priority4"
        },
        {
            "Title": "5 (Critical Equipment)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityCriticalEquipment"
        },
        {
            "Title": "6 (Minimum On Off)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityMinimumOnOff"
        },
        {
            "Title": "7 (Heavy Equip Delay)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityHeavyEquipDelay"
        },
        {
            "Title": "8 (Operator Override)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityOperatorOverride"
        },
        {
            "Title": "9 (Application)",
            "TitleEnumerationKey": "writePriorityEnumSet.priority9"
        },
        {
            "Title": "10 (Application)",
            "TitleEnumerationKey": "writePriorityEnumSet.priority10"
        },
        {
            "Title": "11 (Demand Limiting)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityDemandLimiting"
        },
        {
            "Title": "12 (Application)",
            "TitleEnumerationKey": "writePriorityEnumSet.priority12"
        },
        {
            "Title": "13 (Load Rolling)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityLoadRolling"
        },
        {
            "Title": "14 (Application)",
            "TitleEnumerationKey": "writePriorityEnumSet.priority14"
        },
        {
            "Title": "15 (Scheduling)",
            "TitleEnumerationKey": "writePriorityEnumSet.prioritySchedulingOst"
        },
        {
            "Title": "16 (Default)",
            "TitleEnumerationKey": "writePriorityEnumSet.priorityDefault"
        }
        ],
        "Minimum": 1.0,
        "Maximum": 1.0
    }
    ]
}
*/
```

To send the command for each of these it would model the following:

```csharp
var list1 = new List<object> { 70 };
client.SendCommand(objectId, adjust.CommandId, list1);

var list2 = new List<object> { 75 };
client.SendCommand(objectId, operatorOverride.CommandId, list2);

var list3 = new List<object> { "attributeEnumSet.presentValue", "writePriorityEnumSet.priorityNone" };
client.SendCommand(objectId, release.CommandId, list3);
```

### Get Network Devices and other Objects

To get all the available network devices use the method *NetworkDevices.Get* (method *GetNetworkDevices* is deprecated) which returns a list of MetasysObjects. This accepts an optional type number as a string to filter the response. To get all of the available types on your server use the method *NetworkDevices.GetTypes* (method *GetNetworkDeviceTypes* is deprecated) which returns a list of MetasysObjectType.
Note: instead of the optional type number you can also specify the network device type parameter using a dedicated enumeration set (called NetworkDeviceTypeEnum) that helps you to identify the needed type.

```csharp
List<MetasysObjectType> types = client.GetNetworkDeviceTypes().ToList();
Console.WriteLine(types[0]);
/*                        
{
    "Description": "NAE55-NIE59",
    "DescriptionEnumerationKey": "objectTypeEnumSet.n50Class",
    "Id": 185
}
*/
int type1 = types[0].Id;
List<MetasysObject> devices = client.GetNetworkDevices(type1.ToString()).ToList();
MetasysObject device = devices.LastOrDefault();
Console.WriteLine(device);
/*                        
{
    "ItemReference": "Win2016-VM2:vNAE2343996",
    "Id": "142558f8-c4c7-5f89-be97-d806adb72053",
    "Name": "vNAE2343996",
    "Description": "",
    "Type": null,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/185",
    "Category": null,
    "Children": [],
    "ChildrenCount": 0
}
*/
List<MetasysObject> devices2 = client.GetNetworkDevices(NetworkDeviceTypeEnum.SNC).ToList();
MetasysObject device2 = devices2.LastOrDefault();
Console.WriteLine(device2);
/*                        
    {
        "ItemReference": "WIN-21DJ9JV9QH6:EECMI-SNC-KNX",
        "Id": "69b3c2a5-1090-5418-afd9-5efc7186e42f",
        "Name": "EECMI-SNC-KNX",
        "Description": "",
        "Type": null,
        "TypeUrl": "https://win-21dj9jv9qh6/api/v3/enumSets/508/members/448",
        "ObjectType": null,
        "Category": null,
        "Children": [],
        "ChildrenCount": 0
    }            
*/

```
To get the child devices of a network device use the method *NetworkDevices.GetChildren*. This takes the id (Guid) of the parent network device and return the a list of Metasys objects.

To get the child devices or objects of an object use the GetObjects method. This takes the Guid of the parent object and an optional number of levels to retrieve. The default is 1 level or just the immediate children of the object. Depending on the number of objects on your server this method can take a very long time to complete.

```csharp
Guid parentId = client.GetObjectIdentifier("WIN-21DJ9JV9QH6:EECMI-NCE25-2/FCB");
// Get direct children (1 level)
List<MetasysObject> directChildren = client.GetObjects(parentId).ToList();
MetasysObject lastChild = directChildren.LastOrDefault();
Console.WriteLine(lastChild);
/*                        
{
    "ItemReference": "Win2016-VM2:vNAE2343996/Field Bus MSTP1.VAV-08.ZN-T",
    "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
    "Name": "ZN-T",
    "Description": null,
    "Type": null,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/601",
    "Category": null,
    "Children": [],
    "ChildrenCount": 0
}
*/

// Get direct children (1 level) with internal objects
directChildren = client.GetObjects(parentId, includeInternalObjects:true).ToList();  
// Get descendant for 2 levels (it could take long time, depending on the number of objects)
List<MetasysObject> level2Descendants = client.GetObjects(parentId, 2).ToList();
MetasysObject level1Parent = level2Descendants.FindByName("Time");
Console.WriteLine(level1Parent);
/*                        
{
"ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time",
"Id": "22bb952e-7557-5de9-b7e5-dce39e21addd",
"Name": "Time",
"Description": null,
"Type": null,
"TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/176",
"Category": null,
"Children": [
{
    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Day",
    "Id": "5886a93f-9260-553c-995e-6a65374de85d",
    "Name": "Day",
    "Description": null,
    "Type": null,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
    "Category": null,
    "Children": [],
    "ChildrenCount": 0
},
{
    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Hour",
    "Id": "6a50d3af-d0a2-537c-a2f7-9c1b5f271cc5",
    "Name": "Hour",
    "Description": null,
    "Type": null,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
    "Category": null,
    "Children": [],
    "ChildrenCount": 0
},
{
    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Minute",
    "Id": "19a53f38-2fd7-5ac3-a12c-f3b9704ac194",
    "Name": "Minute",
    "Description": null,
    "Type": null,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
    "Category": null,
    "Children": [],
    "ChildrenCount": 0
},
{
    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Year",
    "Id": "74dfc214-22c1-57a7-ace5-606636d0049c",
    "Name": "Year",
    "Description": null,
    "Type": null,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
    "Category": null,
    "Children": [],
    "ChildrenCount": 0
}
],
"ChildrenCount": 4
}
*/
```

### Localization of Metasys Enumerations

To get automatically translated enumerations on enumerations returned from a Metasys server you must specify the culture during client creation, or set the "Culture" property before using the "get" methods. The default language for translations will be the machine's current culture ([see more information here](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture)) or en-US (American English) if the language is not supported (see [Supported Localization Languages](#supported-localization-languages)).

```csharp
client.Culture = new CultureInfo("it-IT");
```

Enumerations returned from a Metasys server will be in a format similar to: "reliabilityEnumSet.reliable". MetasysClient has a method to translate these enumerations manually. This method can be very useful if using an external HttpClient since Metasys servers do not hold translation information.

```csharp
// Access from the client object
string translated = client.Localize("reliabilityEnumSet.reliable"); // Reliable

// Access without instantiating a client
string translated = ResourceManager.Localize("reliabilityEnumSet.reliable",
    new CultureInfo("it-IT"));  // Affidabile
```

Note: If an automatically translated value (such as Variant.StringValue) contains an enumeration value and not a translated string there could be an error with the MetasysClient globalization setup.

If the enumeration key is desired over the translated value use the EnumerationKey attribute. For example, the translated Variant.Reliability has the enumeration key under the attribute: Variant.ReliabilityEnumerationKey. See the documentation of each Model for more information.

### Spaces and equipment
To get all the space types use the GetSpaceTypes method. This method will return a list of MetasysObjectType.
```csharp
IEnumerable<MetasysObjectType> spaceTypes = client.GetSpaceTypes();
foreach (var type in spaceTypes)
{
    Console.WriteLine(type);
}
/*                        
{
    "Description": "Building",
    "DescriptionEnumerationKey": "Building",
    "Id": 1
}
{
    "Description": "Floor",
    "DescriptionEnumerationKey": "Floor",
    "Id": 2
}
{
    "Description": "Generic",
    "DescriptionEnumerationKey": "Generic",
    "Id": 0
}
{
    "Description": "Room",
    "DescriptionEnumerationKey": "Room",
    "Id": 3
}
*/
```

To get all available spaces on an object use the GetSpaces method. This method will return a list of MetasysObjects. This accepts an optional type as enum to filter the response. To get all of the available types on your server use the GetSpaceTypes method which returns a list of MetasysObjectType. To get all of the equipment on your server use the GetEquipment method which returns a list of MetasysObjects.
```csharp
// Retrieves the list of Buildings using SpaceTypeEnum helper
List<MetasysObject> buildings = client.GetSpaces(SpaceTypeEnum.Building).ToList();
MetasysObject building = buildings.LastOrDefault();
Console.WriteLine(building);
/*                        
{
    "ItemReference": "Win2016-VM2:Win2016-VM2/JCI.Building 1",
    "Id": "164aaba2-0fb3-5b5d-bfe9-49cf6b797c93",
    "Name": "North America (BACnet)",
    "Description": null,
    "Type": 2,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/1766/members/1",
    "Category": "Building",
    "Children": [],
    "ChildrenCount": 0
}
*/
// Retrieves all the spaces in a flat hierarchy
List<MetasysObject> spaces = client.GetSpaces().ToList();
MetasysObject firstSpace = spaces.FirstOrDefault();
Console.WriteLine(firstSpace);
/*                        
{
    "ItemReference": "Win2016-VM2:Win2016-VM2/JCI.Building 1.Floor 1.Milwaukee.507 E Michigan Street Campus",
    "Id": "896ba096-db3c-5038-8505-636785906cca",
    "Name": "507 E Michigan Street Campus",
    "Description": null,
    "Type": 2,
    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/1766/members/3",
    "Category": "Room",
    "Children": [],
    "ChildrenCount": 0
}
*/
```

To get the children of a Space use the GetSpaceChildren method. If you wish to retrieve equipment for a given space you can use the GetSpaceEquipment method. The deeper element in the hierarchy is the point, use the getEquipmentPoints method to retrieve the points mapped to an equipment. The Point object contains PresentValue when available. 
```csharp
IEnumerable<MetasysObject> spaceChildren = client.GetSpaceChildren(building.Id);
IEnumerable<MetasysObject> spaceEquipment = client.GetSpaceEquipment(building.Id);
MetasysObject sampleSpaceEquipment = spaceEquipment.FirstOrDefault();
```

To get all the equipment use the GetEquipment method. This method will return a list of MetasysObject objects.
```csharp
List<MetasysObject> equipment = client.GetEquipment().ToList();
MetasysObject sampleEquipment = equipment.FirstOrDefault();
Console.WriteLine(sampleEquipment);
/*                        
{
    "ItemReference": "Win2016-VM2:Win2016-VM2/equipment.vNAE2343947.Field Bus MSTP1.AHU-07",
    "Id": "6c6e18b8-015f-572a-814c-1e5d66142850",
    "Name": "AHU-07",
    "Description": null,
    "Type": 3,
    "TypeUrl": null,
    "Category": null,
    "Children": [],
    "ChildrenCount": 0
}
*/
```

To get all the points of an equipment use the GetEquipmentPoint method. It takes the Guid of the equipments and it will return the list of MetasysPoint objects.
```csharp
IEnumerable<MetasysPoint> equipmentPoints = client.GetEquipmentPoints(sampleEquipment.Id);
MetasysPoint point = equipmentPoints.FindByShortName("CLG-O");
string presentValue = point.PresentValue?.StringValue;
Console.WriteLine(point);
/*                        
{
    "EquipmentName": "AHU-07",
    "ShortName": "CLG-O",
    "Label": "Cooling Output",
    "Category": "",
    "IsDisplayData": true,
    "ObjectId": "9dd107cf-e8dc-583a-9557-813395ae1971",
    "AttributeUrl": "https://win2016-vm2/api/v2/enumSets/509/members/85",
    "ObjectUrl": "https://win2016-vm2/api/v2/objects/9dd107cf-e8dc-583a-9557-813395ae1971",
    "PresentValue": {
    "StringValue": "0",
    "StringValueEnumerationKey": null,
    "NumericValue": 0.0,
    "BooleanValue": false,
    "ArrayValue": null,
    "Attribute": "presentValue",
    "Id": "9dd107cf-e8dc-583a-9557-813395ae1971",
    "Reliability": "Reliable",
    "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
    "Priority": "0 (No Priority)",
    "PriorityEnumerationKey": "writePriorityEnumSet.priorityNone",
    "IsReliable": true
    }
}
*/
```

### Alarms

All services about alarms are provided by Alarms local instance of MetasysClient.
To get all available alarms use the Get method. This method will return a PagedResult with a list of Alarm objects. This accepts an AlarmFilter object to filter the response. To get a single alarm use the FindById method which returns an Alarm object with all the details given the Guid.

```csharp
AlarmFilter alarmFilter = new AlarmFilter
{
    StartTime = new DateTime(2020, 5, 1),
    EndTime = new DateTime(2020, 6, 2),
    ExcludeAcknowledged = true
};
PagedResult<Alarm> alarmsPager = client.Alarms.Get(alarmFilter);
// Prints the number of records fetched and paging information
Console.WriteLine("Total:" + alarmsPager.Total);
Console.WriteLine("Current page:" + alarmsPager.CurrentPage);
Console.WriteLine("Page size:" + alarmsPager.PageSize);
Console.WriteLine("Pages:" + alarmsPager.PageCount);
/* Console Output: Start                       
    Total:4611
    Current page:1
    Page size:100
    Pages:47
Console Output: End */

Alarm alarm = alarmsPager.Items.ElementAt(0);
Console.WriteLine(alarm);
/* Console Output: Start                       
{
    "Self": "https://win-21dj9jv9qh6/api/v3/alarms/e03d81f9-69de-48e8-92d7-81167df19f6c",
    "Id": "e03d81f9-69de-48e8-92d7-81167df19f6c",
    "ItemReference": "WIN-21DJ9JV9QH6:EECMI-NCE25-3",
    "Name": "EECMI-NCE25-3",
    "Message": "WIN-21DJ9JV9QH6:EECMI-NCE25-3 is offline",
    "IsAckRequired": true,
    "TypeUrl": null,
    "Type": "alarmValueEnumSet.avOffline",
    "Priority": 106,
    "TriggerValue": {
    "Value": "",
    "UnitsUrl": null,
    "Units": "unitEnumSet.noUnits"
    },
    "CreationTime": "2020-06-17T11:22:30Z",
    "IsAcknowledged": false,
    "IsDiscarded": false,
    "CategoryUrl": null,
    "Category": "objectCategoryEnumSet.systemCategory",
    "ObjectUrl": "https://win-21dj9jv9qh6/api/v3/objects/e03d81f9-69de-48e8-92d7-81167df19f6c",
    "AnnotationsUrl": "https://win-21dj9jv9qh6/api/v3/alarms/e03d81f9-69de-48e8-92d7-81167df19f6c/annotations"
}             
Console Output: End */
```
To get the alarms of a specific Object or NetworkDevice use the GetForObject and GetForNetworkDevice methods. The Guid of the parent object is required as input.

```csharp
var alarmId="6c6e18b8-015f-572a-814c-1e5d66142850";
Alarm singleAlarm = client.Alarms.FindById(alarmId);

AlarmFilter alarmFilter = new AlarmFilter{};
var objectId="f5fe6054-d0b0-55b6-b03f-d4554f80d8e6";
var objectAlarms = client.Alarms.GetForObject(objectId, alarmFilter);

var networkDeviceId="2aefbd18-9088-54ee-b6ef-6d9312da3c33";
var networkDevicesAlarms = client.Alarms.GetForNetworkDevice(networkDeviceId, alarmFilter);
```
To get the annotations of an alarm use the GetAnnotations method, it takes the Guid of the alarm and returns a collection of AlarmAnnotation objects.

```csharp
 IEnumerable<AlarmAnnotation> annotations = client.Alarms.GetAnnotations(alarm.Id);
 AlarmAnnotation firstAnnotation = annotations.FirstOrDefault();
 Console.WriteLine(firstAnnotation);
  /*
  {
      "AlarmUrl": "https://win-ervotujej94/api/v2/alarms/f0f64d5c-b70e-8754-836c-1ac99182f4e4",
      "Text": "Test Annotation 00",
      "User": "metasyssysagent",
      "CreationTime": "2020-05-27T06:21:31Z",
      "Action": "none"
  } 
  */
```

### Trends

All services about trends are provided by Trends local instance of MetasysClient. To get all available samples given a time filter use the GetSamples method. This method will return a PagedResult with a list of Sample. This accepts the Guid of the object, the attribute ID and a TimeFilter object to filter the response. To get all of the available trended attributes of an object given the ID use the GetTrendedAttributes method. 

```csharp
Guid trendedObjectId = client.GetObjectIdentifier("WIN-21DJ9JV9QH6:EECMI-NCE25-2/FCB.10FEC11 - V6 Unit.E4 Network Outdoor Temperature");

// Get attributes where trend extension is configured
List<MetasysAttribute> trendedAttributes = client.Trends.GetTrendedAttributes(trendedObjectId);
int attributeId = trendedAttributes[0].Id;
TimeFilter timeFilter = new TimeFilter
{
    StartTime = new DateTime(2020, 6, 5),
    EndTime = new DateTime(2020, 6, 6)
};

PagedResult<Sample> samplesPager = client.Trends.GetSamples(trendedObjectId, attributeId, timeFilter);
// Prints the number of records fetched and paging information
Console.WriteLine("Total:" + samplesPager.Total);
Console.WriteLine("Current page:" + samplesPager.CurrentPage);
Console.WriteLine("Page size:" + samplesPager.PageSize);
Console.WriteLine("Pages:" + samplesPager.PageCount);
/*                        
    Total:145
    Current page:1
    Page size:100
    Pages:2
    */
Sample firstSample = samplesPager.Items.FirstOrDefault();
Console.WriteLine(firstSample);
/*                        
    {
        "Value": 82.0,
        "Unit": "deg F",
        "Timestamp": "2020-05-12T05:00:00Z",
        "IsReliable": true
    }
*/
```
Keep in mind that the object must be properly configured with trended attributes and samples are sent to the ADS/ADX. If you try to retrieve values from an object that has no valid trended attributes a MetasysHttpNotFoundException is raised.

### Audits

All services about audits are provided by Audits local instance of MetasysClient.
To get all available audits use the Get method. This method will return a PagedResult with a list of Audit objects. This accepts an AuditFilter object to filter the response. To get a single audit use the FindById method which returns an Audit object with all the details given the Guid.
In the Audit filter you can specify the values of OriginApplications or ActionTypes using values of dedicated enumeration sets concatenated by a '|' character.
```csharp
AuditFilter auditFilter = new AuditFilter
{
    StartTime = new DateTime(2020, 5, 20),
    EndTime = new DateTime(2020, 6, 3),
    OriginApplications = OriginApplicationsEnum.SystemSecurity | OriginApplicationsEnum.AuditTrails,
    ActionTypes = ActionTypeEnum.Subsystem | ActionTypeEnum.Command
};
PagedResult<Audit> auditsPager = client.Audits.Get(auditFilter);

// Prints the number of records fetched and paging information
Console.WriteLine("Total:" + auditsPager.Total);
Console.WriteLine("Current page:" + auditsPager.CurrentPage);
Console.WriteLine("Page size:" + auditsPager.PageSize);
Console.WriteLine("Pages:" + auditsPager.PageCount);
/*                        
    Total:323
    Current page:1
    Page size:100
    Pages:4
*/
Audit audit = auditsPager.Items.FirstOrDefault();
Console.WriteLine(audit);
/*                        
{
    "Id": "8e3b3738-2f5f-494d-bde1-fac15da28c86",
    "CreationTime": "2020-06-23T16:45:54.697Z",
    "ActionTypeUrl": null,
    "ActionType": "auditActionTypeEnumSet.subsystemAuditActionType",
    "Discarded": false,
    "StatusUrl": null,
    "Status": null,
    "PreData": null,
    "PostData": "::1",
    "Parameters": "[]",
    "ErrorString": null,
    "User": "testuser",
    "Signature": null,
    "ObjectUrl": "https://win-21dj9jv9qh6/api/v3/objects/1949c631-7823-5230-b951-aae3f8c9d64a",
    "AnnotationsUrl": null,
    "Legacy": {
    "FullyQualifiedItemReference": "WIN-21DJ9JV9QH6:WIN-21DJ9JV9QH6",
    "ItemName": "EECMI-ADS11",
    "ClassLevel": "auditClassesEnumSet.userActionAuditClass",
    "OriginApplication": "auditOriginAppEnumSet.systemSecurityAuditOriginApp",
    "Description": "auditTrailStringsEnumSet.atstrSecurityUserLoginSuccessful"
    },
    "Self": "https://win-21dj9jv9qh6/api/v3/audits/8e3b3738-2f5f-494d-bde1-fac15da28c86"
}
*/
```

To get the audits of a specific Object use the GetForObject method. The Guid of the parent object is required as input.
```csharp
AuditFilter auditFilter = new AuditFilter{};
var objectId="17ac1932-18d8-518c-8012-420c77bea86b";
var objectAudits = client.Audits.GetForObject(objectId, auditFilter);
```
To get the annotations of an audit use the GetAnnotations method, it takes the Guid of the audit and returns a collection of AuditAnnotation objects.
```csharp
IEnumerable<AuditAnnotation> annotations = client.Audits.GetAnnotations(audit.Id);
AuditAnnotation firstAnnotation = annotations.FirstOrDefault();
Console.WriteLine(firstAnnotation);
/*
{
    "auditUrl": "https://win-ervotujej94/api/v2/audits/40aff6ec-ecb2-4b65-a504-0ac659756956",
    "creationTime": "2020-06-05T15:58:40.407Z",
    "user": "MetasysSysAgent",
    "text": "TEST AUDIT ANNOTATION 02",
    "signature": null,
    "action": "none"
} 
*/
``` 
To discard an Audit (only with API v3) use the Discard method, it takes the Guid of the audit and the text of an annotation to comment the reason of the discard. It doesn't return a value.
```csharp
Guid auditId = new Guid("9cf1c11d-a8cc-48e6-9e4c-f02af26e8fdf");
string annotationText = "Reason why the audit has been discarded";
client.Audits.Discard(auditId, annotationText);
``` 
To discard multiple Audits (only with API v3) use the DiscardMultiple method, it takes a list of BatchRequestParam objects (specifing the list of Audits Guid and annotations) and it returns a list of Result objects.
```csharp
var requests = new List<BatchRequestParam>();
BatchRequestParam request1 = new BatchRequestParam { ObjectId = new Guid("e0fb025a-d8a2-4258-91ea-c4026c1620d1"), Resource = "THIS IS THE FIRST DISCARD ANNOTATION" };
requests.Add(request1);
BatchRequestParam request2 = new BatchRequestParam { ObjectId = new Guid("5ff1341e-dbf1-4eaf-b9a1-987f51dabefa"), Resource = "THIS IS THE SECOND DISCARD ANNOTATION" };
requests.Add(request2);

IEnumerable<Result> results = client.Audits.DiscardMultiple(requests);
Result resultItem = results.ElementAt(0);
Console.WriteLine(resultItem);
/*
{
    "Id": "e0fb025a-d8a2-4258-91ea-c4026c1620d1",
    "Status": 204,
    "Annotation": "THIS IS THE FIRST DISCARD ANNOTATION"
}  
*/
``` 
To add an Annotation to an Audit (only with API v3) use the AddAnnotation method, it takes the Guid of the Audit and the text of the annotation you want to add. It doesn't return a value.
```csharp
Guid auditId = new Guid("9cf1c11d-a8cc-48e6-9e4c-f02af26e8fdf");
string annotationText = "This is the text of the annotation";
client.Audits.AddAnnotation(auditId, annotationText);
``` 
To add multiple Annotations to an Audit (only with API v3) use the AddAnnotationMultiple, it takes a list of BatchRequestParam objects (specifing the list of Audits Guid and annotations) and it returns a list of Result objects.
```csharp
var requests = new List<BatchRequestParam>();
BatchRequestParam request1 = new BatchRequestParam { ObjectId = new Guid("e0fb025a-d8a2-4258-91ea-c4026c1620d1"), Resource = "THIS IS THE FIRST AUDIT ANNOTATION" };
requests.Add(request1);
BatchRequestParam request2 = new BatchRequestParam { ObjectId = new Guid("5ff1341e-dbf1-4eaf-b9a1-987f51dabefa"), Resource = "THIS IS THE SECOND AUDIT ANNOTATION" };
requests.Add(request2);

IEnumerable<Result> results = client.Audits.AddAnnotationMultiple(requests);
Result resultItem = results.ElementAt(0);
Console.WriteLine(resultItem);
/*
{
    "Id": "e0fb025a-d8a2-4258-91ea-c4026c1620d1",
    "Status": 201,
    "Annotation": "THIS IS THE FIRST AUDIT ANNOTATION"
}            /*
*/
``` 


## Usage (COM)

This section demonstrates how to use the LegacyMetasysClient to interact with your Metasys server from a VBA application.
Download the Command Line sample project [here](https://github.com/metasys-server/basic-services-dotnet/tree/master/MetasysServicesComExampleApp) and finally the Excel App is available at this [link](https://github.com/metasys-server/basic-services-dotnet/blob/master/MetasysServicesComExampleApp/MetasysApiTest.xlsm).

### Creating a Client

To create a new client and connect to a Metasys server with the default settings use the ComMetasysClientFactory:

```vb
Dim clientFactory As New ComMetasysClientFactory
Dim client As LegacyMetasysClient
Set client = clientFactory.GetLegacyClient("host")
```
There are three optional parameters when creating a new client:

- ignoreCertificateErrors: If your server does not have a valid certificate the MetasysClient will not behave as expected and will likely block the connection. Setting the ignoreCertificateErrors = true will ignore this error and make an insecure connection with the server. To avoid this problem ensure the Metasys server has a valid certificate.  
  
  **WARNING: You should not ignore certificate errors on a production site. Doing so puts your server at risk of a man-in-the-middle attack.**
  
- apiVersion: If your server is not a current 10.1 Metasys server or later this SDK will not function correctly. The version parameter takes in an ApiVersion string value that defaults to the most current release of Metasys. For Metasys 10.1 the api version is V2.
- cultureInfo: To set the language for localization specify the target culture with the ISO Language Code string. The default culture is en-US.
- logClientErrors: Set this flag to false to disable logging of client errors. By default the library logs any communication error with the Metasys Server in this path: "C:\ProgramData\Johnson Controls\Metasys Services\Logs".
  
To create a client that ignores certificate errors for a 10.1 Metasys server with Italian translations of values:

```vb
Set client = clientFactory.GetLegacyClient("host", true, "V2", "it-IT")
```
In some cases you may want to enrich logs with more specific messages to your application. Typically, you disable internal library logging and catch Metasys Exceptions to be handled in your own logging framework or Log4Net configuration provided by the library. The file log4Net.config allows you to customize settings such as the file path, size, append mode, etc.
To create a client that does not log errors use:

```vb
Set client = clientFactory.GetLegacyClient("host", true, "V2", "it-IT", false)
```

### Login and Access Tokens

After creating the client, to login use the TryLogin method.
The signature has two variants: the first (TryLoginWithCredMan) uses the Credential Manager target to read the credentials, whilst the second (TryLogin) takes a username and password.
Both signatures take an optional parameter to automatically refresh the access token during the client's lifetime. The default token refresh policy is true. See more information [here](https://support.microsoft.com/en-us/help/4026814/windows-accessing-credential-manager) on how to use Credential Manager. If something goes wrong while accessing a Credential Manager target, MetasysClient raises a CredManException. Keep in mind that Credential Manager is available on Windows and is not going to work on other platforms. However, MetasysClient Class could be extended by developers to implement different secure vaults support.

 **Notice: when developing an application that uses a system account always logged without user input, the preferred way to login is to store the username and password in the Credential Manager vault.**

```vb
Dim token As IComAccessToken
'Read username/password from Credential Manager vault and automatically refresh token
Set token = client.TryLogin("vault-target")
'Read username/password from Credential Manager vault and do not automatically refresh token
Set token = client.TryLogin("vault-target", false)
'Automatically refresh token using plain credentials
Set token = client.TryLogin("user", "password")
'Do not automatically refresh token using plain credentials
Set token = client.TryLogin("user", "password", false)
```

### Get an Object Id

In order to use most of the methods in LegacyMetasysClient the id of the target object must be known. This id is in the form of a Guid and can be requested using the following given you know the item reference of the object:

```vb
Dim id As String
id = client.GetObjectIdentifier("siteName:naeName/Folder1.AV1")
```

### Get a Property

In order to get a property you must know the Guid of the target object. An object called "ComVariant" is returned when getting a property from an object. ComVariant contains the property received in many different forms. There is a bit of intuition when handling a ComVariant since it will not explicitly provide the type of object received by the server. If the server cannot find the target object or attribute on the object this method will return a null value.

```vb
Dim result As ComVariant
Set result = client.ReadProperty(id, "presentValue")
Dim stringValue as String
stringValue = result.StringValue
Dim numericValue as Double
numericValue = result.NumericValue
Dim booleanValue as Boolean
booleanValue = result.BooleanValue
```

There is a method to get multiple properties from multiple objects. This can be very useful if the objects all are of the same type or have the same target properties.

```vb
Dim ids() As String
ids = Split("id1,id2", ",")
Dim attributes() As String
ids = Split("name,description", ",")
Dim results() As Object
results = client.ReadPropertyMultiple(ids, attributes)
Dim id1 As IComVariantMultiple
Set id1 = results(0)
Dim variants() As Object
variants=id1.Variants
```

### Write a Property

In order to write a property you must have the Guid of the object and know the attribute name and type. This method contains an optional priority parameter to specify the write priority of the value. This priority is in the form of an enumeration such as "writePriorityEnumSet.priorityNone". To see more options use the "api/v2/enumSets/1/members" or "api/v2/schemas/enums/writePriorityEnumSet" http requests defined in the [Metasys API](https://metasys-server.github.io/api-landing/api/v2/).

```vb
Dim id As String
id = client.GetObjectIdentifier("siteName:naeName/Folder1.AV1")
client.WriteProperty id, "description", "This is an AV."
client.WriteProperty id, "description", "This is an AV.", "writePriorityEnumSet.priorityNone"
```

To change the same attribute values of many objects use the WritePropertyMultiple method. This method also accepts an optional write priority.

```vb
Dim ids() As String
ids = Split("id1,id2", ",")
Dim attributes() As String
attributes = Split("name,description", ",")
Dim attributeValues() As String
attributeValues = Split("AV,This is an AV", ",")
client.WritePropertyMultiple ids, attributes, attributeValues
client.WritePropertyMultiple ids, attributes, attributeValues, "writePriorityEnumSet.priorityNone"
```

### Send Commands

When sending a command there may or may not be a single value or list of values that needs to be sent with the command. The Command.Items property will list all of these values as Items which contains the Title and Type of the value to change. If the type of an Item is "oneOf" this indicates the values is an enumeration and the possible values will be contained in the EnumerationValues list. Keep in mind the values to be sent in the command is the TitleEnumerationKey not the Title. The Title is the user friendly translated value that describes the enumeration. 
```vb

Dim parameters() As String
parameters = Split("offonEnumSet.0,", ",")
client.SendCommand id, "OperatorOverride", parameters

```

### Get Network Devices and other Objects

To get all the available network devices use the GetNetworkDevices method which returns a list of MetasysObjects. This accepts an optional type number as a string to filter the response. To get all of the available types on your server use the GetNetworkDeviceTypes method which returns a list of MetasysObjectType.

```vb
Dim devices() As Object
devices = client.GetNetworkDevices()
Dim device As IComMetasysObject
Set device = devices(0)
Dim itemReference as String
itemReference=device.itemReference
```

To get the child devices or objects of an object use the GetObjects method. This takes the Guid of the parent object and an optional number of levels to retrieve. The default is 1 level or just the immediate children of the object. Depending on the number of objects on your server this method can take a very long time to complete.

```vb
Dim devices() As Object
devices = client.GetObjects(id)
Dim device As IComMetasysObject
Set device = devices(0)
Dim children() As Object
children=device.children
```

### Spaces and equipment

To get all available spaces on an object use the GetSpaces method. This method will return a list of MetasysObjects. This accepts an optional type number as a string to filter the response. To get all of the available types on your server use the GetSpaceTypes method which returns a list of MetasysObjectType. To get all of the equipment on your server use the GetEquipment method which returns a list of MetasysObjects.
```vb
Dim spaceTypes() As Object
spaceTypes = client.GetSpaceTypes()
Dim spaceType As IComMetasysObjectType
Set spaceType = spaceTypes(0)
Dim spaces() As Object
spaces = client.GetSpaces(spaceType.Id)
Dim space As IComMetasysObject
Set space = spaces(0)
Dim equipment() As Object
equipment = client.GetEquipment()
Dim e As IComMetasysObject
Set e = equipment(0)
```
To get the children objects of Spaces and Equipment use the GetObjects method. This takes the Guid of the parent object and an optional number of levels to retrieve. The default is 1 level or just the immediate children of the object. Depending on the number of objects on your server this method can take a very long time to complete. 

### Alarms

To get all available alarms use the GetAlarms method. This method will return a PagedResult with a list of AlarmItemProvider. This accepts an AlarmFilter object to filter the response. To get a single alarm use the GetSingleAlarm method which returns an AlarmItemProvider object with all the details given the Guid.

```vb
'Prepare Alarm filter
Dim filter As New ComAlarmFilter
filter.StartTime = "2020-01-10T08:10:20.243Z"
filter.EndTime = "2020-01-10T09:10:20.243Z"
filter.ExcludeAcknowledged=true
Dim alarmsPager As ComPagedResult
Set alarmsPager = client.GetAlarms(objId, filter)
'Iterate paged results
Dim alarm As ComProvideAlarmItem
Dim alarms() As Object
alarms = alarmsPager.Items
Set alarm = alarms(0)
Dim message as String
message = alarm.message
'Read paging properties
Dim pages as integer
pages=alarmsPager.PageCount
```
To get the alarms of a specific Object or NetworkDevice use the GetAlarmsForAnObject and GetAlarmsForNetworkDevice methods. The Guid of the parent object is required as input.

```vb
Set objectAlarmsPager = client.GetAlarmsForAnObject(objId, filter)
Dim objectAlarms() As Object
ReDim objectAlarms(objectAlarmsPager.Items)
objectAlarms = objectAlarmsPager.Items
Set deviceAlarmsPager = client.GetAlarmsForNetworkDevice(networkDeviceId, filter)
Dim deviceAlarms() As Object
ReDim deviceAlarms(deviceAlarmsPager.Items)
deviceAlarms = deviceAlarmsPager.Items
```
To get the annotations of an alarm use the GetAlarmAnnotations method, it takes the Guid of the alarm and returns a list of AlarmAnnotation objects.

```vb
Dim alarmId As String
alarmId = "6c999f43-6007-5137-b6d3-c30b93fb70ec"
Dim result() As Object
result = client.GetAlarmAnnotations(alarmId)
```


### Trends

 To get all available samples given a time filter use the GetSamples method. This method will return a PagedResult with a list of Sample. This accepts the Guid of the object, the attribute ID and a TimeFilter object to filter the response. To get all of the available trended attributes of an object given the ID use the GetTrendedAttributes method. 

```vb
'Get Trended attributes
Dim attrs() As ComAttribute
attrs = client.GetTrendedAttributes(objId)
Dim attr As ComAttribute
Set attr = attrs(0)
Dim attrId As Integer
attrId = attr.id
'Prepare Time filter
Dim filter As New ComTimeFilter
filter.StartTime = "2020-01-10T08:10:20.243Z"
filter.EndTime = "2020-01-10T09:10:20.243Z"
Dim samplesPager As ComPagedResult
Set samplesPager = client.GetSamples(objId, attrId, filter)
'Iterate paged results
Dim sample As ComSample
Dim samples() As Object
samples = samplesPager.Items
Set sample = samples(0)
Dim value as String
value = sample.Value
'Read paging properties
Dim pages as integer
pages=samplesPager.PageCount
Dim SamplesCount as integer
samplesCount=samplesPager.Total
```
### Audits

To get all available audits use the GetAudits method. This method will return a PagedResult with a list of AuditItemProvider. This accepts an AuditFilter object to filter the response. To get a single audit use the GetSingleAudit method which returns an AuditItemProvider object with all the details given the Guid.

```vb
'Prepare Alarm filter
Dim filter As New ComAuditFilter
filter.StartTime = "2020-01-10T08:10:20.243Z"
filter.EndTime = "2020-01-10T09:10:20.243Z"
filter.OriginApplications="1,2"
filter.ActionTypes="0,1"
Dim auditsPager As ComPagedResult
Set auditsPager = client.GetAudits(filter)
'Iterate paged results
Dim audit As ComProvideAuditItem
Dim audits() As Object
audits = auditsPager.Items
Set audit = audits(0)
Dim user as String
user = audit.user
'Read paging properties
Dim pages as integer
pages=auditsPager.PageCount
```
To get the audits of a specific Object use the GetAuditsForAnObject methods. The Guid of the parent object is required as input.

```vb
Set objectAuditsPager = client.GetAuditsForAnObject(objId, filter)
Dim objectAudits() As Object
ReDim objectAudits(objectAuditsPager.Items)
objectAudits = objectAuditsPager.Items
```
To get the annotations of an audit use the GetAuditAnnotations method, it takes the Guid of the audit and returns a list of AlarmAnnotation objects.

```vb
Dim auditId As String
auditId = "6c999f43-6007-5137-b6d3-c30b93fb70ec"
Dim result() As Object
result = client.GetAuditAnnotations(auditId)
```
To add many annotations to one or many audits use the AddAuditAnnotationMultiple method, it takes an array of strings 
as parameter and returns an array of strings as well.
Each string of the array used as parameter must contains the audit ID 
and the text of the annotation separated by the character | (vertical bar).

```vb
Dim auditId As String
auditId = "6c999f43-6007-5137-b6d3-c30b93fb70ec"

Dim annotation1 as String
annotation1 = "TEXT OF ANNOTATION #1"
Dim annotation2 as String
annotation2 = "TEXT OF ANNOTATION #2"

Dim requestParams(1) As String
requestParams(0) = auditId & "|" & annotation1
requestParams(1) = auditId & "|" & annotation2

Dim result() As String
result = client.AddAuditAnnotationMultiple(auditId)
```

To discard many audits using one call please use the DiscardAuditMultiple method, it takes an array of strings 
as parameter and returns an array of strings as well.
Each string of the array used as parameter must contains the audit ID 
and the text of the discard annotation separated by the character | (vertical bar).

```vb
Dim auditId1 As String
auditId1 = "1b3b3127-a703-42b7-bb9a-7527331e329d"
Dim auditId2 As String
auditId2 = "e3b6cbcf-cf05-43ed-b845-7321c8b86c38"

Dim annotation1 as String
annotation1 = "DISCARD ANNOTATION AUDIT #1"
Dim annotation2 as String
annotation2 = "DISCARD ANNOTATION AUDIT #2"

Dim requestParams(1) As String
requestParams(0) = auditId1 & "|" & annotation1
requestParams(1) = auditId2 & "|" & annotation2

Dim result() As String
result = client.DiscardAuditMultiple(auditId)
```

## License

See [LICENSE](LICENSE).

## Contributing

See [CONTRIBUTING](CONTRIBUTING).

## Additional Information

### Supported Localization Languages

- en-US
- cs-CZ
- de-DE
- es-ES
- fr-FR
- hu-HU
- it-IT
- ja-JP
- ko-KR
- nb-NO
- nl-NL
- pl-PL
- pt-BR
- ru-RU
- sv-SE
- tr-TR
- zh-CN
- zh-Hans-CN
- zh-Hant-TW
- zh-TW
