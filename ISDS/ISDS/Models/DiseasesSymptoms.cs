using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDS.Models
{
    public class DiseasesSymptoms
    {
        [PrimaryKey, AutoIncrement]
        public long ID { get; set; }
        public int DiseaseId { get; set; }
        public int SymptomId { get; set; }
    }
}
