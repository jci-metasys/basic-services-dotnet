# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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
