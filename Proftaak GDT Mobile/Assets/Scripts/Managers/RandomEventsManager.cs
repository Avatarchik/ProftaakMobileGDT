using System;
using System.Collections.Generic;
using System.Linq;
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
        private GameObject _UI;
        [SerializeField]
        private GameObject _feedBack;

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
            Instance = this;

            List<RandomEvent> tempList = JsonSerializer.ReadFromFile("GeneratedJsonData").RandomEvents;

            // Delete TED Links with other categories.
            tempList.RemoveAll(re => re.Type == RandomEvent.RandomEventType.Link && re.IdeaCategory != Player.Instance.Category);
            tempList = this.ShuffleRandomEvents(tempList);


            this._randomEvents = tempList;

            foreach (RandomEvent ra in this._randomEvents)
                ra.SetChoiceActionValues();

            this.CurrentRandomEvent = this._randomEvents[0];
        }

        private List<RandomEvent> ShuffleRandomEvents(List<RandomEvent> events)
        {
            List<RandomEvent> choices = events.Where(x => x.Type == RandomEvent.RandomEventType.Choice).ToList();
            List<RandomEvent> tedlinks = events.Where(x => x.Type == RandomEvent.RandomEventType.Link).ToList();
            List<RandomEvent> info = events.Where(x => x.Type == RandomEvent.RandomEventType.Fact && x.Title != "Inspirerende quote").ToList();
            List<RandomEvent> quotes = events.Where(x => x.Type == RandomEvent.RandomEventType.Fact && x.Title == "Inspirerende quote").ToList();

            List<RandomEvent> shuffledList = new List<RandomEvent>();
            int i = 0;
            while (shuffledList.Count < events.Count)
            {
                if (i == 0)
                {
                    shuffledList.Add(choices[0]);
                    choices.RemoveAt(0);
                }
                else if (i % 5 == 0 && tedlinks.Count > 0)
                {
                    shuffledList.Add(tedlinks[0]);
                    tedlinks.RemoveAt(0);
                }
                else if (i % 4 == 0 && info.Count > 0)
                {
                    shuffledList.Add(info[0]);
                    info.RemoveAt(0);
                }
                else if (i % 3 == 0 && quotes.Count > 0)
                {
                    shuffledList.Add(quotes[0]);
                    quotes.RemoveAt(0);
                }
                else if (i % 2 == 0 && choices.Count > 0)
                {
                    shuffledList.Add(choices[0]);
                    choices.RemoveAt(0);
                }
                else if (quotes.Count > 0)
                {
                    shuffledList.Add(quotes[0]);
                    quotes.RemoveAt(0);
                }
                else if (info.Count > 0)
                {
                    shuffledList.Add(info[0]);
                    info.RemoveAt(0);
                }
                else if (tedlinks.Count > 0)
                {
                    shuffledList.Add(tedlinks[0]);
                    tedlinks.RemoveAt(0);
                }
                else if (choices.Count > 0)
                {
                    shuffledList.Add(choices[0]);
                    choices.RemoveAt(0);
                }
                i++;
            }
            return shuffledList;
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            RandomEvent currentNotification = new RandomEvent
            {
                Title = string.Format("Welkom {0}!", Player.Instance.PlayerName),
                Description = string.Format("{0} is een super tof idee! Probeer dit door heel Nederland te verspreiden en uiteindelijk op TEDxVeghel te komen. Succes met je avontuur!", Player.Instance.IdeaName),
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
                this.CurrentRandomEvent = new RandomEvent(RandomEvent.RandomEventType.Choice, new List<RandomEvent.Choice>
                    {
                        new RandomEvent.Choice("Sluiten", new List<RandomEvent.ChoiceAction>
                        {
                            new RandomEvent.ChoiceAction(RandomEvent.ChoiceAction.ActionType.Ok)
                        })
                    }, "Helaas", "Je hebt er helaas te lang over gedaan om er te komen. Probeer het nogmaals");

                this._button1.gameObject.SetActive(true);
                this._button1Text.text = this.CurrentRandomEvent.Choices[0].Text;

                return;
            }

            string title = this.CurrentRandomEvent.Title.Replace("{player}", Player.Instance.PlayerName);
            title = title.Replace("{idea}", Player.Instance.IdeaName);
            this._randomEventTitleText.text = title;
            string desc = this.CurrentRandomEvent.Description.Replace("{player}", Player.Instance.PlayerName);
            desc = desc.Replace("{idea}", Player.Instance.IdeaName);
            this._randomEventDescText.text = desc;

            if (this.CurrentRandomEvent.Choices.IsNullOrEmpty())
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

            string title = this.CurrentNotification.Title.Replace("{player}", Player.Instance.PlayerName);
            title = title.Replace("{idea}", Player.Instance.IdeaName);
            this._notificationTitle.text = title;
            string desc = this.CurrentNotification.Description.Replace("{player}", Player.Instance.PlayerName);
            desc = desc.Replace("{idea}", Player.Instance.IdeaName);
            this._notificationDescription.text = desc;

            this._buttonOk.gameObject.SetActive(true);
            if (this.CurrentNotification.Choices.IsNullOrEmpty())
                this._buttonOkText.text = "Sluiten";
            else
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

        public bool NewRandomEvent(RandomEvent.Choice choice)
        {
            if (this._randomEvents.Count == 0)
            {
                this.CurrentRandomEvent = null;

                return false;
            }

            if (this.CurrentRandomEvent.HasFollowUpEvent && choice.Text == "Ja")
            {
                this.CurrentRandomEvent = this._randomEvents[0];
                this._randomEvents.RemoveAt(0);
            }
            else
            {
                if (choice != null && choice.Text == "Nee")
                {
                    this.CurrentRandomEvent = this._randomEvents[1];
                    this._randomEvents.RemoveAt(0);
                    this._randomEvents.RemoveAt(1);
                }
                else
                {
                    this.CurrentRandomEvent = this._randomEvents[0];
                    this._randomEvents.RemoveAt(0);
                }
            }

            return true;
        }

        public void ShowRandomEventsCanvas()
        {
            AudioManager.Instance.PlayNotification();
            if (this.CurrentRandomEvent != null && this.CurrentRandomEvent.Choices.IsNullOrEmpty())
            {
                this.ShowNotificationCanvas(this.CurrentRandomEvent);
            }
            else
            {
                this._randomEventsCanvas.SetActive(true);
                this.UpdateToGuiTopcurrentRandomEvent();
            }
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
            if (this.CurrentRandomEvent.Choices.IsNullOrEmpty())
            {
                this.HideRandomEventsCanvas();
                this.NewRandomEvent(null);
                this.UpdateToGuiTopcurrentRandomEvent();
            }
            else
                this.DoChoice(this.CurrentRandomEvent.Choices[0]);
        }

        public void Button2Click()
        {
            this.DoChoice(this.CurrentRandomEvent.Choices[1]);
        }

        public void Button3Click()
        {
            this.DoChoice(this.CurrentRandomEvent.Choices[2]);
        }

        public void Button4Click()
        {
            this.DoChoice(this.CurrentRandomEvent.Choices[3]);
        }

        public void ButtonConfirmClick()
        {
            if (this.CurrentNotification.Choices.IsNullOrEmpty())
            {
                this.HideNotificationCanvas();
                this.NewRandomEvent(null);
                this.UpdateToGuiTopcurrentRandomEvent();
            }
            else
                this.DoChoice(this.CurrentNotification.Choices[0]);
        }
        
        private void DoChoice(RandomEvent.Choice choice)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            // float value = choice.Min == choice.Max ? choice.Max : UnityEngine.Random.Range(choice.Min, choice.Max);

            // Debug.Log("RandomEventsManager: value = " + value);
            int actionValueSkill = 0;
            int actionValueFollowers = 0;
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
                            if (increaseValue < 0)
                            {
                                this.VisualFeedBack(increaseValue.ToString()).GetComponent<Animator>().SetTrigger("SkillUp");
                            }
                            else
                            {
                                this.VisualFeedBack("+ " + increaseValue.ToString()).GetComponent<Animator>().SetTrigger("SkillUp");
                            }

                            actionValueSkill += increaseValue;
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

                            this.VisualFeedBack("+ " + increaseValue.ToString()).GetComponent<Animator>().SetTrigger("FollowerUp");
                            actionValueFollowers += increaseValue;
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
                            break;
                        }
                    case RandomEvent.ChoiceAction.ActionType.VisitUrl:
                        {

#if (UNITY_WP8_1 || UNITY_WP_8_1 || UNITY_WP8 || UNITY_WSA_8_1)

                            Application.OpenURL(this.CurrentRandomEvent.TedUrl);
#else
                            YoutubeVideo ytv = new YoutubeVideo();
                            UnityEngine.Handheld.PlayFullScreenMovie(ytv.RequestVideo(this.CurrentRandomEvent.TedUrl, 720));                            
#endif
                            Player.Instance.KnowledgeSkills++;
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

            if (actionValueFollowers < 0 && actionValueSkill < 0)
            {
                AudioManager.Instance.PlayNegativeFeedback();
            }
            else if (actionValueFollowers > 0 && actionValueSkill > 0)
            {
                AudioManager.Instance.PlayPositiveFeedback();
            }

            this.HideRandomEventsCanvas();
            this.NewRandomEvent(choice);
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
        public GameObject VisualFeedBack(string text)
        {
            GameObject temp = Instantiate(this._feedBack);
            RectTransform tempRect = temp.GetComponent<RectTransform>();
            temp.transform.SetParent(this._UI.transform);

            temp.GetComponent<Text>().text = text;
            Destroy(temp.gameObject, 2);

            return temp;
        }
    }
}
