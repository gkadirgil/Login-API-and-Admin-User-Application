using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoginApplication.Infrustructor
{
    public class BaseController : Controller
    {
        public readonly string BaseUrl = "https://localhost:44398/api/";
        public T Get<T>(string endPoint)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(BaseUrl + endPoint).Result;
                return CheckResponse<T>(response);
            }
        }
        public T Post<T>(string endPoint, object data)
        {
            var requestData = JsonConvert.SerializeObject(data);
            var content = new StringContent(requestData, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(BaseUrl + endPoint, content).Result;
                return CheckResponse<T>(response);
            }
        }
        public T CheckResponse<T>(HttpResponseMessage data)
        {
            try
            {
                var responseContent = data.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(responseString);
                return result;
            }
            catch (Exception ex)
            {
                var ExData = ex;
            }
            return default;
        }
    }
}
