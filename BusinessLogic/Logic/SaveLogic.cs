using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace BusinessLogic.Logic
{
    public static class SaveLogic
    {
        public static void AddFile(string fileName)
        {
            //Application app = new Application();
            //Document doc = app.Documents.Add(Visible: true);
            //doc.Save();
            //app.Documents.Open(@"C:\Users\Тимофей\Downloads\Otchet.docx");
            
            System.IO.File.Copy(fileName, TakeNameFile(fileName), true);
            //window.Documents.Add(fileName);
           // window.Documents.Open(@"C:\Users\Тимофей\Downloads\Otchet.docx");
        }

        public static string TakeNameFile(string filename)
        {
            string[] splitString = filename.Split('\\');
            string name = splitString.Last();

            return name;
        }
    }
}
