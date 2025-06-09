using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdministrativeClass : EntityBase
    {
        public string Name { get; set; } = null!;
        public string Department { get; set; } = null!;
    }
}
