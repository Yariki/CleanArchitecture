﻿namespace CleanArchitecture.Domain.Common;

public abstract class BaseAuditableEntity<TId> : BaseEntity<TId>
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
