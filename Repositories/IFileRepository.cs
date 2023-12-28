using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<CustomFileDao> Files { get; }
        void SaveFile(CustomFileDao customFile);
        CustomFileDao? GetFileById(int fileId);
        void DeleteFile(int fileId);
    }
}