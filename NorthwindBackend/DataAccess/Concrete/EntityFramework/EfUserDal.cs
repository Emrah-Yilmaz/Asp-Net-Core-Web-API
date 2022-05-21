using Core.DataAccess.EntityFramework;
using Core.Entities.Contrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new NorthwindContext();
            var result = from operationCalim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                         on operationCalim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationCalim.Id, Name = operationCalim.Name };
            return result.ToList();

        }
    }
}
