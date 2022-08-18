using System.IO;

namespace PL.Helper
{
    internal class fileStream
    {
        private string filePath;
        private FileMode create;

        public fileStream(string filePath, FileMode create)
        {
            this.filePath = filePath;
            this.create = create;
        }
    }
}