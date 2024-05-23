using Assesment.Models;

namespace Assesment.Services;

public interface IAvatarData
{
    public AvatarInfo GetAvatarInfo(string identifier);
}
