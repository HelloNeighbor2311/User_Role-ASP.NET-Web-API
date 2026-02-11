namespace User_Role.DTOs
{
    public class PageResult<T>
    {
        public List<T>? Items { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool hasPreviousPage => PageNumber > 1;
        public bool hasNextPage => PageNumber < TotalPages;

        public PageResult(List<T> items, int count , int pageNumber, int pageSize)
        {
            this.Items = items;
            this.TotalPages = (int)Math.Ceiling((double)count / pageSize);
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
    }
}
