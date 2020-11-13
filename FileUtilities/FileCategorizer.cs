using System;
using System.Collections.Generic;
using System.Linq;

namespace FileUtilities
{
    public class FileCategorizer
    {
        public IReadOnlyList<FileCategory> Categorize(
            string[] fileNames, IFileCategorizationStrategy cStrategy)
        {
            var extensionlessNames = cStrategy.GetFullCategoryNames(fileNames);
            var fileCategoryQueues = GenerateCategoryQueues(extensionlessNames);
            List<FileCategory> mainCategories = fileCategoryQueues
                .Select(cq => cq.Value.Dequeue()).Distinct()
                .Select(c => new FileCategory(c)).ToList();

            List<FileCategory> currentNodes = new List<FileCategory>(mainCategories);
            List<FileCategory> nextNodes = new List<FileCategory>();
            while (true)
            {
                // filter empty queues and break if categorization is done
                fileCategoryQueues = fileCategoryQueues.Where(cq => cq.Value.Count > 0)
                    .ToDictionary(cq => cq.Key, cq => cq.Value);
                if (fileCategoryQueues.Count == 0) break;

                foreach (FileCategory node in currentNodes)
                {
                    var matchingQueues = GetMatchingQueues(fileCategoryQueues, node);
                    // errors unless subcategories is a list
                    List<string> subCategories = matchingQueues
                        .Select(q => q.Dequeue()).Distinct().ToList();
                    IEnumerable<FileCategory> childNodes = subCategories
                        .Select(c => new FileCategory(c));
                    foreach (FileCategory childCategory in childNodes)
                    {
                        node.AddSubCategory(childCategory);
                        nextNodes.Add(childCategory);
                    }
                }
                currentNodes = new List<FileCategory>(nextNodes);
                nextNodes.Clear();
            }
            return mainCategories;
        }

        internal Dictionary<string, Queue<string>> GenerateCategoryQueues(
            IEnumerable<string> fullCategoryNames)
        {
            return fullCategoryNames.Distinct().ToDictionary(
                f => f, f => new Queue<string>(f.Split('_')));
        }

        internal List<Queue<string>> GetMatchingQueues(
            Dictionary<string, Queue<string>> fileCategoryQueues, FileCategory category)
        {
            return fileCategoryQueues
                .Where(cq => cq.Key.StartsWith(category.FullCategory))
                .Select(cq => cq.Value).ToList();
        }
    }
}
