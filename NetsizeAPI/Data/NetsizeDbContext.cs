using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetsizeAPI.Data
{
    public class NetsizeDbContext : IdentityDbContext
    {
        public NetsizeDbContext(DbContextOptions<NetsizeDbContext> options) : base(options)
        {

        }
    }
}
