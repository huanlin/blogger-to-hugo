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
    public class ImageProcessor
    {
        public ImageProcessor()
        {
            DownloadedImageDict = new Dictionary<string, string>();
        }

        public Dictionary<string,string> DownloadedImageDict { get; set; }

        public void PrepareImageDict(string imageDirctory)
        {
            var allImageFiles = Directory.GetFiles(imageDirctory)
                .Where(x => x.EndsWith(".json") == false).ToList();

            var metaFiles = Directory.GetFiles(imageDirctory, "*.json");

            foreach (var file in metaFiles)
            {
                var model = JsonConvert.DeserializeObject<ImageMeta>(File.ReadAllText(file));

                if (string.IsNullOrEmpty(model.url) == false)
                {
                    var localFile = allImageFiles.FirstOrDefault(x => x.Contains(Path.GetFileNameWithoutExtension(file)));
                    DownloadedImageDict.Add(model.url, localFile);
                }
            }
        }

        public void ProcessImage(BlogPostModel model, string postPath)
        {
            DownloadImages(model, postPath);

            ReplaceImageInContent(model);
        }

        private void ReplaceImageInContent(BlogPostModel model)
        {
            foreach (var item in model.Images)
            {
                model.Content = model.Content.Replace(item.OriginalUrl, item.WyamAbsolutePath);
            }
        }

        public void DownloadImages(BlogPostModel model, string postPath)
        {
            if (model.Images.Count > 0)
            {
                var basePath = Path.GetFileNameWithoutExtension(model.NewFileName) + "_Asset";
                var path = Path.Combine(postPath, basePath);

                Directory.CreateDirectory(path);

                foreach (var item in model.Images)
                {
                    //if(DownloadedImageDict.ContainsKey(item.OriginalUrl) == false)
                    //{
                    //    Console.WriteLine($"{item.OriginalUrl} 不存在");
                    //}
                    var key = DownloadedImageDict.Keys.FirstOrDefault(x => x.StartsWith(item.OriginalUrlWithDomainFix.Substring(0, 59)));
                    var found = DownloadedImageDict[key];

                    var newFilePath = Path.Combine(path, Path.GetFileName(found));

                    if (File.Exists(newFilePath) == false)
                    {
                        File.Copy(found, newFilePath);
                    }

                    item.SaveToPath = newFilePath;
                    item.LocalPath = Path.Combine(basePath, Path.GetFileName(found));
                }
            }
        }

        internal void PrepareImageDict(object offLineImagePath)
        {
            throw new NotImplementedException();
        }
    }
}
