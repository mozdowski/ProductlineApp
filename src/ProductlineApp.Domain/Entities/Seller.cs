﻿using ProductlineApp.Domain.Common;

namespace ProductlineApp.Domain.Entities;

public class Seller : Person
{
    public Seller(
        Guid id,
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth)
    : base(id, firstName, lastName, email, dateOfBirth)
    {
    }
}