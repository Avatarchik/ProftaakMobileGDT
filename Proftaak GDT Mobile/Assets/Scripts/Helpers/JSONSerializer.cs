using System;
using System.Collections.Generic;
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

        public static RandomEventsList ReadFromFile(string fileName)
        {
            fileName = fileName.Trim();

            if (fileName.IsNullEmptyOrWhitespace())
            {
                throw new Exception("Cannot read from empty fileName");
            }

            TextAsset textFile = Resources.Load<TextAsset>(fileName);

            if (textFile != null)
            {
                return JsonUtility.FromJson<RandomEventsList>(textFile.text);
            }

            return new RandomEventsList();
        }
    }
}