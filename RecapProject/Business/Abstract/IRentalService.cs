﻿using Core.Results.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailsDto>> GetRentalDetails();
        IResult Add(Rental rental);
        IDataResult<List<RentalDetailsDto>> GetByCarId(int id);

    }
}
