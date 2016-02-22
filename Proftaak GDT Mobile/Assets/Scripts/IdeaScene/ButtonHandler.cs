using UnityEngine.SceneManagement;

namespace Assets.Scripts.IdeaScene
{
    using System;
    using Assets.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.UI;

    internal class ButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private InputField SpelerNaamTb;
        [SerializeField]
        private InputField IdeeNaamTb;
        [SerializeField]
        private Dropdown CategorieDropDrown;

        [SerializeField]
        private GameObject FoutmeldingPanel;

        [SerializeField]
        private Text ErrorText;

        public void StartButtonClicked()
        {
            String captiontext = this.CategorieDropDrown.captionText.text;
            Debug.Log(captiontext);

            if (this.SpelerNaamTb.text.IsNullEmptyOrWhitespace())
            {
                this.ShowFoutmeldingCanvas("De Spelernaam mag niet leeg zijn");
                return;
            }
            if (this.IdeeNaamTb.text.IsNullEmptyOrWhitespace())
            {
                this.ShowFoutmeldingCanvas("De naam van je idee mag niet leeg zijn");
                return;
            }
            if (this.CategorieDropDrown.captionText.text == "Kies een categorie")
            {
                this.ShowFoutmeldingCanvas("Kies een categorie");
                return;
            }
            Player.Instance = new Player();
            Player.Instance.PlayerName = this.SpelerNaamTb.text;
            Player.Instance.IdeaName = this.IdeeNaamTb.text;
            Player.Instance.Category = (IdeaCategory)Enum.Parse(typeof(IdeaCategory), this.CategorieDropDrown.captionText.text.Replace(" ", "_"));
            SceneManager.LoadScene("Nederland");
        }

        private void ShowFoutmeldingCanvas(string text)
        {
            this.ErrorText.text = text;
            this.FoutmeldingPanel.SetActive(true);
        }

        public void ButtonCloseClicked()
        {
            this.FoutmeldingPanel.SetActive(false);
        }

        public void BackButtonClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
