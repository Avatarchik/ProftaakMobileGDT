using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.RandomEvents;
using Newtonsoft.Json;
#if UNITY_EDITOR
using UnityEditor;
#endif
#if UNITY_EDITOR_64
using UnityEditor;
#endif
using UnityEngine;

namespace Assets.Scripts.Helpers
{
#if UNITY_EDITOR_64
    [InitializeOnLoad]
#endif
    public static class JsonSerializer
    {
        static JsonSerializer()
        {
            string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process);

            string dllPath = Application.dataPath + Path.DirectorySeparatorChar + "JSON";

            if (!string.IsNullOrEmpty(currentPath) && !currentPath.Contains(dllPath))
            {
                Environment.SetEnvironmentVariable("PATH", currentPath + Path.PathSeparator + dllPath, EnvironmentVariableTarget.Process);

                Debug.Log(Environment.GetEnvironmentVariable("PATH"));
            }
        }

        private class RandomEventsList
        {
            public readonly List<RandomEvent> RandomEvents;

            public RandomEventsList()
            {
                this.RandomEvents = new List<RandomEvent>();
            }
        }

        public static List<RandomEvent> JsonToRandomEventsList(string reTextParam)
        {
            try
            {
                string reText = reTextParam;

                if (!reTextParam.ToLower().StartsWith("{"))
                {
                    reText = reTextParam.Remove(0, reText.IndexOf("{", StringComparison.Ordinal));
                }

                RandomEventsList reList = JsonConvert.DeserializeObject<RandomEventsList>(reText);

                return reList.RandomEvents.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string RandomEventsListToJson(List<RandomEvent> reListParam)
        {
            try
            {
                RandomEventsList reList = new RandomEventsList();

                foreach (RandomEvent re in reListParam)
                {
                    reList.RandomEvents.Add(re);
                }

                string reJson = JsonConvert.SerializeObject(reList);

                return reJson;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<RandomEvent> ReadFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Cannot read from empty directory");
            }

            string path = Path.GetDirectoryName(filePath);

            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("Cannot read from empty directory");
            }

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                string json = File.ReadAllText(filePath).Trim();

                if (!json.IsNullEmptyOrWhitespace())
                {
                    return JsonSerializer.JsonToRandomEventsList(json);
                }
            }

            return new List<RandomEvent>();
        }

        public static void WriteToFile(string filePath, string text)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Cannot write to empty directory");
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