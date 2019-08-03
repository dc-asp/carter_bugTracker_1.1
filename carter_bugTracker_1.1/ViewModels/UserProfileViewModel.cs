using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1.ViewModels
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }

        [MaxLength(50, ErrorMessage = "50 characters max")]
        [MinLength(3, ErrorMessage = "3 characters min")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "50 characters max")]
        [MinLength(3, ErrorMessage = "3 characters min")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "20 characters max")]
        [MinLength(3, ErrorMessage = "3 characters min")]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Avatar path")]
        public string AvatarUrl { get; set; }

        
        public HttpPostedFileBase Avatar { get; set; }
    }
}