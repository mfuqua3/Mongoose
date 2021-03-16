using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mongoose.Core
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MongooseContext>
    {
        public MongooseContext CreateDbContext(string[] args)
        {
            if (!args.Any())
                throw new InvalidOperationException("Must provide a connection string");
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(args[0]);
            return new MongooseContext(builder.Options);
        }
    }
}