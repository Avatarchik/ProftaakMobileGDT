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
            this.SuspendLayout();
            // 
            // lbEventTitle
            // 
            this.lbEventTitle.AutoSize = true;
            this.lbEventTitle.Location = new System.Drawing.Point(255, 55);
            this.lbEventTitle.Name = "lbEventTitle";
            this.lbEventTitle.Size = new System.Drawing.Size(32, 16);
            this.lbEventTitle.TabIndex = 9;
            this.lbEventTitle.Text = "Titel";
            // 
            // txtEventTitle
            // 
            this.txtEventTitle.Location = new System.Drawing.Point(258, 74);
            this.txtEventTitle.Name = "txtEventTitle";
            this.txtEventTitle.Size = new System.Drawing.Size(257, 22);
            this.txtEventTitle.TabIndex = 8;
            // 
            // lbEventDescription
            // 
            this.lbEventDescription.AutoSize = true;
            this.lbEventDescription.Location = new System.Drawing.Point(255, 99);
            this.lbEventDescription.Name = "lbEventDescription";
            this.lbEventDescription.Size = new System.Drawing.Size(77, 16);
            this.lbEventDescription.TabIndex = 10;
            this.lbEventDescription.Text = "Beschrijving";
            // 
            // txtEventDescription
            // 
            this.txtEventDescription.Location = new System.Drawing.Point(258, 118);
            this.txtEventDescription.Multiline = true;
            this.txtEventDescription.Name = "txtEventDescription";
            this.txtEventDescription.Size = new System.Drawing.Size(257, 139);
            this.txtEventDescription.TabIndex = 11;
            // 
            // cmbEventType
            // 
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(258, 28);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(257, 24);
            this.cmbEventType.TabIndex = 12;
            this.cmbEventType.SelectedIndexChanged += new System.EventHandler(this.cmbEventType_SelectedIndexChanged);
            // 
            // lbEventType
            // 
            this.lbEventType.AutoSize = true;
            this.lbEventType.Location = new System.Drawing.Point(255, 9);
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
            this.lblUrl.Location = new System.Drawing.Point(255, 260);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(33, 16);
            this.lblUrl.TabIndex = 16;
            this.lblUrl.Text = "URL";
            this.lblUrl.Visible = false;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(258, 279);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(257, 22);
            this.txtUrl.TabIndex = 15;
            this.txtUrl.Visible = false;
            // 
            // RandomEventGenerator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
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
            this.Name = "RandomEventGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random Event Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RandomEventGenerator_FormClosed);
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
    }
}