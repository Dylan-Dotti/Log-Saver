using System;
using System.Collections.Generic;
using System.Linq;

namespace LogSaverServer
{
    public class FileCategoryTree
    {
        public FileCategoryTree(string[] fileNames)
        {
            var extensionlessNames = fileNames.Select(f => f.Split('.').First());
            var fileCategoryQueues = extensionlessNames.ToDictionary(
                f => f, f => new Queue<string>(f.Split('_')));
        }

        private class CategoryTreeNode
        {
            private CategoryTreeNode parentNode;
            private List<CategoryTreeNode> childNodes;

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
        }
    }
}
