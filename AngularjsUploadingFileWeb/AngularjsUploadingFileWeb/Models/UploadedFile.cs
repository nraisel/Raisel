using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularjsUploadingFileWeb.Models
{
    public class UploadedFile
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "The file name can not exceed 100 characters")]
        public virtual string FileName { get; set; }

        [MaxLength(300, ErrorMessage = "The file descritpion can not exceed 300 characters")]
        public virtual string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public virtual string FilePath { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The file size can not be 0 or less")]
        public virtual int FileSize { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public virtual int Estado { get; set; }
    }
}