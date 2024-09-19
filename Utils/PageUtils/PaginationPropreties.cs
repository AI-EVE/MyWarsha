namespace Utils.PageUtils
{
    public class PaginationPropreties
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public int Skip () 
        {
            return (PageNumber - 1) * PageSize;
        }
    }
}