using ISDS.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ISDS.Utils
{
    static class DataModel
    {
        public static Symptom[] Symptoms { get; private set; }
        public static Disease[] Diseases { get; private set; }
        public static DiseasesSymptoms[] Relations { get; private set; }
        //public static DiseaseDetails[] DiseasesDetails { get; private set; }
        public static bool IsFirstTime { get; private set; }
        public static bool IsReadyD { get; private set; } = false;
        public static bool IsReadyC { get; private set; } = false;

        static SQLiteConnection db;
        public static void Initialize()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ISDS.db3");
            if (!File.Exists(path))
            {
                db = new SQLiteConnection(path);
                IsFirstTime = true;
                db.CreateTable<Disease>();
                db.CreateTable<Symptom>();
                db.CreateTable<DiseasesSymptoms>();
                db.CreateTable<DiseaseDetails>();

                Diseases = APIInterface.GetDiseases();
                Symptoms = APIInterface.GetSymptoms();
                Relations = APIInterface.GetRelations();

                db.InsertAll(Diseases);
                db.InsertAll(Symptoms);
                db.InsertAll(Relations);
                db.InsertAll(APIInterface.GetDetails());
            }
            else
            {
                db = new SQLiteConnection(path);
                Symptoms = db.Table<Symptom>().ToArray();
                Diseases = db.Table<Disease>().ToArray();
                Relations = db.Table<DiseasesSymptoms>().ToArray();
                //DiseasesDetails = db.Table<DiseaseDetails>().ToArray();
            }
            IsReadyD = true;
            IsReadyC = true;
        }

        public static DiseaseDetails GetDetails(int diseaseId)
            => db.Table<DiseaseDetails>().FirstOrDefault(x => x.DiseaseID == diseaseId);

    }
}
