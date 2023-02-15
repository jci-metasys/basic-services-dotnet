# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [5.0.2] - 2023-02-07

### Added

- Added the support for 'Ad-Hoc' calls.

### Changed

- Updated reference to Newtonsoft.Json v13.0.2 (and removes a few unused references).

## [5.0.1] - 2022-11-09

### Changed

- Modified the default value of the parameter 'pageSize' from 100 to 1000.
- Modified the method Equipments.Get() in order to add a few optional parameters as 'page' and 'pageSize'.

## [5.0.0] - 2022-06-01

### Added

- Support to Metasys API v4 (provided by Metasys 12).
- Added new Alarm service methods: Alarms.Acknowledge, Alarms.Discard.
- Added new Enumeration service and related methods: Enumerations.Get, Enumerations.Create, Enumerations.GetValues, Enumerations.Edit, Enumerations.Replace, Enumerations.Delete.
- Added new Equipment service and related methods: Equipments.Get, Equipments.FindById, Equipments.GetServedByEquipment, Equipments.GetPoint, Equipments.GetServingASpace, Equipments.GetHostedByNetworkDevice, Equipments.GetServingAnEquipment.
- Added new NetworkDevice service and related methods: NetworkDevices.Get, NetworkDevices.GetTypes, NetworkDevices.FindById, NetworkDevices.GetHostingAnEquipment, NetworkDevices.GetChildren, NetworkDevices.GetServingASpace.
- Added new Space service and related methods: Spaces.Get, Spaces.GetChildren, Spaces.GetTypes, Spaces.FindById, Spaces.GetServedByEquipment, Spaces.GetServedByNetworkDevice.
- Added new Stream service and related methods: StartReadingCOV, StopReadingCOV, Streams.GetCOV, Streams.StartCollectingAlarms, Streams.StopCollectingAlarms, Streams.GetAlarmEvents, Streams.StartCollectingAudits, Streams.StopCollectingAudits, Streams.GetAuditEvents, Streams.KeepAlive.
- Added a new specific exception to report when a method is not supported by the specified API version.
- Added a new TestClient application to show how to use all the provided methods.

### Changed

- Updated the file 'MetasysApiTest.xlsm' to shown examples of the new methods.
- Modified the following existing methods to support API v4: Alarms.Get, Alarms.FindById, Alarms.GetForNetworkDevice, Alarms.GetForObject, Alarms.GetAnnotations, Audits.Get, Audits.FindById, Audits.GetForObject, Audits.GetAnnotations, Audits.Discard, Audits.DiscardMultiple.

### Deprecated

- Deprecated the following existing methods: GetEquipmentPoints, GetNetworkDevices, GetEquipment, GetSpaceEquipment, GetNetworkDevices, GetNetworkDeviceTypes, GetSpaces, GetSpaceChildren, GetSpaceTypes. These methods have been replaced by the equivalent ones provided by the different services.

## [4.2.0] - 2020-10-20

### Added

- Added new method AddAuditAnnotationMultiple (COM) to add many audit annotations in one call.
- Added the new method DiscardAuditMultiple (COM) to discard many audits in one call.
- Added a new specific exception to report when a method is not supported by the specified API version.

### Changed

- Updated the file 'MetasysApiTest.xlsm' to shown examples of the new methods.
- Updated Id for Equipment and Space examples

### Fixed

- Issue in the method GetSampleAsync (due to v3 changes)


## [4.1.0] - 2020-07-24

### Added

- Translations for Fully Qualified Enum Attributes returned by API v3 (for Alarms and Audits)
- The new method GetServerTime
- A new enumeration set for ActionType
- A new enumeration set for OriginApplication
- A new enumeration set for ClassLevel
- A new enumeration set for NetworkDeviceType
- Added AuditSignature and LegacyInfo strong typed objects for Audits (.Net and COM)
- Added a few new Test Cases (mainly for v3)

### Changed

- Handled single values scenario for PreData and PostData (for Audits)
- Modified the method GetnetworkDevices to accept the new NetworkDeviceType enumeration as parameter
- Modified the AuditFilter object to accept the new enumeration sets as paramenters
- Modified Equals and GetHashCode methods in a few class as Alarm, Audit, AuditData and LegacyData
- Removed priority from write methods in Excel app
- Updated Id for Equipment and Space examples

### Fixed

- Issue in the parameters passed to the SendCommands method (due to v3 changes)
- Issue in FindById method (for Alarms and Audits) due to difference in the object structure of v3
- Issue is the response parsing of GetCommands method (when using v3)

## [4.0.0] - 2020-06-19

### Added

-  Support to API v3 (pre-release)
-  GetBatchRequestAsync, PutBatchRequestAsync, PostBatchRequestAsync methods to support Objects batch endpoint of v3
-  Support for Batch request on ReadPropertyMultiple
-  Support for Batch request on AddAnnotationMultiple (for Audits)
-  Support for Batch request on DiscardMultiple (for Audits)
-  Public setter for ApiVersion and Hostname
-  Overload for WritePropertyMultiple that takes a dictionary of key/value pairs
-  Support to fully qualified enums of v3 (Sample, Alarm, Audit)
-  Helpers FindByName, FindByID, FindByShortName to work with MetasysObject, MetasysPoint, Variant, VariantMultiple collections
-  Support for the method GetAnnotations (for Alarms)
-  Support for the methods GetAnnotations, AddAnnotation, Discard (for Audits)
-  Added the new class ResourceManager to support the static methods: Localize, GetCommandEnumeration and GetObjectTypeEnumeration

