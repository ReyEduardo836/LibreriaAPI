﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Domain.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
