using System;
using System.IO;
using System.Threading.Tasks;

namespace SportDirect.Core.Interfaces
{
    public interface ILocalFileProvider 
    {
        Task<string> SaveFileToDisk(Stream stream, string fileName);
    }
}
