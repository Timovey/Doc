using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BusinessLogic.Logic
{
    public static class SaveLogic
    {
        private static string nameListDocs = "docs.xml";

        public static void AddFile(string fileName)
        {
            try
            {
                string shortName = TakeNameFile(fileName);
                if (!File.Exists(nameListDocs))
                {
                    var xElement = new XElement("Docs");
                    xElement.Add(new XElement("Doc", shortName));
                    XDocument xDocument = new XDocument(xElement);
                    xDocument.Save(nameListDocs);
                }
                else
                {
                    bool repeatName = false;
                    XDocument xDocument = XDocument.Load(nameListDocs);
                    var xElements = xDocument.Root.Elements("Doc").ToList();
                    foreach (var elem in xElements)
                    {
                    if(elem.Value.Equals(shortName))
                        {
                            repeatName = true;
                        }
                    }
                    if (!repeatName)
                    {
                        XElement xElement = new XElement("Doc", shortName);
                        xDocument.Root.Add(xElement);
                        xDocument.Save(nameListDocs);
                    }
                }
                File.Copy(fileName, shortName, true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFile(string fileName)
        {
            try
            {
                XDocument xDocument = XDocument.Load(nameListDocs);
                var xElements = xDocument.Root.Elements("Doc").ToList();
                int count = -1;
                foreach (var elem in xElements)
                {
                    count++;
                    if (elem.Value.Equals(fileName))
                    {
                        break;
                    }
                }
                if(count != -1)
                {
                   xDocument.Root.Elements("Doc").ElementAt(count).Remove();
                   xDocument.Save(nameListDocs);
                    File.Delete(fileName);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            public static string TakeNameFile(string filename)
        {
            string[] splitString = filename.Split('\\');
            string name = splitString.Last();

            return name;
        }
    }
}
