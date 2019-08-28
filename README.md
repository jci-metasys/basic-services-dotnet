Metasys Basic Services
====================

This project provides a library for accessing the most
common services of the Metasys Server API.

The intent is to provide an API that is very similar to the
original MSSDA (Metasys System Secure Data Access) library.

Package name and even org name can still be changed at this time. Suggestions welcome.


Installation
------

Not implemented yet. This is an illustration of desired installation. This section should be updated when
we release v1


For dotnet app you can install and use like this:

```bash
$ dotnet new console
$ nuget install metasys-basic-services
```

For Excel App (or any other COM app)

We need a way to install the dll(s) and then also register
them with COM system.

```bash
$ nuget install metasys-basic-services
./register
```

This approach needs some investigation

1. I assume nuget packages can just be installed "anywhere"? Typically they would be added to some existing
   dotnet project. But in this case we just need the dll's installed somewhere on box
2. Need some direction on where they should be installed. Some guidance for the Excel app developer as to what will happen
3. Guidance on switching to the correct path and then running the ./register script
4. Guidance on how to add a reference to the dll from excel

Usage
-------

The following is just some pseudocode. Note, we'll need a resource manager and resource files (work already begun) 
to provide translations for enums (even for English). This section should be updated with real examples when
we release v1

```csharp
// Login
var client = new TraditionalClient();

// apiversion will always have a default based on the release of basic-services, like this initial version will 
// default to v2. The next major version (released with Metasys 11.0 will likely default to v3)
// If you need to access both versions then instantiate two clients.
client.Login(username, password, hostname, apiversion) 

// Read an analog value
var result = client.ReadProperty(guid, "presentValue")
Console.Log(result.NumericValue)

// Read an enum value
var result = client.ReadProperty(guid2, "presentValue")
var enumValue = result.StringValue
Console.Log(resourceManger.GetString(enumValue, "en-US")

// Read a string value
var result = client.ReadProperty(guid3, "description")
Console.Log(result.StringValue)

// Read a boolean value
var result = client.ReadProperty(guid4, "isEnabled")
Console.Log(result.StringValue) // prints "True" or "False" 
Console.Log(result.NumericValue) // prints 1 or 0
Console.Log(result.BooleanValue) // prints "True" or "False". This BooleanValue isn't in scope but perhaps it should be

// Read an array value, new for basic services, didn't exist in MSSDA
var result = client.ReadProperty(guid5, "ipAddress") // ipAddress is an array of bytes
var firstByteResult = result.ArrayValue[0]
Console.Log(firstByteResult.Item1)   // prints "192" as Item1 is the string representation

// alternatively
var (string StringValue, double NumericValue) secondByte = result.ArrayValue[1] 
Console.Log(result.StringValue)

```


Requirements
-----------

