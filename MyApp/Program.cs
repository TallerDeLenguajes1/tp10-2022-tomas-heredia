using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using TP10;


        Root civilizaciones;
        var url = "https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
        var request = (HttpWebRequest) WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try{
            using(WebResponse respuesta = request.GetResponse()){
                using(Stream StreamReader = respuesta.GetResponseStream()){
                    if (StreamReader != null)
                    {
                        using (StreamReader objReader = new StreamReader(StreamReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            civilizaciones = JsonSerializer.Deserialize<Root>(responseBody);
                            foreach (Civilization civilization in civilizaciones.Civilizations)
                            {
                                Console.WriteLine(civilization.Name);
                            }
                        }
                    }else
                    {
                        Console.WriteLine("No Responde");
                    }
                }
            }
            
        }catch(WebException e){
                Console.WriteLine(e.ToString());
    }


