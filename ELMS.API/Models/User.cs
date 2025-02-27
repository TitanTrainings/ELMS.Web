﻿using System.ComponentModel.DataAnnotations;

namespace ELMS.API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int SickLeaveBalance { get; set; }
        public int VacationLeaveBalance { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }   
}
