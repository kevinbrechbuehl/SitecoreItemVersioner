# Sitecore Item Versioner
The Sitecore Item Versioner module adds a new ribbon into the versions chunk of the Content Editor. With the new ribbon it is possible to initially create an item version in all configured languages (under _/sitecore/system/Languages_). It will only create a new version if there is not already a version in the specific language.

The module is perfect for administrators i.e. to create standard values in each language or to add language versions for dictionary items. But it can also be used as a content author to create a skeleton of a content item in each language.

## Download
You can either clone the repository from GitHub or download the Sitecore package from the [Sitecore Marketplace] (http://marketplace.sitecore.net/en/Modules/Sitecore_Item_Versioner.aspx).

## Installation
You can clone the GitHub repository and build the source code. You need to copy the _Sitecore.Kernel.dll_ into the _lib_ directory, otherwise you won't be able to build because of missing references. There are some MSBuild targets which copies all needed files into a directory defined in the _build/deploy.txt_ file. Just copy all this files into your Sitecore installation directory. You also need to copy the _data/serialization_ folder into your data folder and update the Core database.

Alternatively you can also download the Sitecore package from the [Sitecore Marketplace] (http://marketplace.sitecore.net/en/Modules/Sitecore_Item_Versioner.aspx) and install it with the _Installation Wizard_.

## Version
The Item Versioner has been developed with Visual Studio 2012 and Sitecore 6.6. You should be able to work with lower versions as well.

## License
The Sitecore Item Versioner is licensed under the LGPL. Please see [LICENSE.txt] (https://github.com/aquasonic/SitecoreItemVersioner/blob/master/LICENSE.txt) for more informations.