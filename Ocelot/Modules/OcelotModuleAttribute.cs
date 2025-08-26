using System;

namespace Ocelot.Modules;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class OcelotModuleAttribute(int configOrder = int.MaxValue, int mainOrder = int.MaxValue, string group = "default") : Attribute
{
    public int ConfigOrder { get; init; } = configOrder;

    public int MainOrder { get; init; } = mainOrder;

    public string ConfigGroup { get; init; } = group;
}
