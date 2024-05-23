using Assesment.Models;
using Assesment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Controllers;

[Produces("application/json")]
[Route("[controller]")]
[ApiController]
public class AvatarController : ControllerBase
{
    public IAvatarData _avatarData { get; }

    public AvatarController(IAvatarData avatarData)
    {
        _avatarData = avatarData;
    }

    // GET /<AvatarController>/abcd555
    [HttpGet("{userIdentifier}")]
    public JsonResult Get(string? userIdentifier)
    {
        AvatarInfo avatarInfo = _avatarData.GetAvatarInfo(userIdentifier);

        return new JsonResult(avatarInfo);
    }
}
