using System;

namespace Neo.Logging{
  /// <summary>
  /// Interface for our logging class.
  /// </summary>
  public interface ILogger{
    /// <summary>
    /// Logs the arguments as debug information
    /// </summary>
    /// <param name="what">to log</param>
    void Log(params object[] what);
    /// <summary>
    /// Logs the result of the lazy function as debug information
    /// </summary>
    /// <param name="lazy">to log</param>
    void Log(Func<string> lazy);
    /// <summary>
    /// Logs the arguments as a warning
    /// </summary>
    /// <param name="what">to log</param>
    void Warn(params object[] what);
    /// <summary>
    /// Logs the result of the lazy function as warning
    /// </summary>
    /// <param name="lazy">to log</param>
    void Warn(Func<string> lazy);
    /// <summary>
    /// Logs the arguments as an error
    /// </summary>
    /// <param name="what">to log</param>
    void Error(params object[] what);
    /// <summary>
    /// Logs the result of the lazy function as error
    /// </summary>
    /// <param name="lazy">to log</param>
    void Error(Func<string> lazy);
    /// <summary>
    /// Logs an exception. This stops the execution!
    /// </summary>
    /// <param name="e">to log</param>
    void Exception(Exception e);
  }
}
