using FileUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileUtilitiesTests
{
    public class FileCategorizerTests
    {
        private readonly FileCategorizer categorizer = new FileCategorizer();

        [Fact]
        public void DoubleLayerTreeTest()
        {
            string[] fileNames = { "a_b_d", "a_c_e" };
            IReadOnlyList<FileCategory> categories = categorizer.Categorize(fileNames);
            Assert.Equal(1, categories.Count);
            Assert.Equal("a", categories[0].Category);
            IReadOnlyList<FileCategory> subCategories = categories[0].SubCategories;
            Assert.Equal(2, subCategories.Count);
            Assert.Equal("b", subCategories[0].Category);
            Assert.Equal("c", subCategories[1].Category);
            Assert.Equal(1, subCategories[0].SubCategories.Count);
            Assert.Equal(1, subCategories[1].SubCategories.Count);
            FileCategory subCategoryD = subCategories[0].SubCategories[0];
            Assert.Equal("d", subCategoryD.Category);
            Assert.Equal(0, subCategoryD.SubCategories.Count);
            FileCategory subCategoryE = subCategories[1].SubCategories[0];
            Assert.Equal("e", subCategoryE.Category);
            Assert.Equal(0, subCategoryE.SubCategories.Count);
        }

        [Fact]
        public void GenerateCategoryQueuesTest()
        {
            string[] extensionlessNames = { "a_b_d", "a_c_e", "a_c_e_f" };
            var categoryQueues = categorizer.GenerateCategoryQueues(extensionlessNames);
            Assert.Equal(3, categoryQueues.Count);
            Queue<string> queue1 = categoryQueues["a_b_d"];
            Assert.Equal(3, queue1.Count);
            Assert.Equal("a", queue1.Dequeue());
            Assert.Equal("b", queue1.Dequeue());
            Assert.Equal("d", queue1.Dequeue());
            Queue<string> queue2 = categoryQueues["a_c_e"];
            Assert.Equal("a", queue2.Dequeue());
            Assert.Equal("c", queue2.Dequeue());
            Assert.Equal("e", queue2.Dequeue());
            Queue<string> queue3 = categoryQueues["a_c_e_f"];
            Assert.Equal("a", queue3.Dequeue());
            Assert.Equal("c", queue3.Dequeue());
            Assert.Equal("e", queue3.Dequeue());
            Assert.Equal("f", queue3.Dequeue());

        }
    }
}
