﻿namespace HtmlXmlTest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {

            WebResourceLoader webResourceLoader = new WebResourceLoader();
            // XmlIO xmlIO = new XmlIO();
            string rootUrl = "https://intensapp003.internal.visma.com/rest/";
            string rootLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\rest\\";
           
            List<Link> myLinks = WebResourceReader.MainReader(rootUrl, rootLocalPath);

            List<string> serverXmlPath = new List<string>();
            List<string> localFilePath = new List<string>();
            List<string> localFileName = new List<string>();
            foreach (Link link in myLinks)
            {
                serverXmlPath.Add(rootUrl + link.Href.Substring(6) + link.Href.Substring(5) + ".wadl");
                serverXmlPath.Add(rootUrl + link.Href.Substring(6) + link.Href.Substring(5) + ".xsd");
                localFileName.Add(link.Href.Substring(6) + ".wadl");
                localFileName.Add(link.Href.Substring(6) + ".xsd");
                localFilePath.Add(link.Filepath);
                localFilePath.Add(link.Filepath);
            }

            webResourceLoader.FetchMultipleXmlAndSaveToDisk(serverXmlPath, localFilePath, localFileName, 60).Wait();

            Console.WriteLine("Complete!");
            Console.ReadKey();
        }

        private static LinkList XmlToLinkList(XDocument xmlDocument)
        {
            LinkList allLinks = new LinkList
            {
                /*
                Links = (from link in xmlDocument.Descendants("link")
                         select new Link
                         {
                             Href = link.Element("href").Value,
                             Description = link.Element("description").Value,
                         }).ToList()
                 */

            };
            return allLinks;
        }   
    }
}
