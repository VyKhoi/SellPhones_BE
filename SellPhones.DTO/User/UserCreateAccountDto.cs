﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.DTO.User
{
    public class UserCreateAccountDto
    {
        public string? Name { get; set; } = null!;

        public string? Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? PassWord { get; set; }

        public bool IsActive { get; set; } = true;


    }
}