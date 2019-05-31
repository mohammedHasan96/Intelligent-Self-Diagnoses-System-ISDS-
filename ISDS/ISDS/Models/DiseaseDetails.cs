using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDS.Models
{
    public class DiseaseDetails
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public Nullable<int> DiseaseID { get; set; }
        public string Symptoms { get; set; }
        public string HowCommon { get; set; }
        public string Overview { get; set; }
        public string WhatToExpect { get; set; }
        public string MadeWorsenBy { get; set; }
        public string Community { get; set; }
        public string DidYouKnow { get; set; }
        public string Fact { get; set; }
        public string TreatmentsMayInclude { get; set; }
        public string SelfCare { get; set; }
        public string WorsenBy { get; set; }
        public string DiagnosedBy { get; set; }
        public string WhenToSeeYourDoctor { get; set; }
        public string QuestionsToAskYourDoctor { get; set; }
    }
}
