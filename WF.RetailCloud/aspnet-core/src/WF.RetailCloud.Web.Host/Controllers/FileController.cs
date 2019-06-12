using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Authorization;
using WF.RetailCloud.Configuration;
using WF.RetailCloud.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WF.RetailCloud.Web.Host.Controllers
{
    public class FileController : AbpController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [RequestFormSizeLimit(valueCountLimit: 2147483647)]
        [HttpPost]
        [AbpAllowAnonymous]
        //[Audited]
        public async Task<JsonResult> DocFilesPostsAsync(IFormFile[] file)
        {
            var date = Request;
            var files = Request.Form.Files;
            //long size = files.Sum(f => f.Length);
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var filePath = string.Empty;
            var returnUrl = string.Empty;
            var fileName = string.Empty;
            long fileSize = 0;
            string fileExt = string.Empty;

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    fileName = formFile.FileName.Substring(0, formFile.FileName.IndexOf('.'));
                    fileExt = Path.GetExtension(formFile.FileName); //文件扩展名，不含“.”
                    fileSize = formFile.Length; //获得文件大小，以字节为单位
                    var uid = Guid.NewGuid().ToString();
                    string newFileName = uid + fileExt; //随机生成新的文件名
                    var fileDire = webRootPath + "/docfiles/";
                    if (!Directory.Exists(fileDire))
                    {
                        Directory.CreateDirectory(fileDire);
                    }
                    filePath = fileDire + newFileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    returnUrl = "/docfiles/" + newFileName;
                }
            }
            var apiResult = new APIResultDto();
            apiResult.Code = 0;
            apiResult.Msg = "上传文件成功";
            apiResult.Data = new { name = fileName, size = fileSize, ext = fileExt, url = returnUrl };
            return Json(apiResult);
        }

    }
}
