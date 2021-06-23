using K2_betterware_Biostart_Assistance.Core.DTOs;
//using K2_betterware_Biostart_Assistance.Infrastructure.ExternaService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
//using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Net.Http;


namespace K2_betterware_Biostart_Assistance.Infrastructure.Service
{
    public class AssistanceService
    {
        public string config_biostart()
        {
            

            /////////// credenciales biostar /////////////////////////////////////
            string url_bio = "http://10.10.26.55:443/api/login";
            string usr_bio = "consultas";
            string id_bio = "Consulta1#";

            /////////// metodos ///////////////////////////////////////////////
            string usr = "http://10.10.26.55:443/api/users?group_id=1&limit=1&offset=1&order_by=user_id%3Afalse&userId=1&last_modified=10009";
            string serch = "http://10.10.26.55:443/api/events/search";
            string dev = "http://10.10.26.55:443/api/devices?monitoring_permission=false";
            string ev = "http://10.10.26.55:443/api/events/search";


            return url_bio + '*' + usr_bio + '*' + id_bio + '*' + usr + '*' + serch + '*' + dev + '*' + ev;
        }


        ////////////////////////////// metodos biostar /////////////////////////////////////////////////////////////
        public string token_bio()
        {
            string responseBody = "nada";
            string vv = "nada";
            string v2 = "nada";

            string url = config_biostart().Split('*')[0];
            string usr = config_biostart().ToString().Split('*')[1];
            string id = config_biostart().ToString().Split('*')[2];


        //  string url = "http://10.10.26.55:443/api/login";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Accept", "application/json");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
            //  string jsonb = "{\"User\":{\"login_id\":\"consultas\",\"password\":\"Consulta1#\"}}";
                string jsonb = "{\"User\":{\"login_id\":\"" + usr + "\",\"password\":\"" + id + "\"}}";
                streamWriter.Write(jsonb);
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) ;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd().ToString();
                            vv = response.Headers.Get(1).ToString();   //obtencion de los headers
                            //v2 = response.Headers.Get(0).ToString();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                responseBody = ex.ToString();
            }
            return vv;//responseBody+'_'+v2+'_'+vv;
        }

        public string user_bio()
        {

            string url = config_biostart().Split('*')[3];
            // string url = "http://10.10.26.55:443/api/users?group_id=1&limit=1&offset=1&order_by=user_id%3Afalse&userId=1&last_modified=10009";
            var myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            myRequest.Headers.Add("bs-session-id", token_bio());
            WebResponse response = myRequest.GetResponse();
            Stream strReader = response.GetResponseStream();
            StreamReader objReader = new StreamReader(strReader);
            string responseBody = objReader.ReadToEnd().ToString();
            return responseBody;
        }

        public string event_search_bio()
        {
            string responseBody = "nada";
            string vv = "nada";

            string url = config_biostart().Split('*')[4];
         // string url = "http://10.10.26.55:443/api/events/search";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("bs-session-id", token_bio());
            request.ContentType = "application/json";
            request.Headers.Add("Accept", "application/json");
            // limite, operador, valor fecha-hora //
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string jsonb = "{\"Query\":{\"limit\":51,\"conditions\":[{\"column\":\"datetime\",\"operator\":3,\"values\":[\"2019-07-30T15:00:00.000Z\"]}],\"orders\":[{\"column\":\"datetime\",\"descending\":false}]}}";
                streamWriter.Write(jsonb);
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) ;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd().ToString();
                            //vv = response.Headers.Get(1).ToString();   //obtencion de los headers
                            //v2 = response.Headers.Get(0).ToString();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                responseBody = ex.ToString();
            }
            return responseBody;
        }


        public string device_bio()
        {
            string responseBody = "nada";
            string vv = "nada";

            string url = config_biostart().Split('*')[5];
         // string url = "http://10.10.26.55:443/api/devices?monitoring_permission=false";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("bs-session-id", token_bio());
            request.ContentType = "application/json";
            request.Headers.Add("Accept", "application/json");
            WebResponse response = request.GetResponse();
            Stream strReader = response.GetResponseStream();
            StreamReader objReader = new StreamReader(strReader);
            responseBody = objReader.ReadToEnd().ToString();
            return responseBody;
        }


       

        public string[] bio_event_search(string tk_bio) //Tuple<string, string> bio_event_search() 
        {
            string responseBody = "nada";
            string vv = "nada";
            string cadena = "nada";

            string url = config_biostart().Split('*')[6];
         // string url = "http://10.10.26.55:443/api/events/search";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";


            //request.Headers.Add("bs-session-id", token_bio());
            request.Headers.Add("bs-session-id", tk_bio);


            request.ContentType = "application/json";
            request.Headers.Add("Accept", "application/json");
            // limite, operador, valor fecha-hora //
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //string jsonb = "{\"Query\":{\"limit\":51,\"conditions\":[{\"column\":\"datetime\",\"operator\":1,\"values\":[\"2019-07-30T15:00:00.000Z\"]}],\"orders\":[{\"column\":\"datetime\",\"descending\":false}]}}";
                string jsonb = "{\"Query\":{\"limit\":51,\"orders\":[{\"column\":\"datetime\",\"descending\":true}]}}";
                streamWriter.Write(jsonb);
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) ;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            //Data_event.raiz_data from_js = JsonSerializer.Deserialize<Data_event.raiz_data>(objReader.ReadToEnd().ToString());
                            responseBody = objReader.ReadToEnd().ToString();

                            //vv = response.Headers.Get(1).ToString();   //obtencion de los headers
                            //v2 = response.Headers.Get(0).ToString();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                responseBody = ex.ToString();
            }
            Data_event.raiz_data from_js = JsonSerializer.Deserialize<Data_event.raiz_data>(responseBody);
            Data_event.intern_row from_js_2 = JsonSerializer.Deserialize<Data_event.intern_row>(from_js.EventCollection);
            /////////////////////////////////////////
            String str = from_js_2.rows.ToString();
            //dynamic objects = JsonSerializer.Deserialize<dynamic>(str);
            dynamic objects = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(str);
            string[] respuestas = new string[objects.Count];
            int ct = 0;
            for (int i_el = 0; i_el < objects.Count; i_el++)
            {
                Data_event.intern_data from_js_3 = JsonSerializer.Deserialize<Data_event.intern_data>(objects[i_el].ToString());
                Data_event.intern_in_data from_js_dtime = JsonSerializer.Deserialize<Data_event.intern_in_data>(from_js_3.device_id);

                if (from_js_3.user_id_name != null)
                {
                    //respuestas[ct] = "fecha_:" + from_js_3.datetime.ToString() + "__Id_dispositivo_:" + from_js_dtime.id.ToString() + "__Nombre_:" + from_js_dtime.name.ToString() + '_' + from_js_3.user_id_name.ToString();
                    respuestas[ct] = from_js_3.datetime.ToString() + "/" + from_js_dtime.id.ToString() + "/" + from_js_dtime.name.ToString() + '/' + from_js_3.user_id_name.ToString();
                    ct += 1;
                    //Data_event.intern_in_data from_js_usr = JsonSerializer.Deserialize<Data_event.intern_in_data>(from_js_3.user_id_name);
                    //cadena = cadena + "fecha_:" + from_js_3.datetime.ToString() + "__Id_dispositivo_:" + from_js_dtime.id.ToString() + "__Nombre_:" + from_js_dtime.name.ToString()+'_'+ from_js_3.user_id_name.ToString();// +'_'+ from_js_dtime.user_id_name.ToString();// + '_' + usd_id.user_id.ToString() + '_' + usd_id.name.ToString();
                }
            }
            string[] salida = new string[ct - 1];
            Array.Copy(respuestas, 0, salida, 0, ct - 1);
            return salida;// +'_'+usd_id.user_id.ToString()+'_'+usd_id.name.ToString();      //objects[0].ToString(); //from_js_2.rows.ToString() + objects[0];// from_js_dtime.ToString() + '_' + from_js_dvid.id.ToString() + '_' + from_js_dvid.name.ToString();//from_js_2.rows.ToString();//from_js.EventCollection.ToString();//responseBody.ToString(); // from_js.ToString();//new Tuple<string, string>(from_js.ToString(), from_js.ToString());  //responseBody;
        }


        


    }
}
