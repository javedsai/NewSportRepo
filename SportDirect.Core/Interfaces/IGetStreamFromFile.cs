using System;
using System.IO;

namespace SportDirect.Core.Interfaces
{
    public interface IGetStreamFromFile
    {
        Stream LoadFromFile(string filename);
        byte[] LoadBytesFromFile(string filePath);
    }
}
