using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Office.Interop.Word;

namespace BusinessLogic.Logic
{
    public static class TakeLogic
    {

        public static async void TakeFile(string filePath, string fileName)
        {
            if(!File.Exists(fileName))
            {
                throw new Exception("Файл не найден");
            }
            try
            {
                File.Copy(fileName, filePath, true);

                Application app = new Application();
                app.Visible = true;
                //Document doc = app.Documents.Add(Visible: true);
                //doc.Save();
                Document doc = app.Documents.Open(FileName: filePath,Visible:true);
                //doc.Save();
                app.Quit();

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
