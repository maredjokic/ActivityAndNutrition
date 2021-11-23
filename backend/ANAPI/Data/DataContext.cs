using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ANAPI.Models;

namespace ANAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {}

        public DbSet<User> Users { get; set; }
    }
}