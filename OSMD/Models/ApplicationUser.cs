using System;
using Microsoft.AspNetCore.Identity;


namespace OSMD.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public DateTime Year { get; set; }
        public int Apartment { get; set; }
        public byte[] Foto { get; set; }
    }
}
