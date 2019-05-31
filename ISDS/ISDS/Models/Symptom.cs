using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDS.Models
{
    public class Symptom
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String SymptomName { get; set; }
        public String SymptomLink { get; set; }
        public int DiseasesCount { get; set; }
    }
}
