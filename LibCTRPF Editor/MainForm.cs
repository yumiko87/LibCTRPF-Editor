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

namespace libEditor
{
    public partial class MainForm : Form
    {
        private string m_DragDroppedFile;
        private byte[] m_DragDroppedFileBytes = null;
        private bool m_IsFileLoaded = false;
        private Bitmap m_NewIconBitmap;
        
        public MainForm()
        {
            InitializeComponent();
            this.LibVersionComboBox.SelectedIndex = 0;
            this.IconsComboBox.SelectedIndex = 0;
        }
        
        private void UpdateIconImage()
        {
            if (Icons.GetIconsList().Contains(this.IconsComboBox.Text) && m_IsFileLoaded)
            {
                Bitmap IconBitmap = new Bitmap(Icons.GetDimension("Width", this.IconsComboBox.Text), Icons.GetDimension("Height", this.IconsComboBox.Text));
                byte[] CurrentIconBytes = Icons.GetBytes(m_DragDroppedFileBytes, this.IconsComboBox.Text);
                int PixelIndex = 0;
                
                for (int X = 0; X < IconBitmap.Width; X++)
                {
                    for (int Y = 0; Y < IconBitmap.Height; Y++)
                    {
                        IconBitmap.SetPixel(X, IconBitmap.Height - Y - 1, Color.FromArgb(CurrentIconBytes[PixelIndex], CurrentIconBytes[PixelIndex + 3], CurrentIconBytes[PixelIndex + 2], CurrentIconBytes[PixelIndex + 1]));
                        PixelIndex += 4;
                    }
                }
            }
        }
        
