using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace BloggerToHugo.Model
{
    public class XmlBackupProcessOption
    {
        [Option('p', HelpText = "Path to xml file exported from Blogger.", DefaultValue = Constants.DefaultInputFile)]
        public string BackupXmlPath { get; set; }

        [Option('i', HelpText = "Path to downloaded image files.", DefaultValue = Constants.DefaultImageDownloadPath)]
        public string OffLineImagePath { get; set; }

        [Option('o', HelpText = "Path to output files.", DefaultValue = Constants.DefaultOutputPath)]
        public string FinalOutputPostPath { get; set; }
    }
}
