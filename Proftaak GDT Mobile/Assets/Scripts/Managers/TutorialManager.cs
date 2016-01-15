using UnityEngine;
using Assets.Scripts.Managers;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private int stepCounter = 0;
    private string tutorialDescription;
    private string tutorialTitle;

    public bool inTutorial;

    public Sprite[] images;

    [SerializeField]
    private Image placeHolder;

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text description;

    [SerializeField]
    private GameObject tutorialPlane;

    private Step currentStep;

    [SerializeField]
    private GameObject prevButton;
    [SerializeField]
    private GameObject nextButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.tutorialPlane.active)
        {
            Time.timeScale = 0f;
        }

        this.prevButton.SetActive(this.stepCounter >= 1);

        switch (this.stepCounter)
        {
            case 0:
                {
                    this.currentStep = new Step("Er volg nu een korte uitleg over het spel!",
                        "", null);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;

                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 1:
                {
                    this.currentStep = new Step("Volgers",
    "Links boven in het scherm zie je hetzelfde icoon als hieronder! Dit icoon wordt gevolgd door een getal dit zijn je volgers. Je wilt zoveel mogelijk volgers behouden door het spel heen!", this.images[0]);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 2:
                {
                    this.currentStep = new Step("Vaardigheden",
"Onder aan het scherm zie je 3 icoontjes dit zijn je vaardigheden, deze hebben allemaal weer invloed op de random events waar we het eerder over hadden. Deze eerste staat voor je presentatie-vaardigheden.", this.images[1]);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 3:
                {
                    this.currentStep = new Step("Vaardigheden",
"Deze tweede staat er voor hoe krachtig je social-media vaardigheden zijn.", this.images[2]);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }

            case 4:
                {
                    this.currentStep = new Step("Vaardigheden",
"En tot slot staat dit laatste icoon ervoor hoe groot je kennis over je idee is.", this.images[3]);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 5:
                {
                    this.currentStep = new Step("Random Events",
"Random events zijn events in het spel waarbij je bepaalde keuzes moet maken om je idee te verspreiden. Deze beïnvloeden de groei van je idee enorm.",null);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 6:
                {
                    this.currentStep = new Step("Random Events",
"Als je dit symbool op de landkaart ziet verschijnen moet je er snel op drukken voor dat deze verdwijnt! Dit zal een random event starten.", this.images[4]);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 7:
                {
                    this.currentStep = new Step("Random Events",
"Ook als dit symbool verschijnt zal je deze snel moeten indrukken! Dit zal je volgers of vaardigheidspunten geven.", this.images[5]);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 8:
                {
                    this.currentStep = new Step("Verbeteringen",
"Jij kan natuurlijk aan jezelf en je idee werken. Onder aan het scherm zie je een rode knop met 'Vaardigheden' Als je deze knop indrukt kun je verschillende vaardigheden bekijken en verbeteren!", this.images[6]);

                    this.title.text = this.currentStep.titleStep;
                    this.description.text = this.currentStep.descriptionStep;
                    this.nextButton.GetComponentInChildren<Text>().text = "Volgende";
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            case 9:
                {
                    this.currentStep = new Step("That's all folks!",
"Je bent nu klaar om je idee te gaan verspreiden! \n Heel veel succes!", null);

                    this.title.text = currentStep.titleStep;
                    this.description.text = currentStep.descriptionStep;
                    this.nextButton.GetComponentInChildren<Text>().text = "Start";
                    if (this.currentStep.RequiresImage)
                    {
                        this.placeHolder.enabled = true;
                        this.placeHolder.sprite = this.currentStep.placeHolder;
                    }
                    else
                    {
                        this.placeHolder.enabled = false;
                    }
                    break;
                }
            default:
                {
                    this.tutorialPlane.SetActive(false);
                    this.stepCounter = 0;
                    Time.timeScale = 1f;
                    BalloonManager.Instance.StartBalloons();
                    FollowerManager.Instance.StartFollowers();
                    break;
                }

        }


    }

    public void NextStep()
    {
        this.stepCounter++;
        Debug.Log(this.stepCounter);
    }

    public void PrevStep()
    {
        this.stepCounter--;
    }


    private class Step
    {

        public string titleStep;
        public string descriptionStep;
        public Sprite placeHolder;
        public bool RequiresImage = true;

        public Step(string title, string description, Sprite placeHolder)
        {
            this.titleStep = title;
            this.descriptionStep = description;
            this.placeHolder = placeHolder;
            if (this.placeHolder == null)
            {
                this.RequiresImage = false;
            }
        }


    }


}




