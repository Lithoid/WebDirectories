using System.Linq.Expressions;
using WebDirectories.Entities;

namespace WebDirectories.Repository
{
    public interface IFolderRepository
    {
        Task<List<Folder>> GetAll(Expression<Func<Folder, bool>>? filter = null, string? includeProps = null);

        Task<Folder> Get(Expression<Func<Folder, bool>>? filter = null, bool tracked = true, string? includeProps = null);
        Task Create(Folder entity);
        Task CreateRange(IEnumerable<Folder> entities);
        Task Remove(Folder entity);
        Task RemoveAll();
        Task Save();
    }
}
