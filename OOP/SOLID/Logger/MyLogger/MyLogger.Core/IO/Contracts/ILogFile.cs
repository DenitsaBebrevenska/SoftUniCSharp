namespace MyLogger.Core.IO.Contracts
{
    public interface ILogFile
    {
        string Name { get; }
        string Extension { get; }
        string Path { get; }
        string FullPath { get; }
        int Size { get; }
    }
}
