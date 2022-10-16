using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using WebDirectories.Entities;
using WebDirectories.Data;

namespace WebDirectories.Repository
{
    public class FolderRepository : IFolderRepository
    {
        private readonly AppDataContext _db;
        internal DbSet<Folder> DbSet;

        public FolderRepository(AppDataContext db)
        {
            _db = db;
            DbSet = _db.Set<Folder>();
        }
        public async Task Create(Folder entity)
        {
            await DbSet.AddAsync(entity);
            await Save();
        }
        public async Task CreateRange(IEnumerable<Folder> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await Save();
        }

        public async Task<Folder> Get(Expression<Func<Folder, bool>>? filter = null, bool tracked = true, string includeProps = null)
        {
            IQueryable<Folder> query = DbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProps != null)
            {
                foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Folder>> GetAll(Expression<Func<Folder, bool>> filter = null, string includeProps = null)
        {
            IQueryable<Folder> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProps != null)
            {
                foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task Remove(Folder entity)
        {
            DbSet.Remove(entity);
            await Save();
        }
        public async Task RemoveAll()
        {
            DbSet.RemoveRange(DbSet);
            await Save();
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
