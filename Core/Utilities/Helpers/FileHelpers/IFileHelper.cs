using Core.Utilities.Result.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        IResult Add(IFormFile formFile);
        IResult Ubadte(IFormFile formFile, string filepath, string root);
        IResult Delete(string filepath);

    }
}
