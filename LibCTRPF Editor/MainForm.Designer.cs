namespace libEditor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            
            base.Dispose(disposing);
        }
        
        #region Code généré par le Concepteur Windows Form
        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.EditorTabs = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.LibVersionLabel = new System.Windows.Forms.Label();
            this.LibVersionComboBox = new System.Windows.Forms.ComboBox();
            this.BackupButton = new System.Windows.Forms.Button();
            this.GenerateDefaultLibButton = new System.Windows.Forms.Button();
            this.AutoSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.FileLoadedLabel = new System.Windows.Forms.Label();
            this.IconsTab = new System.Windows.Forms.TabPage();
            this.IconsGroupBox = new System.Windows.Forms.GroupBox();
            this.DownloadIcons = new System.Windows.Forms.Button();
            this.SaveIconButton = new System.Windows.Forms.Button();
            this.NewIconButton = new System.Windows.Forms.Button();
            this.IconsComboBox = new System.Windows.Forms.ComboBox();
            this.CreditsTab = new System.Windows.Forms.TabPage();
            this.CreditsLabel = new System.Windows.Forms.Label();
            this.EditorTabs.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.IconsTab.SuspendLayout();
            this.IconsGroupBox.SuspendLayout();
            this.CreditsTab.SuspendLayout();
            this.SuspendLayout();
            
            this.EditorTabs.AllowDrop = true;
            this.EditorTabs.Controls.Add(this.MainTab);
            this.EditorTabs.Controls.Add(this.IconsTab);
            this.EditorTabs.Controls.Add(this.CreditsTab);
            this.EditorTabs.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.EditorTabs.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorTabs.ItemSize = new System.Drawing.Size(147, 19);
            this.EditorTabs.Location = new System.Drawing.Point(1, 1);
            this.EditorTabs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EditorTabs.Name = "EditorTabs";
            this.EditorTabs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EditorTabs.SelectedIndex = 0;
            this.EditorTabs.Size = new System.Drawing.Size(284, 139);
            this.EditorTabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.EditorTabs.TabIndex = 0;
            
            this.MainTab.AllowDrop = true;
            this.MainTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.MainTab.CausesValidation = false;
            this.MainTab.Controls.Add(this.LibVersionLabel);
            this.MainTab.Controls.Add(this.LibVersionComboBox);
            this.MainTab.Controls.Add(this.BackupButton);
            this.MainTab.Controls.Add(this.GenerateDefaultLibButton);
            this.MainTab.Controls.Add(this.AutoSaveCheckBox);
            this.MainTab.Controls.Add(this.FileLoadedLabel);
            this.MainTab.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainTab.Location = new System.Drawing.Point(4, 23);
            this.MainTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainTab.Size = new System.Drawing.Size(276, 112);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "Main";
            
            this.LibVersionLabel.AutoSize = true;
            this.LibVersionLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LibVersionLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.LibVersionLabel.Location = new System.Drawing.Point(170, 12);
            this.LibVersionLabel.Name = "LibVersionLabel";
            this.LibVersionLabel.Size = new System.Drawing.Size(125, 21);
            this.LibVersionLabel.TabIndex = 7;
            this.LibVersionLabel.Text = "CTRPF Version";
            
            this.LibVersionComboBox.BackColor = System.Drawing.Color.White;
            this.LibVersionComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LibVersionComboBox.DropDownHeight = 55;
            this.LibVersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LibVersionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LibVersionComboBox.FormattingEnabled = true;
            this.LibVersionComboBox.IntegralHeight = false;
            this.LibVersionComboBox.ItemHeight = 21;
            this.LibVersionComboBox.Items.AddRange(new object[] {"v0.7.0"});
            this.LibVersionComboBox.Location = new System.Drawing.Point(174, 37);
            this.LibVersionComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LibVersionComboBox.Name = "LibVersionComboBox";
            this.LibVersionComboBox.Size = new System.Drawing.Size(95, 29);
            this.LibVersionComboBox.TabIndex = 6;
            this.LibVersionComboBox.TextChanged += new System.EventHandler(this.LibVersionTextChanged);
            
            this.BackupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.BackupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackupButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BackupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.BackupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.BackupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackupButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupButton.ForeColor = System.Drawing.Color.White;
            this.BackupButton.Location = new System.Drawing.Point(146, 74);
            this.BackupButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(123, 30);
            this.BackupButton.TabIndex = 5;
            this.BackupButton.Text = "Backup";
            this.BackupButton.UseVisualStyleBackColor = false;
            this.BackupButton.Click += new System.EventHandler(this.BackupLoadedLibClicked);
            
            this.GenerateDefaultLibButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.GenerateDefaultLibButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateDefaultLibButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.GenerateDefaultLibButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.GenerateDefaultLibButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.GenerateDefaultLibButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateDefaultLibButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateDefaultLibButton.ForeColor = System.Drawing.Color.White;
            this.GenerateDefaultLibButton.Location = new System.Drawing.Point(7, 74);
            this.GenerateDefaultLibButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GenerateDefaultLibButton.Name = "GenerateDefaultLibButton";
            this.GenerateDefaultLibButton.Size = new System.Drawing.Size(123, 30);
            this.GenerateDefaultLibButton.TabIndex = 4;
            this.GenerateDefaultLibButton.Text = "Default";
            this.GenerateDefaultLibButton.UseVisualStyleBackColor = false;
            this.GenerateDefaultLibButton.Click += new System.EventHandler(this.GenerateDefaultLibClicked);
            
            this.AutoSaveCheckBox.AutoSize = true;
            this.AutoSaveCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoSaveCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.AutoSaveCheckBox.ForeColor = System.Drawing.Color.PowderBlue;
            this.AutoSaveCheckBox.Location = new System.Drawing.Point(6, 37);
            this.AutoSaveCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoSaveCheckBox.Name = "AutoSaveCheckBox";
            this.AutoSaveCheckBox.Size = new System.Drawing.Size(120, 25);
            this.AutoSaveCheckBox.TabIndex = 2;
            this.AutoSaveCheckBox.Text = "Auto Save";
            this.AutoSaveCheckBox.UseVisualStyleBackColor = true;
            
            this.FileLoadedLabel.AutoSize = true;
            this.FileLoadedLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLoadedLabel.ForeColor = System.Drawing.Color.Orange;
            this.FileLoadedLabel.Location = new System.Drawing.Point(7, 12);
            this.FileLoadedLabel.Name = "FileLoadedLabel";
            this.FileLoadedLabel.Size = new System.Drawing.Size(139, 21);
            this.FileLoadedLabel.TabIndex = 1;
            
            this.IconsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.IconsTab.CausesValidation = false;
            this.IconsTab.Controls.Add(this.IconsGroupBox);
            this.IconsTab.Location = new System.Drawing.Point(4, 23);
            this.IconsTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IconsTab.Name = "IconsTab";
            this.IconsTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IconsTab.Size = new System.Drawing.Size(276, 112);
            this.IconsTab.TabIndex = 1;
            this.IconsTab.Text = "Icons";
            
            this.IconsGroupBox.Controls.Add(this.DownloadIcons);
            this.IconsGroupBox.Controls.Add(this.SaveIconButton);
            this.IconsGroupBox.Controls.Add(this.NewIconButton);
            this.IconsGroupBox.Controls.Add(this.IconsComboBox);
            this.IconsGroupBox.Location = new System.Drawing.Point(-4, -11);
            this.IconsGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IconsGroupBox.Name = "IconsGroupBox";
            this.IconsGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IconsGroupBox.Size = new System.Drawing.Size(296, 141);
            this.IconsGroupBox.TabIndex = 0;
            
            this.DownloadIcons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.DownloadIcons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownloadIcons.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DownloadIcons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.DownloadIcons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.DownloadIcons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadIcons.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadIcons.ForeColor = System.Drawing.Color.White;
            this.DownloadIcons.Location = new System.Drawing.Point(11, 85);
            this.DownloadIcons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DownloadIcons.Name = "DownloadIcons";
            this.DownloadIcons.Size = new System.Drawing.Size(262, 30);
            this.DownloadIcons.TabIndex = 6;
            this.DownloadIcons.Text = "Download";
            this.DownloadIcons.UseVisualStyleBackColor = false;
            this.DownloadIcons.Click += new System.EventHandler(this.DownloadIconsClick);
            
            this.SaveIconButton.AutoEllipsis = true;
            this.SaveIconButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveIconButton.Enabled = false;
            this.SaveIconButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SaveIconButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveIconButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SaveIconButton.Location = new System.Drawing.Point(222, 25);
            this.SaveIconButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveIconButton.Name = "SaveIconButton";
            this.SaveIconButton.Size = new System.Drawing.Size(50, 31);
            this.SaveIconButton.TabIndex = 4;
            this.SaveIconButton.Text = "Save";
            this.SaveIconButton.UseVisualStyleBackColor = true;
            this.SaveIconButton.Click += new System.EventHandler(this.SaveNewIconClick);
            
            this.NewIconButton.AllowDrop = true;
            this.NewIconButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.NewIconButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewIconButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NewIconButton.Location = new System.Drawing.Point(147, 25);
            this.NewIconButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewIconButton.Name = "NewIconButton";
            this.NewIconButton.Size = new System.Drawing.Size(69, 31);
            this.NewIconButton.TabIndex = 3;
            this.NewIconButton.Text = "Open";
            this.NewIconButton.UseVisualStyleBackColor = true;
            this.NewIconButton.Click += new System.EventHandler(this.NewIconButtonClick);
            this.NewIconButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.NewIconDragDrop);
            this.NewIconButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.NewIconDragEnter);
            
            this.IconsComboBox.AllowDrop = true;
            this.IconsComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconsComboBox.DropDownHeight = 140;
            this.IconsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IconsComboBox.DropDownWidth = 200;
            this.IconsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IconsComboBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconsComboBox.FormattingEnabled = true;
            this.IconsComboBox.IntegralHeight = false;
            this.IconsComboBox.Items.AddRange(new object[]
            {
                "About15",
                "CapsLockOn15",
                "CapsLockOnFilled15",
                "CentreofGravity15",
                "UnCheckedCheckbox15",
                "CheckedCheckbox15",
                "ClearSymbol15",
                "ClearSymbolFilled15",
                "Clipboard25",
                "ClipboardFilled25",
                "CloseWindow20",
                "CloseWindowFilled20",
                "Controller15",
                "Cut25",
                "CutFilled25",
                "Duplicate25",
                "DuplicateFilled25",
                "Edit25",
                "EditFilled25",
                "EnterKey15",
                "EnterKeyFilled15",
                "FolderFilled15",
                "AddFavorite25",
                "AddFavoriteFilled25",
                "Star15",
                "File15",
                "GameController25",
                "GameControllerFilled25",
                "Grid15",
                "Info25",
                "InfoFilled25",
                "UserManualFilled15",
                "HandCursor15",
                "Happy15",
                "HappyFilled15",
                "Keyboard25",
                "KeyboardFilled25",
                "More15",
                "Plus25",
                "PlusFilled25",
                "RAM15",
                "Restart15",
                "Rocket40",
                "Save25",
                "Search15",
                "Settings15",
                "Shutdown15",
                "Maintenance15",
                "Trash25",
                "TrashFilled25"
            });
            this.IconsComboBox.Location = new System.Drawing.Point(11, 28);
            this.IconsComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IconsComboBox.Name = "IconsComboBox";
            this.IconsComboBox.Size = new System.Drawing.Size(130, 29);
            this.IconsComboBox.TabIndex = 0;
            this.IconsComboBox.SelectedIndexChanged += new System.EventHandler(this.IconsGroupBoxIndexChanged);
            this.IconsComboBox.TextChanged += new System.EventHandler(this.IconsGroupBoxTextChanged);
            
            this.CreditsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.CreditsTab.Controls.Add(this.CreditsLabel);
            this.CreditsTab.Location = new System.Drawing.Point(4, 23);
            this.CreditsTab.Name = "CreditsTab";
            this.CreditsTab.Size = new System.Drawing.Size(276, 112);
            this.CreditsTab.TabIndex = 2;
            this.CreditsTab.Text = "Credits";
            
            this.CreditsLabel.AutoEllipsis = true;
            this.CreditsLabel.AutoSize = true;
            this.CreditsLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsLabel.ForeColor = System.Drawing.Color.White;
            this.CreditsLabel.Location = new System.Drawing.Point(7, 10);
            this.CreditsLabel.Name = "CreditsLabel";
            this.CreditsLabel.Size = new System.Drawing.Size(286, 63);
            this.CreditsLabel.TabIndex = 8;
            this.CreditsLabel.Text = "Original program developed by\r\nKominost, updated and modified\r\nby Jared0714";
            
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(287, 144);
            this.Controls.Add(this.EditorTabs);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibCTRPF Editor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainDragEnter);
            this.EditorTabs.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.MainTab.PerformLayout();
            this.IconsTab.ResumeLayout(false);
            this.IconsGroupBox.ResumeLayout(false);
            this.CreditsTab.ResumeLayout(false);
            this.CreditsTab.PerformLayout();
            this.ResumeLayout(false);
        }
        
        #endregion
        private System.Windows.Forms.TabPage IconsTab;
        private System.Windows.Forms.TabControl EditorTabs;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.Label LibVersionLabel;
        private System.Windows.Forms.ComboBox LibVersionComboBox;
        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.Button GenerateDefaultLibButton;
        private System.Windows.Forms.CheckBox AutoSaveCheckBox;
        private System.Windows.Forms.Label FileLoadedLabel;
        private System.Windows.Forms.GroupBox IconsGroupBox;
        private System.Windows.Forms.Button SaveIconButton;
        private System.Windows.Forms.Button NewIconButton;
        private System.Windows.Forms.ComboBox IconsComboBox;
        private System.Windows.Forms.Button DownloadIcons;
        private System.Windows.Forms.TabPage CreditsTab;
        private System.Windows.Forms.Label CreditsLabel;
    }
}