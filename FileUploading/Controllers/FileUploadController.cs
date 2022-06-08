//Contains types that allow reading and writing to files and data
//streams, and types that provide basic file and directory support.

using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    
    public class FileUploadController : Controller
    {
        
         
          [HttpGet]
        public ActionResult upload()  //INSIDE FileUpload
        {
            return View();
        }

        //Single File Upload
        [HttpPost]
        public ActionResult Index( string flexRadioDefault, HttpPostedFileBase files) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length

            if (files != null && files.ContentLength > 0)  
            {
                // extract  the filename  

                var fileName = Path.GetFileName(files.FileName);
                // extract  the file extension
                var EXTENSION = Path.GetExtension(files.FileName);

              
                

                //if extension is .... store in pictures
                if (EXTENSION == ".png"|| EXTENSION == ".jpg"|| EXTENSION == ".jpeg"|| EXTENSION == ".gif"|| flexRadioDefault == "Image")
                {
                    var path = Path.Combine(HttpContext.Server.MapPath("~/Content/pictures"), Path.GetFileName(files.FileName));
                    files.SaveAs(path);
                    ViewBag.Messsage = "successful";
                }
                //if extension is .... store in videos
                else if (EXTENSION == ".mp4" || flexRadioDefault == "Video")
                {
                    var path = Path.Combine(HttpContext.Server.MapPath("~/Content/videos"), Path.GetFileName(files.FileName));
                    files.SaveAs(path);
                    ViewBag.Messsage = "successful";
                }
                //if extension is .... store in uploads
                else if (EXTENSION == ".pdf"|| EXTENSION == ".docx" || EXTENSION == ".doc"|| flexRadioDefault == "Document")
                {
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    files.SaveAs(path);
                }


                   
                

                

                
            }
            // redirect back to the index action to show the form once again

            return RedirectToAction("upload");
        }
    }
}