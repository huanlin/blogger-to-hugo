using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggerToHugo.Model;
using Newtonsoft.Json;

namespace BloggerToHugo.Bll
{
    public class BlogPostModelToHtmlLogic
    {
        public string ToHtmlTemplateString(BlogPostModel model)
        {
            var template = GetTemplate();

            template = ReplaceTemplate(template, "Title", model.Title);
            template = ReplaceTemplate(template, "PublishedDate", DateString(model.PublishedDate));
            template = ReplaceTemplate(template, "Modified", DateString(model.ModifyDate));
            template = ReplaceTemplate(template, "Tags", JsonConvert.SerializeObject(model.Tags.Select(x => x.ToLower().Replace("c#", "csharp"))));
            template = ReplaceTemplate(template, "Series", JsonConvert.SerializeObject(model.Series));
            template = ReplaceTemplate(template, "RedirectFrom", model.UrlWithouDomain);
/*
            if (model.Images.Count > 0)
            {
                template = ReplaceTemplate(template, "Image", model.Images.First().WyamAbsolutePath.Replace("\\", "/"));
            }
            else
            {
                template = ReplaceTemplate(template, "Image", "\"\"");
            }
*/
            template = ReplaceTemplate(template, "Content", model.Content);

            return template;
        }

        private string DateString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        private string ReplaceTemplate(string template, string v, string title)
        {
            return template.Replace("{{" + v + "}}", title);
        }

        private string GetTemplate()
        {
            return File.ReadAllText("Template\\BlogPostTemplate.html");
        }
    }
}
