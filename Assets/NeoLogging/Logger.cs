using System;
using System.Text;
using UnityEngine;

namespace Neo.Logging{
  ///<summary>
  /// This is only a logger which bases on Unity's Debug.Log
  /// One might use another output in later versions.
  ///
  /// The logger supports four levels of logging:
  /// 1. Log (= Debug)
  /// 2. Warn
  /// 3. Error
  /// 4. Exception
  ///
  /// The level of logging can be configured setting Logger.LogLevel, but Exceptions
  /// will always be logged.
  ///
  /// Logging is done either via simple method call which sends some strings or via
  /// a callback which will only be invoked if the logging level is matched.
  /// Later is especially useful for logging information which serialization to string is
  /// slow and/or heavy in memory usage (e.g. JSON or ApiObject). So it should only be done
  /// if needed.
  ///
  /// Usage:
  ///
  ///  Logger logger = new Logger("MyClass");
  ///  logger.Log(() => "This will be 1 logged");
  /// </summary>
  public class Logger : ILogger {
    /// <summary>
    /// The global logging level for all instances of the logger.
    /// </summary>
    public Level LogLevel = Level.WARN;

    /// <summary>
    /// The current name of logger. Will be prefixed.
    /// </summary>
    public string Name{get; private set;}
    private readonly bool logging;

    /// <summary>
    /// Create a new instance and sets it's name
    /// </summary>
    /// <param name="name">of the logger, will be prefixed</param>
    public Logger(string name){
      this.Name = name;
      logging   = Application.isPlaying;
    }

    /// <summary>
    /// Logs the arguments
    /// </summary>
    /// <param name="what">to log</param>
    public void Log(params object[] what){
     Out(Level.LOG, what);
    }

    /// <summary>
    /// Logs the result of the lazy function
    /// </summary>
    /// <param name="lazy">to log</param>
    public void Log(Func<string> lazy){
      Out(Level.LOG, lazy);
    }

    /// <summary>
    /// Logs what as warning
    /// </summary>
    /// <param name="what">to log</param>
    public void Warn(params object[] what){
      Out(Level.WARN, what);
    }

    /// <summary>
    /// Logs the result of the lazy function as warning
    /// </summary>
    /// <param name="lazy">to log</param>
    public void Warn(Func<string> lazy){
      Out(Level.WARN, lazy);
    }

    /// <summary>
    /// Logs what as error
    /// </summary>
    /// <param name="what">to log</param>
    public void Error(params object[] what){
      Out(Level.ERROR, what);
    }

    /// <summary>
    /// Logs the result of the lazy function as error
    /// </summary>
    /// <param name="lazy">to log</param>
    public void Error(Func<string> lazy){
      Out(Level.ERROR, lazy);
    }

    /// <summary>
    /// Logs an exception. This stops the execution!
    /// </summary>
    /// <param name="e">to log</param>
    public void Exception(Exception e){
      Debug.LogException(e);
    }

    private void Out(Level level, params object[] what){
      if(logging && (level >= LogLevel)) {
        StringBuilder sb = new StringBuilder("[").Append(Name).Append("] ");
        what.ForEach((o) => {
          if(o != null) sb.Append(o.ToString()).Append(" ");
          else sb.Append("null ");
        });
        print(level, sb.ToString());
      }
    }

    private void Out(Level level, Func<string> what){
      if(logging && (level >= LogLevel)) {
        StringBuilder sb = new StringBuilder("[").Append(Name).Append("] ").Append(what());
        print(level, sb.ToString());
      }
    }

    private void print(Level level, string output){
      switch(level){
        case Level.WARN:
          Debug.LogWarning(output);
          break;
        case Level.ERROR:
          Debug.LogError(output);
          break;
        default:
          Debug.Log(output);
          break;
      }
    }
  }
}
