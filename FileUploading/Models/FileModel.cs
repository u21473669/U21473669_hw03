//Ensure that CodeLens is activated
//Select >> Tools >> Options >> Text Editor >> All Languages >> CodeLens

using System.ComponentModel.DataAnnotations; //Add for look and feel
using System.Web;

namespace FileUploading.Models
{
    public class FileModel
    {
        //Display options.

        [Display(Name = "File Name")]
        public string FileName { get; set; }
      
        public string Path1 { get; set; }
     






        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }
    }

    
}






