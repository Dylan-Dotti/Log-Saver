using FileUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileUtilitiesTests
{
    public class CategoryTreeNodeTests
    {
        private readonly string simpleTreeJson = "{\"Category\":\"a\",\"SubCategories\":[{\"Category\":\"b\",\"SubCategories\":[]},{\"Category\":\"c\",\"SubCategories\":[]}]}";
        private readonly string doubleLayerTreeJson = "{\"Category\":\"a\",\"SubCategories\":[{\"Category\":\"b\",\"SubCategories\":[{\"Category\":\"d\",\"SubCategories\":[]}]},{\"Category\":\"c\",\"SubCategories\":[{\"Category\":\"e\",\"SubCategories\":[]}]}]}";

        [Fact]
        public void SimpleTreeSerializationTest()
        {
            FileCategory rootNode = new FileCategory("a");
            FileCategory[] childNodes = new FileCategory[]
            {
                new FileCategory("b"), new FileCategory("c")
            };
            rootNode.AddSubCategories(childNodes);
            string expectedJson = simpleTreeJson;
            string actualJson = JsonConvert.SerializeObject(rootNode);
            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public void SimpleTreeDeserializationTest()
        {
            string json = simpleTreeJson;
            FileCategory rootNode = JsonConvert.DeserializeObject<FileCategory>(json);
            Assert.Equal("a", rootNode.Category);
            IReadOnlyList<FileCategory> childNodes = rootNode.SubCategories;
            Assert.Equal(2, childNodes.Count);
            Assert.Equal("b", childNodes[0].Category);
            Assert.Equal("c", childNodes[1].Category);
        }

        [Fact]
        public void DoubleLayerTreeSerializationTest()
        {
            FileCategory rootNode = new FileCategory("a");
            FileCategory leftChild = new FileCategory("b");
            FileCategory rightChild = new FileCategory("c");
            rootNode.AddSubCategories(new FileCategory[] { leftChild, rightChild });
            leftChild.AddSubCategory(new FileCategory("d"));
            rightChild.AddSubCategory(new FileCategory("e"));
            string actualJson = JsonConvert.SerializeObject(rootNode);
            Assert.Equal(doubleLayerTreeJson, actualJson);
        }

        [Fact]
        public void DoubleLayerTreeDeserializationTest()
        {
            FileCategory rootNode = JsonConvert.DeserializeObject<FileCategory>(doubleLayerTreeJson);
            Assert.Equal("a", rootNode.Category);
            IReadOnlyList<FileCategory> childNodes = rootNode.SubCategories;
            Assert.Equal(2, childNodes.Count);
            Assert.Equal("b", childNodes[0].Category);
            Assert.Equal("c", childNodes[1].Category);
            Assert.Equal("d", childNodes[0].SubCategories[0].Category);
            Assert.Equal("e", childNodes[1].SubCategories[0].Category);
        }
    }
}
