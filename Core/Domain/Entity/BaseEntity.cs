using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class BaseEntity
    {
        
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
        public void Update()
        {
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
