using RESTAPI.Model;
using System.IO;

namespace RESTAPI.Business.Implementattions
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fulPath = path + "\\Other\\49195138.pdf";
            return File.ReadAllBytes(fulPath);
        }
    }
}
