using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ResourceController : ControllerBase
{
    private readonly ResourceService _resourceService;

    public ResourceController(ResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Resource>>> GetResources()
    {
        try
        {
            IList<Resource> resources = await _resourceService.GetAllResourcesAsync();
            return Ok(resources);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Resource>> GetResource([FromRoute] int id)
    {
        try
        {
            Resource resource = await _resourceService.GetResourceAsync(id);
            if (resource == null)
            {
                return StatusCode(500, "Couldn't find desired booking");
            }

            return Ok(resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Resource>> AddResource([FromBody] Resource resource)
    {
        try
        {
            Resource added = await _resourceService.AddResourceAsync(resource);
            return Created($"/{resource.ResourceId}", resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Resource>> UpdateResource([FromBody] Resource resource)
    {
        try
        {
            await _resourceService.UpdateResourceAsync(resource);
            return Ok(resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Resource>> DeleteResource([FromRoute] int id)
    {
        try
        {
            Resource deletedResource = await _resourceService.RemoveResourceAsync(id);
            if (deletedResource == null)
            {
                return StatusCode(500, "Couldn't find desired booking");
            }

            return Ok(deletedResource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}