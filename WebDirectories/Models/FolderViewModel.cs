using System.ComponentModel.DataAnnotations.Schema;
using WebDirectories.Entities;
using WebDirectories.Repository;

namespace WebDirectories.Models
{
    public class FolderViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        public FolderViewModel()
        {

        }

        public static implicit operator Folder(FolderViewModel model)
        {
            return new Folder
            {
                Id = model.Id,
                FullName = model.FullName,
                ParentId = model.ParentId,
                Name = model.Name,


            };
        }
        public FolderViewModel(Folder folder)
        {
            Id = folder.Id;
            FullName = folder.FullName;
            ParentId = folder.ParentId;
            Name = folder.Name;
        }



        public static FolderViewModel GetNode(IFolderRepository repository, Guid? id = null)
        {
            if (id.HasValue)
            {
                var topNode = repository.Get(f => f.Id == id.Value, includeProps: "Parent").Result;
                if (topNode == null)
                {
                    return null;
                }
                var model = new FolderViewModel(topNode);
                return model;
            }
            else
            {
                var topNode = repository.Get(f => f.ParentId == null, includeProps: "Parent").Result;
                if (topNode == null)
                {
                    return null;
                }
                var model = new FolderViewModel(topNode);
                return model;
            }



        }

        public static IEnumerable<FolderViewModel> GetChildren(Guid parentId, IFolderRepository repository)
        {

            var children = repository.GetAll(f => f.ParentId == parentId, includeProps: "Parent").Result;
            var models = children.Select(f => new FolderViewModel(f));

            return models;
        }
        public static IEnumerable<FolderViewModel> GetAll(IFolderRepository repository)
        {

            var children = repository.GetAll(includeProps: "Parent").Result;
            var models = children.Select(f => new FolderViewModel(f));

            return models;
        }
    }
}
