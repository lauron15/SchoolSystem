﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SystemSchool.Server.Models
{
    [Table("users")]
    public class Users : IdentityUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("password")]
        public string? Password { get; set; }

    }
}
