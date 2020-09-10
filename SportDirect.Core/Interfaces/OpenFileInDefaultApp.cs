using System;
namespace SportDirect.Core.Interfaces
{
    public interface OpenFileInDefaultApp
    {
        void OpenFileByName(string FileName, string FileType);
        void OpenFileByPath(string FileName, string FilePath, string FileType);
    }
}
