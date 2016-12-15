using AngularjsUploadingFileWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularjsUploadingFileWeb.Controllers
{
    public class FileStreamingController : Controller
    {
        //
        // GET: /FileStreaming/

        [HttpPost]
        public JsonResult UploadImages(string description)
        {
            string Message = "";
            string path = "";
            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hfb = Request.Files[file] as HttpPostedFileBase;
                    if (hfb.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(hfb.FileName);
                        if (extension != ".jpg" && extension != ".png" && extension != ".jpeg" && extension != ".gif")
                        {
                            ViewBag.Message = "Just images please";
                        }
                        else
                        {
                            var fn = Path.GetFileName(hfb.FileName);
                            path = Path.Combine(Server.MapPath("~/App_Data/Product"), fn);
                            //if (!System.IO.Directory.Exists(path))
                            //    System.IO.Directory.CreateDirectory(path);
                            hfb.SaveAs(path);

                            Message = Persist(description, Message, path, hfb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = "Upload failed. " + ex.Message;
            }

            return new JsonResult { Data = new { Message = Message } };

        }

        [HttpPost]
        public JsonResult UploadVideo(string description)
        {
            string Message = "";
            string path = "";
            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hfb = Request.Files[file] as HttpPostedFileBase;
                    if (hfb.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(hfb.FileName);

                        var fn = Path.GetFileName(hfb.FileName);
                        path = Path.Combine(Server.MapPath("~/Content/UploadedFiles"), fn);
                        if (!System.IO.Directory.Exists(path))
                            System.IO.Directory.CreateDirectory(path);
                        hfb.SaveAs(path);
                        Message = Persist(description, Message, path, hfb);
                    }
                }
            }
            catch
            {
                Message = "Upload failed";
            }

            return new JsonResult { Data = new { Message = Message } };

        }

        private static string Persist(string description, string Message, string path, HttpPostedFileBase hfb)
        {
            using (var context = new ApplicationDbContext())
            {
                var uploadedFile = new UploadedFile
                {
                    FileName = hfb.FileName,
                    Description = description,
                    FilePath = path,
                    FileSize = hfb.ContentLength
                };
                context.UploadFiles.Add(uploadedFile);
                if (context.SaveChanges() > 0)
                    Message = "Upload successful";
            }

            return Message;
        }
    }
}