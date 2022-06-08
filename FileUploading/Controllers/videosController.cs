using FileUploading.Models; // If we do not have this then it is

// List<Models.FileModel> files = new List<Models.FileModel>();

using System.Collections.Generic; // Helps with lists

using System.IO; // Required for reading and writing IO (Input / Output).
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    public class videosController : Controller
    {
        // GET: videos
        public ActionResult video(string fileName)
        {

            //Fetch all files in the Folder (Directory).

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Content/videos"));

            //string[] filePaths = Directory.GetFiles(Server.MapPath("~/trypictures/uploads/"));

            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {// display file name

                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });


            }






            return View(files);
        }



        public FileResult DownloadFile(string fileName) // Why fileName and not FileName????
                                                        // Because of using.
        {
            //Build the File Path.

            string path = Server.MapPath("~/Content/videos/") + fileName;
            /// string Path = Server.MapPath("~/trypictures/uploads/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Content/videos/") + fileName;
            ///string path = Server.MapPath("~/trypictures/uploads/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("video");
        }
    }
}
        
