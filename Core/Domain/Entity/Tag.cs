using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Tag:BaseEntity
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
