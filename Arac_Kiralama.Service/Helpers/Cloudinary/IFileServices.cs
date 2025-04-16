using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Helpers.Cloudinary
{
    public interface IFileService
    {
        string UploadImage(IFormFile file, string folderName);
    }
}
