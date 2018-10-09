using System;
using System.IO;
using System.IO.Abstractions;

namespace League
{
    public interface IDataLoader
    {
        string LoadData();
    }

    public class FileLoader : IDataLoader
    {
        readonly IFileSystem _fileSystem;

        private readonly string _fileName;

        public FileLoader(IFileSystem fileSystem, string fileName)
        {
            _fileSystem = fileSystem;
            _fileName = fileName;
        }

        public FileLoader(string fileName) : this(fileSystem: new FileSystem(), fileName: fileName)
        {
        }

        public string LoadData()
        {
            return _fileSystem.File.ReadAllText(_fileName);
        }
    }

}
