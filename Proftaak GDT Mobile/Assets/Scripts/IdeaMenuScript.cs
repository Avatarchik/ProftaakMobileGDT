using UnityEngine;
using UnityEngine.UI;

public class IdeaMenuScript : MonoBehaviour
{

    [SerializeField]
    private GameObject _tutorialPanel;

    [SerializeField]
    private GameObject _tutorialBackground;

    [SerializeField]
    private Text _titleText;

    [SerializeField]
    private Text _descriptionText;

    private int _stepCounter = 0;

    public void ButtonClick()
    {
        this._stepCounter++;

        if (this._stepCounter == 1)
        {
            this._titleText.text = "Doel";
            this._descriptionText.text = "Je hebt een idee en je wil dit verspreiden. Met genoeg volgers mag je op het TEDxVeghel evenement spreken. Je kunt hier je naam, de naam van je idee en de categorie van je idee invullen.";
        }
        else
        {
            this._tutorialPanel.SetActive(false);
            this._tutorialBackground.SetActive(false);
        }
    }
}
