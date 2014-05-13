using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CrowdSourceDiscovery.Contracts.Dtos
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLoggedTime { get; set; }

        public string FullName()
        {
            return string.Format("{0} {1}", FirstName, SecondName);
        }
    }
}