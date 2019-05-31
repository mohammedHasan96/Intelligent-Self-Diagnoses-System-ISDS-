using System;
using System.Collections.Generic;
using System.Text;

namespace ISDS.Models
{
    public class DiseaseList
    {
        public Disease Disease { get; set; }
        public Symptom[] Symptoms { get; set; }
        public bool IsConsernd { get; set; } = true;
    }
}
