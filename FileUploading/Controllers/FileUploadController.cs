//Contains types that allow reading and writing to files and data
//streams, and types that provide basic file and directory support.

using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    
    public class FileUploadController : Controller
    {
        
          //Example: A client (browser) sends an HTTP request to the server;
          //then the server returns a response to the client. The response
          //contains status information about the request and may also
          //contain the requested content.

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
                // extract only the filename

                var fileName = Path.GetFileName(files.FileName);
                var EXTENSION = Path.GetExtension(files.FileName);

                // store the file inside ~/App_Data/uploads folder
                if (flexRadioDefault== "Document")
                {
                    ViewBag.Message = ("hello");
                   
                }
               else if (flexRadioDefault == "Image")
                {
                    ViewBag.Message = ("hello");

                }
               else if (flexRadioDefault == "Video")
                {
                    ViewBag.Message = ("hello");

                }
                else
                {
                    ViewBag.Message = ("slect a button");

                }

                //var path = Path.Combine(Server.MapPath("~/trypictures/uploads"), fileName);
                if (EXTENSION == ".png"|| EXTENSION == ".jpg")
                {
                    var path = Path.Combine(HttpContext.Server.MapPath("~/Content/pictures"), Path.GetFileName(files.FileName));
                    files.SaveAs(path);
                    ViewBag.Messsage = "successful";
                }
              else if (EXTENSION == ".mp4" )
                {
                    var path = Path.Combine(HttpContext.Server.MapPath("~/Content/videos"), Path.GetFileName(files.FileName));
                    files.SaveAs(path);
                    ViewBag.Messsage = "successful";
                }
                else if (EXTENSION == ".pdf"|| EXTENSION == ".docx")
                {
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    files.SaveAs(path);
                }


                   
                

                // The chosen default path for saving

                
            }
            // redirect back to the index action to show the form once again

            return RedirectToAction("upload");
        }
    }
}