using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; } // örneğin admin rolüne kimler sahip olabilir gibi açıklamalar
        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName,string description)
        {
            this.Description = description;
        }
    }
}