namespace MSCSaveManager
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toast = new System.Windows.Forms.ToolStripStatusLabel();
            this.mscSaveFolder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.autoBackup = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.includeMods = new System.Windows.Forms.CheckBox();
            this.slotsNotesSave = new System.Windows.Forms.Button();
            this.restore = new System.Windows.Forms.TabPage();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.restoreTimestamp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSelection = new System.Windows.Forms.ComboBox();
            this.backup = new System.Windows.Forms.TabPage();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.note = new System.Windows.Forms.TextBox();
            this.saveTimestamp = new System.Windows.Forms.Label();
            this.tabpage = new System.Windows.Forms.TabControl();
            this.saveSlots = new System.Windows.Forms.TabPage();
            this.slotTimestamp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.slotNotes = new System.Windows.Forms.RichTextBox();
            this.slotsMods = new System.Windows.Forms.CheckBox();
            this.slotSelection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.slotDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.slotsSave = new System.Windows.Forms.Button();
            this.slotsLoad = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.slotsUse = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.restore.SuspendLayout();
            this.backup.SuspendLayout();
            this.tabpage.SuspendLayout();
            this.saveSlots.SuspendLayout();
            this.about.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentDate,
            this.currentTime,
            this.toast});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(402, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // currentDate
            // 
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(69, 17);
            this.currentDate.Text = "currentDate";
            // 
            // currentTime
            // 
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(71, 17);
            this.currentTime.Text = "currentTime";
            // 
            // toast
            // 
            this.toast.Name = "toast";
            this.toast.Size = new System.Drawing.Size(247, 17);
            this.toast.Spring = true;
            this.toast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mscSaveFolder
            // 
            this.mscSaveFolder.Location = new System.Drawing.Point(4, 260);
            this.mscSaveFolder.Name = "mscSaveFolder";
            this.mscSaveFolder.Size = new System.Drawing.Size(394, 40);
            this.mscSaveFolder.TabIndex = 3;
            this.mscSaveFolder.Text = "MSC Save Folder";
            this.mscSaveFolder.UseVisualStyleBackColor = true;
            this.mscSaveFolder.Click += new System.EventHandler(this.mscSaveFolder_Click);
            // 
            // autoBackup
            // 
            this.autoBackup.AutoSize = true;
            this.autoBackup.Location = new System.Drawing.Point(8, 23);
            this.autoBackup.Name = "autoBackup";
            this.autoBackup.Size = new System.Drawing.Size(88, 17);
            this.autoBackup.TabIndex = 0;
            this.autoBackup.Text = "Auto Backup";
            this.toolTip1.SetToolTip(this.autoBackup, "Create new backup each time when you save a game.");
            this.autoBackup.UseVisualStyleBackColor = true;
            this.autoBackup.CheckedChanged += new System.EventHandler(this.autoBackup_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Save Timestamp:";
            this.toolTip1.SetToolTip(this.label1, "Last modification date of a save file");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Note:";
            this.toolTip1.SetToolTip(this.label2, "This text will be included at the end of filename");
            // 
            // includeMods
            // 
            this.includeMods.AutoSize = true;
            this.includeMods.Location = new System.Drawing.Point(8, 46);
            this.includeMods.Name = "includeMods";
            this.includeMods.Size = new System.Drawing.Size(90, 17);
            this.includeMods.TabIndex = 7;
            this.includeMods.Text = "Include Mods";
            this.toolTip1.SetToolTip(this.includeMods, "If checked this program will be adding mods folder to backup (not recommended it " +
        "takes much space)");
            this.includeMods.UseVisualStyleBackColor = true;
            // 
            // slotsNotesSave
            // 
            this.slotsNotesSave.Enabled = false;
            this.slotsNotesSave.Location = new System.Drawing.Point(207, 129);
            this.slotsNotesSave.Name = "slotsNotesSave";
            this.slotsNotesSave.Size = new System.Drawing.Size(75, 23);
            this.slotsNotesSave.TabIndex = 13;
            this.slotsNotesSave.Text = "SaveNotes";
            this.toolTip1.SetToolTip(this.slotsNotesSave, "This button will only save notes");
            this.slotsNotesSave.UseVisualStyleBackColor = true;
            this.slotsNotesSave.Click += new System.EventHandler(this.slotsNotesSave_Click);
            // 
            // restore
            // 
            this.restore.Controls.Add(this.buttonRestore);
            this.restore.Controls.Add(this.restoreTimestamp);
            this.restore.Controls.Add(this.label3);
            this.restore.Controls.Add(this.fileSelection);
            this.restore.Location = new System.Drawing.Point(4, 22);
            this.restore.Name = "restore";
            this.restore.Padding = new System.Windows.Forms.Padding(3);
            this.restore.Size = new System.Drawing.Size(394, 228);
            this.restore.TabIndex = 2;
            this.restore.Text = "RESTORE";
            this.restore.UseVisualStyleBackColor = true;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(8, 177);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(378, 45);
            this.buttonRestore.TabIndex = 3;
            this.buttonRestore.Text = "Restore!";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // restoreTimestamp
            // 
            this.restoreTimestamp.AutoSize = true;
            this.restoreTimestamp.Location = new System.Drawing.Point(132, 61);
            this.restoreTimestamp.Name = "restoreTimestamp";
            this.restoreTimestamp.Size = new System.Drawing.Size(0, 13);
            this.restoreTimestamp.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Selected save timestamp:";
            // 
            // fileSelection
            // 
            this.fileSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileSelection.FormattingEnabled = true;
            this.fileSelection.Location = new System.Drawing.Point(8, 18);
            this.fileSelection.Name = "fileSelection";
            this.fileSelection.Size = new System.Drawing.Size(378, 21);
            this.fileSelection.TabIndex = 0;
            this.fileSelection.DropDown += new System.EventHandler(this.fileSelection_DropDown);
            this.fileSelection.SelectionChangeCommitted += new System.EventHandler(this.fileSelection_SelectionChangeCommitted);
            // 
            // backup
            // 
            this.backup.Controls.Add(this.includeMods);
            this.backup.Controls.Add(this.pictureBox1);
            this.backup.Controls.Add(this.buttonBackup);
            this.backup.Controls.Add(this.note);
            this.backup.Controls.Add(this.saveTimestamp);
            this.backup.Controls.Add(this.label2);
            this.backup.Controls.Add(this.label1);
            this.backup.Controls.Add(this.autoBackup);
            this.backup.Location = new System.Drawing.Point(4, 22);
            this.backup.Name = "backup";
            this.backup.Padding = new System.Windows.Forms.Padding(3);
            this.backup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backup.Size = new System.Drawing.Size(394, 228);
            this.backup.TabIndex = 0;
            this.backup.Text = "BACKUP";
            this.backup.UseVisualStyleBackColor = true;
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(8, 177);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(378, 45);
            this.buttonBackup.TabIndex = 5;
            this.buttonBackup.Text = "Backup!";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // note
            // 
            this.note.Location = new System.Drawing.Point(44, 133);
            this.note.MaxLength = 140;
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(167, 20);
            this.note.TabIndex = 4;
            // 
            // saveTimestamp
            // 
            this.saveTimestamp.AutoSize = true;
            this.saveTimestamp.Location = new System.Drawing.Point(90, 88);
            this.saveTimestamp.Name = "saveTimestamp";
            this.saveTimestamp.Size = new System.Drawing.Size(81, 13);
            this.saveTimestamp.TabIndex = 3;
            this.saveTimestamp.Text = "saveTimestamp";
            // 
            // tabpage
            // 
            this.tabpage.Controls.Add(this.backup);
            this.tabpage.Controls.Add(this.restore);
            this.tabpage.Controls.Add(this.saveSlots);
            this.tabpage.Controls.Add(this.about);
            this.tabpage.Location = new System.Drawing.Point(0, 0);
            this.tabpage.Name = "tabpage";
            this.tabpage.SelectedIndex = 0;
            this.tabpage.Size = new System.Drawing.Size(402, 254);
            this.tabpage.TabIndex = 1;
            this.tabpage.SelectedIndexChanged += new System.EventHandler(this.tabpage_SelectedIndexChanged);
            // 
            // saveSlots
            // 
            this.saveSlots.Controls.Add(this.slotsNotesSave);
            this.saveSlots.Controls.Add(this.slotTimestamp);
            this.saveSlots.Controls.Add(this.label6);
            this.saveSlots.Controls.Add(this.slotNotes);
            this.saveSlots.Controls.Add(this.slotsMods);
            this.saveSlots.Controls.Add(this.slotSelection);
            this.saveSlots.Controls.Add(this.label4);
            this.saveSlots.Controls.Add(this.slotDelete);
            this.saveSlots.Controls.Add(this.label5);
            this.saveSlots.Controls.Add(this.slotsSave);
            this.saveSlots.Controls.Add(this.slotsLoad);
            this.saveSlots.Controls.Add(this.slotsUse);
            this.saveSlots.Location = new System.Drawing.Point(4, 22);
            this.saveSlots.Name = "saveSlots";
            this.saveSlots.Padding = new System.Windows.Forms.Padding(3);
            this.saveSlots.Size = new System.Drawing.Size(394, 228);
            this.saveSlots.TabIndex = 3;
            this.saveSlots.Text = "SAVE SLOTS";
            this.saveSlots.UseVisualStyleBackColor = true;
            // 
            // slotTimestamp
            // 
            this.slotTimestamp.AutoSize = true;
            this.slotTimestamp.Location = new System.Drawing.Point(65, 81);
            this.slotTimestamp.Name = "slotTimestamp";
            this.slotTimestamp.Size = new System.Drawing.Size(0, 13);
            this.slotTimestamp.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Notes:";
            // 
            // slotNotes
            // 
            this.slotNotes.Enabled = false;
            this.slotNotes.Location = new System.Drawing.Point(6, 129);
            this.slotNotes.MaxLength = 316;
            this.slotNotes.Name = "slotNotes";
            this.slotNotes.Size = new System.Drawing.Size(195, 64);
            this.slotNotes.TabIndex = 10;
            this.slotNotes.Text = "";
            // 
            // slotsMods
            // 
            this.slotsMods.AutoSize = true;
            this.slotsMods.Enabled = false;
            this.slotsMods.Location = new System.Drawing.Point(297, 10);
            this.slotsMods.Name = "slotsMods";
            this.slotsMods.Size = new System.Drawing.Size(89, 17);
            this.slotsMods.TabIndex = 9;
            this.slotsMods.Text = "Include mods";
            this.slotsMods.UseVisualStyleBackColor = true;
            // 
            // slotSelection
            // 
            this.slotSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.slotSelection.FormattingEnabled = true;
            this.slotSelection.Items.AddRange(new object[] {
            "Slot 1",
            "Slot 2",
            "Slot 3",
            "Slot 4"});
            this.slotSelection.Location = new System.Drawing.Point(6, 6);
            this.slotSelection.Name = "slotSelection";
            this.slotSelection.Size = new System.Drawing.Size(121, 21);
            this.slotSelection.TabIndex = 8;
            this.slotSelection.SelectionChangeCommitted += new System.EventHandler(this.slotSelection_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Last played:";
            // 
            // slotDelete
            // 
            this.slotDelete.Location = new System.Drawing.Point(253, 199);
            this.slotDelete.Name = "slotDelete";
            this.slotDelete.Size = new System.Drawing.Size(100, 23);
            this.slotDelete.TabIndex = 6;
            this.slotDelete.Text = "Delete";
            this.slotDelete.UseVisualStyleBackColor = true;
            this.slotDelete.Click += new System.EventHandler(this.slotDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "In use:";
            // 
            // slotsSave
            // 
            this.slotsSave.Location = new System.Drawing.Point(147, 199);
            this.slotsSave.Name = "slotsSave";
            this.slotsSave.Size = new System.Drawing.Size(100, 23);
            this.slotsSave.TabIndex = 1;
            this.slotsSave.Text = "Save";
            this.slotsSave.UseVisualStyleBackColor = true;
            this.slotsSave.Click += new System.EventHandler(this.slotsSave_Click);
            // 
            // slotsLoad
            // 
            this.slotsLoad.Location = new System.Drawing.Point(41, 199);
            this.slotsLoad.Name = "slotsLoad";
            this.slotsLoad.Size = new System.Drawing.Size(100, 23);
            this.slotsLoad.TabIndex = 0;
            this.slotsLoad.Text = "Load";
            this.slotsLoad.UseVisualStyleBackColor = true;
            this.slotsLoad.Click += new System.EventHandler(this.slotsLoad_Click);
            // 
            // about
            // 
            this.about.Controls.Add(this.button1);
            this.about.Controls.Add(this.label8);
            this.about.Controls.Add(this.label7);
            this.about.Controls.Add(this.pictureBox2);
            this.about.Location = new System.Drawing.Point(4, 22);
            this.about.Name = "about";
            this.about.Padding = new System.Windows.Forms.Padding(3);
            this.about.Size = new System.Drawing.Size(394, 228);
            this.about.TabIndex = 4;
            this.about.Text = "ABOUT";
            this.about.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "github";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(355, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "v1.0.0\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(8, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 32);
            this.label7.TabIndex = 1;
            this.label7.Text = "Made by: Szymon Kaczmarek\r\n\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(221, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Beer");
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // slotsUse
            // 
            this.slotsUse.Image = global::MSCSaveManager.Properties.Resources.Ampeross_Qetto_2_No_256;
            this.slotsUse.Location = new System.Drawing.Point(49, 42);
            this.slotsUse.Name = "slotsUse";
            this.slotsUse.Size = new System.Drawing.Size(20, 20);
            this.slotsUse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.slotsUse.TabIndex = 4;
            this.slotsUse.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MSCSaveManager.Properties.Resources.MSCSaveManagerIcon;
            this.pictureBox2.Location = new System.Drawing.Point(228, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 329);
            this.Controls.Add(this.mscSaveFolder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabpage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSC Save Manager";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.restore.ResumeLayout(false);
            this.restore.PerformLayout();
            this.backup.ResumeLayout(false);
            this.backup.PerformLayout();
            this.tabpage.ResumeLayout(false);
            this.saveSlots.ResumeLayout(false);
            this.saveSlots.PerformLayout();
            this.about.ResumeLayout(false);
            this.about.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel currentDate;
        private System.Windows.Forms.ToolStripStatusLabel currentTime;
        private System.Windows.Forms.Button mscSaveFolder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage restore;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Label restoreTimestamp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fileSelection;
        private System.Windows.Forms.TabPage backup;
        private System.Windows.Forms.CheckBox includeMods;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Label saveTimestamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox autoBackup;
        private System.Windows.Forms.TabControl tabpage;
        private System.Windows.Forms.TabPage saveSlots;
        private System.Windows.Forms.ToolStripStatusLabel toast;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox slotsUse;
        private System.Windows.Forms.Button slotsSave;
        private System.Windows.Forms.Button slotsLoad;
        private System.Windows.Forms.TabPage about;
        private System.Windows.Forms.CheckBox slotsMods;
        private System.Windows.Forms.ComboBox slotSelection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button slotDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox slotNotes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label slotTimestamp;
        private System.Windows.Forms.Button slotsNotesSave;
        private System.Windows.Forms.Button button1;
    }
}

