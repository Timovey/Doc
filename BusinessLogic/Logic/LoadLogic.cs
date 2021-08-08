using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.Logic
{
    public static class LoadLogic
    {
        private static string nameListDocs = "docs.xml";

        public static List<string> GetListDocs()
        {
            var list = new List<string>();
            try
            {
                if (!File.Exists(nameListDocs))
                {
                    return null;
                }

                XDocument xDocument = XDocument.Load(nameListDocs);
                var xElements = xDocument.Root.Elements("Doc").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(elem.Value);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}
