using System.Collections.Generic;

namespace FileUtilities
{
    public interface IFileCategorizationStrategy
    {
        IEnumerable<string> GetFullCategoryNames(IEnumerable<string> fileNames);
    }
}
