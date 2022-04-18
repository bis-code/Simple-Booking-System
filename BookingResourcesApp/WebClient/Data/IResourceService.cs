using WebClient.Model;

namespace WebClient.Data;

public interface IResourceService
{
    Task<IList<Resource>> GetAllResourcesAsync();
    Task<Resource> GetResourceAsync(int resourceId);
    Task<bool> AddResourceAsync(Resource resource);
    Task<bool> RemoveResourceAsync(int resourceId);
    Task<bool> UpdateResourceAsync(Resource resource);
}