This section should be moved into a seperate Requirements document. Or we can create cards in the 
associated [project](https://github.com/metasys-server/basic-services-dotnet/projects/1) to track
work/requirements. Or we can use Issues. Once development begins in earnest lets clean this up.

This project will have several small phases. The first phase will
expose add reading of objects/attributes. The second phase will add writing and commanding.
The final phase will add discovery of devices and objects.

* The project must maintain a CHANGELOG (https://keepachangelog.com/en/1.0.0/ ).I have example here: https://github.com/metasys-server/nodekit/blob/master/CHANGELOG.md 
* This package must be published in the metasys organization at nuget.org with appropriate semantic versioning, https://semver.org
copyright, licensing, link to github repo, etc. 

* We will release a version at the end of Phase 1. Most likely 1.0. Earlier versions can be published but only as 0.x versions
or as pre-release versions of 1.0 (follow microsoft guidance here on prerelease versioning: https://docs.microsoft.com/en-us/nuget/create-packages/prerelease-packages )
    Breaking changes should align with major versions of Metasys where possible. We should avoid any breaking changes
    in between release of Metasys.
    
* Naming guidelines: Follow Microsoft Naming guidelines https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines 

* All submitted code must be reviewed through pull requests.

* Good commit messages must be used on all commits. https://chris.beams.io/posts/git-commit/ 
Most commits should NOT be one liners. When adding a commit add a paragraph or a few paragraphs explaining what you did.
Only the smallest of commits should be one line messages.

* Consider adding a light weight CONTRIBUTING.md or referencing Microsoft's for guidance for outsiders and others in JCI.

* Track the Issues on this repo and provide guidance (where possible) on roadmap.

* We should consider the suitability of signing our dll. See this tutorial on how one might mark their dlls as
  truste in the nuget repository. https://natemcmaster.com/blog/2018/07/02/code-signing/ 
  
* Every published release should be tagged with a signed tag. So if there is a v1 in nuget.org then the releases tab
  and the tags tab of this repo should have a v1 as well.
  
* We want our customers to get documentation of our library while using intellisense in their IDE. Follow Microsoft
  guidelines for writing XML Comments and making them available in nuget package for clients. Here's a stackoverflow
  Q&A that says how to do it. https://stackoverflow.com/questions/19672943/xml-comments-in-nuget-package 
  
* Need CI pipeline. Once a PR is create the automated tests run. Nice to have an publish process as well so that
  once we decide we want to publish a version it's easy to do. Perhaps a simple script. Consider an OAS in Azure that
  we can snapshot to reset back to known state before tests run.
  
* Add appropriate badges to README (for example last build successful) 

### Phase 1

We will begin on what I'm calling the TraditionalClient. (name can be changed).
I'm calling it the TraditionalClient because of its heavy influence on the old MSSDA.
The traditional client is probably ideal for the typical MSSDA customer because it 
doesn't utilize many advanced C# features. But it is non-ideal for advanced development.

1. It is synchronous. A more advanced SDK would expose all operations as asynch operations.
2. It doesn't use generics. Instead it returns simple return structures (like ReadPropertyResult) that
   model attribute values as strings, numbers and array. The client just needs to know based on what
   attribute they are reading which of the values is most appropriate for thier usage. This is how 
   MSSDA worked as well. A more advanced SDK would use `JToken` values or `dynamic` or generics.
3. It doesn't use Nullable<T> which makes it a little awkward in some cases. Like what is the numeric value
   of the string "AV1"? Using the MSSDA guidelines the numeric value of a string will be 0. (A more sophisticated
   API would mark the numeric value as nullable for when it doesn't make sense)
   
The following requirements will be met in phase 1:

1. Implement Login
1. Implement GetObjectIdentifier
1. Implement ReadProperty
2. Implement ReadPropertyMultiple
3. Expose the library as COM dll for use in Excel apps
4. Ensure signatures of the methods are easy to consume via COM (Using exceptions is probably a bad idea.
   If we find exceptions are the best for .Net consumers then we'll want separate methods exposed for Excel
   that return error codes rather than throw exceptions)
5. Must provide client side resource files for translating enum values
   coming back from the server. (Unlike MSSDA, enums are not returned
   from the server as localized strings. They are returned as "symbolic
   strings" which are more useful at the API level. The client side
   resource files will provide the ability for clients to show localized
   strings.
6. Nuget package support (for deployment to metasys-server org)
7. Script for registering dll for COM (would only be used by Excel apps, wouldn't be needed for .Net apps)
8. Script for unregistering dll

Suppoted Data Types

boolean, numbers, strings, enums, arrays of one of these.

Not supported: date, time, listOf, structs, object identifiers, bits, etc.

### Phase 2

Allow for reverse lookup of resource file. Given a localized string,
find the enum value associated (for usage in SendCommand and WriteProperty)

2. Implement WriteProperty
4. Implement WritePropertyMultiple
5. Implement GetCommands
5. Implement SendCommand


### Phase 3

1. Implement GetObjectList() this will differ from MSSDA. MSSDA returned just the immediate children of given object.
   10.1 Metasys Server has the /objects endpoint which doesn't allow you to specify a depth parameter. It returns all children
   but the result is paged. So we can decide if GetObjectList should fetch all pages or if we should add paging support to
   this method. First release should probably just use a large page size and loop until all children have been processed.
   
2. Implement GetDeviceList() this will likely differ from MSSDA as well. We have the /networkDevices endpoint which will
   be the source of data. 