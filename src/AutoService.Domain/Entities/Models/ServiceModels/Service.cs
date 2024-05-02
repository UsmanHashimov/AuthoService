using AutoService.Domain.Entities.Models.CompanyModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.ServiceModels
{
    public class Service
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public virtual Company Company { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }

    }
}
