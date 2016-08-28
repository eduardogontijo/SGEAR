using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LusaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

    }
}
