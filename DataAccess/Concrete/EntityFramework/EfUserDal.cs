using Core.DataAccess.EntittyFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarContext())
            {
               
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                // operationClaim (contexteki tabloyu al)ile userOperationClaim(contexteki tabloyu al) join edip
                // hangi koşula göre (on) operationClaim id si ile userOperationClaim tablosundaki OperationClaimId eşit olan
                //userOperationClaim deki UserId si kullanıcının girdiği
                //select ile sonuçda dönen liste oluşturulur
                return result.ToList();
                //listeyi vericek
            }
           
        }
    }
}
