using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelper : IFileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public IResult Add(IFormFile formFile)
        {
            var guidName = Guid.NewGuid().ToString();
            var filetype = Path.GetExtension(formFile.FileName);
            IResult result = Run(CheckFileExist(formFile.FileName),CheckFileTeypeValid(filetype));

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + guidName + filetype, formFile);

            return new SuccessResult((_folderName + guidName + filetype).Replace("\\", "/"));

        }

        public IResult Delete(string filepath)
        {
            return DeleteOldFile(_currentDirectory+filepath.Replace("/","\\"));
           
        }

       

        public IResult Update(IFormFile formFile, string filepath)
        {
            var guidName = Guid.NewGuid().ToString();
            var filetype = Path.GetExtension(formFile.FileName);

            IResult result = Run(CheckFileExist(formFile.FileName), CheckFileTeypeValid(filetype));

            DeleteOldFile(_currentDirectory + filepath.Replace("/", "\\"));

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + guidName + filetype, formFile);
            return new SuccessResult((_folderName + guidName + filetype).Replace("\\", "/"));

        }
        public static IResult Run(params IResult[] logies)
        {
            foreach (var logic in logies)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }

        private IResult CheckFileExist(string filepath)
        {
            if (filepath!=null && filepath.Length>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }
        private IResult CheckFileTeypeValid(string filetype)
        {
            if (filetype != ".jpeg" && filetype != ".png" && filetype != ".jpg")
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fileStream=File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
        private static IResult DeleteOldFile(string directoryToBrDeleted)
        {
            if (File.Exists(directoryToBrDeleted.Replace("/", "\\")))
            {
                File.Delete(directoryToBrDeleted.Replace("/", "\\"));
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
