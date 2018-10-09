using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using League;
using Xunit;

namespace Tests
{
    public class FileLoaderTests
    {
        [Fact]
        public void FileLoader_Load_ShouldReadFromFilesystem()
        {
            var fileName = "foo-bar.txt";
            var data = "foo bar";

            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {
                    fileName, new MockFileData(data)
                }
            });

            var loader = new FileLoader(fileSystem, fileName);

            Assert.Equal(data, loader.LoadData());
        }
    }
}
