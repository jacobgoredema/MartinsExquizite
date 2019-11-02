using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Entities.Models
{
    public class Category:BaseEntity
    {
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool isFeatured { get; set; }
        public string SanitizedName { get; set; }

        public int DisplaySeqNo { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
