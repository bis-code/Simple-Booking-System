using System.Net;
using System.Text;
using System.Text.Json;
using WebClient.Model;

namespace WebClient.Data;

public class ResourceService : IResourceService
{
    private string uri = "https://localhost:7263";
    private readonly HttpClient client;

    public ResourceService()
    {
        client = new HttpClient();
    }
    
    public async Task<IList<Resource>> GetAllResourcesAsync()
    {
        Task<string> stringAsync = client.GetStringAsync($"{uri}/Resource");
        string message = await stringAsync;
        List<Resource> resources = JsonSerializer.Deserialize<List<Resource>>(message);
        return resources;
    }

    public async Task<Resource?> GetResourceAsync(int resourceId)
    {
        Task<string> stringAsync = client.GetStringAsync($"{uri}/Resource/{resourceId}");
        string message = await stringAsync;
        Resource resource = JsonSerializer.Deserialize<Resource>(message);
        return resource;
    }

    public async Task<bool> AddResourceAsync(Resource resource)
    {
        string resourceAsJson = JsonSerializer.Serialize(resource);
        HttpContent content = new StringContent(resourceAsJson,
            Encoding.UTF8,
            "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Resource", content);
        return responseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveResourceAsync(int resourceId)
    {
        HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/Resource/{resourceId}");
        return responseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateResourceAsync(Resource resource)
    {
        string resourceAsJson = JsonSerializer.Serialize(resource);
        HttpContent content = new StringContent(resourceAsJson,
            Encoding.UTF8,
            "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync($"{uri}/Resource/{resource.ResourceId}", content);
        return responseMessage.IsSuccessStatusCode;
    }
}