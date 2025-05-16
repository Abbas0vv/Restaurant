using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Restaurant.Helpers.Extentions;

public static class FileExtention
{
    public static string CreateFile(this IFormFile file, string webRootPath, string folderName)
    {
        if (!IsValidFile(file)) return string.Empty;

        string fileName = Guid.NewGuid().ToString() + file.FileName;
        string path = Path.Combine(webRootPath, folderName);
        using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    public static string UpdateFile(this IFormFile file, string webRootPath, string folderName, string oldUrl)
    {
        if (IsValidFile(file)) RemoveFile(webRootPath, folderName, oldUrl);
        return file.CreateFile(webRootPath, folderName);
    }

    public static void RemoveFile(string webRootPath, string folderName, string oldUrl)
    {
        string ExitingFile = Path.Combine(webRootPath, folderName, oldUrl);
        System.IO.File.Delete(ExitingFile);
    }

    public static bool IsValidFile(IFormFile file)
    {
        if (file == null) return false;
        if (file.FileName == null) return false;
        if (file.FileName.Length >= 65) return false;
        if (!file.ContentType.Contains("image")) return false;
        if (file.Length > 2000000 &&  file.Length == 0) return false;

        return true;
    }
}
