using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Entities.Models
{
    public class Project:BaseEntity
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isFeatured { get; set; }
        public int ThumbnailPictureId { get; set; }

        public virtual List<ProjectPicture> ProjectPictures { get; set; }
    }
}
