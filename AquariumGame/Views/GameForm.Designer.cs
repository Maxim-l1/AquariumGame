namespace AquariumGame.Views
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Save = new System.Windows.Forms.Button();
            this.Download = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IsGameOver = new System.Windows.Forms.Timer(this.components);
            this.AddFishTimer = new System.Windows.Forms.Timer(this.components);
            this.gun = new System.Windows.Forms.PictureBox();
            this.AddTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gun)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(491, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.Highlight;
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(3, 668);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(276, 79);
            this.Save.TabIndex = 1;
            this.Save.Text = "Сохранить прогресс";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Download
            // 
            this.Download.BackColor = System.Drawing.SystemColors.Highlight;
            this.Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Download.Location = new System.Drawing.Point(285, 668);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(276, 79);
            this.Download.TabIndex = 2;
            this.Download.Text = "Загрузить прогресс";
            this.Download.UseVisualStyleBackColor = false;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // IsGameOver
            // 
            this.IsGameOver.Tick += new System.EventHandler(this.IsGameOver_Tick);
            // 
            // AddFishTimer
            // 
            this.AddFishTimer.Interval = 500;
            this.AddFishTimer.Tick += new System.EventHandler(this.AddFishTimer_Tick);
            // 
            // gun
            // 
            this.gun.BackColor = System.Drawing.Color.Transparent;
            this.gun.Location = new System.Drawing.Point(255, 587);
            this.gun.Name = "gun";
            this.gun.Size = new System.Drawing.Size(65, 65);
            this.gun.TabIndex = 4;
            this.gun.TabStop = false;
            // 
            // AddTimer
            // 
            this.AddTimer.Interval = 30000;
            this.AddTimer.Tick += new System.EventHandler(this.AddTimer_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AquariumGame.Properties.Resources.back1;
            this.ClientSize = new System.Drawing.Size(563, 749);
            this.Controls.Add(this.gun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Aquarium Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer IsGameOver;
        private System.Windows.Forms.Timer AddFishTimer;
        private System.Windows.Forms.PictureBox gun;
        private System.Windows.Forms.Timer AddTimer;
    }
}