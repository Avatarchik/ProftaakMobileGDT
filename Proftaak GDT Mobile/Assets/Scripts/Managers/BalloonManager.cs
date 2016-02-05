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

        public int currentRadius;

        public int growFactor;

        public SpawnGrid spwnGrd;

        public SpawnPoint startingPoint;
        
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

        [SerializeField]
        private Canvas _balloonsCanvas;

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

            GameObject go = (GameObject)Instantiate(this._bubblePrefab, new Vector3(spawnPos.x,spawnPos.y,21), Quaternion.identity);
            go.transform.SetParent(this._balloonsCanvas.transform);

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

        public Vector3 NewPosition(bool setTaken)
        {
            Vector2 pos = this.NewPosition(currentRadius, setTaken);
            while (pos == Vector2.zero)
            {
                currentRadius += growFactor;
                pos = this.NewPosition(currentRadius, setTaken);
            }

            return new Vector3(pos.x, pos.y, -4.1f);            
        }


        public Vector2 NewPosition(int radius, bool setTaken)
        {
          return  spwnGrd.GetRandomLocation(setTaken, spwnGrd.GetLocationsClosestToCenter(radius, this.startingPoint.location, true), setTaken);
        }

        public void Respawn(Balloon balloon)
        {
            AudioManager.Instance.PlaySpawnObject();
            balloon.transform.position = this.NewPosition(balloon is LightbulbBalloon);
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
            Vector3 pos = this.NewPosition(true);
            LightbulbBalloon go = (LightbulbBalloon)Instantiate(this._lightbulbBalloonPrefab, pos, Quaternion.identity);
            go.ShouldRespawn = respawn;
            go.transform.SetParent(this._balloonsCanvas.transform);
            if (!go.gameObject.activeSelf)
                go.gameObject.SetActive(true);
        }
        public void SpawnRandomEvent(bool respawn)
        {
            AudioManager.Instance.PlaySpawnObject();
            Vector3 pos = this.NewPosition(false);
            RandomEventBalloon go = (RandomEventBalloon)Instantiate(this._randomEventBalloonPrefab, pos, Quaternion.identity);
            go.ShouldRespawn = respawn;
            go.transform.SetParent(this._balloonsCanvas.transform);
            if (!go.gameObject.activeSelf)
                go.gameObject.SetActive(true);
        }

    }
}
