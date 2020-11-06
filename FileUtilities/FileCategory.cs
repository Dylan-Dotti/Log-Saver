using Newtonsoft.Json;
using System.Collections.Generic;

namespace FileUtilities
{
    public class FileCategory
    {
        private readonly List<FileCategory> subCategories;

        [JsonProperty("Category", Order = 1, Required = Required.Always)]
        public string Category { get; private set; }

        [JsonProperty("SubCategories", Order = 2, Required = Required.Always)]
        public IReadOnlyList<FileCategory> SubCategories => subCategories;

        [JsonIgnore]
        public FileCategory ParentCategory { get; set; }

        [JsonIgnore]
        public string FullCategory => ParentCategory == null ?
            Category : ParentCategory.FullCategory + '_' + Category;

        [JsonIgnore]
        public bool HasSubcategories => subCategories.Count > 0;

        public FileCategory(string category) 
            : this(category, new FileCategory[0])
        { }

        [JsonConstructor]
        public FileCategory(string category, IEnumerable<FileCategory> subCategories)
        {
            this.subCategories = new List<FileCategory>();
            AddSubCategories(subCategories);
            Category = category;
        }

        public void AddSubCategory(FileCategory category)
        {
            subCategories.Add(category);
            category.ParentCategory = this;
        }

        public void AddSubCategories(IEnumerable<FileCategory> categories)
        {
            foreach (FileCategory category in categories)
            {
                AddSubCategory(category);
            }
        }
    }
}
