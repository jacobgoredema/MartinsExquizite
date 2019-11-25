using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Entities.Models
{
    public class Comment
    {
        public DateTime TimeStamp { get; set; }

        public string UserId { get; set; }
        public virtual eMartinsExquiziteUser User { get; set; }

        public int Rating { get; set; }
        public string Text { get; set; }

        public int EntityId { get; set; }
        public int RecordId { get; set; }
    }
}
