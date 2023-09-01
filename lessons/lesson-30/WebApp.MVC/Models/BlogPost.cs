namespace WebApp.MVC.Models
{
    public class BlogPost
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public string[] Tags { get; set; }

        public bool IsNew { get; set; }
    }
}
