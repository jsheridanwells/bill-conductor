using BillConductor.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillConductor.Core.HealthCheck
{
    public class HealthCheckDate : ValueObject
    {
        public DateTime Value { get; set; }
    }
}
