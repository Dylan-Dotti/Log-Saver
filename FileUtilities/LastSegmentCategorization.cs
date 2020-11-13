using System.Collections.Generic;
using System.Linq;

namespace FileUtilities
{
    public class LastSegmentCategorization : IFileCategorizationStrategy
    {
        public IEnumerable<string> GetFullCategoryNames(IEnumerable<string> fileNames)
        {
            return fileNames.Select(f => f.Split('.').Last());
        }
    }
}
