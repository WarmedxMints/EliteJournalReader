﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
/* Unmerged change from project 'EliteJournalReader (netstandard2.1)'
Before:
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
After:
using System.Text;
using System.Threading.Tasks;
*/

/* Unmerged change from project 'EliteJournalReader (net47)'
Before:
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
After:
using System.Text;
using System.Threading.Tasks;
*/

/* Unmerged change from project 'EliteJournalReader (netstandard2.0)'
Before:
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
After:
using System.Text;
using System.Threading.Tasks;
*/

/* Unmerged change from project 'EliteJournalReader (net46)'
Before:
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
After:
using System.Text;
using System.Threading.Tasks;
*/

/* Unmerged change from project 'EliteJournalReader (net472)'
Before:
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
After:
using System.Text;
using System.Threading.Tasks;
*/

/* Unmerged change from project 'EliteJournalReader (net48)'
Before:
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
After:
using System.Text;
using System.Threading.Tasks;
*/

/* Unmerged change from project 'EliteJournalReader (net50)'
Before:
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
After:
using System.Text;
using System.Threading.Tasks;
*/


namespace EliteJournalReader
{
    public static class EnumHelpers
    {
        private static readonly Dictionary<Type, Dictionary<string, object>> enumDescriptionCache = new();

        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (value == null)
                return defaultValue;

            var type = typeof(T);
            if (!enumDescriptionCache.TryGetValue(type, out var cache))
            {
                cache = new Dictionary<string, object>();
                var attrs = type.GetFields().SelectMany(f => f.GetCustomAttributes<DescriptionAttribute>().Select(d => new { field = f, desc = d }));
                foreach (var attr in attrs)
                {
                    cache[attr.desc.Description] = attr.field.GetValue(null);
                }
                enumDescriptionCache[type] = cache;
            }

            // check if it's in the cache
            if (cache.TryGetValue(value, out object resultFromCache) && resultFromCache is T resultTyped)
            {
                return resultTyped;
            }

            // so it's not in the cache, maybe we can parse it the usual way?
            if (Enum.TryParse(value, true, out T resultDirect))
            {
                cache[value] = resultDirect; // store for next time!
                return resultDirect;
            }

            // if this all fails, try it again, but now case insensitive
            var e = typeof(T)
                .GetFields()
                .FirstOrDefault(f => f.GetCustomAttributes<DescriptionAttribute>()
                             .Any(a => a.Description.Equals(value, StringComparison.OrdinalIgnoreCase))
                ) ?? typeof(T)
                    .GetFields()
                    .FirstOrDefault(f => f.Name.Equals(value, StringComparison.OrdinalIgnoreCase));
            if (e != null)
            {
                var resultInsensitive = (T)e.GetValue(null);
                cache[value] = resultInsensitive; // remember for next time
                return resultInsensitive;
            }

            // we've tried everything, return the default value, but remember this for next time
            cache[value] = defaultValue;
            return defaultValue;
        }

        public static string StringValue(this Enum enumItem)
        {
            if (enumItem == null)
                return string.Empty;
            return enumItem
            .GetType()
            .GetField(enumItem.ToString())
            .GetCustomAttributes<DescriptionAttribute>()
            .Select(a => a.Description)
            .FirstOrDefault() ?? enumItem.ToString();
        }
    }


    public class ExtendedStringEnumConverter<T> : StringEnumConverter where T : struct
    {
        private readonly T defaultValue;

        public ExtendedStringEnumConverter()
        {
            defaultValue = default;
        }

        public ExtendedStringEnumConverter(T defaultValue)
        {
            this.defaultValue = defaultValue;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
                return defaultValue;

            if (reader.TokenType == JsonToken.String)
            {
                string enumText = reader.Value.ToString();
                return enumText.ToEnum(defaultValue);
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
