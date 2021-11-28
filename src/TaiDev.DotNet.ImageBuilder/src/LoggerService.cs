﻿
using System.ComponentModel.Composition;

namespace TaiDev.DotNet.ImageBuilder;

[Export(typeof(ILoggerService))]
internal class LoggerService : ILoggerService
{
    public void WriteError(string error)
    {
        Logger.WriteError(error);
    }

    public void WriteHeading(string heading)
    {
        Logger.WriteHeading(heading);
    }

    public void WriteMessage()
    {
        Logger.WriteMessage();
    }

    public void WriteMessage(string message)
    {
        Logger.WriteMessage(message);
    }

    public void WriteSubheading(string subheading)
    {
        Logger.WriteSubheading(subheading);
    }
}
