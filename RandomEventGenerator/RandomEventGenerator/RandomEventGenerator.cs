using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RandomEventGenerator
{
    using System.Linq;
    using System.Text;
    using System.Windows.Forms.VisualStyles;

    public partial class RandomEventGenerator : Form
    {
        private const string Filename = "GeneratedJsonData.txt";
        private string _totalPath;
        private List<RandomEvent> _randomEvents;

        private RandomEvent _currentRandomEvent;
        private List<RandomEvent.ChoiceAction> _currentChoiceActions;


        public RandomEventGenerator()
        {
            this.InitializeComponent();
            this.LoadRandomEvents();
            this.ResetFields();
            this.NewRandomEvent();
        }

        private void LoadRandomEvents()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\School\Game Design\GPT - Proftaak\JSON Files";
            this._totalPath = Path.Combine(path, Filename);
            this._randomEvents = JsonSerializer.ReadFromFile(path, Filename).RandomEvents;
            foreach (RandomEvent ra in this._randomEvents)
                ra.SetChoiceActionValues();
            this.lbCurrentEventAmount.Text = this._randomEvents.Count + " events";
        }

        private void ResetFields()
        {
            this.cmbEventType.DataSource = Enum.GetValues(typeof(RandomEvent.RandomEventType));
            this.cbActionType.DataSource = Enum.GetValues(typeof(RandomEvent.ChoiceAction.ActionType));
            this.cbChoiceActionsValue.DataSource = Enum.GetValues(typeof(PlayerSkill));

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private bool EventIsValid()
        {
            return !string.IsNullOrWhiteSpace(this.txtEventTitle.Text.Trim()) &&
                   !string.IsNullOrWhiteSpace(this.txtEventDescription.Text.Trim());
        }

        private bool IsLinkEvent()
        {
            return (RandomEvent.RandomEventType)this.cmbEventType.SelectedItem == RandomEvent.RandomEventType.Link;
        }

        private bool IsChoiceEvent()
        {
            return (RandomEvent.RandomEventType)this.cmbEventType.SelectedItem == RandomEvent.RandomEventType.Choice;
        }

        private void CreateEvent()
        {
            if (!this.EventIsValid())
            {
                return;
            }

            this._currentRandomEvent.Type = (RandomEvent.RandomEventType)this.cmbEventType.SelectedItem;
            this._currentRandomEvent.Title = this.txtEventTitle.Text.Trim();
            this._currentRandomEvent.Description = this.txtEventDescription.Text.Trim();

            if (this.IsLinkEvent())
            {
                this._currentRandomEvent.TedUrl = this.txtUrl.Text.Trim();
            }

            this._randomEvents.Add(this._currentRandomEvent);

            string json = JsonSerializer.RandomEventsListToJson(this._randomEvents);

            JsonSerializer.WriteToFile(this._totalPath, json);

            this.ResetFields();
            this.NewRandomEvent();
            this.lbCurrentEventAmount.Text = this._randomEvents.Count + " events";
        }

        private void NewRandomEvent()
        {
            this._currentRandomEvent = new RandomEvent { Choices = new List<RandomEvent.Choice>() };
            this._currentChoiceActions = new List<RandomEvent.ChoiceAction>();
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            this.CreateEvent();
        }

        private void cmbEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isVisible = this.IsLinkEvent();

            this.lblUrl.Visible = isVisible;
            this.txtUrl.Visible = isVisible;
            this.gbxChoices.Visible = this.IsChoiceEvent();
            this.gbxChoices.Enabled = this.IsChoiceEvent();
        }

        private void RandomEventGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RandomEventGenerator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.CreateEvent();
            }
        }


        #region Choices


        private void cbActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbChoiceActionsValue.Visible = (RandomEvent.ChoiceAction.ActionType)this.cbActionType.SelectedItem == RandomEvent.ChoiceAction.ActionType.SkillIncrease;
        }
        private void btnAddChoiceAction_Click(object sender, EventArgs e)
        {
            if (!this.CreateChoiceAction())
                return;
            this.tbChoicesValues.Clear();
            RandomEvent.ChoiceAction lastAction = this._currentChoiceActions[this._currentChoiceActions.Count - 1];
            this.lbChoiceActions.Items.Add(lastAction.ToString());
        }

        private bool CreateChoiceAction()
        {
            try
            {
                string[] values = this.tbChoicesValues.Text.Split(';');
                RandomEvent.ChoiceAction.ActionType actionType = (RandomEvent.ChoiceAction.ActionType)this.cbActionType.SelectedItem;
                switch (actionType)
                {
                    case RandomEvent.ChoiceAction.ActionType.SkillIncrease:
                        int number = Convert.ToInt32(values[0]);
                        if (values.Length > 2)
                        {
                            var temp1 = (PlayerSkill)Convert.ToInt32(values[1]);
                            var temp2 = Convert.ToInt32(values[2]);
                        }
                        this._currentChoiceActions.Add(new RandomEvent.ChoiceAction(
                            actionType, (int)Enum.Parse(typeof(PlayerSkill),this.cbChoiceActionsValue.SelectedItem.ToString()) + ";"+ this.tbChoicesValues.Text));
                        break;
                    case RandomEvent.ChoiceAction.ActionType.FollowerIncrease:
                        int followers = Convert.ToInt32(values[0]);
                        if (values.Length > 2)
                        {
                            var temp1 = (PlayerSkill)Convert.ToInt32(values[1]);
                            var temp2 = Convert.ToInt32(values[2]);
                        }
                        this._currentChoiceActions.Add(new RandomEvent.ChoiceAction(actionType, this.tbChoicesValues.Text));
                        break;
                    case RandomEvent.ChoiceAction.ActionType.Ok:
                        this._currentChoiceActions.Add(new RandomEvent.ChoiceAction(actionType));
                        break;
                    case RandomEvent.ChoiceAction.ActionType.NewLightbulbNear:
                        bool shouldRespawn = Convert.ToBoolean(values[0]);
                        this._currentChoiceActions.Add(new RandomEvent.ChoiceAction(actionType, this.tbChoicesValues.Text));
                        break;
                    case RandomEvent.ChoiceAction.ActionType.VisitUrl:
                        this._currentChoiceActions.Add(new RandomEvent.ChoiceAction(actionType, this.tbChoicesValues.Text));
                        break;
                    case RandomEvent.ChoiceAction.ActionType.Tutorial:
                        throw new Exception("Tutorial is geen keuze, sorry :)");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void btnAddChoice_Click(object sender, EventArgs e)
        {
            if (!this.IsChoiceValid())
            {
                MessageBox.Show("Niet alles is ingevuld");
                return;
            }

            this.CreateChoice();
            this.NewChoice();
        }

        private bool IsChoiceValid()
        {
            if (String.IsNullOrWhiteSpace(this.tbxChoicesText.Text))
                return false;
            return this.lbChoiceActions.Items.Count != 0;
        }

        private void CreateChoice()
        {
            this._currentRandomEvent.Choices.Add(new RandomEvent.Choice(this.tbxChoicesText.Text, new List<RandomEvent.ChoiceAction>(this._currentChoiceActions)));
            this._currentChoiceActions.Clear();
            this.lbChoices.Items.Add(this.tbxChoicesText.Text + ":" + this._currentRandomEvent.Choices[this._currentRandomEvent.Choices.Count -1].Actions.Aggregate(", ", (lvCurrent, ca) => lvCurrent + ca.ToString()).Remove(0, 2));
        }

        private void NewChoice()
        {
            this.lbChoiceActions.Items.Clear();
            this.tbChoicesValues.Clear();
            this.tbxChoicesText.Clear();
        }

        #endregion
    }


    public static class ExtensionMethods
    {

        public static string ArrayToString(this object[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object o in array)
                sb.Append(o + ";");
            return sb.ToString().Remove(sb.ToString().Length - 1, 1);
        }
        public static string ArrayToString(this int[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int o in array)
                sb.Append(o + ";");
            return sb.ToString().Remove(sb.ToString().Length - 1, 1);
        }
    }
}