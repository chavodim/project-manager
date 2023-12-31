using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FolderManagerApp.Models
{
    public class FolderDao
    {
        [Key]
        public int FolderId { get; set; }

        public string FolderName { get; set; } = string.Empty;

        public List<CustomFileDao>? Files { get; set; }

        public string FolderPath { get; set; } = string.Empty;

        public int? ParentFolderId { get; set; }

        public FolderDao? ParentFolder { get; set; }

        public List<FolderDao>? ChildrenFolders { get; set; }

        public string FolderPathWithoutRoot()
        {
            int firstIndexOfSlash = FolderPath.IndexOf(@"\");

            if (firstIndexOfSlash == -1)
            {
                return "";
            }
            return FolderPath.Substring(firstIndexOfSlash);
        }


    }
}