using Assesment.Models;

namespace Assesment.Data;

public interface IAvatarImageRepository
{
    AvatarImage GetById(int imageId);
}
