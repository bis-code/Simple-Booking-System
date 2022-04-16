using WebAPI.Model;

namespace WebAPI.Data;

public interface IResourceService
{
    Task<IList<Resource>> GetAllResourcesAsync();
    Task<Resource?> GetResourceAsync(int resourceId);
    Task<Resource> AddResourceAsync(Resource resource);
    Task<Resource?> RemoveResourceAsync(int resourceId);
    Task UpdateResourceAsync(Resource resource);
}