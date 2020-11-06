using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FileUtilities;

namespace LogSaverClient.GUI
{
    public partial class CategorySelectionDisplay : UserControl
    {
        public IReadOnlyList<FileCategory> Categories
        {
            set
            {
                OnCategoriesChanged(value);
            }
        }

        public CategorySelectionDisplay()
        {
            InitializeComponent();
        }

        private void OnCategoriesChanged(IEnumerable<FileCategory> categories)
        {
            foreach (FileCategory category in categories)
            {
                TreeNode node = categoriesTreeView.Nodes.Add(category.Category);
                AddSubCategoriesRecursive(node, category);
            }
        }

        private void AddSubCategoriesRecursive(TreeNode node, FileCategory category)
        {
            if (!category.HasSubcategories) return;
            foreach (FileCategory subCategory in category.SubCategories)
            {
                TreeNode childNode = node.Nodes.Add(subCategory.Category);
                AddSubCategoriesRecursive(childNode, subCategory);
            }
        }
    }
}
