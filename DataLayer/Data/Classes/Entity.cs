using System;
using System.Linq;

namespace Frameworkone.Domain
{
    [Serializable]
    public abstract class Entity
    {
        protected Entity()
        {
            AuditData = new AuditInformation();
        }

        public long? Id { get; set; }

        public AuditInformation AuditData { get; internal set; }
    }

    [Serializable]
    public class AuditInformation
    {
        public string LastUpdatedUser { get; set; }
        public DateTime DateLastUpdated { get; set; }

    }
}
