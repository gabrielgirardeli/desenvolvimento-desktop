using MultApps.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.Entities.Abstract
{
    public abstract class EntidadesBase
    {
      public int Id { get; set; }
      public DateTime DataCriacao { get; set; }
      public DateTime DataAlteacao { get; set; }
      public  StatusEnum Status { get; set; }


    }
}
