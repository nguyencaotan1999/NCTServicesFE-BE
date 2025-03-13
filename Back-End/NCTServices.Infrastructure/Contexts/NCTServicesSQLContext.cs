using Microsoft.EntityFrameworkCore;
using NCTServices.Contracts.Interfaces.Responsitories;
using System.Data;


namespace NCTServices.Infrastructure.Contexts
{
    public abstract class NCTServicesSQLContext : DbContext, IApplicationDbContext
    {
        public NCTServicesSQLContext(DbContextOptions options) : base(options)
        {

        }
        public IDbConnection Connection => Database.GetDbConnection();

        public virtual async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
