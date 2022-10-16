using WebDirectories.Models;

namespace WebDirectories.Additionals
{
    public static class Manager
    {
        public static List<FolderViewModel> Folders { get; set; }= new List<FolderViewModel>();
        public static void WalkDirectoryTree(DirectoryInfo root,Guid? rootId = null)
        {
            DirectoryInfo[] subDirs = null;


            FolderViewModel folder = new FolderViewModel();
            folder.Id = Guid.NewGuid();
            folder.FullName = root.FullName;
            folder.Name = root.Name;
            if (rootId.HasValue)
            {
                folder.ParentId = rootId.Value;
            }
            Folders.Add(folder);


            subDirs = root.GetDirectories();

            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo,folder.Id);
            }
        }
    }
}
