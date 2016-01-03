using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RandomEventGenerator
{
    public partial class RandomEventGenerator : Form
    {
        #region Enums
        private enum Actions
        {
            Create,
            Edit
        }

        private enum Icons
        {
            Choice,
            Fact,
            Info,
            Link
        }
        #endregion

        private readonly List<RandomEvent> _randomEvents;
        private readonly string _PATH;
        private const string _FILENAME = "GeneratedJsonData.txt";
        private readonly string _TOTAL_PATH;
        public RandomEventGenerator()
        {
            _PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\School\Game Design\GPT - Proftaak\";
            this._TOTAL_PATH = System.IO.Path.Combine(this._PATH, _FILENAME);
            Console.WriteLine(_TOTAL_PATH);
            

            _randomEvents = JsonSerializer.ReadFromFile(_PATH, _FILENAME);

            InitializeComponent();
        }

        #region Info
        private void btCreateInfoSave_Click(object sender, EventArgs e)
        {
            if (!InfoIsValid(Actions.Create))
            {
                return;
            }

            _randomEvents.Add(new RandomEvent()
            {
                Title = this.tbCreateInfoTitle.Text.Trim(),
                Description = this.tbCreateInfoDescription.Text.Trim(),
                IconPath = Icons.Info.ToString()
            });

            string json = JsonSerializer.RandomEventsListToJson(_randomEvents);

            JsonSerializer.WriteToFile(this._TOTAL_PATH, json);
        }

        private void btEditInfoSave_Click(object sender, EventArgs e)
        {
            if (!InfoIsValid(Actions.Edit))
            {
                return;
            }

            // TODO Find the correct event to edit

            string json = JsonSerializer.RandomEventsListToJson(_randomEvents);

            JsonSerializer.WriteToFile(this._TOTAL_PATH, json);
        }

        private bool InfoIsValid(Actions action)
        {
            bool isValid;

            switch (action)
            {
                case Actions.Create:
                    isValid = !string.IsNullOrWhiteSpace(this.tbCreateInfoTitle.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbCreateInfoDescription.Text.Trim());
                    break;
                case Actions.Edit:
                    isValid = !string.IsNullOrWhiteSpace(this.tbEditInfoTitle.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbEditInfoDescription.Text.Trim());
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }
        #endregion

        #region Choice
        private void btCreateChoiceSave_Click(object sender, EventArgs e)
        {
            if (!ChoiceIsValid(Actions.Create))
            {
                return;
            }

            _randomEvents.Add(new ChoiceEvent()
            {
                Title = this.tbCreateChoiceTitle.Text.Trim(),
                Description = this.tbCreateChoiceDescription.Text.Trim(),
                IconPath = Icons.Choice.ToString()
            });

            string json = JsonSerializer.RandomEventsListToJson(_randomEvents);

            JsonSerializer.WriteToFile(this._TOTAL_PATH, json);
        }

        private void btEditChoiceSave_Click(object sender, EventArgs e)
        {
            if (!ChoiceIsValid(Actions.Edit))
            {
                return;
            }

            // TODO Find the correct event to edit

            string json = JsonSerializer.RandomEventsListToJson(_randomEvents);

            JsonSerializer.WriteToFile(this._TOTAL_PATH, json);
        }

        private bool ChoiceIsValid(Actions action)
        {
            bool isValid;

            switch (action)
            {
                case Actions.Create:
                    isValid = !string.IsNullOrWhiteSpace(this.tbCreateChoiceTitle.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbCreateChoiceDescription.Text.Trim());
                    break;
                case Actions.Edit:
                    isValid = !string.IsNullOrWhiteSpace(this.tbEditChoiceTitle.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbEditChoiceDescription.Text.Trim());
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }
        #endregion

        #region Link
        private void btCreateLinkSave_Click(object sender, EventArgs e)
        {
            if (!LinkIsValid(Actions.Create))
            {
                return;
            }

            _randomEvents.Add(new LinkEvent()
            {
                Title = this.tbCreateLinkTitle.Text.Trim(),
                Description = this.tbCreateLinkDescription.Text.Trim(),
                IconPath = Icons.Link.ToString(),
                SpeakerName = this.tbCreateLinkSpeaker.Text.Trim(),
                EventName = this.tbCreateLinkEvent.Text.Trim(),
                Url = this.tbEditLinkLink.Text.Trim()
            });

            string json = JsonSerializer.RandomEventsListToJson(_randomEvents);

            JsonSerializer.WriteToFile(this._TOTAL_PATH, json);
        }

        private void btEditLinkSave_Click(object sender, EventArgs e)
        {
            if (!LinkIsValid(Actions.Edit))
            {
                return;
            }

            // TODO Find the correct event to edit

            string json = JsonSerializer.RandomEventsListToJson(_randomEvents);

            JsonSerializer.WriteToFile(this._TOTAL_PATH, json);
        }

        private bool LinkIsValid(Actions action)
        {
            bool isValid;

            switch (action)
            {
                case Actions.Create:
                    isValid = !string.IsNullOrWhiteSpace(this.tbCreateLinkTitle.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbCreateLinkDescription.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbCreateLinkSpeaker.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbCreateLinkEvent.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbCreateLinkLink.Text.Trim());
                    break;
                case Actions.Edit:
                    isValid = !string.IsNullOrWhiteSpace(this.tbEditLinkTitle.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbEditLinkDescription.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbEditLinkSpeaker.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbEditLinkEvent.Text.Trim()) &&
                              !string.IsNullOrWhiteSpace(this.tbEditLinkLink.Text.Trim());
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }
        #endregion

        private void RandomEventGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}