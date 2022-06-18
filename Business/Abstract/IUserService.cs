using Core.Entities.Concrete;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        //kullanıcı eklemek içim
        Result Add(User user);
        //Kullanıcıyı emailinden bulmak için 
        User GetByMail(string email);

    }
}
