namespace Lesson_33_Commerce.Models
{
    public class PaginationViewModel
    {
        public int PageCount { get; set; }

        public int CurrentPage { get; set; }

        public bool IsFirstPage => CurrentPage == 1;

        public bool IsLastPage => CurrentPage == PageCount;

        public int? PreviousPage => IsFirstPage ? default : CurrentPage - 1;

        public int? NextPage => IsLastPage ? default : CurrentPage + 1;
    }
}
