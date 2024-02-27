using BillConductor.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillConductor.Core.HealthCheck
{
    public class Uid : ValueObject
    {
        public Guid Value { get; set; }
    }
}