### Changed

-  Simplified methods and models names of Alarm and Audit service
-  PostBatchRequestAsync method to support Objects batch endpoint of v3
-  Support for Batch request on ReadPropertyMultiple
-  Renamed Point class in MetasysPoint
-  Renamed Attribute class in MetasysClass
-  Renamed Variants property of VariantMultiple in Values
-  Modified the Localize method that now uses the new class ResourceManager

## [3.5.1] - 2020-05-18

### Fixed

- Fixed issue of silent thread termination on custom SynchronizationContext for async methods
- Fixed parsing of type parameter for COM GetSpaces and added COM GetSpaceChildren method

## [3.5.0] - 2020-05-15

### Added

- GetSpaceChildren method
- SpaceType enum
- Set AccessToken method
- Issuer and IssuedTo properties for AccessToken
- TypeUrl property for MetasysObject
- Category property for MetasysObject
- ToString with JSON format for output objects

## [3.4.0] - 2020-03-26

### Added

- Added ReadAttributeValue option flag for GetEquipmentPoints method.

## [3.3.0] - 2020-03-12

### Added

- Added logClientErrors flag for MetasysClient constructor.
- Added logClientErrors flag for GetLegacyClient method.
- Added CredManException when an error occurs while retrieving Credential Manager target.
- Runtime errors are now automatically written to a dedicated text file.

## [3.2.0] - 2020-02-28

### Added

- Added support to Credential Manager for TryLogin method of MetasysClient.
- Added support to Credential Manager for TryLoginWithCredMan method of LegacyMetasysClient.
- Added CredentialUtil to retrieve/set user and passwords from the secure vault.
- Added Log4Net support in MetasysClient and LegacyMetasysClient.
- Added Log4Net support in Basic Services as a facility for the host application (see example apps for usage).

### Fixed

- Mapping with ComPoint in LegacyClient and SpaceEquipment method.

## [3.1.0] - 2020-02-13

### Added

- Dedicated Service Provider for Audits.
- Get Audits method with filter object.
- Get Single Audit by guid method.
- Get Audits for a specific object method.

### Fixed

- Empty Guid check on Get Equipment points.

## [3.0.0] - 2020-01-30

### Added

- Dedicated Service Provider for Trends
- Get Trended Attributes method for a specific object.
- Get Samples for a specific object given the attribute ID and the Time filter.

### Changed

- Alarms services are now exposed by a dedicated Alarms provider of MetasysClient class.
- GetAlarms methods now returns a PagedResult of type AlarmItemProvider.
- GetSingleAlarm, GetAlarmsForAnObject, GetAlarmsForNetworkDevice methods now accept Guid object as input in Metasys Services.

### Fixed

- COM methods for Alarms accept input filter object and return results using proper mapping.

## [2.3.0] - 2020-01-20

### Added

- Get Alarms method with filter object.
- Get Single Alarm by guid method.
- Get Alarms for a specific object or network devices methods.

## [2.0.0] - 2019-11-26

### Added

- Get Spaces, Get Space Types and Get Equipment methods.
- Get Space Equipment and GetEquipment Points methods.
- Caching for Get Object Identifier.

### Changed

- MetasysHttpNotFoundException is raised when attempt to read from a nonexistent resource. ReadProperty and GetObjectIdentifier methods do not use nullable return type anymore.
- Factory for COM: GetLegacyClient is now the main method to get the instance.
- Host parameter was moved from TryLogin method to GetLegacyClient Factory.

## [1.0.0] - 2019-10-31

First Release.

### Added

- MetasysClient to perform basic Http requests on a Metasys server.
- LegacyMetasysClient for compatibility with COM services.
- Automatic enumeration translations for supported languages.

[Unreleased]: https://github.com/metasys-server/basic-services-dotnet/compare/v4.1.0...HEAD
[4.2.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v4.1.0...v4.2.0
[4.1.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v4.0.0...v4.1.0
[4.0.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v3.5.1...v4.0.0
[3.5.1]: https://github.com/metasys-server/basic-services-dotnet/compare/v3.5.0...v3.5.1
[3.5.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v3.4.0...v3.5.0
[3.4.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v3.3.0...v3.4.0
[3.3.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v3.2.0...v3.3.0
[3.2.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v3.1.0...v3.2.0
[3.1.0]: https://github.com/metasys-server/basic-services-dotnet/compare/3.0.0...v3.1.0
[3.0.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v2.3.0...3.0.0
[2.3.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v2.0.0...v2.3.0
[2.0.0]: https://github.com/metasys-server/basic-services-dotnet/compare/v1.0.0...v2.0.0
[1.0.0]: https://github.com/metasys-server/basic-services-dotnet/releases/tag/v1.0.0
