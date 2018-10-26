# NeoLogging: A simple wrapper for logging in `Unity3D`

NeoLogging is a very simple library for logging using the build-in UnityEngine.Debug class, but allowing a very simple control of logging levels.

## Installation

You can either use to copy the source files of this project into your Unity3D project or use Visual Studio to compile a DLL-file to be included in your project.

### Using Unity3D

* Clone the repository
* Copy the files from `Assets\NeoCollections` into your project
  * This folder also includes an Assembly definition file

### Using VisualStudio

* Clone the repository
* Open the folder as a Unity3D project
* Build the solution using "Build -> Build NeoLogging"
* Import the DLL (`obj/Release/NeoLogging.dll`) into your Unity3D project

Hint: Unity currently always reset the LangVersion to "7.3" which isn't supported by Visual Studio. Therefor you need to manually
set / revert the `LangVersion` to `6` in `NeoLogging.csproj`:

    <LangVersion>6</LangVersion>

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
