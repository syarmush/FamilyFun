using System;

namespace FamilyFun.Web.Models
{
    public interface IPrizeImageDirectoryPathRetriever
    {
        string RetrieveImageDirectoryPath();
    }

    public class StaticPrizeImageDirectoryPathRetriever : IPrizeImageDirectoryPathRetriever
    {
        private readonly string _directoryPath;

        public StaticPrizeImageDirectoryPathRetriever(string directoryPath)
        {
            _directoryPath = directoryPath ?? throw new ArgumentNullException(nameof(directoryPath));
        }

        public string RetrieveImageDirectoryPath()
        {
            return _directoryPath;
        }
    }
}