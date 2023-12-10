using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.SampleItems.Queries.GetSampleItemsWithPagination;

public class SampleItemBriefDto : IMapFrom<SampleItem>
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
