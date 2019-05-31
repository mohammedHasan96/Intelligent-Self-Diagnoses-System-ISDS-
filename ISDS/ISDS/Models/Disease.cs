using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDS.Models
{
    public class Disease
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseDescription { get; set; }
        public string DiseaseLink { get; set; }
    }
}
