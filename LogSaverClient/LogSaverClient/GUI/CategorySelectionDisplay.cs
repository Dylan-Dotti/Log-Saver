using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FileUtilities;

namespace LogSaverClient.GUI
{
    public partial class CategorySelectionDisplay : UserControl
    {
        private IReadOnlyList<FileCategory> categories;

        public string[] FullCategories => GetFullCategories();

        public IReadOnlyList<FileCategory> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnCategoriesChanged();
            }
        }

        public CategorySelectionDisplay()
        {
            InitializeComponent();
        }

        private void OnCategoriesChanged()
        {
            foreach (FileCategory category in categories)
            {
                TreeNode node = categoriesTreeView.Nodes.Add(category.Category);
                node.Checked = true;
                AddSubCategoriesRecursive(node, category);
            }
        }

        private void AddSubCategoriesRecursive(TreeNode node, FileCategory category)
        {
            if (!category.HasSubcategories) return;
            foreach (FileCategory subCategory in category.SubCategories)
            {
                TreeNode childNode = node.Nodes.Add(subCategory.Category);
                childNode.Checked = true;
                AddSubCategoriesRecursive(childNode, subCategory);
            }
        }

        private string[] GetFullCategories()
        {
            List<string> fullCategories = new List<string>();
            foreach (TreeNode node in categoriesTreeView.Nodes)
            {
                fullCategories.AddRange(GetFullCategoriesRecursive(node, ""));
            }
            return fullCategories.ToArray();
        }

        private List<string> GetFullCategoriesRecursive(TreeNode node, string runningCategory)
        {
            List<string> fullCategories = new List<string>();
            runningCategory += (runningCategory.Length == 0 ? "" : "_") + node.Text;
            if (node.Nodes.Count == 0)
            {
                // leaf node, category is complete
                if (allCategoriesRadio.Checked || node.Checked)
                {
                    fullCategories.Add(runningCategory);
                }
            }
            else
            {
                // has child nodes, continue down chain
                foreach (TreeNode childNode in node.Nodes)
                {
                    fullCategories.AddRange(
                        GetFullCategoriesRecursive(childNode, runningCategory));
                }
            }
            return fullCategories;
        }

        private void CheckAllChildNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                childNode.Checked = node.Checked;
                if (childNode.Nodes.Count > 0)
                {
                    CheckAllChildNodes(childNode);
                }
            }
        }

        private void OnRadioSelected(object sender, EventArgs e)
        {
            allCategoriesLabel.Enabled = allCategoriesRadio.Checked;
            selectedCategoriesLabel.Enabled = selectedCategoriesRadio.Checked;
            categoriesTreeView.Enabled = selectedCategoriesRadio.Checked;
        }

        private void categoriesTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChildNodes(e.Node);
        }
    }
}
