namespace Portfolio
{
    public class PagingJournal
    {
        public PagingJournal(int pageIndex, int count) 
        { 
            PageIndex = pageIndex;
            TotalPages = count;
        } 

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
