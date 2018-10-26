# NeoLogging: A simple wrapper for logging in `Unity3D`

NeoLogging is a very simple library for logging using the build-in UnityEngine.Debug class, but allowing a very simple control of logging levels.

## Installation

If you don't have access to [Microsoft VisualStudio](http://msdn.microsoft.com/de-de/vstudio) you can just use Unity3D and its compiler.
Or use your VisualStudio installation in combination with [Visual Studio Tools for Unity](http://unityvs.com) to compile a DLL-file, which
can be included into your project.

### Using Unity3D

* Clone the repository
* Copy the files from `Assets\NeoLogging` into your project

### Using VisualStudio

* Clone the repository
* Open the folder as a Unity3D project
* Install the *free* [Visual Studio Tools for Unity](http://unityvs.com) and import its Unity-package
* Open `UnityVS.NeoLogging.sln`
* [Build a DLL-File](http://forum.unity3d.com/threads/video-tutorial-how-to-use-visual-studio-for-all-your-unity-development.120327)
* Import the DLL and dependencies into your Unity3D project

## Dependencies

None

## Usage

Set the logging level for all instances of a logger:

```csharp
Neo.Logging.Logger.LogLevel = Neo.Logging.Level.WARN;

```

Using instances of the `Logger` class you can log by sending parameters or a callback which will *only* be called if the logging level matches:

```csharp
using Neo.Logging;

var logger = new Logger("MyClass");

logger.Log("This will be logged:", 12f); // => [MyClass] This will be logged: 12.0

logger.Warn(() => "This will only be called if needed"); // => This will only be called if needed
```
