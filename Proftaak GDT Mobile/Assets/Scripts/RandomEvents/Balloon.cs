﻿namespace Assets.Scripts.RandomEvents
{
    using Assets.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class Balloon : MonoBehaviour
    {
        public float MinTimeToDestroy = int.MaxValue -1;
        public float MaxTimeToDestroy = int.MaxValue;

        public float MinRespawnTime = 6f;
        public float MaxRespawnTime = 13f;


        private const bool _LOG = true;

        public bool DoAnimation = true;
        public float MaxScale = 0.1f;
        public float ScaleStep = 0.1f;

        private float _startSizeX, _startSizeY;
        private bool _scalingUp;

        public bool ShouldRespawn;

        // ReSharper disable once UnusedMember.Local
        private void OnEnable()
        {
            this.Invoke("DisableBalloon", Random.Range(this.MinTimeToDestroy, this.MaxTimeToDestroy));
            this.MinTimeToDestroy = 4f;
            this.MaxTimeToDestroy = 8f;
            this._startSizeX = this.transform.localScale.x;
            this._startSizeY = this.transform.localScale.y;
            LightbulbBalloon asLightbulb = this as LightbulbBalloon;
            if (asLightbulb != null && BalloonManager.Instance.LightBulbBalloons.Contains(asLightbulb))
            {
                BalloonManager.Instance.LightBulbBalloons.Add(asLightbulb);
                Debug.Log("Balloon: added to Lightbulbs");
            }

            RandomEventBalloon asRandomEvent = this as RandomEventBalloon;
            if (asRandomEvent != null && BalloonManager.Instance.RandomEventsBalloons.Contains(asRandomEvent))
            {
                BalloonManager.Instance.RandomEventsBalloons.Add(asRandomEvent);
                Debug.Log("Balloon: added to RandomEvents");
            }
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (this.DoAnimation)
                this.Animate();
        }

        private void Animate()
        {
            Vector3 localScale = this.transform.localScale;
            if (!(this.MaxScale > 0)) return;
            if (this._scalingUp)
            {
                if (this.transform.localScale.x > this._startSizeX + this.MaxScale)
                    this._scalingUp = false;
                else
                    this.transform.localScale = new Vector3(localScale.x + (this.ScaleStep * Time.deltaTime), localScale.y + (this.ScaleStep * Time.deltaTime), localScale.z);
            }
            else
            {
                if (this.transform.localScale.x < this._startSizeX - this.MaxScale)
                    this._scalingUp = true;
                else
                    this.transform.localScale = new Vector3(localScale.x - (this.ScaleStep * Time.deltaTime), localScale.y - (this.ScaleStep * Time.deltaTime), localScale.z);
            }
        }

        // ReSharper disable once UnusedMember.Local
        public void DisableBalloon()
        {
            // DisableBallon is called in OnEnable but also on Click, so we don't want it to disable twice, maybe it respawns very shortly after disabled.
            if (!this.gameObject.activeInHierarchy) return;
            if (_LOG)
                Debug.Log("Disabling balloon");
            this.transform.localScale = new Vector3(this._startSizeX, this._startSizeY, this.transform.localScale.z);
            this.gameObject.SetActive(false);
            if (this.ShouldRespawn)
                this.Invoke("Respawn", Random.Range(this.MinRespawnTime, this.MaxRespawnTime));
        }

        public abstract void OnButtonClicked();


        // ReSharper disable once UnusedMember.Local
        private void Respawn()
        {
            Debug.Log("Respawned Balloon");
            BalloonManager.Instance.Respawn(this);
        }
    }
}
