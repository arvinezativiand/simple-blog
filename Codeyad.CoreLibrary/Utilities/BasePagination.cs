using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.Utilities
{
    public class BasePagination
    {
        public int Take { get; private set; }
        public int CurrentPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int PageCount { get; private set; }
        public int EntityCount { get; private set; }
        public void Generatepagination(IQueryable<object> data, int take, int currentPage)
        {
            EntityCount = data.Count();
            Take = take;
            CurrentPage = currentPage;
            PageCount = EntityCount / Take + ((EntityCount % Take != 0) ? 1 : 0);
            StartPage = (CurrentPage - 4 > 0) ? CurrentPage - 4 : 1;
            EndPage = (CurrentPage + 5 < PageCount) ? CurrentPage + 5 : PageCount;
        }
    }
}
