using System;

namespace GeneratorTools;

/// <summary>
///     Attribute to signify to documentation generator to not item include in output.
/// </summary>
[OmitFromDocumentation]
[AttributeUsage(AttributeTargets.All)]
public sealed class OmitFromDocumentationAttribute : Attribute
{
}
