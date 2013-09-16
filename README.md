# Sitecore Item Versioner
The Sitecore Item Versioner module adds a new ribbon into the versions chunk of the Content Editor. With the new ribbon it is possible to initially create an item version in all configured languages (under _/sitecore/system/Languages_). It will only create a new version if there is not already a version in the specific language.

The module is perfect for administrators i.e. to create standard values in each language or to add language versions for dictionary items. But it can also be used as a content author to create a skeleton of a content item in each language.

## Download
You can either clone the repository from GitHub, download the NuGet package from the [NuGet Gallery] (https://www.nuget.org/packages/SitecoreItemVersioner) or download the Sitecore package from the [Sitecore Marketplace] (http://marketplace.sitecore.net/en/Modules/Sitecore_Item_Versioner.aspx).

## Installation
### Manual Installation
You can clone the GitHub repository and build the source code. You need to copy the _Sitecore.Kernel.dll_ into the _lib_ directory, otherwise you won't be able to build because of missing references. There are some MSBuild targets which copies all needed files into a directory defined in the _build/deploy.txt_ file. Just copy all this files into your Sitecore installation directory. You also need to copy the _data/serialization_ folder into your data folder and update the Core database.

### NuGet
There is a NuGet package available to download on the [NuGet Gallery] (https://www.nuget.org/packages/SitecoreItemVersioner). For installing the NuGet package, Sitecore Rocks and the following two steps are required (instructions from [Ethan Truong] (http://blog.velir.com/index.php/2012/12/04/create-and-deploy-sitecore-modules-with-nuget/)):

1. Attach a Sitecore Rocks Connection to a Visual Studio Project using [Sitecore Rocks] (http://visualstudiogallery.msdn.microsoft.com/44a26c88-83a7-46f6-903c-5c59bcd3d35b/) by:
	- Right clicking on the Visual Studio project to which you will install the package, then clicking "Sitecore" and then "Connect".
	- Connect using an existing Sitecore Rocks connection or create a new Sitecore Rocks connection to the Sitecore server where you want to install the package.
	- John West walks you through this in his [blog post] (http://www.sitecore.net/Community/Technical-Blogs/John-West-Sitecore-Blog/Posts/2011/06/Attach-a-Sitecore-Rocks-Connection-to-a-Visual-Studio-Project.aspx).

2. [Install the NuGet package] (https://www.nuget.org/packages/SitecoreItemVersioner)

### Sitecore Package
Alternatively you can also download the Sitecore package from the [Sitecore Marketplace] (http://marketplace.sitecore.net/en/Modules/Sitecore_Item_Versioner.aspx) and install it with the _Installation Wizard_.

## Version
The Item Versioner has been developed with Visual Studio 2012 and Sitecore 6.6. It is also tested on Sitecore 6.5 and Sitecore 7.0 You should be able to work with other versions as well. If you have some problems with any versions, please let me know by [adding an issue] (https://github.com/aquasonic/SitecoreItemVersioner/issues).

## License
The Sitecore Item Versioner is licensed under the LGPL. Please see [LICENSE.txt] (https://github.com/aquasonic/SitecoreItemVersioner/blob/master/LICENSE.txt) for more informations.