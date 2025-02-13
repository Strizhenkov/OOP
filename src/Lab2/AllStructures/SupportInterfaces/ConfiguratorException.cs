using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public class ConfiguratorException : Exception
{
    public ConfiguratorException() { }

    public ConfiguratorException(string message)
        : base(message) { }

    public ConfiguratorException(string message, Exception innerException)
        : base(message, innerException) { }
}