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
        IResult Update(IFormFile formFile, string filepath);
        IResult Delete(string filepath);

    }
}
