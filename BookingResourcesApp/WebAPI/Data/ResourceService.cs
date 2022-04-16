using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess;
using WebAPI.Model;

namespace WebAPI.Data;

public class ResourceService : IResourceService
{
    private readonly BookingDBContext _bookingDbContext;

    public ResourceService()
    {
        _bookingDbContext = new BookingDBContext();
    }
    
    public async Task<IList<Resource>> GetAllResourcesAsync()
    {
        return await _bookingDbContext.Resources.ToListAsync();
    }

    public async Task<Resource?> GetResourceAsync(int resourceId)
    {
        return await _bookingDbContext.Resources.FirstOrDefaultAsync(r => r.ResourceId == resourceId);
    }

    public async Task<Resource> AddResourceAsync(Resource resource)
    {
        await _bookingDbContext.Resources.AddAsync(resource);
        await _bookingDbContext.SaveChangesAsync();

        return resource;
    }

    public async Task<Resource?> RemoveResourceAsync(int resourceId)
    {
        Resource removedResource = _bookingDbContext.Resources.First(r => r.ResourceId == resourceId);
        _bookingDbContext.Resources.Remove(removedResource);
        await _bookingDbContext.SaveChangesAsync();

        return removedResource;
    }

    public async Task UpdateResourceAsync(Resource resource)
    {
        _bookingDbContext.Resources.Update(resource);
        await _bookingDbContext.SaveChangesAsync();
    }
}