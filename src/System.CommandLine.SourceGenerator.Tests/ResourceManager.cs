using System.Collections.Generic;
using System.IO;

namespace System.CommandLine.SourceGenerator.Tests;

internal static class ResourceManager
{
    public static IEnumerable<string> GetResourceNames()
    {
        return typeof(ResourceManager).Assembly.GetManifestResourceNames();
    }

    public static string GetString(string resource)
    {
        using var stream = typeof(ResourceManager).Assembly.GetManifestResourceStream(resource);
        using var streamReader = new StreamReader(stream!);
        return streamReader.ReadToEnd();
    }
}
