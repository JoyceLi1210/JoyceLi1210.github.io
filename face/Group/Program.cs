using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CSHttpClientSample
{

    static class Program
    {
        const string mykey= "0a368f47a3b74e8faf8b5df5048540d7";
        private static string results;
        private static string faceId_;
        private static string personId_;
        private static string confidence_;


        static void Main()
        {
            
            //PersonGroup_Create
            //PersonGroup_Create();

            //PersonGroup Person - Create
            //PersonGroup_Person_Create();

            //PersonGroup Person -Add Face
            //PersonGroup_Person_Add_Face();

            //PersonGroup - Train
           // PersonGroup_Train();

            //PersonGroup - Get Training Status
            //PersonGroup_Get_Training_Status();
          
            //PersonGroup Person - Get Face
            //PersonGroup_Person_Get_Face();
            
            //Face_Detect
            //Face_Detect();


            //Console.WriteLine("Hit ENTER to exit...");
            //Console.ReadLine();
            while (true)
            {

                // Get the path and filename to process from the user.
                Console.WriteLine("Detect faces:");
                Console.Write("Enter image path : ");
                string imageFilePath = Console.ReadLine();

                if (File.Exists(imageFilePath))
                {
                    try
                    {
                        Face_Detect(imageFilePath);
                        Console.WriteLine("\nWait a moment for the results to appear.\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n" + e.Message + "\nPress Enter to exit...\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid file path.\nPress Enter to exit...\n");
                }
                Console.ReadLine();
            }
        }

        static async void Face_Detect(string imageFilePath)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "age,gender,emotion";
            queryString["recognitionModel"] = "recognition_01";
            queryString["returnRecognitionModel"] = "false";
            queryString["detectionModel"] = "detection_01";
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?" + queryString;

            HttpResponseMessage response;

            // Request body
            //byte[] byteData = Encoding.UTF8.GetBytes("{\"url\": \"https://vignette.wikia.nocookie.net/mrbean/images/4/4b/Mr_beans_holiday_ver2.jpg/revision/latest?cb=20181130033425\"}");
            //byte[] byteData = Encoding.UTF8.GetBytes("{\"url\":\"" + phtotUrl + "\"}");
            byte[] byteData = GetImageAsByteArray(imageFilePath);


            using (var content = new ByteArrayContent(byteData))
            {
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
            }

            //抓faceId 給 Face_Identify
            JArray arr = JArray.Parse(await response.Content.ReadAsStringAsync());
            foreach (JObject obj in arr.Children<JObject>())
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var rcvdData = JsonConvert.DeserializeObject<RootObject>(obj.ToString(), settings);
                faceId_ = rcvdData.faceId;
            }

            results = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Face_Detect\n" + JsonPrettyPrint(results)+"\n");

            //Face_Identify
            Face_Identify(faceId_);


        }

        // Returns the contents of the specified file as a byte array.
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }


        static async void Face_Identify(string faceId_)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/identify?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"faceIds\":[\""+faceId_+"\"]," +
                "                                       \"personGroupId\":\"bean\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }
            results = await response.Content.ReadAsStringAsync();
            
            JArray arr = JArray.Parse(await response.Content.ReadAsStringAsync());
            try
            {
                foreach (JObject obj in arr.Children<JObject>())
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    var rcvdData = JsonConvert.DeserializeObject<RootObject>(obj.ToString(), settings);

                    personId_ = rcvdData.candidates[0].personId;
                    confidence_ = rcvdData.candidates[0].confidence;
                    results = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Face_Identify\n" + JsonPrettyPrint(results) + "\n");

                    //PersonGroup Person -Get
                    PersonGroup_Person_Get(personId_, confidence_);


                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("not found");
            }
            
        }

        public class RootObject
        {
            public List<Candidates> candidates { get; set; }
            public string faceId { get; set; }
        }
        public class Candidates
        {
            public string personId { get; set; }
            public string confidence { get; set; }
        }


        static async void PersonGroup_Create()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers  
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/bean?" + queryString;  //personGroupId=bean

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"name\": \"group1\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
                
            }
            //string contentstring = await response.Content.ReadAsStringAsync(); 
            //Console.WriteLine(JsonPrettyPrint(contentstring));
        }

        static async void PersonGroup_Person_Create()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/bean/persons?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"name\": \"Mr.Bean\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

            }
             results = await response.Content.ReadAsStringAsync();
             Console.WriteLine("PersonGroup_Person_Create\n" + JsonPrettyPrint(results));

        }

        static async void PersonGroup_Person_Get(string personId_, string confidence_)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/bean/persons/"+ personId_ +"?" + queryString;

            var response = await client.GetAsync(uri);
            results = await response.Content.ReadAsStringAsync();
            Console.WriteLine("PersonGroup_Person_Get\n" + JsonPrettyPrint(results) + "\n");

            
            Name rb = JsonConvert.DeserializeObject<Name>(results);
            Console.WriteLine("name = " + rb.name);
            Console.WriteLine("confidence = " + confidence_);
        }

        public class Name
        {
            public string name { get; set; }
        }

        static async void PersonGroup_Person_Add_Face()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            // Request parameters
           // queryString["userData"] = "{string}";
           // queryString["targetFace"] = "{string}";
            //queryString["detectionModel"] = "detection_01";
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/bean/persons/5f704329-aab9-4edd-b578-c1c177be2532/persistedFaces?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{ \"url\": \"https://th.thgim.com/migration_catalog/article10268775.ece/alternates/FREE_660/bean\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue( "application/json" );
                response = await client.PostAsync(uri, content);
                Console.WriteLine(response);
            }
            results = await response.Content.ReadAsStringAsync();
            Console.WriteLine("PersonGroup_Person_Add_Face\n"+JsonPrettyPrint(results));

        }

        static async void PersonGroup_Train()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/bean/train?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }
            results = await response.Content.ReadAsStringAsync();
            Console.WriteLine("PersonGroup_Train\n"+JsonPrettyPrint(results));
        }


        static async void PersonGroup_Get_Training_Status()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/bean/training?" + queryString;

            var response = await client.GetAsync(uri);
            results = await response.Content.ReadAsStringAsync();
            Console.WriteLine("PersonGroup_Get_Training_Status\n" + JsonPrettyPrint(results));
        }


        static async void PersonGroup_Person_Get_Face()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", mykey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/bean/persons/5f704329-aab9-4edd-b578-c1c177be2532/persistedFaces/d37686e5-7985-49cf-ae5c-37e8d317df2b?" + queryString;

            var response = await client.GetAsync(uri);

            results = await response.Content.ReadAsStringAsync();
            Console.WriteLine("PersonGroup_Person_Get_Face\n" + JsonPrettyPrint(results));
        }


        // Formats the given JSON string by adding line breaks and indents.
        static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            break;
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}