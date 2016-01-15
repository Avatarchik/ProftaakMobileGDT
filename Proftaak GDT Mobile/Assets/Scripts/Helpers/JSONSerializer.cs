using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.RandomEvents;
using UnityEngine;

namespace Assets.Scripts.Helpers
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

        public static RandomEventsList ReadFromFile(string filePath)
        {
            filePath = filePath.Trim();

            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Cannot read from empty filepath");
            }

            if (File.Exists(filePath))
            {
                return JsonUtility.FromJson<RandomEventsList>(File.ReadAllText(filePath));
            }

            return new RandomEventsList();
        }
    }
}