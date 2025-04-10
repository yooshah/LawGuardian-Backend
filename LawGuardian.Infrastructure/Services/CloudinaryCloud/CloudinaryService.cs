using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LawGuardian.Application.ServiceContracts.Cloudinary;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Services.CloudinaryCloud
{
    public class CloudinaryService : ICloudinaryService
    {

        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            var cloudName = configuration["CLOUDINARY-CLOUDNAME"];
            var apiKey = configuration["CLOUDINARY-API-SECRET"];
            var apiSecret = configuration["CLOUDINARY-API-KEY"];
        }
        public async Task<string> UploadImage(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return null;
            }

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = "LawGuardianImageStore",
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };



                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {

                    throw new Exception($"Cloudinary upload error: {uploadResult.Error.Message}");
                }

                return uploadResult.SecureUrl?.ToString();

            }


        }
    }
}