        private void ShowNewIconPreview(ref Image NewIconImage)
        {
            if (m_IsFileLoaded)
            {
                if (Icons.GetIconsList().Contains(this.IconsComboBox.Text))
                {
                    Bitmap NewIconBitmap = new Bitmap(Icons.GetDimension("Width", this.IconsComboBox.Text), Icons.GetDimension("Height", this.IconsComboBox.Text));
                    
                    if (NewIconBitmap.Width == NewIconImage.Width && NewIconBitmap.Height == NewIconImage.Height)
                        MessageBox.Show("Done!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    else
                    {
                        MessageBox.Show(string.Concat("New icon dimensions for ", this.IconsComboBox.Text, " must be ", NewIconBitmap.Width.ToString(), 'x', NewIconBitmap.Height.ToString(), '!'), "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NewIconImage = null;
                    }
                }
            }
        }
        
        private void SaveNewIcon()
        {
            if (m_IsFileLoaded)
            {
                if (m_NewIconBitmap != null)
                {
                    int PixelIndex = 0;
                    
                    for (int X = 0; X < m_NewIconBitmap.Width; X++)
                    {
                        for (int Y = 0; Y < m_NewIconBitmap.Height; Y++)
                        {
                            m_DragDroppedFileBytes[Icons.GetIconOffset(this.IconsComboBox.Text) + PixelIndex] = m_NewIconBitmap.GetPixel(X, m_NewIconBitmap.Height - Y - 1).A;
                            m_DragDroppedFileBytes[Icons.GetIconOffset(this.IconsComboBox.Text) + PixelIndex + 3] = m_NewIconBitmap.GetPixel(X, m_NewIconBitmap.Height - Y - 1).R;
                            m_DragDroppedFileBytes[Icons.GetIconOffset(this.IconsComboBox.Text) + PixelIndex + 2] = m_NewIconBitmap.GetPixel(X, m_NewIconBitmap.Height - Y - 1).G;
                            m_DragDroppedFileBytes[Icons.GetIconOffset(this.IconsComboBox.Text) + PixelIndex + 1] = m_NewIconBitmap.GetPixel(X, m_NewIconBitmap.Height - Y - 1).B;
                            PixelIndex += 4;
                        }
                    }
                    
                    using (BinaryWriter Writer = new BinaryWriter(File.OpenWrite(m_DragDroppedFile)))
                    {
                        Writer.Write(m_DragDroppedFileBytes);
                        Writer.Flush();
                    }
                    
                    MessageBox.Show(string.Concat("Successfully saved new icon for ", this.IconsComboBox.Text, '!'), "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            else
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void MainDragEnter(object sender, DragEventArgs e)
        {
            string[] DragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string Extension = Path.GetExtension(DragFile[0]).ToLower();
            
            if (Extension == ".a" && DragFile.Length == 1)
                e.Effect = DragDropEffects.Move;
            
            else
                e.Effect = DragDropEffects.None;
        }
        
        private void NewIconDragEnter(object sender, DragEventArgs e)
        {
            string[] DragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string Extension = Path.GetExtension(DragFile[0]).ToLower();
            
            if ((Extension == ".png" || Extension == ".jpg" || Extension == ".bmp") && DragFile.Length == 1)
                e.Effect = DragDropEffects.Move;
            
            else
                e.Effect = DragDropEffects.None;
        }
        
        private void MainDragDrop(object sender, DragEventArgs e)
        {
            string[] DragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string Extension = Path.GetExtension(DragFile[0]).ToLower();
            
            if (Extension == ".a" && DragFile.Length == 1)
            {
                if (File.ReadAllBytes(DragFile[0]).Length == Lib.GetSize(this.LibVersionComboBox.Text))
                {
                    m_DragDroppedFile = DragFile[0];
                    this.FileLoadedLabel.Text = string.Concat(Path.GetFileName(DragFile[0]), " Loaded!");
                    this.FileLoadedLabel.ForeColor = Color.SpringGreen;
                    m_DragDroppedFileBytes = File.ReadAllBytes(m_DragDroppedFile);
                    m_IsFileLoaded = (m_DragDroppedFileBytes.Length == Lib.GetSize(this.LibVersionComboBox.Text));
                    UpdateIconImage();
                }
                
                else
                    MessageBox.Show("Invalid file!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void NewIconDragDrop(object sender, DragEventArgs e)
        {
            string[] DragFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string Extension = Path.GetExtension(DragFile[0]).ToLower();
            
            if ((Extension == ".png" || Extension == ".jpg" || Extension == ".bmp") && DragFile.Length == 1)
            {
                Image NewIconImage = Image.FromFile(DragFile[0]);
                ShowNewIconPreview(ref NewIconImage);
                
                if (NewIconImage != null)
                    m_NewIconBitmap = new Bitmap(NewIconImage);
                
                this.SaveIconButton.Enabled = (m_NewIconBitmap != null);
                
                if (this.AutoSaveCheckBox.CheckState == CheckState.Checked)
                {
                    if (m_NewIconBitmap != null)
                    {
                        SaveNewIcon();
                        m_NewIconBitmap = null;
                        this.SaveIconButton.Enabled = (m_NewIconBitmap != null);
                    }
                }
            }
        }
        
        private void LibVersionTextChanged(object sender, EventArgs e)
        {
            m_DragDroppedFile = "";
            m_DragDroppedFileBytes = null;
            m_IsFileLoaded = false;
            m_NewIconBitmap = null;
            this.FileLoadedLabel.ForeColor = System.Drawing.Color.Orange;
            this.FileLoadedLabel.Text = "No file loaded!";
            UpdateIconImage();
        }
        
        private void DownloadIconsClick(object sender, EventArgs e)
        {
            if (m_IsFileLoaded)
            {
                Directory.CreateDirectory(string.Concat("Icons/", this.LibVersionComboBox.Text));
                
                Bitmap IconBitmap;
                byte[] CurrentIconBytes;
                int PixelIndex = 0;
                
                foreach (string i in Icons.GetIconsList())
                {
                    IconBitmap = new Bitmap(Icons.GetDimension("Width", i), Icons.GetDimension("Height", i));
                    CurrentIconBytes = Icons.GetBytes(m_DragDroppedFileBytes, i);
                    
                    for (int X = 0; X < IconBitmap.Width; X++)
                    {
                        for (int Y = 0; Y < IconBitmap.Height; Y++)
                        {
                            IconBitmap.SetPixel(X, IconBitmap.Height - Y - 1, Color.FromArgb(CurrentIconBytes[PixelIndex], CurrentIconBytes[PixelIndex + 3], CurrentIconBytes[PixelIndex + 2], CurrentIconBytes[PixelIndex + 1]));
                            PixelIndex += 4;
                        }
                    }
                    
                    IconBitmap.Save(string.Concat(string.Concat("Icons/", this.LibVersionComboBox.Text), '/', i, ".png"));
                    PixelIndex = 0;
                }
                
                MessageBox.Show("Successfully downloaded icons!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void GenerateDefaultLibClicked(object sender, EventArgs e)
        {
            Dictionary<string, byte[]> GetLibBytes = new Dictionary<string, byte[]>
            {
                {"v0.7.0", libEditor.Properties.Resources.LibCTRPF_v0_7_0.ToArray()}
            };
            
            foreach (object i in this.LibVersionComboBox.Items)
            {
                string Path = string.Concat(Directory.GetCurrentDirectory(), "/Lib/", i.ToString());
                Directory.CreateDirectory(Path);
                BinaryWriter Writer = new BinaryWriter(File.OpenWrite(string.Concat(Path, "/libctrpf.a")));
                Writer.Write(GetLibBytes[i.ToString()]);
                Writer.Close();
            }
            
            MessageBox.Show("Successfully generated default lib!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void BackupLoadedLibClicked(object sender, EventArgs e)
        {
            if (m_IsFileLoaded)
            {
                string Path = string.Concat("Backups/", this.LibVersionComboBox.Text);
                Directory.CreateDirectory(Path);
                BinaryWriter Writer = new BinaryWriter(File.OpenWrite(string.Concat(Path, "/libctrpf.a")));
                Writer.Write(m_DragDroppedFileBytes);
                Writer.Close();
                MessageBox.Show("Successfully backed up libctrpf.a!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void IconsGroupBoxTextChanged(object sender, EventArgs e)
        {
            m_NewIconBitmap = null;
            this.SaveIconButton.Enabled = false;
            UpdateIconImage();
        }
        
        private void NewIconButtonClick(object sender, EventArgs e)
        {
            if (m_IsFileLoaded)
            {
                if (Icons.GetIconsList().Contains(this.IconsComboBox.Text))
                {
                    using (OpenFileDialog NewIconDialog = new OpenFileDialog())
                    {
                        NewIconDialog.InitialDirectory = Directory.GetCurrentDirectory();
                        NewIconDialog.Filter = "PNG File (*.png)|*.png|JPG File(*.jpg)|*.jpg|BMP File(*.bmp)|*.bmp";
                        NewIconDialog.FilterIndex = 0;
                        NewIconDialog.RestoreDirectory = true;
                        
                        if (NewIconDialog.ShowDialog() == DialogResult.OK)
                        {
                            Image NewIconImage = Image.FromFile(NewIconDialog.FileName);
                            ShowNewIconPreview(ref NewIconImage);
                            
                            if (NewIconImage != null)
                                m_NewIconBitmap = new Bitmap(NewIconImage);
                            
                            this.SaveIconButton.Enabled = (m_NewIconBitmap != null);
                            
                            if (this.AutoSaveCheckBox.CheckState == CheckState.Checked)
                            {
                                if (m_NewIconBitmap != null)
                                {
                                    SaveNewIcon();
                                    m_NewIconBitmap = null;
                                    this.SaveIconButton.Enabled = (m_NewIconBitmap != null);
                                }
                            }
                        }
                    }
                }
                
                else
                    MessageBox.Show("Invalid icon name!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else
                MessageBox.Show("libctrpf.a is not loaded!", "LibCTRPF Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void SaveNewIconClick(object sender, EventArgs e)
        {
            if (m_NewIconBitmap != null)
            {
                SaveNewIcon();
                m_NewIconBitmap = null;
                this.SaveIconButton.Enabled = (m_NewIconBitmap != null);
            }
        }
        
        private void IconsGroupBoxIndexChanged(object sender, EventArgs e)
        {
            UpdateIconImage();
        }
    }
}