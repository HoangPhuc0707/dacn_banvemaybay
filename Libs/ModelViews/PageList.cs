namespace DemoMayBayCN.Areas.Admin.ModelView
{
    public class PageList<T>:List<T>
    {
        public int CurrentPage { get; set; }
        public int Pagesize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PageList(List<T> items, int count, int pageNumber, int pagesize )
        {
            TotalCount = count;
            CurrentPage = pageNumber;
            Pagesize = pagesize;
            TotalPages = (int)Math.Ceiling(count/(double)pagesize);
            AddRange(items);
        }
        public static PageList<T> GetPagedList(IQueryable<T> source,int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            return new PageList<T>(items,count,pageNumber,pageSize);
        }
    }
}
