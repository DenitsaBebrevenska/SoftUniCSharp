using MyLogger.Core.Exceptions;
using MyLogger.Core.IO.Contracts;

namespace MyLogger.Core.IO
{
    public class LogFile : ILogFile
    {
        private const string DefaultExtenstion = "txt";
        private static readonly string DefaultName = $"Log_{DateTime.Now:yyyy-MM-dd-hh-mm-ss}";
        private static readonly string DefaultPath = $"{Directory.GetCurrentDirectory()}";
        private string name;
        private string extension;
        private string path;

        public LogFile()
        {
            Name = DefaultName;
            Extension = DefaultExtenstion;
            Path = DefaultPath;
        }

        public LogFile(string extension) : this()
        {
            Extension = extension;
        }
        public LogFile(string name, string extension, string path) : this()
        {
            Name = name;
            Extension = extension;
            Path = path;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileDetailException();
                }
                name = value;
            }
        }

        public string Extension
        {
            get => extension;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileDetailException();
                }
                extension = value;
            }
        }

        public string Path
        {
            get => path;
            private set
            {
                if (!Directory.Exists(value))
                {
                    throw new InvalidPathException();
                }
                path = value;
            }
        }
        public string FullPath => System.IO.Path.GetFullPath($"{Path}/{Name}.{Extension}");
        public int Size => File.ReadAllText(FullPath).ToCharArray().Where(char.IsAsciiLetter).Sum(c => c);
    }
}
