using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LoginApplication.Controllers
{
    public class FileController : Controller
    {
        private IWebHostEnvironment Environment;

        public FileController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this.Environment.WebRootPath, "files/") + fileName;
            

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(fileName);
            //byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

    }
}
