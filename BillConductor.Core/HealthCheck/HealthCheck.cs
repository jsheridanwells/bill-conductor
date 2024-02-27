using BillConductor.Core.Abstractions;

namespace BillConductor.Core.HealthCheck
{
    public sealed class HealthCheck : Entity
    {
        public Uid Uid { get; private set; }
        public HealthCheckDate HealthCheckDate { get; private set; }

        private HealthCheck(Uid uid, HealthCheckDate healthCheckDate) 
        { 
            Uid = uid;
            HealthCheckDate = healthCheckDate;
        }

// For ORM only
# pragma warning disable CS8618 
        private HealthCheck() { }
# pragma warning restore CS8618

        public static HealthCheck Create(Uid uid, HealthCheckDate healthCheckDate)
        {
            // TODO : replace with Guard
            if (DateTime.Compare(healthCheckDate.Value, DateTime.Now) > 0)
                throw new ArgumentException("HealthCheckDate cannot be in the future");

            return new HealthCheck(uid, healthCheckDate);
        }
    }
}
