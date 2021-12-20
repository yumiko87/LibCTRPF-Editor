using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace LibEditor {
    public partial class MainForm : Form {
        private string droppedFile;
        private byte[] droppedFileBytes = null;
        private bool isFileLoaded = false;
        private Bitmap newIconBmp;
        
        public MainForm() {
            InitializeComponent();
            this.LibVersionComboBox.SelectedIndex = 0;
            this.IconsComboBox.SelectedIndex = 0;
        }
        
        private void UpdateIconImage() {
            if (Icons.AllIcons().Contains(this.IconsComboBox.Text) && isFileLoaded) {
                Bitmap iconBmp = new Bitmap(Icons.GetDimension("Width", this.IconsComboBox.Text), Icons.GetDimension("Height", this.IconsComboBox.Text));
                byte[] curIconBytes = Icons.GetBytes(droppedFileBytes, this.IconsComboBox.Text);
                int pixelIndex = 0;
                
                for (int x = 0; x < iconBmp.Width; x++) {
                    for (int y = 0; y < iconBmp.Height; y++) {
                        iconBmp.SetPixel(x, iconBmp.Height - y - 1, Color.FromArgb(curIconBytes[pixelIndex], curIconBytes[pixelIndex + 3], curIconBytes[pixelIndex + 2], curIconBytes[pixelIndex + 1]));
                        pixelIndex += 4;
                    }
                }
            }
        }
        
        private void ShowNewIconPreview(ref Image newIconImg) {
            if (isFileLoaded) {
                if (Icons.AllIcons().Contains(this.IconsComboBox.Text)) {
                    Bitmap newIconBmp = new Bitmap(Icons.GetDimension("Width", this.IconsComboBox.Text), Icons.GetDimension("Height", this.IconsComboBox.Text));
                    
                    if (newIconBmp.Width == newIconImg.Width && newIconBmp.Height == newIconImg.Height) {
                        MessageBox.Show("Done!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    else {
                        MessageBox.Show(string.Concat("New icon dimensions for ", this.IconsComboBox.Text, " must be ", newIconBmp.Width.ToString(), 'x', newIconBmp.Height.ToString(), '!'), "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        newIconImg = null;
                    }
                }
            }
        }
        
        private void SaveNewIcon() {
            if (isFileLoaded) {
                if (newIconBmp != null) {
                    int pixelIndex = 0;
                    
                    for (int x = 0; x < newIconBmp.Width; x++) {
                        for (int y = 0; y < newIconBmp.Height; y++) {
                            droppedFileBytes[Icons.AllIconOffset(this.IconsComboBox.Text) + pixelIndex] = newIconBmp.GetPixel(x, newIconBmp.Height - y - 1).A;
                            droppedFileBytes[Icons.AllIconOffset(this.IconsComboBox.Text) + pixelIndex + 3] = newIconBmp.GetPixel(x, newIconBmp.Height - y - 1).R;
                            droppedFileBytes[Icons.AllIconOffset(this.IconsComboBox.Text) + pixelIndex + 2] = newIconBmp.GetPixel(x, newIconBmp.Height - y - 1).G;
                            droppedFileBytes[Icons.AllIconOffset(this.IconsComboBox.Text) + pixelIndex + 1] = newIconBmp.GetPixel(x, newIconBmp.Height - y - 1).B;
                            pixelIndex += 4;
                        }
                    }
                    
                    using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(droppedFile))) {
                        writer.Write(droppedFileBytes);
                        writer.Flush();
                    }
                    
                    MessageBox.Show(string.Concat("Successfully saved new icon for ", this.IconsComboBox.Text, '!'), "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            else {
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void MainDragEnter(object sender, DragEventArgs e) {
            string[] dragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string ext = Path.GetExtension(dragFile[0]).ToLower();
            
            if (ext == ".a" && dragFile.Length == 1) {
                e.Effect = DragDropEffects.Move;
            }
            
            else {
                e.Effect = DragDropEffects.None;
            }
        }
        
        private void NewIconDragEnter(object sender, DragEventArgs e) {
            string[] dragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string ext = Path.GetExtension(dragFile[0]).ToLower();
            
            if ((ext == ".png" || ext == ".jpg" || ext == ".bmp") && dragFile.Length == 1) {
                e.Effect = DragDropEffects.Move;
            }
            
            else {
                e.Effect = DragDropEffects.None;
            }
        }
        
        private void MainDragDrop(object sender, DragEventArgs e) {
            string[] dragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string ext = Path.GetExtension(dragFile[0]).ToLower();
            
            if (ext == ".a" && dragFile.Length == 1) {
                if (File.ReadAllBytes(dragFile[0]).Length == Lib.GetSize(this.LibVersionComboBox.Text)) {
                    droppedFile = dragFile[0];
                    this.FileLoadedLabel.Text = string.Concat(Path.GetFileName(dragFile[0]), " Loaded!");
                    this.FileLoadedLabel.ForeColor = Color.SpringGreen;
                    droppedFileBytes = File.ReadAllBytes(droppedFile);
                    isFileLoaded = (droppedFileBytes.Length == Lib.GetSize(this.LibVersionComboBox.Text));
                    UpdateIconImage();
                }
                
                else {
                    MessageBox.Show("Invalid file!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        
        private void NewIconDragDrop(object sender, DragEventArgs e) {
            string[] dragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string ext = Path.GetExtension(dragFile[0]).ToLower();
            
            if ((ext == ".png" || ext == ".jpg" || ext == ".bmp") && dragFile.Length == 1) {
                Image newIconImg = Image.FromFile(dragFile[0]);
                ShowNewIconPreview(ref newIconImg);
                
                if (newIconImg != null) {
                    newIconBmp = new Bitmap(newIconImg);
                }
                
                this.SaveIconButton.Enabled = (newIconBmp != null);
                
                if (this.AutoSaveCheckBox.CheckState == CheckState.Checked) {
                    if (newIconBmp != null) {
                        SaveNewIcon();
                        newIconBmp = null;
                        this.SaveIconButton.Enabled = (newIconBmp != null);
                    }
                }
            }
        }
        
        private void LibVersionTextChanged(object sender, EventArgs e) {
            droppedFile = "";
            droppedFileBytes = null;
            isFileLoaded = false;
            newIconBmp = null;
            this.FileLoadedLabel.ForeColor = System.Drawing.Color.Orange;
            this.FileLoadedLabel.Text = "No file loaded!";
            UpdateIconImage();
        }
        
        private void DownloadIconsClick(object sender, EventArgs e) {
            if (isFileLoaded) {
                Directory.CreateDirectory(string.Concat("Icons/", this.LibVersionComboBox.Text));
                
                Bitmap iconBmp;
                byte[] curIconBytes;
                int pixelIndex = 0;
                
                foreach (string i in Icons.AllIcons()) {
                    iconBmp = new Bitmap(Icons.GetDimension("Width", i), Icons.GetDimension("Height", i));
                    curIconBytes = Icons.GetBytes(droppedFileBytes, i);
                    
                    for (int x = 0; x < iconBmp.Width; x++) {
                        for (int y = 0; y < iconBmp.Height; y++) {
                            iconBmp.SetPixel(x, iconBmp.Height - y - 1, Color.FromArgb(curIconBytes[pixelIndex], curIconBytes[pixelIndex + 3], curIconBytes[pixelIndex + 2], curIconBytes[pixelIndex + 1]));
                            pixelIndex += 4;
                        }
                    }
                    
                    iconBmp.Save(string.Concat(string.Concat("Icons/", this.LibVersionComboBox.Text), '/', i, ".png"));
                    pixelIndex = 0;
                }
                
                MessageBox.Show("Successfully downloaded icons!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else {
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void GenerateDefaultLibClicked(object sender, EventArgs e) {
            Dictionary<string, byte[]> getLibBytes = new Dictionary<string, byte[]> {
                {"v0.7.0", LibEditor.Properties.Resources.LibCTRPFv070.ToArray()}
            };
            
            foreach (object i in this.LibVersionComboBox.Items) {
                string path = string.Concat(Directory.GetCurrentDirectory(), "/Lib/", i.ToString());
                Directory.CreateDirectory(path);
                BinaryWriter writer = new BinaryWriter(File.OpenWrite(string.Concat(path, "/libctrpf.a")));
                writer.Write(getLibBytes[i.ToString()]);
                writer.Close();
            }
            
            MessageBox.Show("Successfully generated default lib!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void BackupLoadedLibClicked(object sender, EventArgs e) {
            if (isFileLoaded) {
                string path = string.Concat("Backups/", this.LibVersionComboBox.Text);
                Directory.CreateDirectory(path);
                BinaryWriter writer = new BinaryWriter(File.OpenWrite(string.Concat(path, "/libctrpf.a")));
                writer.Write(droppedFileBytes);
                writer.Close();
                MessageBox.Show("Successfully backed up libctrpf.a!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else {
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void IconsGroupBoxTextChanged(object sender, EventArgs e) {
            newIconBmp = null;
            this.SaveIconButton.Enabled = false;
            UpdateIconImage();
        }
        
        private void NewIconButtonClick(object sender, EventArgs e) {
            if (isFileLoaded) {
                if (Icons.AllIcons().Contains(this.IconsComboBox.Text)) {
                    using (OpenFileDialog newIconDialog = new OpenFileDialog()) {
                        newIconDialog.InitialDirectory = Directory.GetCurrentDirectory();
                        newIconDialog.Filter = "PNG File (*.png)|*.png|JPG File(*.jpg)|*.jpg|BMP File(*.bmp)|*.bmp";
                        newIconDialog.FilterIndex = 0;
                        newIconDialog.RestoreDirectory = true;
                        
                        if (newIconDialog.ShowDialog() == DialogResult.OK) {
                            Image newIconImg = Image.FromFile(newIconDialog.FileName);
                            ShowNewIconPreview(ref newIconImg);
                            
                            if (newIconImg != null) {
                                newIconBmp = new Bitmap(newIconImg);
                            }
                            
                            this.SaveIconButton.Enabled = (newIconBmp != null);
                            
                            if (this.AutoSaveCheckBox.CheckState == CheckState.Checked) {
                                if (newIconBmp != null) {
                                    SaveNewIcon();
                                    newIconBmp = null;
                                    this.SaveIconButton.Enabled = (newIconBmp != null);
                                }
                            }
                        }
                    }
                }
                
                else {
                    MessageBox.Show("Invalid icon name!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            else {
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void SaveNewIconClick(object sender, EventArgs e) {
            if (newIconBmp != null) {
                SaveNewIcon();
                newIconBmp = null;
                this.SaveIconButton.Enabled = (newIconBmp != null);
            }
        }
        
        private void IconsGroupBoxIndexChanged(object sender, EventArgs e) {
            UpdateIconImage();
        }
    }
}