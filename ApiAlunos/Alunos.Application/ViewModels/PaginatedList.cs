using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.ViewModels
{
    public class PaginatedList<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
