using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class DBInitializer : DropCreateDatabaseIfModelChanges<StudentsEntity>
    {
        protected override void Seed(StudentsEntity context)
        {
        }
    }
}
