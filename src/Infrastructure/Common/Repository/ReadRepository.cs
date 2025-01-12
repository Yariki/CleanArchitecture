﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Common.Repository;
public class ReadRepository<TId, TEntity> : IReadRepository<TId, TEntity> where TEntity : class
{

    private readonly IApplicationDbContext _context;

    public ReadRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<TEntity> GetBySpecificationAsync(ISpecification<TEntity> spec, CancellationToken cancellation)
    {
        var query = SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), spec);
        return query.FirstOrDefaultAsync<TEntity>(cancellationToken: cancellation);
    }

    public async Task<IEnumerable<TEntity>> GetListBySpecificationAsync(ISpecification<TEntity> spec, CancellationToken cancellation)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        query = spec.Criteria.IsNotNull()
            ? query.Where(spec.Criteria).AsNoTracking()
            : query.AsNoTracking();

        query = spec.OrderBy.IsNotNull()
            ? query.OrderBy(spec.OrderBy)
            : spec.OrderByDescending.IsNotNull()
                ? query.OrderByDescending(spec.OrderByDescending)
                : query;

        return await query.ToListAsync(cancellation).ConfigureAwait(false);
    }
}
