using System.Collections;

namespace Assets.Scripts.Managers
{
    using System.Collections.Generic;
    using Followers;
    using RandomEvents;
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

        [SerializeField]
        private LightbulbBalloon _lightbulbBalloonPrefab;
        [SerializeField]
        private RandomEventBalloon _randomEventBalloonPrefab;
        [SerializeField]
        private GameObject _bubblePrefab;

        private bool _bubbleCooldown;

        [SerializeField]
        private Canvas _balloonsCanvas;

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            this._bubbleCooldown = false;
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
            Vector3 spawnPos = Vector3.zero;
            if (Input.touchCount > 0)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                spawnPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (ray.origin == Vector3.back && ray.direction == Vector3.down) return;

            if (!_bubbleCooldown)
            {
                this._bubbleCooldown = true;
                GameObject go = (GameObject)Instantiate(this._bubblePrefab, new Vector3(spawnPos.x, spawnPos.y, 21), Quaternion.identity);
                go.transform.SetParent(this._balloonsCanvas.transform);
                Invoke("ResetBubbleCooldown", 0.3f);
            }

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

        public Vector3 NewPosition()
        {
            List<FollowerGroup> groups = FollowerManager.Instance.FollowerGroups;
            Vector3 respawnPos = Vector3.zero;
            for (int i = 0; i < groups.Count; i++)
            {
                if (i != groups.Count - 1 && Random.Range(0, groups.Count) != 0) continue;
                int randSide = Random.Range(1, 4);

                float minX, maxX, minY, maxY;
                switch (randSide)
                {
                    case 1: // left
                        //Debug.Log("Left side");
                        minX = groups[i].transform.position.x - this.OffsetPosX - groups[i].transform.localScale.x / this.DivideByScale;
                        maxX = groups[i].transform.position.x - groups[i].transform.localScale.x / this.DivideByScale;
                        minY = groups[i].transform.position.y - this.OffsetPosY - groups[i].transform.localScale.x / this.DivideByScale;
                        maxY = groups[i].transform.position.y + this.OffsetPosY + groups[i].transform.localScale.x / this.DivideByScale;
                        break;
                    case 2: // right
                        //Debug.Log("right side");
                        minX = groups[i].transform.position.x + groups[i].transform.localScale.x / this.DivideByScale;
                        maxX = groups[i].transform.position.x + this.OffsetPosX + groups[i].transform.localScale.x / this.DivideByScale;
                        minY = groups[i].transform.position.y - this.OffsetPosY - groups[i].transform.localScale.x / this.DivideByScale;
                        maxY = groups[i].transform.position.y + this.OffsetPosY + groups[i].transform.localScale.x / this.DivideByScale;
                        break;
                    case 3: // down
                            //Debug.Log("bottom side");
                            //minX = groups[i].transform.position.x - this.OffsetPosX - groups[i].transform.localScale.x / this.DivideByScale;
                            //maxX = groups[i].transform.position.x + this.OffsetPosX + groups[i].transform.localScale.x / this.DivideByScale;
                            //minY = groups[i].transform.position.y - this.OffsetPosY - groups[i].transform.localScale.x / this.DivideByScale;
                            //maxY = groups[i].transform.position.y - groups[i].transform.localScale.x / this.DivideByScale;


                        // we willen eigenlijk nooit shit beneden spawnen
                        // top
                        //Debug.Log("top side");
                        minX = groups[i].transform.position.x - this.OffsetPosX - groups[i].transform.localScale.x / this.DivideByScale;
                        maxX = groups[i].transform.position.x + this.OffsetPosX + groups[i].transform.localScale.x / this.DivideByScale;
                        minY = groups[i].transform.position.y + groups[i].transform.localScale.x / this.DivideByScale;
                        maxY = groups[i].transform.position.y + this.OffsetPosY + groups[i].transform.localScale.x / this.DivideByScale;
                        break;
                    default: // top
                        //Debug.Log("top side");
                        minX = groups[i].transform.position.x - this.OffsetPosX - groups[i].transform.localScale.x / this.DivideByScale;
                        maxX = groups[i].transform.position.x + this.OffsetPosX + groups[i].transform.localScale.x / this.DivideByScale;
                        minY = groups[i].transform.position.y + groups[i].transform.localScale.x / this.DivideByScale;
                        maxY = groups[i].transform.position.y + this.OffsetPosY + groups[i].transform.localScale.x / this.DivideByScale;
                        break;
                }

                //Debug.Log(string.Format("minX: {0} maxX: {1} minY: {2} maxY: {3}", minX, maxX, minY, maxY));
                respawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), -4.1f);
            }
            return respawnPos;
        }

        public void Respawn(Balloon balloon)
        {
            AudioManager.Instance.PlaySpawnObject();
            balloon.transform.position = this.NewPosition();
            balloon.gameObject.SetActive(true);
        }

        public void StartBalloons()
        {
            AudioManager.Instance.PlaySpawnObject();
            this._firstRandomEventBalloon.gameObject.SetActive(true);
        }

        public void SpawnLightbulb(bool respawn)
        {
            AudioManager.Instance.PlaySpawnObject();
            Vector3 pos = this.NewPosition();
            LightbulbBalloon go = (LightbulbBalloon)Instantiate(this._lightbulbBalloonPrefab, pos, Quaternion.identity);
            go.ShouldRespawn = respawn;
            go.transform.SetParent(this._balloonsCanvas.transform);
            if (!go.gameObject.activeSelf)
                go.gameObject.SetActive(true);
        }
        public void SpawnRandomEvent(bool respawn)
        {
            AudioManager.Instance.PlaySpawnObject();
            Vector3 pos = this.NewPosition();
            RandomEventBalloon go = (RandomEventBalloon)Instantiate(this._randomEventBalloonPrefab, pos, Quaternion.identity);
            go.ShouldRespawn = respawn;
            go.transform.SetParent(this._balloonsCanvas.transform);
            if (!go.gameObject.activeSelf)
                go.gameObject.SetActive(true);
        }
        private void ResetBubbleCooldown()
        {
            this._bubbleCooldown = false;
        }

    }
}
