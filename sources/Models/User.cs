﻿using System;
using System.Collections.Generic;

namespace SetMeta.Web.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public DateTime? PasswordResetRequestedAt { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public int LoginTryCount { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string ImageUrl { get; set; }
        public string Language { get; set; }
    }
}