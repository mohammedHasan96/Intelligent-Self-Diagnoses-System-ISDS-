using ISDS.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ISDS.Utils
{
    public static class APIInterface
    {

        public static Disease[] GetDiseases()
            => GetResult<Disease>(Values.APIIndex);

        public static Symptom[] GetSymptoms()
            => GetResult<Symptom>(Values.APISymptoms);

        public static DiseasesSymptoms[] GetRelations()
            => GetResult<DiseasesSymptoms>(Values.APIRelations);

        public static DiseaseDetails[] GetDetails()
           => GetResult<DiseaseDetails>(Values.APIDetailsAll);

        public static CheckerResult Predict(int[] ids)
        {
            try
            {
                var client = new HttpClient();
                var str = Newtonsoft.Json.JsonConvert.SerializeObject(ids);
                var cont = new StringContent(str);
                cont.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(Values.APIPredict, cont).Result.Content.ReadAsStringAsync().Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<CheckerResult>(response);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }
        }

        private static T[] GetResult<T>(string url)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(response);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }
        }

    }
}