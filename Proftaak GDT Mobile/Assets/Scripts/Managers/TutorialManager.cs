using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class TutorialManager : MonoBehaviour
    {
        private int _stepCounter = 0;
        private string _tutorialDescription;
        private string _tutorialTitle;

        public bool InTutorial;

        public Sprite[] Images;

        [SerializeField]
        private Image _placeHolder;

        [SerializeField]
        private Text _title;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private GameObject _tutorialPlane;

        private Step _currentStep;

        [SerializeField]
        private GameObject _prevButton;
        [SerializeField]
        private GameObject _nextButton;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (this._tutorialPlane.active)
            {
                Time.timeScale = 0f;
            }

            this._prevButton.SetActive(this._stepCounter >= 1);

            switch (this._stepCounter)
            {
                case 0:
                    {
                        this._currentStep = new Step("Er volg nu een korte uitleg over het spel!", "", null);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 1:
                    {
                        this._currentStep = new Step("Volgers", "Links boven in het scherm zie je hetzelfde icoon als hieronder. Dit icoon wordt gevolgd door een getal wat je volgers vertegenwoordigd. De bedoeling is om zoveel mogelijk volgers te behouden door het spel heen, om uiteindelijk opgemerkt te worden door de organisatie van TEDx Veghel!", this.Images[0]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 2:
                    {
                        this._currentStep = new Step("Vaardigheden", "Onder aan het scherm zie je 3 icoontjes die je vaardigheden voorstellen. Deze vaardigheden hebben allemaal invloed op de random events die door het spel heen verschijnen, maar daar gaan we het later nog over hebben. Deze eerste staat voor je presentatie-vaardigheden.", this.Images[1]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;

                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 3:
                    {
                        this._currentStep = new Step("Vaardigheden", "Deze tweede staat voor hoe krachtig je social-media vaardigheden zijn.", this.Images[2]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }

                case 4:
                    {
                        this._currentStep = new Step("Vaardigheden", "En tot slot staat dit laatste icoon ervoor hoe groot je kennis over je idee is.", this.Images[3]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 5:
                    {
                        this._currentStep = new Step("Random Events", "Random events zijn events in het spel waarbij je bepaalde keuzes moet maken om je idee te verspreiden. Deze beïnvloeden de groei van je idee enorm.", null);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 6:
                    {
                        this._currentStep = new Step("Random Events", "Als je dit symbool op de landkaart ziet verschijnen moet je er snel op drukken voor dat deze verdwijnt! Dit zal een random event starten.", this.Images[4]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 7:
                    {
                        this._currentStep = new Step("Random Events", "Ook als dit symbool verschijnt zal je deze snel moeten indrukken! Dit zijn potentiële volgers die je kan overhalen om je idee te steunen.", this.Images[5]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 8:
                    {
                        this._currentStep = new Step("Verbeteringen", "Je kan natuurlijk aan jezelf en je idee werken. Onder aan het scherm zie je een rode knop met 'Vaardigheden'. Als je deze knop indrukt kun je verschillende vaardigheden bekijken en verbeteren!", this.Images[6]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 9:
                    {
                        this._currentStep = new Step("Verbeteringen", "Om aan jezelf te werken heb je ervaringspunten nodig. Je kunt door verschillende random events en keuzes te maken deze punten verdienen!", this.Images[7]);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                case 10:
                    {
                        this._currentStep = new Step("That's all folks!", "Je bent nu klaar om je idee te gaan verspreiden! \n Heel veel succes!", null);

                        this._title.text = this._currentStep.TitleStep;
                        this._description.text = this._currentStep.DescriptionStep;
                        this._nextButton.GetComponentInChildren<Text>().text = "Start";

                        if (this._currentStep.RequiresImage)
                        {
                            this._placeHolder.enabled = true;
                            this._placeHolder.sprite = this._currentStep.PlaceHolder;
                        }
                        else
                        {
                            this._placeHolder.enabled = false;
                        }
                        break;
                    }
                default:
                    {
                        this._tutorialPlane.SetActive(false);
                        this._stepCounter = 0;
                        Time.timeScale = 1f;
                        BalloonManager.Instance.StartBalloons();
                        FollowerManager.Instance.StartFollowers();
                        break;
                    }

            }


        }

        public void NextStep()
        {
            this._stepCounter++;
            //Debug.Log(this._stepCounter);
        }

        public void PrevStep()
        {
            this._stepCounter--;
        }


        private class Step
        {
            public readonly string TitleStep;
            public readonly string DescriptionStep;
            public readonly Sprite PlaceHolder;
            public readonly bool RequiresImage = true;

            public Step(string title, string description, Sprite placeHolder)
            {
                this.TitleStep = title;
                this.DescriptionStep = description;
                this.PlaceHolder = placeHolder;

                if (this.PlaceHolder == null)
                {
                    this.RequiresImage = false;
                }
            }

        }
    }
}
