using ISDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISDS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VDiseaseDetials : TabbedPage
    {
        public VDiseaseDetials(Disease disease, DiseaseDetails details)
        {
            InitializeComponent();
            //Disease
            Details.DiseaseName.Text = disease.DiseaseName;
            Details.Community.Text = details?.Community;
            Details.DidYouKnow.Text = details?.DidYouKnow;
            Details.HowCommon.Text = details?.HowCommon;
            Details.MadeWorsenBy.Text = details?.MadeWorsenBy;
            Details.Symptoms.Text = details?.Symptoms;
            Details.WhatToExpect.Text = details?.WhatToExpect;
            //Treatment
            Treatment.DiseaseName.Text = disease.DiseaseName;
            Treatment.DiagnosedBy.Text = details?.DiagnosedBy;
            Treatment.QuestionsToAskYourDoctor.Text = details?.QuestionsToAskYourDoctor;
            Treatment.SelfCare.Text = details?.SelfCare;
            Treatment.TreatmentsMayInclude.Text = details?.TreatmentsMayInclude;
            Treatment.WhenToSeeYourDoctor.Text = details?.WhenToSeeYourDoctor;
            Treatment.WorsenBy.Text = details?.WorsenBy;
        }
    }
}