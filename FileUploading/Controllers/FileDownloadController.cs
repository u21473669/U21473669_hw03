using FileUploading.Models; // If we do not have this then it is

// List<Models.FileModel> files = new List<Models.FileModel>();

using System.Collections.Generic; // Helps with lists

using System.IO; // Required for reading and writing IO (Input / Output).
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    public class FileDownloadController : Controller // Complete then Add View as List using model
    {
        // GET: Home
        public ActionResult filedownload()
        {
            //Fetch all files in the Folder (Directory).

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/uploads/"));

            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
               
                
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName) 
        {
            
            //Build the File Path.

            string path = Server.MapPath("~/App_Data/uploads/") + fileName;
            //string path = Server.MapPath("~/trypictures/uploads/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {

            //Build the File Path.
            string path = Server.MapPath("~/App_Data/uploads/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //delete the path
            System.IO.File.Delete(path);

            return RedirectToAction("filedownload");
        }
    }
}