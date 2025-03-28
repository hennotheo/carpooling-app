using System.Reflection;

namespace CarPoolingAPICore.Extensions;

public static class ReflectionExtension
{
    public static bool PropertyEquals<T, TId>(this PropertyInfo prop, T entity, TId id)
    {
        return prop.GetValue(entity)!.Equals(id);
    }
}