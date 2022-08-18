using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PL.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string folderName)
        {

            var folderPath=Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/files",folderName);

            var filename=$"{Guid.NewGuid()}{Path.GetFileName( file.Name)}";
            
            var FilePath=Path.Combine( folderPath,filename);

            using var fs = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(fs);

            return filename;

        }

        public static void DeletImage(string FileName ,string FolderName)
        {
            var imagepath= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", FileName,FolderName);

            if(File.Exists(imagepath))
                File.Delete(imagepath);
        }
    }
}
