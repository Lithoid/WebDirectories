namespace WebDirectories.Models
{
    public class DisplayViewModel
    {
        public string CurrentFolder { get; set; }
        public IEnumerable<FolderViewModel> Folders { get; set; } = new List<FolderViewModel>();
    }
}
