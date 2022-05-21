using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Products product)
        {
            _productDal.Add(product);
            return new SuccessDataResult<Products>(Messages.ProductAdded);
            
        }

        public IResult Delete(Products product)
        {
            _productDal.Delete(product);
            return new SuccessDataResult<Products>(Messages.ProductDeleted);

        }

        public IResult Update(Products product)
        {
            _productDal.Update(product);
            return new SuccessDataResult<Products>(Messages.ProductUpdated);

        }

        public IDataResult<Products> GetById(int productId)
        {
            return new SuccessDataResult<Products>(_productDal.GetT(filter: p => p.ProductId == productId));

        }

        public IDataResult<List<Products>> GetList()
        {
            return new SuccessDataResult<List<Products>>(_productDal.GetAll().ToList());
        }

        public IDataResult<List<Products>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Products>>(_productDal.GetAll(filter: p => p.CategoryId == categoryId).ToList());
        }

        

    }
}
