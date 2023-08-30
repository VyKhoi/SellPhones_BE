using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPhones.Domain.Entity.Identity
{
    public interface IAudit
    {
        DateTime? AddedTimestamp { get; set; }
     
        DateTime? ChangedTimestamp { get; set; }
      
    }
}
