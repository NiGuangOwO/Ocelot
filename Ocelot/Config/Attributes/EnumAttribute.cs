using System;
using System.Reflection;
using Ocelot.Config.Handlers;
using Ocelot.Modules;

namespace Ocelot.Config.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class EnumAttribute : ConfigAttribute
{
    private Type type { get; }

    private readonly string provider;

    public EnumAttribute(Type type, string provider)
    {
        if (!type.IsEnum)
            throw new ArgumentException($"Type '{type.FullName}' must be an enum.", nameof(type));

        this.type = type;
        this.provider = provider;
    }

    public override Handler GetHandler(ModuleConfig self, ConfigAttribute attr, PropertyInfo prop) =>
        (Handler)Activator.CreateInstance(typeof(EnumHandler<>).MakeGenericType(type), self, attr, prop, provider)!;
}
