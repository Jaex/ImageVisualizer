## What is Image Visualizer?

Image Visualizer allows you to preview image or bitmap variables while debugging in Visual Studio. You just need to hover any image or bitmap variable while debugging and press magnifier icon as shown below:

![](http://i.imgur.com/BlFYInS.png)

This will open Image Visualizer window which will allow you to preview image. In this window you can see image info, change zoom level, copy image to clipboard or save image as file.

![](http://i.imgur.com/2p5NIFg.png)

## How to install it?

### Requirements

* Visual Studio 2017
* .NET Framework 4.6.1

### Option 1: Download it

1. Download `ImageVisualizer.dll` from [here](https://github.com/Jaex/ImageVisualizer/releases/latest).

2. Check if Windows blocked downloaded dll file by going to Properties window of the file (Right click -> Properties) and if it's blocked unblock it using this check box:

 ![](http://i.imgur.com/TiPdU4G.png)

3. Copy `ImageVisualizer.dll` to `%USERPROFILE%\Documents\Visual Studio 2017\Visualizers` folder.

### Option 2: Compile it yourself

1. Open `ImageVisualizer.sln` with Visual Studio and compile it.

2. Post build event of Visual Studio will copy `ImageVisualizer.dll` file to `%USERPROFILE%\Documents\Visual Studio 2017\Visualizers` folder automatically.

## Credits

Icons: [Fugue Icons](http://p.yusukekamiyamane.com)