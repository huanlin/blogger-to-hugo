namespace BloggerToHugo.Model
{
    public class BlogImage
    {
        public string OriginalUrl { get; set; }
        public string OriginalUrlWithDomainFix
        {
            get
            {
                return OriginalUrl.Replace("http://lh4.ggpht.com", "https://lh3.googleusercontent.com")
                        .Replace("http://lh6.ggpht.com", "https://lh3.googleusercontent.com")
                        .Replace("http://lh3.ggpht.com", "https://lh3.googleusercontent.com")
                        .Replace("http://lh5.ggpht.com", "https://lh3.googleusercontent.com")
                        .Replace("http:", "https:");
            }
        }
        public string SaveToPath { get; set; }
        public string LocalPath { get; set; }
        public string WyamAbsolutePath { get { return $"/posts/migrate/{LocalPath.Replace("\\", "/")}"; } }
    }
}