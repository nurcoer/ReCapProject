﻿using Business.Abstract;
using Business.Constants;
using Core.Results.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.AddedUser);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.DeletedUser);
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>( _userDal.GetAll());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdatedUser);
        }
    }
}