﻿using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
            if (!user.Email.Contains("@"))
            {
                return new ErrorResult(Messages.UserEmailFormatIsWrong);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);

        }

        public IResult Update(User user)
        {
            if (!user.Email.Contains("@"))
            {
                return new ErrorResult(Messages.UserEmailFormatIsWrong);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (Exception)
            {
                throw new Exception(Messages.UserCanNotDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), Messages.GetUserByUserId);
        }
    }
}
