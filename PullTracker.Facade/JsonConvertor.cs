using System;



namespace PullTracker.Facade
{
    public static class JsonConvertor 
    {
        public static T JsonDeserializer<T>(string json)
        {

            try
            {
                return (T)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(T));

            }
            catch (Exception exception)
            {
                
                throw exception;
            }
        }
    }
}