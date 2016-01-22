using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace RandomEventGenerator
{
    public static class JsonSerializer
    {
        [Serializable]
        public class RandomEventsList
        {
            public List<RandomEvent> RandomEvents;

            public RandomEventsList()
            {
                this.RandomEvents = new List<RandomEvent>();
            }
        }

        public static RandomEventsList JsonToRandomEventsList(string randomEventsText)
        {
            try
            {
                return JsonConvert.DeserializeObject<RandomEventsList>(randomEventsText);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string RandomEventsListToJson(List<RandomEvent> randomEventsList)
        {
            try
            {
                return JsonConvert.SerializeObject(new RandomEventsList
                {
                    RandomEvents = randomEventsList
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static RandomEventsList ReadFromFile(string filePath, string filename)
        {
            string totalPath = Path.Combine(filePath, filename);

            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Cannot read from empty directory");
            }

            string path = Path.GetDirectoryName(filePath);

            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("Cannot read from empty directory");
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (!File.Exists(totalPath))
            {
                File.Create(totalPath).Close();
            }
            else
            {
                string json = File.ReadAllText(totalPath).Trim();

                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonToRandomEventsList(json);
                }
            }

            return new RandomEventsList();
        }

        public static void WriteToFile(string filePath, string text)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Cannot write to empty file");
            }

            string path = Path.GetDirectoryName(filePath);

            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("Cannot write to empty directory");
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(filePath);
            }

            File.WriteAllText(filePath, text);
        }
    }
}