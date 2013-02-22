# Sitecore Item Versioner
The Sitecore Item Versioner module adds a new ribbon into the versions chunk of the Content Editor. With the new ribbon it is possible to initially create an item version in all configured languages. 

## Download
The module is currently only available at GitHub, because there is no final release available yet.

## Installation
You can clone the GitHub repository and build the source code. You need to copy the Sitecore.Kernel.dll into the lib directory, otherwise you won't be able to build because of missing references.

There are some MSBuild targets which copies all needed files into a directory defined in the build/deploy.txt file. Just copy all this files into your Sitecore installation directory. You also need to copy the serialization folder into your data folder and update the Core database.

## Version
The Item Versioner has been developed with Visual Studio 2012 and Sitecore 6.6. You should be able to work with lower versions as well.

## License
The Sitecore Item Versioner is licensed under the LGPL. Please see [LICENSE.txt] (https://github.com/unic/SitecoreErrorManager/blob/master/LICENSE.txt) for more informations.