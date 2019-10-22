<!-- markdownlint-disable MD014 -->

# How to Contribute <!-- omit in toc -->

Please follow the contribution guidelines outlined below.

- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
  - [COM Development](#com-development)
- [Work Area Setup](#work-area-setup)
- [Recommended Tools](#recommended-tools)
- [Adding Content](#adding-content)

## Project Structure

The main project is under MetasysServices: the MetasysClient. Any changes to the Http requests or core application content is made here.

MetasysServicesCom contains the LegacyMetasysClient which is compatible with COM services. This project aims to match the original MSSDA as closely as possible. The LegacyMetasysClient is closely coupled with the MetasysClient since it uses it for all core application content.

## Prerequisites

- Have the .NET Framework 4.7.2 installed ([installation options](https://docs.microsoft.com/en-us/dotnet/framework/install/guide-for-developers)). You can check your installed versions with the `clrver` command.

### COM Development

- Have dotnet-zip installed (dotnet tool install --global dotnet-zip).

## Work Area Setup

Follow the steps below to setup a personal work area to contribute to this repository. For more details see this [help page](https://help.github.com/en/articles/fork-a-repo).

1. Fork the repository on Github and clone your new repository locally:

    ```bash
    $ git clone git@github.com:<Username>/basic-services-dotnet.git
    ```

2. Setup Git workflow:

    ```bash
    $ git remote add upstream git@github.com:<Username>/basic-services-dotnet
    $ git remote add origin git@github.com:metasys-server/basic-services-dotnet.git
    $ git remote -v
    origin git@github.com:metasys-server/basic-services-dotnet.git (fetch)
    origin git@github.com:metasys-server/basic-services-dotnet.git (push)
    upstream git@github.com:<Username>/basic-services-dotnet (fetch)
    upstream git@github.com:<Username>/basic-services-dotnet (push)
    ```

3. Create a new branch with an intuitive name describing your work such as:

    ```bash
    $ git checkout -b "UpdateReadProperty"
    ```

4. Follow the Git workflow of pulling from origin, pushing upstream:

    ```bash
    $ git push upstream
    $ git pull origin master
    ```

5. Create pull requests on the metasys-server/basic-services-dotnet repository (see [Adding Content](#adding-content) for pull request guidelines).

## Recommended Tools

If using Visual Studio Code add the following extensions:

- markdownlint (linter for modifying markdown files)
- Markdown All in One (for modifying markdown files)
- Code Spell Checker (spellcheck for camel cased words)

## Adding Content

- Follow the general c# coding conventions specified by Microsoft [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) and naming guidelines [here](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines).
- Add tests to the appropriate .Tests folder for new code.
- Commits
  - Use good commit messages to specify changes.
  - Keep commit history clean (remove unnecessary messages).
  - See these [guidelines](https://chris.beams.io/posts/git-commit/).
- Pull Requests
  - Run ALL TESTS and ensure they pass before submitting a pull request.
  - Create a good title that summarizes the reason for the merge.
  - Include a short summary of changes (details should be included in commit messages).
  - If addressing an issue on Github link the pull request in the issue's comment section.
    - Move issue to "In Review" on applicable projects.
    - Example comment message: "Issue addressed in #1."
  - Include @buldrinie as a reviewer on all pull requests.
    - Include @mgwelch for architecture or design review request.
- Issue Tracking
  - Add any new issues or bugs to the main GitHub repository for tracking purposes.
