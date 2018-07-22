using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BloggerToHugo.Model;

namespace BloggerToHugo.Bll.Helper
{
    public static class FeedEntryExtension
    {
        public static BlogPostModel ToBlogPostModel(this feedEntry entry)
        {
            var link = entry.link.FirstOrDefault(x => x.rel == "alternate" && x.type == "text/html");

            if (link == null)
                return null;

            var result = new BlogPostModel();

            result.Id = entry.id;
            result.Title = entry.title.Value;
            result.PublishedDate = entry.published;
            result.ModifyDate = entry.updated;
            result.Tags = entry.category.Where(x => x.scheme.EndsWith("ns#")).Select(x => x.term).ToList();
            result.Url = link.href;
            result.Content = entry.content.Value;

            var regex = new Regex("src=([\"'])(.*?)\\1");
            var matches = regex.Matches(result.Content);

            foreach (Match item in matches)
            {
                var value = item.Groups[2].Value;

                if((value.Contains("google") || value.Contains("ggpht")) == false)
                {
                    continue;
                }

                result.Images.Add(new BlogImage()
                {
                    OriginalUrl = value
                });
            }

            return result;
        }
    }
}
