﻿using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime? RentalEnd { get; set; }
    }
}