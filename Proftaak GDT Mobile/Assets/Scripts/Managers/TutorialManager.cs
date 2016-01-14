using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private int stepCounter = 0;
    private string tutorialDescription;
    private string tutorialTitle;

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text description;

    [SerializeField]
    private GameObject tutorialPlane;

    private Step currentStep;

    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        prevButton.enabled = stepCounter >= 1;

        switch (stepCounter)
        {
            case 0:
                {
                    currentStep = new Step("Skills",
                        "These are your skills. These skills are here for you to mollest and stuff.");

                    this.title.text = currentStep.titleStep;
                    this.description.text = currentStep.descriptionStep;
                    break;
                }
            case 1:
                {
                    currentStep = new Step("Enhancements",
    "These are your enhancements.");

                    this.title.text = currentStep.titleStep;
                    this.description.text = currentStep.descriptionStep;
                    break;
                }
            case 2:
                {
                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    break;
                }
            default:
                {
                    this.tutorialPlane.SetActive(false);
                    stepCounter = 0;
                    break;
                }

        }


    }

    public void NextStep()
    {
        stepCounter++;
        Debug.Log(stepCounter);
    }

    public void PrevStep()
    {
        stepCounter--;
    }


    private class Step
    {

        public string titleStep;
        public string descriptionStep;

        public Step(string title, string description)
        {
            this.titleStep = title;
            this.descriptionStep = description;
        }


    }


}




