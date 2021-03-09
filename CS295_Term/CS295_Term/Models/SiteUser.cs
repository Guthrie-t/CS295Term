using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS295_Term.Models
{
    public class SiteUser : IdentityUser
    {
        [StringLength(60)]
        public string Nickname { get; set; }

        public DateTime AccountAge { get; } //this is automatically set when a user registers and should not change
        //must be calculated into length of time when used by the view?
        //CurrentDay - RegisterDate = AccountAge

        [NotMapped]
        public IList<string> RoleNames { get; set; }

    }
}
