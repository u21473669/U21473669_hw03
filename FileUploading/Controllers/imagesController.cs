using FileUploading.Models; // If we do not have this then it is

// List<Models.FileModel> files = new List<Models.FileModel>();

using System.Collections.Generic; // Helps with lists

using System.IO; // Required for reading and writing IO (Input / Output).
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    public class imagesController : Controller
    {
        // GET: images
        
      
        public ActionResult images(string fileName)
        {
           
            //Fetch all files in the Folder (Directory).

          string[] filePaths = Directory.GetFiles(Server.MapPath("~/Content/pictures"));

            
            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {// display file name
                
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });

            
            }
        
                return View(files);
        }
        
        

        public FileResult DownloadFile(string fileName) 
        {
            //Build the File Path.

         string path = Server.MapPath("~/Content/pictures/") + fileName;
           
            
            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            
            //Build the File Path.
            string path = Server.MapPath("~/Content/pictures/") + fileName;
           
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //delete path
            System.IO.File.Delete(path);

             return RedirectToAction("images");
            
        }
    }
}
        