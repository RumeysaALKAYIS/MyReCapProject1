using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IAuthService
    {
        //Kullanıcı kayıt olmak için

        IDataResult<User> Register(UserForRegisterDto userForRegister);
        
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
