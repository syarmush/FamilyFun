using System;

namespace FamilyFun.Web.Models
{
    public interface IMitzvahImageDirectoryPathRetriever
    {
        string RetrieveImageDirectoryPath();
    }

    public class StaticMitzvahImageDirectoryPathRetriever : IMitzvahImageDirectoryPathRetriever
    {
        private readonly string _directoryPath;

        public StaticMitzvahImageDirectoryPathRetriever(string directoryPath)
        {
            _directoryPath = directoryPath ?? throw new ArgumentNullException(nameof(directoryPath));
        }

        public string RetrieveImageDirectoryPath()
        {
            return _directoryPath;
        }
    }
}