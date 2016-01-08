namespace Assets.Scripts.Managers
{
    using System.Collections.Generic;
    using Assets.Scripts.RandomEvents;
    using UnityEngine;

    public class BalloonManager : MonoBehaviour
    {
        public static BalloonManager Instance;


        public IList<LightbulbBalloon> LightBulbBalloons { get; set; }
        public IList<RandomEventBalloon> RandomEventsBalloons { get; set; }

        [SerializeField]
        private LightbulbBalloon _firstLightbulbBalloon;
        [SerializeField]
        private RandomEventBalloon _firstRandomEventBalloon;
        

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            this.LightBulbBalloons = new List<LightbulbBalloon>();
            this.RandomEventsBalloons = new List<RandomEventBalloon>();
            this.LightBulbBalloons.Add(this._firstLightbulbBalloon);
            this.RandomEventsBalloons.Add(this._firstRandomEventBalloon);
            this._firstRandomEventBalloon.gameObject.SetActive(true);
        }

    }
}
