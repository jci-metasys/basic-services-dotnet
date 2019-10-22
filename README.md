# Metasys Basic Services <!-- omit in toc -->

This project provides a library for accessing the most common services of the Metasys Server API.
The intent is to provide an API that is very similar to the original MSSDA
(Metasys System Secure Data Access) library.

For versioning information see the [changelog](CHANGELOG).

## Contents <!-- omit in toc -->

- [Installation](#installation)
  - [Prerequisites](#prerequisites)
  - [.NET](#net)
  - [Excel Applications & COM (Component Object Model)](#excel-applications--com-component-object-model)
- [Usage (.NET)](#usage-net)
  - [Creating a Client](#creating-a-client)
  - [Login and Access Tokens](#login-and-access-tokens)
  - [Get a Property](#get-a-property)
  - [Localization of Metasys Enumerations](#localization-of-metasys-enumerations)
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

### Excel Applications & COM (Component Object Model)

The package should automatically register with the COM interop when the project is built. To register or unregister use the RegCOM.bat and UnregCOM.bat scripts located in the Scripts directory.

To manually register for COM interop use the Regasm.exe (Assembly Registration Tool) or similar tool.
[See more information here](https://docs.microsoft.com/en-us/dotnet/framework/tools/regasm-exe-assembly-registration-tool).

## Usage (.NET)

This section demonstrates how to use the MetasysClient to interact with your Metasys server from a .NET application.
<!-- Download the sample project [here](https://github.com/metasys-server). -->

### Creating a Client

To create a new client and connect to a Metasys server with the default settings use:

```csharp
var client = new MetasysClient("hostname");
```

There are three optional parameters when creating a new client:

- ignoreCertificateErrors: If your server does not have a valid certificate the MetasysClient will not behave as expected and will likely block the connection. Setting the ignoreCertificateErrors = true will ignore this error and make an insecure connection with the server. To avoid this problem ensure the Metasys server has a valid certificate.
- apiVersion: If your server is not a current 10.1 Metasys server or later this SDK will not function correctly. The version parameter takes in an ApiVersion enumeration value that defaults to the most current release of Metasys. For Metasys 10.1 the api version is V2.
- cultureInfo: To set the language for localization specify the target culture with a CultureInfo object. The default culture is en-US.

To create a client that ignores certificate errors for a 10.1 Metasys server with Italian translations of values:

```csharp
CultureInfo culture = new CultureInfo("it-IT");
var client = new MetasysClient(hostname, true, ApiVersion.V2, culture);
```

### Login and Access Tokens

After creating the client, to login use the TryLogin method which takes a username, password, and an optional parameter to automatically refresh the access token during the client's lifetime. The default token refresh policy is true.

```csharp
// Automatically refresh token
client.TryLogin("username", "password");

// Do not automatically refresh token
client.TryLogin("username", "password", false);
```

At any time you want to manually refresh the access token before it expires use the following:

```csharp
client.Refresh();
```

To use the authorization token in an different HttpClient use the AccessToken object returned by these methods. A successful token will be in the form "Bearer ...".

```csharp
AccessToken token = client.Refresh();
Console.WriteLine($"Token: {token.Token}\nExpires: {dateToDisplay.ToString("g", token.Expires)}");

// Token: Bearer eyJ0eXAi...
// Expires: 10/1/2019 5:04 PM
```

### Get a Property

In order to get a property you must know the fully qualified reference of the object which will be used to get the id of the object in the form of a Guid. An object called "Variant" is returned when getting a property from an object. Variant contains the property received in many different forms. There is a bit of intuition when handling a Variant since it will not explicitly provide the type of object received by the server.

```csharp
Guid id = client.GetObjectIdentifier("siteName:naeName/Folder1.AV1");
Variant result = client.ReadProperty(id, "presentValue");
string stringValue = result.StringValue;
double numericValue = result.NumericValue;
bool booleanValue = result.BooleanValue;
Variant[] array = result.ArrayValue;
```

There is a method to get multiple properties from multiple objects. This can be very useful if the objects are all have the same properties. There is an optional parameter to ignore any Http "Not Found" errors to avoid throwing an exception if the property does not exist on an object. The default is to ignore these errors.

```csharp
List<Guid> ids = new List<Guid> { id1, id2 };
List<string> attributes = new List<string> { "name", "description" };

// Do not throw exceptions for missing resources
IEnumerable<VariantMultiple> results = client.ReadPropertyMultiple(ids, attributes);

// Throw exceptions if an attribute is not found by the server
IEnumerable<VariantMultiple> results = client.ReadPropertyMultiple(ids, attributes, true);

IEnumerable<Variant> id1Variants = results.ElementAt(0).Variants;
```

### Localization of Metasys Enumerations

To get automatically translated enumerations on enumerations returned from a Metasys server you must specify the culture during client creation, or set the "Culture" property before using the "get" methods. The default language for translations will be the machine's current culture ([see more information here](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture)) or en-US (American English) if the language is not supported (see [Supported Localization Languages](#supported-localization-languages)).

```csharp
client.Culture = new CultureInfo("it-IT");
```

Enumerations returned from a Metasys server will be in a format similar to: "reliabilityEnumSet.reliable". MetasysClient has a method to translate these enumerations. This method can be very useful if using a different HttpClient since Metasys servers do not hold translation information.

```csharp
// Access from the client object
string translated = client.Localize("reliabilityEnumSet.reliable"); // Reliable

// Access without instantiating a client
string translated = MetasysClient.StaticLocalize("reliabilityEnumSet.reliable",
    new CultureInfo("it-IT"));  // Affidabile
```

Note: If a Variant contains an enumeration value and not a translated string there could be an error with the MetasysClient globalization setup.

<!-- ## Usage (COM) -->

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
- zh-TW
