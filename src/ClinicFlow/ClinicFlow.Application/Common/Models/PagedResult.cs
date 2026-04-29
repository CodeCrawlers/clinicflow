using System.Collections.Generic;

namespace ClinicFlow.Application.Common.Models;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; private set; } = new List<T>();
    public int TotalCount { get; private set; }
    public int Page { get; private set; }
    public int PageSize { get; private set; }

    public PagedResult(IEnumerable<T> items, int totalCount, int page, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }
}
