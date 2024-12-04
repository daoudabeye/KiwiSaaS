using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Kiwi.Core.MetaData
{
    public class PropertyPermissions: ValueObject
    {
        public List<Guid> CanRead { get; set; }

        public List<Guid> CanUpdate { get; set; }

        public PropertyPermissions()
        {
            CanRead = new List<Guid>();
            CanUpdate = new List<Guid>();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CanRead;
            yield return CanUpdate;
        }
    }
}
