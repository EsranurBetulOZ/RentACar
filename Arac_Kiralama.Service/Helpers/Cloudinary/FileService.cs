using Arac_Kiralama.Service.Abstracts;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Helpers.Cloudinary;

public class CloudinaryFileService : IFileService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;

    public CloudinaryFileService(IOptions<CloudinarySettings> options)
    {
        var account = new Account(
            options.Value.CloudName,
            options.Value.ApiKey,
            options.Value.ApiSecret);

        _cloudinary = new CloudinaryDotNet.Cloudinary(account);
    }



    public string UploadImage(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            return string.Empty;

        using (var stream = file.OpenReadStream())
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = folderName,
                Transformation = new Transformation()
                    .Width(800).Height(600).Crop("fill").Quality("auto:good")
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new Exception($"Cloudinary upload failed: {uploadResult.Error.Message}");
            }

            return uploadResult.SecureUrl.ToString();
        }
    }
}

