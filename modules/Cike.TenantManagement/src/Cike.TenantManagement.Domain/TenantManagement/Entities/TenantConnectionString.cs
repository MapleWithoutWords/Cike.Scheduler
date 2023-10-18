using System;
using Cike.TenantManagement.Domain.Shared;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Cike.TenantManagement.Domain.TenantManagement.Entities;

public class TenantConnectionString : Entity
{
    public virtual Guid TenantId { get; protected set; }

    public virtual string Name { get; protected set; }

    public virtual string Value { get; protected set; }

    protected TenantConnectionString()
    {

    }

    public TenantConnectionString(Guid tenantId, [NotNull] string name, [NotNull] string value)
    {
        TenantId = tenantId;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), TenantConsts.Length64);
        SetValue(value);
    }

    public virtual void SetValue([NotNull] string value)
    {
        Value = Check.NotNullOrWhiteSpace(value, nameof(value), TenantConsts.Length1024);
    }

    public override object[] GetKeys()
    {
        return new object[] { TenantId, Name };
    }
}
