using Assesment.Models;

namespace Assesment.Data;

public class AvatarImageRepository : IAvatarImageRepository
{
    private readonly AvatarDatabaseContext _context;

    public AvatarImageRepository(AvatarDatabaseContext context)
    {
        _context = context;
    }

    public AvatarImage GetById(int imageId)
    {
        return _context.AvatarInfo.Find(imageId);
    }
}
