using System;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.RandomEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class RandomEventsManager : MonoBehaviour
    {
        public static RandomEventsManager Instance;

        [SerializeField]
        private GameObject _randomEventsCanvas;
        [SerializeField]
        private GameObject _temporaryTutorialCanvas;

        [SerializeField]
        private List<RandomEvent> _randomEvents = new List<RandomEvent>();
        private List<RandomEvent> _randomFacts = new List<RandomEvent>();
        private List<RandomEvent> _randomInfo = new List<RandomEvent>();

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
        private Text _randomEventTitleText;
        [SerializeField]
        private Text _randomEventDescText;

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

        public RandomEvent CurrentRandomEvent { get; private set; }
        public RandomEvent CurrentNotification { get; private set; }

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }


            List<RandomEvent> tempList = JsonSerializer.ReadFromFile("GeneratedJsonData").RandomEvents;
            
            // TODO iets in deze richting voor Notifications.
            //List<RandomEvent> shuffleEvents = new List<RandomEvent>(tempList);
            //shuffleEvents.RemoveRange(0, 4);
            //shuffleEvents.Shuffle();
            //this._randomEvents = new List<RandomEvent>(tempList.GetRange(0,4));
            //this._randomEvents.AddRange(shuffleEvents);

            this._randomEvents = tempList;

            foreach (RandomEvent ra in this._randomEvents)
                ra.SetChoiceActionValues();

            this.CurrentRandomEvent = this._randomEvents[0];
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            RandomEvent currentNotification = new RandomEvent
            {
                Title = string.Format("Welkom {0}!", Player.Instance.PlayerName),
                Description = string.Format("{0} is een super tof idee! Probeer dit door heel Nederland te verspreiden en uiteindelijk op TEDx Veghel te komen. Succes met je avontuur!", Player.Instance.IdeaName),
                Choices = new List<RandomEvent.Choice>
                {
                    new RandomEvent.Choice("Sluiten", new List<RandomEvent.ChoiceAction>
                    {
                        new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.Tutorial)
                    })
                }
            };

            this.ShowNotificationCanvas(currentNotification);
        }

        private void UpdateToGuiTopcurrentRandomEvent()
        {

            this._randomEventDescText.text = string.Empty;
            this.DeactivateAllButtons();

            if (this.CurrentRandomEvent == null)
            {
                this.CurrentRandomEvent = new RandomEvent(RandomEvent.RandomEventType.Choice, new List<RandomEvent.Choice>()
                    {
                        new RandomEvent.Choice("Sluiten", new List<RandomEvent.ChoiceAction>() { new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.Ok) })
                    }, "Helaas", "Je hebt er helaas te lang over gedaan om er te komen. Probeer het nogmaals");
                this._button1.gameObject.SetActive(true);
                this._button1Text.text = this.CurrentRandomEvent.Choices[0].Text;
                return;
            }

            this._randomEventTitleText.text = this.CurrentRandomEvent.Title;
            this._randomEventDescText.text = this.CurrentRandomEvent.Description;


            if (this.CurrentRandomEvent.Choices == null)
            {
                this._button1.gameObject.SetActive(true);
                this._button1Text.text = "Sluiten";
            }
            else
                for (int i = 0; i < this.CurrentRandomEvent.Choices.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                this._button1.gameObject.SetActive(true);
                                this._button1Text.text = this.CurrentRandomEvent.Choices[i].Text;

                                break;
                            }
                        case 1:
                            {
                                this._button2.gameObject.SetActive(true);
                                this._button2Text.text = this.CurrentRandomEvent.Choices[i].Text;

                                break;
                            }
                        case 2:
                            {
                                this._button3.gameObject.SetActive(true);
                                this._button3Text.text = this.CurrentRandomEvent.Choices[i].Text;

                                break;
                            }
                        case 3:
                            {
                                this._button4.gameObject.SetActive(true);
                                this._button4Text.text = this.CurrentRandomEvent.Choices[i].Text;

                                break;
                            }
                        default:
                            {
                                throw new ArgumentOutOfRangeException("Meer dan 4 keuzes, hoe kan dit?");
                            }
                    }
                }
        }

        private void UpdateToGuiTopcurrentNotification()
        {
            this._notificationDescription.text = string.Empty;
            this.DeactivateAllButtons();

            if (this.CurrentNotification == null)
            {
                return;
            }

            this._notificationTitle.text = this.CurrentNotification.Title;
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
            AudioManager.Instance.PlayNotification();
            this._randomEventsCanvas.SetActive(true);
            this.UpdateToGuiTopcurrentRandomEvent();
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
            AudioManager.Instance.PlayNotification();
            this._notificationPanel.SetActive(true);
            this.UpdateToGuiTopcurrentNotification();
            Time.timeScale = 0f;
        }


        public void HideRandomEventsCanvas()
        {
            this._randomEventsCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Button1Click()
        {
            if (!this.CheckButtonClickIsValid(1))
            {
                return;
            }

            this.DoChoice(this.CurrentRandomEvent.Choices[0]);
        }

        public void Button2Click()
        {
            if (!this.CheckButtonClickIsValid(2))
            {
                return;
            }

            this.DoChoice(this.CurrentRandomEvent.Choices[1]);
        }

        public void Button3Click()
        {
            if (!this.CheckButtonClickIsValid(3))
            {
                return;
            }

            this.DoChoice(this.CurrentRandomEvent.Choices[2]);
        }

        public void Button4Click()
        {
            if (!this.CheckButtonClickIsValid(4))
            {
                return;
            }

            this.DoChoice(this.CurrentRandomEvent.Choices[3]);
        }

        public void ButtonConfirmClick()
        {
            if (!this.CheckButtonClickIsValid2(1))
            {
                return;
            }

            this.DoChoice(this.CurrentNotification.Choices[0]);
        }

        private bool CheckButtonClickIsValid(int number)
        {
            if (this.CurrentRandomEvent == null || this.CurrentRandomEvent.Choices == null)
            {
                return true;
            }

            return this.CurrentRandomEvent.Choices.Count >= number;
        }

        private bool CheckButtonClickIsValid2(int number)
        {
            if (this.CurrentNotification == null)
            {
                return false;
            }

            return this.CurrentNotification.Choices.Count >= number;
        }

        private void DoChoice(RandomEvent.Choice choice)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            // float value = choice.Min == choice.Max ? choice.Max : UnityEngine.Random.Range(choice.Min, choice.Max);

            // Debug.Log("RandomEventsManager: value = " + value);
            int increasevalue_1 = 0;
            int increasevalue_2 = 0;

            foreach (RandomEvent.ChoiceAction action in choice.Actions)
            {
                switch (action.Action)
                {
                    case RandomEvent.ChoiceAction.ActionType.SkillIncrease:
                        {
                            int increaseValue = (int)action.Values[1];
                            if (action.Values.Length > 3)

                                switch ((PlayerSkill)action.Values[2])
                                {
                                    case PlayerSkill.Knowledge:
                                        increaseValue += Player.Instance.KnowledgeSkills * (int)action.Values[3];
                                        break;
                                    case PlayerSkill.Presentation:
                                        increaseValue += Player.Instance.PresentationSkills * (int)action.Values[3];
                                        break;
                                    case PlayerSkill.Media:
                                        increaseValue += Player.Instance.MediaSkills * (int)action.Values[3];
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }



                            IncreasePlayerSkill((PlayerSkill)action.Values[0], increaseValue);
                            break;
                        }
                    case RandomEvent.ChoiceAction.ActionType.FollowerIncrease:
                        {
                            int increaseValue = (int)action.Values[0];
                            if (action.Values.Length > 2)
                                switch ((PlayerSkill)action.Values[1])
                                {
                                    case PlayerSkill.Knowledge:
                                        increaseValue += Player.Instance.KnowledgeSkills * (int)action.Values[2];
                                        break;
                                    case PlayerSkill.Presentation:
                                        increaseValue += Player.Instance.PresentationSkills * (int)action.Values[2];
                                        break;
                                    case PlayerSkill.Media:
                                        increaseValue += Player.Instance.MediaSkills * (int)action.Values[2];
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }

                            FollowerManager.Instance.TotalFollowers += increaseValue;
                            break;
                        }
                    case RandomEvent.ChoiceAction.ActionType.Ok:
                        {
                            break;
                        }
                    case RandomEvent.ChoiceAction.ActionType.NewLightbulbNear:
                        {
                            bool respawn = (bool)action.Values[0];
                            BalloonManager.Instance.SpawnLightbulb(respawn);
                            //IList<LightbulbBalloon> lightbulbs = BalloonManager.Instance.LightBulbBalloons;
                            //if (lightbulbs.Count > 0 && !lightbulbs[0].gameObject.activeInHierarchy)
                            //{
                            //    lightbulbs[0].gameObject.SetActive(true);
                            //}

                            break;
                        }
                    case RandomEvent.ChoiceAction.ActionType.VisitUrl:
                        {
                            Application.OpenURL(this.CurrentRandomEvent.TedUrl);

                            break;
                        }
                    case RandomEvent.ChoiceAction.ActionType.Tutorial:
                        {
                            this._notificationPanel.SetActive(false);
                            this._temporaryTutorialCanvas.SetActive(true);

                            break;
                        }
                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }
            }


            if (this.CurrentRandomEvent.FollowUpRandomEvents == null || this.CurrentRandomEvent.FollowUpRandomEvents[choice] == null)
            {

                if (increasevalue_1 < 0 && increasevalue_2 < 0)
                {
                    AudioManager.Instance.PlayNegativeFeedback();
                }
                else if(increasevalue_1 > 0 && increasevalue_2 > 0)
                {
                    AudioManager.Instance.PlayPositiveFeedback();

                }else
                {
                    //Play no sound.
                }
                this.HideRandomEventsCanvas();
                this.NewRandomEvent();
                this.UpdateToGuiTopcurrentRandomEvent();

                return;
            }

            this.CurrentRandomEvent = this.CurrentRandomEvent.FollowUpRandomEvents[choice];
            this.UpdateToGuiTopcurrentRandomEvent();
        }

        private static void IncreasePlayerSkill(PlayerSkill pSkill, int value)
        {
            switch (pSkill)
            {
                case PlayerSkill.Knowledge:
                    {
                        Player.Instance.KnowledgeSkills += value;

                        break;
                    }
                case PlayerSkill.Presentation:
                    {
                        Player.Instance.PresentationSkills += value;

                        break;
                    }
                case PlayerSkill.Media:
                    {
                        Player.Instance.MediaSkills += value;

                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }
    }
}
