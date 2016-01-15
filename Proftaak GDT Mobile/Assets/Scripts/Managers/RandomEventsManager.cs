using System;
using System.Collections.Generic;
using Assets.Scripts.RandomEvents;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Assets.Scripts.Helpers;

namespace Assets.Scripts.Managers
{
    internal class RandomEventsManager : MonoBehaviour
    {
        public static RandomEventsManager Instance;

        [SerializeField]
        private GameObject _randomEventsCanvas;

        [SerializeField]
        private GameObject _temporaryTutorialCanvas;

        [SerializeField]
        private List<RandomEvent> _randomEvents = new List<RandomEvent>();

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


        //Notifications

        [SerializeField]
        private GameObject _notificationPanel;

        [SerializeField]
        private Text _notificationTitle;

        [SerializeField]
        private Text _notificationDescription;

        [SerializeField]
        private Button _buttonOk;

        [SerializeField]
        private Text _buttonOkText;

        public RandomEvent CurrentNotification { get; private set; }

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            RandomEvent currentNotificitaion1 = new RandomEvent()
            {
                Description = string.Format("Welkom {0}. {1} is een super tof idee! Probeer dit door heel Nederland te verspreiden en uiteindelijk op TEDx Veghel te komen. Succes met je avontuur!", Player.Instance.PlayerName, Player.Instance.IdeaName),
                Choices = new List<RandomEvent.Choice>() { new RandomEvent.Choice("SLUITEN", new List<RandomEvent.ChoiceAction>() { new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.Tutorial) }) }
            };

            // read randomEvents from JSON file.
            this._randomEvents = JsonSerializer.ReadFromFile(Application.dataPath + Path.DirectorySeparatorChar + "JSON" + Path.DirectorySeparatorChar + "GeneratedJsonData.txt").GetRange(0, 4);

            this.HardCodeChoices();

            Debug.Log("Aantal events geladen: " + this._randomEvents.Count);
            if (_randomEvents[0] == null)
            {
                Debug.LogError("WRONG YOU NEED TO FILL THE LIST WITH RANDOM EVENTS!!");
            }
            this.CurrentRandomEvent = _randomEvents[0];

            this.ShowNotificationCanvas(currentNotificitaion1);
        }

        private void HardCodeChoices()
        {
            this._randomEvents[0].Choices = new List<RandomEvent.Choice>
            {
                new RandomEvent.Choice("Verdiepen", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease)
                }, 1, 1, PlayerSkill.Knowledge),
                new RandomEvent.Choice("Niet verdiepen", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.Ok)
                })
            };
            this._randomEvents[1].Choices = new List<RandomEvent.Choice>
            {
                new RandomEvent.Choice("Verhaal", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease),
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.FollowerIncrease)
                }, 100000, 1, 1, PlayerSkill.Presentation),
                new RandomEvent.Choice("Feiten", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease),
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.FollowerIncrease)
                }, 10, -1, -1, PlayerSkill.Presentation)
            };
            this._randomEvents[2].Choices = new List<RandomEvent.Choice>
            {
                new RandomEvent.Choice("10 minuten / 5 slides", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease),
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.FollowerIncrease)
                }, 10, -1, -1, PlayerSkill.Presentation),
                new RandomEvent.Choice("20 minutes / 10 slides", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease),
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.FollowerIncrease)
                }, 100000, 1, 1, PlayerSkill.Presentation),
                new RandomEvent.Choice("30 minutes / 15 slides", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease),
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.FollowerIncrease)
                }, 10, -1, -1, PlayerSkill.Presentation)
            };
            this._randomEvents[3].Choices = new List<RandomEvent.Choice>
            {
                new RandomEvent.Choice("Gemeentehuis", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease),
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.FollowerIncrease)
                }, 100000, 1, 1, PlayerSkill.Presentation),
                new RandomEvent.Choice("Beursgebouw", new List<RandomEvent.ChoiceAction>
                {
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.SkillIncrease),
                    new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.FollowerIncrease)
                }, 10, -1, -1, PlayerSkill.Presentation)
            };
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


        private void UpdateToGUITopcurrentNotification()
        {
            this._notificationDescription.text = string.Empty;
            this.DeactivateAllButtons();
            if (this.CurrentNotification == null) return;
            this._notificationDescription.text = this.CurrentNotification.Description;

                        this._buttonOk.gameObject.SetActive(true);
                        this._buttonOkText.text = this.CurrentNotification.Choices[0].Text;

        }

        private void DeactivateAllButtons()
        {
            this._button1.gameObject.SetActive(false);
            this._button2.gameObject.SetActive(false);
            this._button3.gameObject.SetActive(false);
            this._button4.gameObject.SetActive(false);
            this._buttonOk.gameObject.SetActive(false);
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
            this._randomEventsCanvas.SetActive(true);
            this.UpdateToGUITopcurrentRandomEvent();
            Time.timeScale = 0f;
        }

        public void HideNotificationCanvas()
        {
            this._notificationPanel.SetActive(false);
            Time.timeScale = 1f;
        }


        public void ShowNotificationCanvas(RandomEvent RE)
        {
            this.CurrentNotification = RE;
            this._notificationPanel.SetActive(true);
            this.UpdateToGUITopcurrentNotification();
            Time.timeScale = 0f;
        }

        public void HideRandomEventsCanvas()
        {
            this._randomEventsCanvas.SetActive(false);
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
        public void ButtonConfirmClick()
        {
            if (!this.CheckButtonClickIsValid2(1)) return;
            this.DoChoice(this.CurrentNotification.Choices[0]);
        }
        private bool CheckButtonClickIsValid(int number)
        {
            if (this.CurrentRandomEvent == null) return false;
            return this.CurrentRandomEvent.Choices.Count >= number;
        }
        private bool CheckButtonClickIsValid2(int number)
        {
            if (this.CurrentNotification == null) return false;
            return this.CurrentNotification.Choices.Count >= number;
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
                    case RandomEvent.ChoiceAction.ActionType.FollowerIncrease:
                        FollowerManager.Instance.TotalFollowers += (int)choice.Percentage;
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

                    case RandomEvent.ChoiceAction.ActionType.Tutorial:
                        Debug.Log("FUUUUUU");
                        this._notificationPanel.SetActive(false);
                        this._temporaryTutorialCanvas.SetActive(true);
                        // Time.timeScale = 0f;
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
