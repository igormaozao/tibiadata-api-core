using System;
using System.ComponentModel;
using System.Linq;

namespace TibiaDataApiCore.Extensions {
    public static class EnumExtensions {

        public static string GetDescription(this Enum value) {

            var customAttributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(true);

            var customAttributeData = customAttributes.FirstOrDefault(a => a.GetType() == typeof(DescriptionAttribute));

            // Null check just in case we forget to add the Description attribute in our enum
            // Or should we throw an exception if the attribute is not set?
            // We will see..
            if (customAttributeData is null) return "";
            else return (customAttributeData as DescriptionAttribute).Description;
        }
    }
}
