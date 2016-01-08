namespace Assets.Scripts.Managers
{
    using System;
    using System.Collections.Generic;
    using Assets.Scripts.RandomEvents;
    using UnityEngine;
    using UnityEngine.UI;

    internal class RandomEventsManager : MonoBehaviour
    {
        public static RandomEventsManager Instance;

        [SerializeField]
        private Canvas _randomEventsCanvas;

        [SerializeField]
        private readonly List<RandomEvent> _randomEvents = new List<RandomEvent>();

        [SerializeField]
        private Button _button1;
        [SerializeField]
        private Text _button1Text;
        [SerializeField]
        private Button _button2;
        [SerializeField]
        private Text _button2Text;
        [SerializeField]
        private Button _button3;
        [SerializeField]
        private Text _button3Text;
        [SerializeField]
        private Button _button4;
        [SerializeField]
        private Text _button4Text;
        [SerializeField]
        private Text _descText;

        public RandomEvent CurrentRandomEvent { get; private set; }

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            // read randomEvents from JSON file.
            this._randomEvents.Shuffle();

            this.CurrentRandomEvent = new RandomEvent()
            {
                Description = string.Format("Welkom {0}. {1} is een super tof idee! Probeer dit door heel Nederland te verspreiden en uiteindelijk op TEDx Veghel te komen. Succes met je avontuur!", Player.Instance.PlayerName, Player.Instance.IdeaName),
                Choices = new List<RandomEvent.Choice>() { new RandomEvent.Choice("Ok", new List<RandomEvent.ChoiceAction>() { new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.Ok) }) }
            };

            List<RandomEvent.ChoiceAction> listActions = new List<RandomEvent.ChoiceAction>() { new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease), new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.NewLightbulbNear) };
            List<RandomEvent.Choice> choices = new List<RandomEvent.Choice>
            {
                new RandomEvent.Choice("Presentatie oefenen", listActions , 1, 4, PlayerSkill.Presentation),
                new RandomEvent.Choice("VLOG maken", listActions, 1, 4, PlayerSkill.Media)
            };
            this._randomEvents.Add(new RandomEvent() { Description = "Wil je je vrije tijd besteden om je presentatie te oefenen, of om een VLOG te maken?", Choices = choices });
            this._randomEvents.Add(new RandomEvent() { Description = "TED video van \"Do schools kill creativity\"", TedUrl = "http://www.ted.com/talks/ken_robinson_says_schools_kill_creativity", Choices = new List<RandomEvent.Choice>() { new RandomEvent.Choice("Bekijk", new List<RandomEvent.ChoiceAction>() { new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.VisitUrl) }), new RandomEvent.Choice("Ok", new List<RandomEvent.ChoiceAction>() { new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.Ok) }) } });


            this.ShowRandomEventsCanvas();
        }

        // TODO: Setup RandomEventCanvas using CurrentRandomEvent -> Show buttons and change button text, description etc.
        private void UpdateToGUITopcurrentRandomEvent()
        {
            this._descText.text = string.Empty;
            this.DeactivateAllButtons();
            if (this.CurrentRandomEvent == null) return;
            this._descText.text = this.CurrentRandomEvent.Description;
            for (int i = 0; i < this.CurrentRandomEvent.Choices.Count; i++)
                switch (i)
                {
                    case 0:
                        this._button1.gameObject.SetActive(true);
                        // KUT UNITY WAAROM NULL REFERENCE EXCEPTION BIJ text.text :(
                        Transform child = this._button1.transform.GetChild(0);
                        Text text = child.GetComponent<Text>();
                        text.text = "Test123";
                        this._button1Text.text = this.CurrentRandomEvent.Choices[i].Text;
                        break;
                    case 1:
                        this._button2.gameObject.SetActive(true);
                        this._button2Text.text = this.CurrentRandomEvent.Choices[i].Text;
                        break;
                    case 2:
                        this._button3.gameObject.SetActive(true);
                        this._button3Text.text = this.CurrentRandomEvent.Choices[i].Text;
                        break;
                    case 3:
                        this._button4.gameObject.SetActive(true);
                        this._button4Text.text = this.CurrentRandomEvent.Choices[i].Text;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Meer dan 4 keuzes, hoe kan dit?");
                }
        }

        private void DeactivateAllButtons()
        {
            this._button1.gameObject.SetActive(false);
            this._button2.gameObject.SetActive(false);
            this._button3.gameObject.SetActive(false);
            this._button4.gameObject.SetActive(false);
        }

        public bool NewRandomEvent()
        {
            if (this._randomEvents.Count == 0)
            {
                this.CurrentRandomEvent = null;
                return false;
            }

            this.CurrentRandomEvent = this._randomEvents[0];
            this._randomEvents.RemoveAt(0);
            return true;
        }
        public void ShowRandomEventsCanvas()
        {
            this._randomEventsCanvas.gameObject.SetActive(true);
            this.UpdateToGUITopcurrentRandomEvent();
            Time.timeScale = 0f;
        }

        public void HideRandomEventsCanvas()
        {
            this._randomEventsCanvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Button1Click()
        {
            if (!this.CheckButtonClickIsValid(1)) return;
            this.DoChoice(this.CurrentRandomEvent.Choices[0]);
        }
        public void Button2Click()
        {
            if (!this.CheckButtonClickIsValid(2)) return;
            this.DoChoice(this.CurrentRandomEvent.Choices[1]);
        }
        public void Button3Click()
        {
            if (!this.CheckButtonClickIsValid(3)) return;
            this.DoChoice(this.CurrentRandomEvent.Choices[2]);
        }
        public void Button4Click()
        {
            if (!this.CheckButtonClickIsValid(4)) return;
            this.DoChoice(this.CurrentRandomEvent.Choices[3]);
        }
        private bool CheckButtonClickIsValid(int number)
        {
            if (this.CurrentRandomEvent == null) return false;
            return this.CurrentRandomEvent.Choices.Count >= number;
        }

        private void DoChoice(RandomEvent.Choice choice)
        {
            float value = 0;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            value = choice.Min == choice.Max ? choice.Max : UnityEngine.Random.Range(choice.Min, choice.Max);
            Debug.Log("RandomEventsManager: value = " + value);
            foreach (RandomEvent.ChoiceAction action in choice.Actions)
                switch (action.Action)
                {
                    case RandomEvent.ChoiceAction.ActionType.SkillIncrease:
                        IncreasePlayerSkill(choice.Skill, value);
                        break;
                    case RandomEvent.ChoiceAction.ActionType.Ok:
                        break;
                    case RandomEvent.ChoiceAction.ActionType.NewLightbulbNear:
                        // TODO: Iets anders
                        IList<LightbulbBalloon> lightbulbs = BalloonManager.Instance.LightBulbBalloons;
                        if (lightbulbs.Count > 0 && !lightbulbs[0].gameObject.activeInHierarchy)
                            lightbulbs[0].gameObject.SetActive(true);
                        break;
                    case RandomEvent.ChoiceAction.ActionType.VisitUrl:
                        Application.OpenURL(this.CurrentRandomEvent.TedUrl);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            if (this.CurrentRandomEvent.FollowUpRandomEvents == null || this.CurrentRandomEvent.FollowUpRandomEvents[choice] == null)
            {
                this.HideRandomEventsCanvas();
                this.NewRandomEvent();
                this.UpdateToGUITopcurrentRandomEvent();
                return;
            }
            // show following random event;
            this.CurrentRandomEvent = this.CurrentRandomEvent.FollowUpRandomEvents[choice];
            this.UpdateToGUITopcurrentRandomEvent();
        }

        private static void IncreasePlayerSkill(PlayerSkill pSkill, float value)
        {
            switch (pSkill)
            {
                case PlayerSkill.Knowledge:
                    Player.Instance.KnowledgeSkills += (int)value;
                    break;
                case PlayerSkill.Presentation:
                    Player.Instance.PresentationSkills += (int)value;
                    break;
                case PlayerSkill.Media:
                    Player.Instance.MediaSkills += (int)value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
