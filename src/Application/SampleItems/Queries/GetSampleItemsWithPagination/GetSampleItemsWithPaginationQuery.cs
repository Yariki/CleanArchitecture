using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetSampleItemsWithPaginationQuery : IRequest<PaginatedList<SampleItemBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetSampleItemsWithPaginationQueryHandler : IRequestHandler<GetSampleItemsWithPaginationQuery, PaginatedList<SampleItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSampleItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SampleItemBriefDto>> Handle(GetSampleItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.SampleItems
            .OrderBy(x => x.Title)
            .ProjectTo<SampleItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
