namespace Assets.Scripts.IdeaScene
{
    using System;
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
        
        
        public void StartButtonClicked()
        {
            String captiontext = this.CategorieDropDrown.captionText.text;
            Debug.Log(captiontext);

            if(!this.SpelerNaamTb.text.IsNullEmptyOrWhitespace() && !this.IdeeNaamTb.text.IsNullEmptyOrWhitespace() && this.CategorieDropDrown.captionText.text != "Kies een categorie")
            {
                Player.Instance.PlayerName= this.SpelerNaamTb.text;
                Player.Instance.IdeaName = this.IdeeNaamTb.text;
                Player.Instance.Category = (IdeaCategory)Enum.Parse(typeof(IdeaCategory), this.CategorieDropDrown.captionText.text.Replace(" ","_"));
                Application.LoadLevel("Nederland");
            }
            else
            {
                Debug.Log("OH NOO");
            }

        } 

        public void BackButtonClicked()
        {
            Application.LoadLevel("MainMenu");
        }

    }
}
