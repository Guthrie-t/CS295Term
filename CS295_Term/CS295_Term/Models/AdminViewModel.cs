using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CS295_Term.Models
{
    public class AdminViewModel
    {
        public IEnumerable<SiteUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
