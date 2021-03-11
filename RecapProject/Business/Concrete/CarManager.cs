﻿
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Results.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            //validation buraya gelen ürünün uyması gereken kurallar. --> fluentValidation
            //business code kullanıcının bu işlemi yapmaya uygun olup olmadığı.
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);
            if (false)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new  SuccessResult(Messages.ProductDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ListedProduct) ;
        }

        public IDataResult<List<CarDetails>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetails>>( _carDal.GetCarDetails(),Messages.GetCarDetailMessage);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int ıd)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == ıd),Messages.GetCarsByBrandId);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int ıd)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId == ıd),Messages.GetCarsByColorId);
        }

        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
