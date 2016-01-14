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

        private void Update()
        {
            Ray ray = new Ray(Vector3.back, Vector3.down);
            if (Input.touchCount > 0)
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            else if (Input.GetMouseButtonDown(0))
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (ray.origin == Vector3.back && ray.direction == Vector3.down) return;

            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, new Vector3(0, 0, 2000f));
            //Debug.DrawRay(ray.origin, new Vector3(0, 0, 1500f), Color.green, 3f);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.GetComponent<LightbulbBalloon>() != null)
                    hit.transform.GetComponent<LightbulbBalloon>().OnButtonClicked();
                else  if (hit.transform.GetComponent<RandomEventBalloon>() != null)
                    hit.transform.GetComponent<RandomEventBalloon>().OnButtonClicked();

            }
        }

    }
}
