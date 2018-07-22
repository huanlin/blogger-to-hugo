using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerToHugo.Model
{
    public class BlogPostModel
    {
        public BlogPostModel()
        {
            Tags = new List<string>();
            Images = new List<BlogImage>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string UrlWithouDomain { get { return Url.TrimStart("http://blog.alantsai.net/".ToCharArray()); } }
        public DateTime PublishedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Series { get { return Tags.Where(x => x.StartsWith("「")); } }
        public string Content { get; set; }
        public IList<BlogImage> Images { get; set; }

        public string NewFileName
        {
            get
            {
               return PublishedDate.ToString("yyyy-MM-dd") + "-" + 
                    UrlWithouDomain.Split('/').Last();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"id: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Url: {Url}");
            sb.AppendLine($"PublishedDate: {PublishedDate}");
            sb.AppendLine($"ModifyDate: {ModifyDate}");
            sb.AppendLine($"Tags: {string.Join(",", Tags)}");

            return sb.ToString();
        }

        public string ToStringWithContent()
        {
            var result = ToString() + Environment.NewLine + $"Content:{Content}";

            result = result + Environment.NewLine + $"Images: {string.Join(",", Images.Select(x => x.OriginalUrl))}";

            return result;
        }
    }
}
