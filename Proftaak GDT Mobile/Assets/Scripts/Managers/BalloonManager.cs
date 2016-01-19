namespace Assets.Scripts.Managers
{
    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Followers;
    using Assets.Scripts.RandomEvents;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class BalloonManager : MonoBehaviour
    {
        public static BalloonManager Instance;

        public float OffsetPosX = 15f;
        public float OffsetPosY = 15f;
        public float DivideByScale = 0.03f;

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
        }

        // ReSharper disable once UnusedMember.Local
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
                else if (hit.transform.GetComponent<RandomEventBalloon>() != null)
                    hit.transform.GetComponent<RandomEventBalloon>().OnButtonClicked();

            }
        }

        public void Respawn(Balloon balloon)
        {
            List<FollowerGroup> groups = FollowerManager.Instance.FollowerGroups;
            Vector3 respawnPos = Vector3.zero;
            for (int i = 0; i < groups.Count; i++)
            {
                if (i == groups.Count - 1 || Random.Range(0, groups.Count) == 0)
                {
                    int randSide = Random.Range(1, 4);
                    
                    float minX, maxX, minY, maxY;
                    randSide = 4;
                    switch (randSide)
                    {
                        case 1: // left
                            Debug.Log("Left side");
                            minX = groups[i].transform.position.x - this.OffsetPosX - groups[i].transform.localScale.x / this.DivideByScale;
                            maxX = groups[i].transform.position.x - groups[i].transform.localScale.x / this.DivideByScale;
                            minY = groups[i].transform.position.y - this.OffsetPosY - groups[i].transform.localScale.x / this.DivideByScale;
                            maxY = groups[i].transform.position.y + this.OffsetPosY + groups[i].transform.localScale.x / this.DivideByScale;
                            break;
                        case 2: // right
                            Debug.Log("right side");
                            minX = groups[i].transform.position.x + groups[i].transform.localScale.x / this.DivideByScale;
                            maxX = groups[i].transform.position.x + this.OffsetPosX+  groups[i].transform.localScale.x / this.DivideByScale;
                            minY = groups[i].transform.position.y - this.OffsetPosY - groups[i].transform.localScale.x / this.DivideByScale;
                            maxY = groups[i].transform.position.y + this.OffsetPosY + groups[i].transform.localScale.x / this.DivideByScale;
                            break;
                        case 3: // down
                            Debug.Log("bottom side");
                            minX = groups[i].transform.position.x - this.OffsetPosX - groups[i].transform.localScale.x / this.DivideByScale;
                            maxX = groups[i].transform.position.x + this.OffsetPosX + groups[i].transform.localScale.x / this.DivideByScale;
                            minY = groups[i].transform.position.y - this.OffsetPosY - groups[i].transform.localScale.x / this.DivideByScale;
                            maxY = groups[i].transform.position.y - groups[i].transform.localScale.x / this.DivideByScale;
                            break;
                       default: // top
                            Debug.Log("top side");
                            minX = groups[i].transform.position.x - this.OffsetPosX - groups[i].transform.localScale.x / this.DivideByScale;
                            maxX = groups[i].transform.position.x + this.OffsetPosX + groups[i].transform.localScale.x / this.DivideByScale;
                            minY = groups[i].transform.position.y + groups[i].transform.localScale.x / this.DivideByScale;
                            maxY = groups[i].transform.position.y + this.OffsetPosY + groups[i].transform.localScale.x / this.DivideByScale;
                            break;
                    }
                    
                    Debug.Log(string.Format("minX: {0} maxX: {1} minY: {2} maxY: {3}", minX, maxX, minY, maxY));
                    respawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), balloon.transform.position.z);
                }
            }
            balloon.transform.position = respawnPos;
            balloon.gameObject.SetActive(true);
        }

        public void StartBalloons()
        {
            this._firstRandomEventBalloon.gameObject.SetActive(true);
        }
    }
}
