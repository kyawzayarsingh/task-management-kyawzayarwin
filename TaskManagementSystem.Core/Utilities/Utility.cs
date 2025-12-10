using System.ComponentModel;
using System.Reflection;

namespace TaskManagementSystem.Core.Utilities
{
    public static class Utility
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

                if (attribute != null)
                    return attribute.Description;
            }

            // Return the enum name if no description is found
            return value.ToString();
        }

        public static T? GetEnumValueFromDescription<T>(string description) where T : struct, Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attr = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attr != null && attr.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                    return (T)field.GetValue(null)!;

                if (field.Name.Equals(description, StringComparison.OrdinalIgnoreCase))
                    return (T)field.GetValue(null)!;
            }

            return null;
        }
    }
}
