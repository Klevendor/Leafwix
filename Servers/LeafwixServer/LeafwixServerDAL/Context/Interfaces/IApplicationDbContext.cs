using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Entities.Security;

namespace LeafwixServerDAL.Context.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<RefreshToken> RefreshTokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
