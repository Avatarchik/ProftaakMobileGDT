namespace RandomEventGenerator
{
    partial class RandomEventGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbEventTitle = new System.Windows.Forms.Label();
            this.txtEventTitle = new System.Windows.Forms.TextBox();
            this.lbEventDescription = new System.Windows.Forms.Label();
            this.txtEventDescription = new System.Windows.Forms.TextBox();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.lbEventType = new System.Windows.Forms.Label();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lbCurrentEventAmount = new System.Windows.Forms.Label();
            this.lbChoices = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxChoices = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxChoicesText = new System.Windows.Forms.TextBox();
            this.lbChoiceActions = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddChoiceAction = new System.Windows.Forms.Button();
            this.cbActionType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbChoicesValues = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddChoice = new System.Windows.Forms.Button();
            this.cbChoiceActionsValue = new System.Windows.Forms.ComboBox();
            this.gbxChoices.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEventTitle
            // 
            this.lbEventTitle.AutoSize = true;
            this.lbEventTitle.Location = new System.Drawing.Point(12, 55);
            this.lbEventTitle.Name = "lbEventTitle";
            this.lbEventTitle.Size = new System.Drawing.Size(32, 16);
            this.lbEventTitle.TabIndex = 9;
            this.lbEventTitle.Text = "Titel";
            // 
            // txtEventTitle
            // 
            this.txtEventTitle.Location = new System.Drawing.Point(12, 74);
            this.txtEventTitle.Name = "txtEventTitle";
            this.txtEventTitle.Size = new System.Drawing.Size(760, 22);
            this.txtEventTitle.TabIndex = 8;
            // 
            // lbEventDescription
            // 
            this.lbEventDescription.AutoSize = true;
            this.lbEventDescription.Location = new System.Drawing.Point(12, 99);
            this.lbEventDescription.Name = "lbEventDescription";
            this.lbEventDescription.Size = new System.Drawing.Size(77, 16);
            this.lbEventDescription.TabIndex = 10;
            this.lbEventDescription.Text = "Beschrijving";
            // 
            // txtEventDescription
            // 
            this.txtEventDescription.Location = new System.Drawing.Point(12, 118);
            this.txtEventDescription.Multiline = true;
            this.txtEventDescription.Name = "txtEventDescription";
            this.txtEventDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEventDescription.Size = new System.Drawing.Size(760, 63);
            this.txtEventDescription.TabIndex = 11;
            // 
            // cmbEventType
            // 
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(12, 28);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(760, 24);
            this.cmbEventType.TabIndex = 12;
            this.cmbEventType.SelectedIndexChanged += new System.EventHandler(this.cmbEventType_SelectedIndexChanged);
            // 
            // lbEventType
            // 
            this.lbEventType.AutoSize = true;
            this.lbEventType.Location = new System.Drawing.Point(12, 9);
            this.lbEventType.Name = "lbEventType";
            this.lbEventType.Size = new System.Drawing.Size(75, 16);
            this.lbEventType.TabIndex = 13;
            this.lbEventType.Text = "Soort Event";
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Location = new System.Drawing.Point(258, 519);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(257, 30);
            this.btnCreateEvent.TabIndex = 14;
            this.btnCreateEvent.Text = "Opslaan";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 417);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(33, 16);
            this.lblUrl.TabIndex = 16;
            this.lblUrl.Text = "URL";
            this.lblUrl.Visible = false;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(12, 436);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtUrl.Size = new System.Drawing.Size(760, 22);
            this.txtUrl.TabIndex = 15;
            this.txtUrl.Visible = false;
            this.txtUrl.WordWrap = false;
            // 
            // lbCurrentEventAmount
            // 
            this.lbCurrentEventAmount.AutoSize = true;
            this.lbCurrentEventAmount.Location = new System.Drawing.Point(702, 9);
            this.lbCurrentEventAmount.Name = "lbCurrentEventAmount";
            this.lbCurrentEventAmount.Size = new System.Drawing.Size(70, 16);
            this.lbCurrentEventAmount.TabIndex = 17;
            this.lbCurrentEventAmount.Text = "XXX events";
            // 
            // lbChoices
            // 
            this.lbChoices.FormattingEnabled = true;
            this.lbChoices.HorizontalScrollbar = true;
            this.lbChoices.ItemHeight = 16;
            this.lbChoices.Location = new System.Drawing.Point(6, 37);
            this.lbChoices.Name = "lbChoices";
            this.lbChoices.Size = new System.Drawing.Size(212, 68);
            this.lbChoices.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Beschrijving";
            // 
            // gbxChoices
            // 
            this.gbxChoices.Controls.Add(this.cbChoiceActionsValue);
            this.gbxChoices.Controls.Add(this.btnAddChoice);
            this.gbxChoices.Controls.Add(this.label5);
            this.gbxChoices.Controls.Add(this.tbChoicesValues);
            this.gbxChoices.Controls.Add(this.label4);
            this.gbxChoices.Controls.Add(this.cbActionType);
            this.gbxChoices.Controls.Add(this.btnAddChoiceAction);
            this.gbxChoices.Controls.Add(this.label3);
            this.gbxChoices.Controls.Add(this.lbChoiceActions);
            this.gbxChoices.Controls.Add(this.tbxChoicesText);
            this.gbxChoices.Controls.Add(this.label2);
            this.gbxChoices.Controls.Add(this.lbChoices);
            this.gbxChoices.Controls.Add(this.label1);
            this.gbxChoices.Location = new System.Drawing.Point(12, 187);
            this.gbxChoices.Name = "gbxChoices";
            this.gbxChoices.Size = new System.Drawing.Size(760, 201);
            this.gbxChoices.TabIndex = 20;
            this.gbxChoices.TabStop = false;
            this.gbxChoices.Text = "Choices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tekst:";
            // 
            // tbxChoicesText
            // 
            this.tbxChoicesText.Location = new System.Drawing.Point(55, 111);
            this.tbxChoicesText.Name = "tbxChoicesText";
            this.tbxChoicesText.Size = new System.Drawing.Size(163, 22);
            this.tbxChoicesText.TabIndex = 21;
            // 
            // lbChoiceActions
            // 
            this.lbChoiceActions.FormattingEnabled = true;
            this.lbChoiceActions.ItemHeight = 16;
            this.lbChoiceActions.Location = new System.Drawing.Point(560, 37);
            this.lbChoiceActions.Name = "lbChoiceActions";
            this.lbChoiceActions.Size = new System.Drawing.Size(194, 148);
            this.lbChoiceActions.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Actions";
            // 
            // btnAddChoiceAction
            // 
            this.btnAddChoiceAction.Location = new System.Drawing.Point(479, 162);
            this.btnAddChoiceAction.Name = "btnAddChoiceAction";
            this.btnAddChoiceAction.Size = new System.Drawing.Size(75, 23);
            this.btnAddChoiceAction.TabIndex = 24;
            this.btnAddChoiceAction.Text = "Add";
            this.btnAddChoiceAction.UseVisualStyleBackColor = true;
            this.btnAddChoiceAction.Click += new System.EventHandler(this.btnAddChoiceAction_Click);
            // 
            // cbActionType
            // 
            this.cbActionType.FormattingEnabled = true;
            this.cbActionType.Location = new System.Drawing.Point(344, 37);
            this.cbActionType.Name = "cbActionType";
            this.cbActionType.Size = new System.Drawing.Size(210, 24);
            this.cbActionType.TabIndex = 25;
            this.cbActionType.SelectedIndexChanged += new System.EventHandler(this.cbActionType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Type";
            // 
            // tbChoicesValues
            // 
            this.tbChoicesValues.Location = new System.Drawing.Point(344, 111);
            this.tbChoicesValues.Name = "tbChoicesValues";
            this.tbChoicesValues.Size = new System.Drawing.Size(210, 22);
            this.tbChoicesValues.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Waarden ( scheiden met ; )";
            // 
            // btnAddChoice
            // 
            this.btnAddChoice.Location = new System.Drawing.Point(9, 172);
            this.btnAddChoice.Name = "btnAddChoice";
            this.btnAddChoice.Size = new System.Drawing.Size(209, 23);
            this.btnAddChoice.TabIndex = 28;
            this.btnAddChoice.Text = "Add Choice";
            this.btnAddChoice.UseVisualStyleBackColor = true;
            this.btnAddChoice.Click += new System.EventHandler(this.btnAddChoice_Click);
            // 
            // cbChoiceActionsValue
            // 
            this.cbChoiceActionsValue.FormattingEnabled = true;
            this.cbChoiceActionsValue.Location = new System.Drawing.Point(344, 83);
            this.cbChoiceActionsValue.Name = "cbChoiceActionsValue";
            this.cbChoiceActionsValue.Size = new System.Drawing.Size(210, 24);
            this.cbChoiceActionsValue.TabIndex = 29;
            // 
            // RandomEventGenerator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gbxChoices);
            this.Controls.Add(this.lbCurrentEventAmount);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnCreateEvent);
            this.Controls.Add(this.lbEventType);
            this.Controls.Add(this.cmbEventType);
            this.Controls.Add(this.lbEventTitle);
            this.Controls.Add(this.txtEventTitle);
            this.Controls.Add(this.lbEventDescription);
            this.Controls.Add(this.txtEventDescription);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "RandomEventGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random Event Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RandomEventGenerator_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RandomEventGenerator_KeyPress);
            this.gbxChoices.ResumeLayout(false);
            this.gbxChoices.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEventDescription;
        private System.Windows.Forms.Label lbEventDescription;
        private System.Windows.Forms.TextBox txtEventTitle;
        private System.Windows.Forms.Label lbEventTitle;
        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.Label lbEventType;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lbCurrentEventAmount;
        private System.Windows.Forms.ListBox lbChoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxChoices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbChoiceActions;
        private System.Windows.Forms.TextBox tbxChoicesText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddChoiceAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbActionType;
        private System.Windows.Forms.Button btnAddChoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbChoicesValues;
        private System.Windows.Forms.ComboBox cbChoiceActionsValue;
    }
}