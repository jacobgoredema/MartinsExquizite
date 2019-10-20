using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Entities.Models
{
    public class ProjectPicture:BaseEntity
    {
        public int ProjectId { get; set; }
        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
