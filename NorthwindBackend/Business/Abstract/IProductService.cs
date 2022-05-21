using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Products> GetById(int productId);
        IDataResult <List<Products>> GetList();
        IDataResult <List<Products>> GetListByCategory(int categoryId);
        IResult Add(Products product);
        IResult Update(Products product);   
        IResult Delete(Products product);


    }
}
