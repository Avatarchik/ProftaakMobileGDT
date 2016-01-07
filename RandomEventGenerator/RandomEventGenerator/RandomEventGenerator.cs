using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RandomEventGenerator
{
    public partial class RandomEventGenerator : Form
    {
        private const string Filename = "GeneratedJsonData.txt";
        private string _totalPath;
        private List<RandomEvent> _randomEvents;

        public RandomEventGenerator()
        {
            this.LoadRandomEvents();
            this.InitializeComponent();
            this.ResetFields();
        }

        private void LoadRandomEvents()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\School\Game Design\GPT - Proftaak\JSON Files";
            this._totalPath = Path.Combine(path, Filename);
            this._randomEvents = JsonSerializer.ReadFromFile(path, Filename);
        }

        private void ResetFields()
        {
            this.cmbEventType.DataSource = Enum.GetValues(typeof(RandomEvent.RandomEventType));

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

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            if (!EventIsValid())
            {
                return;
            }

            RandomEvent re = new RandomEvent
            {
                Type = (RandomEvent.RandomEventType)this.cmbEventType.SelectedItem,
                Title = this.txtEventTitle.Text.Trim(),
                Description = this.txtEventDescription.Text.Trim()
            };

            if (this.IsLinkEvent())
            {
                re.TedUrl = this.txtUrl.Text.Trim();
            }

            _randomEvents.Add(re);

            string json = JsonSerializer.RandomEventsListToJson(_randomEvents);

            JsonSerializer.WriteToFile(this._totalPath, json);

            this.ResetFields();
        }

        private void cmbEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isVisible = this.IsLinkEvent();

            this.lblUrl.Visible = isVisible;
            this.txtUrl.Visible = isVisible;
        }

        private void RandomEventGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}