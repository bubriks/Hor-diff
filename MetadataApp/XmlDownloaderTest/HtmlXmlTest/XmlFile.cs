﻿namespace HtmlXmlTest
{
    internal class XmlFile
    {
        public XmlFile(string name, string filename, string attachment = null, string errorMSG = null)
        {
            this.Name = name;
            this.Filename = filename;
            this.Attachment = attachment;
            this.ErrorMSG = errorMSG;
        }

        public string Name { get; set; }

        public string Filename { get; set; }

        public string Attachment { get; set; }

        public string ErrorMSG { get; set; }
    }
}
