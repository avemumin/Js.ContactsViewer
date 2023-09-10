using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;

namespace Js.ContactsViewer.Client.Extensions;

public static class SessionStorageServiceExtension
{
    public static async Task SaveItemEncyptedAsync<T>(this ISessionStorageService sessionStorageService, string key, T item)
    {
        var itemJson = JsonSerializer.Serialize(item);

        var itemsJsontToBytes = Encoding.UTF8.GetBytes(itemJson);
        var base64Json = Convert.ToBase64String(itemsJsontToBytes);
        await sessionStorageService.SetItemAsync(key, base64Json);
    }

    public static async Task<T> ReadEncryptedItemAsync<T>(this ISessionStorageService sessionStorageService, string key)
    {
        var base64Json = await sessionStorageService.GetItemAsync<string>(key);
        var itemJsonBytes = Convert.FromBase64String(base64Json);
        var itemJson = Encoding.UTF8.GetString(itemJsonBytes);
        var item = JsonSerializer.Deserialize<T>(itemJson);

        return item;
    }
}
