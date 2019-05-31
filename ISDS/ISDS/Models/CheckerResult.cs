using System;
using System.Collections.Generic;
using System.Text;

namespace ISDS.Models
{
    public class CheckerResult
    {
        public int StateCode { get; set; }
        public Symptom[] ResultSymptoms { get; set; }
        public Disease ResultDisease { get; set; }
    }
}
