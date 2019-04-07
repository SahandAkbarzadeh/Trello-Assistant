namespace TrelloAsistant
{
    partial class Bar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bar));
            this.DragIcon = new System.Windows.Forms.PictureBox();
            this.CurrentTaskLabel = new System.Windows.Forms.Label();
            this.ToDoneButton = new System.Windows.Forms.Button();
            this.ToPoolButton = new System.Windows.Forms.Button();
            this.ToTestingButton = new System.Windows.Forms.Button();
            this.SyncButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DragIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // DragIcon
            // 
            this.DragIcon.BackColor = System.Drawing.Color.Transparent;
            this.DragIcon.Image = global::TrelloAssistant.Properties.Resources.drag;
            this.DragIcon.Location = new System.Drawing.Point(0, 0);
            this.DragIcon.Name = "DragIcon";
            this.DragIcon.Size = new System.Drawing.Size(30, 30);
            this.DragIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DragIcon.TabIndex = 0;
            this.DragIcon.TabStop = false;
            this.DragIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.DragIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.DragIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // CurrentTaskLabel
            // 
            this.CurrentTaskLabel.AutoEllipsis = true;
            this.CurrentTaskLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentTaskLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTaskLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentTaskLabel.Location = new System.Drawing.Point(26, 6);
            this.CurrentTaskLabel.Name = "CurrentTaskLabel";
            this.CurrentTaskLabel.Size = new System.Drawing.Size(318, 21);
            this.CurrentTaskLabel.TabIndex = 1;
            this.CurrentTaskLabel.Text = "This is a sample Task name and acts like a long text so don\'t mind it please";
            this.CurrentTaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToDoneButton
            // 
            this.ToDoneButton.BackColor = System.Drawing.Color.Transparent;
            this.ToDoneButton.BackgroundImage = global::TrelloAssistant.Properties.Resources.done;
            this.ToDoneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ToDoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToDoneButton.ForeColor = System.Drawing.Color.White;
            this.ToDoneButton.Location = new System.Drawing.Point(343, 3);
            this.ToDoneButton.Name = "ToDoneButton";
            this.ToDoneButton.Size = new System.Drawing.Size(25, 25);
            this.ToDoneButton.TabIndex = 2;
            this.ToDoneButton.UseVisualStyleBackColor = false;
            this.ToDoneButton.Click += new System.EventHandler(this.ToDoneButton_Click);
            // 
            // ToPoolButton
            // 
            this.ToPoolButton.BackColor = System.Drawing.Color.Transparent;
            this.ToPoolButton.BackgroundImage = global::TrelloAssistant.Properties.Resources.to_pool;
            this.ToPoolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ToPoolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToPoolButton.ForeColor = System.Drawing.Color.White;
            this.ToPoolButton.Location = new System.Drawing.Point(370, 3);
            this.ToPoolButton.Name = "ToPoolButton";
            this.ToPoolButton.Size = new System.Drawing.Size(25, 25);
            this.ToPoolButton.TabIndex = 3;
            this.ToPoolButton.UseVisualStyleBackColor = false;
            this.ToPoolButton.Click += new System.EventHandler(this.ToPoolButton_Click);
            // 
            // ToTestingButton
            // 
            this.ToTestingButton.BackColor = System.Drawing.Color.Transparent;
            this.ToTestingButton.BackgroundImage = global::TrelloAssistant.Properties.Resources.test;
            this.ToTestingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ToTestingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToTestingButton.ForeColor = System.Drawing.Color.White;
            this.ToTestingButton.Location = new System.Drawing.Point(397, 3);
            this.ToTestingButton.Name = "ToTestingButton";
            this.ToTestingButton.Size = new System.Drawing.Size(25, 25);
            this.ToTestingButton.TabIndex = 4;
            this.ToTestingButton.UseVisualStyleBackColor = false;
            this.ToTestingButton.Click += new System.EventHandler(this.ToTestingButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.BackColor = System.Drawing.Color.Transparent;
            this.SyncButton.BackgroundImage = global::TrelloAssistant.Properties.Resources.sync;
            this.SyncButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SyncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SyncButton.ForeColor = System.Drawing.Color.White;
            this.SyncButton.Location = new System.Drawing.Point(424, 3);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(25, 25);
            this.SyncButton.TabIndex = 5;
            this.SyncButton.UseVisualStyleBackColor = false;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoEllipsis = true;
            this.StatusLabel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.StatusLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(27, 5);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(311, 21);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Loading";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusLabel.Visible = false;
            // 
            // Bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(452, 30);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.ToTestingButton);
            this.Controls.Add(this.ToPoolButton);
            this.Controls.Add(this.ToDoneButton);
            this.Controls.Add(this.CurrentTaskLabel);
            this.Controls.Add(this.DragIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bar";
            this.Text = "Trello Assistant";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.DragIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DragIcon;
        private System.Windows.Forms.Label CurrentTaskLabel;
        private System.Windows.Forms.Button ToDoneButton;
        private System.Windows.Forms.Button ToPoolButton;
        private System.Windows.Forms.Button ToTestingButton;
        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.Label StatusLabel;
    }
}

