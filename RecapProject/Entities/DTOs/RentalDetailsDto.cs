﻿using Core.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailsDto : IDto
    {
        public int CarId { get; set; }
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public string ColorName { get; set; }
        public string BrandName  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
