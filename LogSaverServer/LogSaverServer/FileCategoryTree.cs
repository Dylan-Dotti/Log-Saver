using System;
using System.Collections.Generic;
using System.Linq;

namespace LogSaverServer
{
    public class FileCategoryTree
    {
        private List<CategoryTreeNode> mainCategories;

        public IReadOnlyList<string> MainCategories => 
            mainCategories.Select(c => c.Category).ToList();

        public FileCategoryTree(string[] fileNames)
        {
            Categorize(fileNames);
        }

        private void Categorize(string[] fileNames)
        {
            var extensionlessNames = fileNames.Select(f => f.Split('.').First());
            var fileCategoryQueues = extensionlessNames.Distinct().ToDictionary(
                f => f, f => new Queue<string>(f.Split('_')));
            mainCategories = fileCategoryQueues
                .Select(cq => cq.Value.Dequeue()).Distinct()
                .Select(c => new CategoryTreeNode(c)).ToList();
            mainCategories.ForEach(c => FileLogger.Log("Main category: " + c.Category));

            List<CategoryTreeNode> currentNodes = new List<CategoryTreeNode>(mainCategories);
            List<CategoryTreeNode> nextNodes = new List<CategoryTreeNode>();
            for (int i = 0; i < 100000; i++)
            {
                // filter empty queues and break if categorization is done
                fileCategoryQueues = fileCategoryQueues.Where(cq => cq.Value.Count > 0)
                    .ToDictionary(cq => cq.Key, cq => cq.Value);
                if (fileCategoryQueues.Count == 0) break;

                foreach (CategoryTreeNode node in currentNodes)
                {
                    string fullCategory = node.FullCategory;
                    FileLogger.Log("Full category: " + fullCategory);
                    var matchingQueues = fileCategoryQueues
                        .Where(cq => cq.Key.StartsWith(fullCategory))
                        .Select(cq => cq.Value);
                    var subCategories = matchingQueues.Select(q => q.Dequeue()).Distinct();
                    IEnumerable<CategoryTreeNode> childNodes = subCategories
                        .Select(c => new CategoryTreeNode(c, node));
                    node.AddChildren(childNodes);
                    foreach (var n in childNodes) FileLogger.Log("Adding child node: " + n.Category);
                    nextNodes.AddRange(childNodes);
                }
                currentNodes = nextNodes;
                nextNodes.Clear();
            }
        }

        private class CategoryTreeNode
        {
            private readonly CategoryTreeNode parentNode;
            private readonly List<CategoryTreeNode> childNodes;

            public string Category { get; private set; }
            public string FullCategory => parentNode == null ?
                Category : parentNode.FullCategory + '_' + Category;
            public IReadOnlyList<CategoryTreeNode> ChildNodes => childNodes;

            public bool IsLeafNode => childNodes.Count == 0;

            public CategoryTreeNode(string category) : this(category, null)
            { }

            public CategoryTreeNode(string category, CategoryTreeNode parentNode)
            {
                this.parentNode = parentNode;
                childNodes = new List<CategoryTreeNode>();
                Category = category;
            }

            public void AddChild(CategoryTreeNode node)
            {
                childNodes.Add(node);
            }

            public void AddChildren(IEnumerable<CategoryTreeNode> nodes)
            {
                foreach (CategoryTreeNode node in nodes)
                {
                    AddChild(node);
                }
            }
        }
    }
}
