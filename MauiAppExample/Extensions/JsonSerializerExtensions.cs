using System;
using System.Text.Json;
using MauiAppExample.Data;

namespace MauiAppExample.Extensions
{
    public static class JsonSerializerExtensions
    {
        private static JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        /// <summary>
        /// Serializes object to json
        /// </summary>
        /// <param name="entry">The object to be serialized</param>
        /// <returns>The resulting json as string</returns>
        /// <exception cref="SerializerException"></exception>

        public static string ToJson(this object entry)
        {
            try
            {
                return JsonSerializer.Serialize(entry, _options);
            }
            catch (Exception ex)
            {
                throw new SerializerException(ex.Message, ex);
		    }
		}

        /// <summary>
        /// Deserializes a JSON string to an instance of the given typeparam
        /// </summary>
        /// <typeparam name="T">The output type</typeparam>
        /// <param name="entry">The string to be deserialized</param>
        /// <returns>An instance of the given typeparam</returns>
        /// <exception cref="SerializerException"></exception>

        public static T FromJson<T>(this string entry)
        {
            try 
		    { 
			    return JsonSerializer.Deserialize<T>(entry, _options);
		    }
            catch (Exception ex)
            {
                throw new SerializerException(ex.Message, ex);
		    }
		}
    }
}

