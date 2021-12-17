using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System;
using Newtonsoft.Json;

namespace WEB_953501_KUZAUKOU.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session,
        string key, T item)

        {
            var serializedItem = JsonConvert.SerializeObject(item); //= JsonSerializer.Serialize(item);
            session.SetString(key, serializedItem);

        }
        public static T Get<T>(this ISession session, string key)
        {
            var item = session.GetString(key);
            return item == null
            ? Activator.CreateInstance<T>()
            : JsonConvert.DeserializeObject<T>(item);
        }
    }
}
