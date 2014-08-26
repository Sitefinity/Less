LESS Support
============

[![Build Status](http://sdk-jenkins-ci.cloudapp.net/job/Telerik.Sitefinity.Samples.Less.CI/badge/icon)](http://sdk-jenkins-ci.cloudapp.net/job/Telerik.Sitefinity.Samples.Less.CI/)

The solution contains projects for compilation of LESS syntax to CSS styles.

- `Telerik.Less` - contains the compiler that takes the LESS input and returns the CSS output.
- `Telerik.Less.Test` - contains unit tests for the compiler.
- `Telerik.Sitefinity.Less` - contains the Sitefinity module that adds the compiler functionality to Telerik Sitefinity product.

### Requirements
------------

 The account that will use the module (the application pool identity if the application is hosted in IIS) should have write permissions to the Temp folder (`C:\Windows\Temp or C:\Users\user\AppData\Local\Temp`).

### Prerequisites

Clear the NuGet cache files. To do this:

1. In Windows Explorer, open the **%localappdata%\NuGet\Cache** folder.
2. Select all files and delete them.


### Features
--------

This module handles requests to files with extension `*.less` that are stored in the following locations:

- `Sitefinity_application\App_Themes\ThemeName\`
- `Sitefinity_application\App_Data\Sitefinity\WebsiteTemplates\`

### Installation instructions
------------

There are several ways you can use this module in Sitefinity:

1. Direct usage in SitefinityWebApp without cloning this repository

- Install Telerik.Sitefinity.Less.7.1.5207.nupkg following the instructions on the [nuget server](http://nuget.sitefinity.com/).
- Build the Sitefinity project
- Open Sitefinity in a browser and navigate to Aministration -> Modules and services
- Activate Less module


2. If your Sitefinity project version is different than any of the [releases](https://github.com/Sitefinity/Less/releases) versions, you need to follow the instructions below:

- Clone the Less repository.
- Open your solution in Visual Studio and build it.
- Open your Sitefinity project and copy the Telerik.Sitefinity.Less.dll and Telerik.Less.dll assemblies to the bin folder of your SitefinityWebApp.
- Build your Sitefinity web project.

*NOTE*: With the current implementation the Less module is self-registered. Once you copy the assemblies to the bin folder of the application on the next load the module would be automatically registered. 

This behavior could be changed if you remove the `PreApplicationStartMethodAttribute` from the `AssemblyInfo.cs` file of the `Telerik.Sitefinity.Less` project and add the call to the `RegisterModule` method in the `Initialize` method of the `LessModule.cs` file.

- What you need to do next is go to `Administration -> Modules and services` and activate the Less module.

Ensure that the account that will use the module (the application pool identity if the application is hosted in IIS, e.g. `IIS APPPOOL\[applicationpoolname]`) should have write permissions to the `Temp` folder (`C:\Windows\Temp` or `C:\Users\user\AppData\Local\Temp`).

### Troubleshooting
---------------

- Please note that in order for the module to work correctly you need to copy not only the module assembly (`Telerik.Sitefinity.Less.dll`) but the compiler assembly (`Telerik.Less.dll`) as well to the bin folder of the application.
- Make sure that the `Telerik.Windows.Zip` assembly is presented and it is the same version across all projects.
- On shared hosting there might be some problems with the permissions required to run the compiler process.
