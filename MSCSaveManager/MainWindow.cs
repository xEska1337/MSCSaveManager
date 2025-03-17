using MSCSaveManager.Properties;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;

namespace MSCSaveManager
{
    public partial class MainWindow : Form
    {

        public string mscPath = "";
        public string backupPath = "";
        public string savePath = "";
        public string sha256ValueCurrent = "";
        public string selectedFilePath = "";
        FileSystemWatcher watcher;
        public bool restoreFaild = false;
        public string tempPath = "";
        public string slotsPath = "";
        public string preciseSlotPath = "";
        public int selectedSlot = 0;
        public string slotFile = "";
        public string metadataPath = "";
        public bool containMods = false;

        public MainWindow()
        {
            InitializeComponent();

            //Get MSC Folder Path
            Guid localLowPath = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
            mscPath = Path.Combine(GetKnownFolderPath(localLowPath), @"Amistech\My Summer Car");

            if (!Directory.Exists(mscPath))
            {
                if (MessageBox.Show("You don't have My Summer Car installed or your save directory is invalid. Install My Summer Car and make at least one save",
                               "No MSC",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
            }
            else
            {
                //Backup Path
                backupPath = Path.Combine(mscPath, @"Backups");

                //Save Path
                savePath = Path.Combine(mscPath, @"defaultES2File.txt");

                //Temp Path
                tempPath = Path.Combine(backupPath, @"temp");

                //Save slots Path
                slotsPath = Path.Combine(backupPath, @"saveSlots");

                //Watch for change in file
                watcher = new FileSystemWatcher
                {
                    Path = Path.GetDirectoryName(savePath),
                    Filter = Path.GetFileName(savePath),
                    NotifyFilter = NotifyFilters.LastWrite,
                    EnableRaisingEvents = false
                };

                watcher.Changed += (sender, e) =>
                {
                    //If file changed and auto backup checkbox ticked do backup
                    if (autoBackup.Checked == true)
                    {
                        Thread.Sleep(10000);
                        Checksum(savePath);
                        if (File.Exists(savePath))
                        {
                            StreamReader sr = new StreamReader(savePath);
                            string saveStarts = sr.ReadLine();
                            sr.Dispose();

                            if (!Regex.IsMatch(saveStarts, @"\b\w*RadioTuner\b", RegexOptions.IgnoreCase))
                            {
                                if (sha256ValueCurrent != Settings.Default.sha256ValuePrevious)
                                {
                                    Settings.Default.sha256ValuePrevious = sha256ValueCurrent;
                                    Settings.Default.Save();
                                    DoBackup(true);

                                    //Toast auto backup complete
                                    toast.Text = "!Auto Backup complete";
                                    timer = new System.Threading.Timer(RemoveText, null, 3000, Timeout.Infinite);
                                }
                            }
                        }
                    }
                };
            }
        }

        //Calculating a checksum
        private void Checksum(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        byte[] hashBytes = sha256.ComputeHash(fileStream);
                        sha256ValueCurrent = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Get path from Guid
        private string GetKnownFolderPath(Guid knownFolderId)
        {
            IntPtr pszPath = IntPtr.Zero;
            try
            {
                int hr = SHGetKnownFolderPath(knownFolderId, 0, IntPtr.Zero, out pszPath);
                if (hr >= 0)
                    return Marshal.PtrToStringAuto(pszPath);
                throw Marshal.GetExceptionForHR(hr);
            }
            finally
            {
                if (pszPath != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pszPath);
            }
        }
        [DllImport("shell32.dll")]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        private void Form1_Load(object sender, EventArgs e)
        {
            //Clock
            timer1.Start();

            //Create backup and slots directory
            Directory.CreateDirectory(backupPath);
            Directory.CreateDirectory(slotsPath);

            //Load user settings
            autoBackup.Checked = Settings.Default.autoBackupStatus;
            includeMods.Checked = Settings.Default.includeMods;
            this.Location = new Point(Settings.Default.PX, Settings.Default.PY);

            //Enable auto backup
            if (autoBackup.Checked)
            {
                watcher.EnableRaisingEvents = true;
            }


            //Auto backup on program start if checkbox ticked
            if (autoBackup.Checked == true)
            {
                Checksum(savePath);
                if (File.Exists(savePath))
                {
                    StreamReader sr = new StreamReader(savePath);
                    string saveStarts = sr.ReadLine();
                    sr.Dispose();

                    if (!Regex.IsMatch(saveStarts, @"\b\w*RadioTuner\b", RegexOptions.IgnoreCase))
                    {
                        if (sha256ValueCurrent != Settings.Default.sha256ValuePrevious)
                        {
                            Settings.Default.sha256ValuePrevious = sha256ValueCurrent;
                            Settings.Default.Save();
                            DoBackup(true);

                            //Toast auto backup complete
                            toast.Text = "!Auto Backup complete";
                            timer = new System.Threading.Timer(RemoveText, null, 3000, Timeout.Infinite);
                        }
                    }
                }
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //More Clock
            currentTime.Text = DateTime.Now.ToLongTimeString();
            currentDate.Text = DateTime.Now.ToShortDateString();
        }

        private void mscSaveFolder_Click(object sender, EventArgs e)
        {
            //Open MSC Folder
            System.Diagnostics.Process.Start("explorer.exe", mscPath);
        }

        //Timer to toast
        private System.Threading.Timer timer;

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            DoBackup(false);

            //Clear note
            note.Text = "";

            //Toast backup complete
            toast.Text = "!Backup complete";
            timer = new System.Threading.Timer(RemoveText, null, 3000, Timeout.Infinite);
        }

        //Clear toast
        private void RemoveText(object state)
        {
            Invoke(new Action(() => toast.Text = ""));
            timer.Dispose();
        }

        private void DoBackup(bool automatic)
        {
            //Do backup
            string bakName = "";
            if (automatic == true && includeMods.Checked == false)
            {
                bakName = "MSCSaveBackup_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss_") + "AutoBackup.zip";
            }
            else if (automatic == true && includeMods.Checked == true)
            {
                bakName = "MSCSaveBackup_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss_") + "AutoBackup+Mods.zip";
            }
            else if (includeMods.Checked == true)
            {
                bakName = "MSCSaveBackup_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss_") + note.Text.ToString() + "+Mods.zip";
            }
            else
            {
                bakName = "MSCSaveBackup_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss_") + note.Text.ToString() + ".zip";
            }
            var bakFile = Path.Combine(backupPath, bakName);
            if (includeMods.Checked == true)
            {
                ZipHelper.CreateFromDirectory(mscPath, bakFile, CompressionLevel.Fastest, false, Encoding.UTF8, fileName => !fileName.Contains(@"\Backups\"));
            }
            else
            {
                ZipHelper.CreateFromDirectory(mscPath, bakFile, CompressionLevel.Fastest, false, Encoding.UTF8, fileName => !fileName.Contains(@"\Mods\") && !fileName.Contains(@"\Backups\"));
            }
        }

        //Help to zip files
        public static class ZipHelper
        {
            public static void CreateFromDirectory(
              string sourceDirectoryName
            , string destinationArchiveFileName
            , CompressionLevel compressionLevel
            , bool includeBaseDirectory
            , Encoding entryNameEncoding
            , Predicate<string> filter
            )
            {
                if (string.IsNullOrEmpty(sourceDirectoryName))
                {
                    throw new ArgumentNullException("sourceDirectoryName");
                }
                if (string.IsNullOrEmpty(destinationArchiveFileName))
                {
                    throw new ArgumentNullException("destinationArchiveFileName");
                }
                var filesToAdd = Directory.GetFiles(sourceDirectoryName, "*", SearchOption.AllDirectories);
                var entryNames = GetEntryNames(filesToAdd, sourceDirectoryName, includeBaseDirectory);
                using (var zipFileStream = new FileStream(destinationArchiveFileName, FileMode.Create))
                {
                    using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                    {
                        for (int i = 0; i < filesToAdd.Length; i++)
                        {
                            if (!filter(filesToAdd[i]))
                            {
                                continue;
                            }
                            archive.CreateEntryFromFile(filesToAdd[i], entryNames[i], compressionLevel);
                        }
                    }
                }
            }
        }
        private static string[] GetEntryNames(string[] names, string sourceFolder, bool includeBaseName)
        {
            if (names == null || names.Length == 0)
                return new string[0];
            if (includeBaseName)
                sourceFolder = Path.GetDirectoryName(sourceFolder);
            int length = string.IsNullOrEmpty(sourceFolder) ? 0 : sourceFolder.Length;
            if (length > 0 && sourceFolder != null && sourceFolder[length - 1] != Path.DirectorySeparatorChar && sourceFolder[length - 1] != Path.AltDirectorySeparatorChar)
                length++;
            var result = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                result[i] = names[i].Substring(length);
            }
            return result;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save user settings
            Settings.Default.autoBackupStatus = autoBackup.Checked;
            Settings.Default.includeMods = includeMods.Checked;
            Settings.Default.PX = this.Location.X;
            Settings.Default.PY = this.Location.Y;
            Settings.Default.Save();

            //Delete temp folder
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
        }

        private void UpdateValues()
        {
            //Save Timestamp
            if (File.Exists(savePath))
            {
                var saveModDate = System.IO.File.GetLastWriteTime(savePath);
                saveTimestamp.Text = saveModDate.ToString("dd/MM/yy HH:mm:ss");
            }
            else
            {
                saveTimestamp.Text = "No MSC save";
            }

            //Load backup file list
            string[] fileList = Directory.GetFiles(backupPath, "*.zip");
            fileSelection.Items.Clear();
            foreach (string file in fileList)
            {
                fileSelection.Items.Add(Path.GetFileName(file));
            }

            //Delete temp folder
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }

            //Clear save to restore timestamp
            restoreTimestamp.Text = "";
        }  

        private void tabpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void fileSelection_DropDown(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            //Restore backup
            if (fileSelection.SelectedIndex != -1)
            {
                //Automatic check for mods folder
                using (var archive = ZipFile.OpenRead(selectedFilePath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        string pattern = @"\bMods\b";
                        Match m = Regex.Match(entry.FullName, pattern, RegexOptions.IgnoreCase);
                        if (m.Success)
                        {
                            containMods = true;
                        }
                        else
                        {
                            containMods = false;
                        }
                    }
                }

                if (containMods == true)
                {
                    if (MessageBox.Show("Are you sure, all current files except backups folder will be deleted and replaced with files from this backup?",
                                                                               "Restore",
                                                                               MessageBoxButtons.YesNo,
                                                                               MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        restoreFiles(selectedFilePath, "Backups");
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure, all current files except mods and backups folder will be deleted and replaced with files from this backup?",
                                                                               "Restore",
                                                                               MessageBoxButtons.YesNo,
                                                                               MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        restoreFiles(selectedFilePath, "Backups", "Mods");
                    }
                }
            } 
            else
            {
                MessageBox.Show("Select file to restore.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void restoreFiles(string selectFile, params string[] exceptions)
        {
            if (autoBackup.Checked == true)
            {
                autoBackup.Checked = false;
                watcher.EnableRaisingEvents = false;

                //Deleting files exept Mods and Backups
                DeleteFiles(mscPath, exceptions);

                //Extract backup files
                ExtractToDirectory(selectFile, mscPath, null);

                autoBackup.Checked = true;
                watcher.EnableRaisingEvents = true;

                restoreToast();

            }
            else
            {
                //Deleting files exept Mods and Backups
                DeleteFiles(mscPath, exceptions);

                //Extract backup files
                ExtractToDirectory(selectFile, mscPath, null);

                restoreToast();
            }
        }

        private void restoreToast()
        {
            if (restoreFaild == false)
            {
                //Toast restore complete
                toast.Text = "!Restore complete";
                timer = new System.Threading.Timer(RemoveText, null, 3000, Timeout.Infinite);
            }
            else
            {
                //Toast restore faild
                toast.Text = "):Restore faild";
                timer = new System.Threading.Timer(RemoveText, null, 3000, Timeout.Infinite);
            }
        }

        //Delete files
        static void DeleteFiles(string folderPath, params string[] exceptions)
        {
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Directory not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DirectoryInfo directory = new DirectoryInfo(folderPath);

                foreach (FileInfo file in directory.GetFiles())
                {
                    if (Array.IndexOf(exceptions, file.Name) == -1)
                    {
                        file.Delete();
                    }
                }
                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    if (Array.IndexOf(exceptions, subDirectory.Name) == -1)
                    {
                        subDirectory.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Extract files
        public void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding entryNameEncoding)
        {
            try
            {
                if (string.IsNullOrEmpty(sourceArchiveFileName))
                    throw new ArgumentNullException("sourceArchiveFileName");
                if (string.IsNullOrEmpty(destinationDirectoryName))
                    throw new ArgumentNullException("destinationDirectoryName");

                using (var zipFileStream = new FileStream(sourceArchiveFileName, FileMode.Open))
                {
                    using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Read))
                    {
                        archive.ExtractToDirectory(destinationDirectoryName);
                    }
                }
                restoreFaild = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Restore failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                restoreFaild = true;
            }
        }
        
        private void fileSelection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (fileSelection.SelectedIndex != -1)
            {
                string selectedFileName = fileSelection.SelectedItem.ToString();
                selectedFilePath = Path.Combine(backupPath, selectedFileName);

                restoreTimestamp.Text = "";

                //Delete temp folder
                if (Directory.Exists(tempPath))
                {
                    Directory.Delete(tempPath, true);
                }

                //Create temp folder
                Directory.CreateDirectory(tempPath);

                using (ZipArchive archive = ZipFile.OpenRead(selectedFilePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName == "defaultES2File.txt")
                        {
                            string targetPath = Path.Combine(tempPath, entry.FullName);
                            entry.ExtractToFile(targetPath, true);
                            //Save Timestamp
                            string saveTempPath = Path.Combine(tempPath, @"defaultES2File.txt");
                            var saveModDate = System.IO.File.GetLastWriteTime(saveTempPath);
                            restoreTimestamp.Text = saveModDate.ToString("dd/MM/yy HH:mm:ss");
                        }
                    }
                }
            }
        }

        private void slotSelection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Selected slot
            selectedSlot = slotSelection.SelectedIndex + 1;

            //Path
            preciseSlotPath = Path.Combine(slotsPath, selectedSlot.ToString());

            string slotFileName = "Slot_" + selectedSlot.ToString() + ".zip";
            slotFile = Path.Combine(preciseSlotPath, slotFileName);


            metadataPath = Path.Combine(preciseSlotPath, "metadata");

            //Change use icon
            if (File.Exists(slotFile))
            {
                slotsUse.Image = (Image)Resources.Ampeross_Qetto_2_Check_256;
                slotsNotesSave.Enabled = true;
            }
            else
            {
                slotsUse.Image = (Image)Resources.Ampeross_Qetto_2_No_256;
                slotsNotesSave.Enabled = false;
            }

            //Enable inputs
            slotNotes.Enabled = true;
            slotsMods.Enabled = true;
            

            //Read metadata
            if (File.Exists(metadataPath))
            {
                StreamReader sr = new StreamReader(metadataPath);
                slotsMods.Checked =  Convert.ToBoolean(sr.ReadLine());
                slotTimestamp.Text = sr.ReadLine();
                slotNotes.Text = sr.ReadLine();
                sr.Dispose();
            }
            else
            {
                slotsMods.Checked = false;
                slotTimestamp.Text = "";
                slotNotes.Text = "";
            }
        }

        private void slotsSave_Click(object sender, EventArgs e)
        {
            //Save save slot
            if (slotSelection.SelectedIndex != -1) 
            {
                if (MessageBox.Show("Are you sure, all files from this save slot will be deleted and replaced with files from current save?",
                                                   "Slots Save",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Create directory
                    Directory.CreateDirectory(preciseSlotPath);

                    if (File.Exists(slotFile))
                    {
                        File.Delete(slotFile);
                    }
                    if (slotsMods.Checked == true)
                    {
                        ZipHelper.CreateFromDirectory(mscPath, slotFile, CompressionLevel.Fastest, false, Encoding.UTF8, fileName => !fileName.Contains(@"\Backups\"));

                        MetadataToFile();
                    }
                    else
                    {
                        ZipHelper.CreateFromDirectory(mscPath, slotFile, CompressionLevel.Fastest, false, Encoding.UTF8, fileName => !fileName.Contains(@"\Mods\") && !fileName.Contains(@"\Backups\"));

                        MetadataToFile();
                    }
                    slotsUse.Image = (Image)Resources.Ampeross_Qetto_2_Check_256;
                    slotsNotesSave.Enabled = true;

                    //Toast save completed
                    toast.Text = "!Save successful";
                    timer = new System.Threading.Timer(RemoveText, null, 3000, Timeout.Infinite);
                }
            }
            else
            {
                MessageBox.Show("Select save slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetadataToFile()
        {
            //Metadata to file
            StreamWriter sw = new StreamWriter(metadataPath, false);
            sw.WriteLine(slotsMods.Checked.ToString());
            var saveModDate = System.IO.File.GetLastWriteTime(savePath);
            slotTimestamp.Text = saveModDate.ToString("dd/MM/yy HH:mm:ss");
            sw.WriteLine(saveModDate.ToString("dd/MM/yy HH:mm:ss"));
            sw.WriteLine(slotNotes.Text);
            sw.Dispose();
        }

        private void slotDelete_Click(object sender, EventArgs e)
        {
            //Delete save slot
            if (slotSelection.SelectedIndex != -1)
            {
                if (MessageBox.Show("Are you sure, all files from this save slot will be deleted?",
                                                                   "Slots Delete",
                                                                   MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (Directory.Exists(preciseSlotPath))
                    {
                        Directory.Delete(preciseSlotPath, true);
                        slotsMods.Checked = false;
                        slotTimestamp.Text = "";
                        slotNotes.Text = "";
                        slotsUse.Image = (Image)Resources.Ampeross_Qetto_2_No_256;
                        slotsNotesSave.Enabled = false;

                        //Toast save slot deleted
                        toast.Text = "!Save slot deleted";
                        timer = new System.Threading.Timer(RemoveText, null, 3000, Timeout.Infinite);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select save slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void slotsLoad_Click(object sender, EventArgs e)
        {
            //Load save slot
            if (slotSelection.SelectedIndex != -1)
            {
                if (MessageBox.Show("Are you sure, all current files except backups folder will be deleted and replaced with files from this save slot?",
                                                                   "Slots Load",
                                                                   MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Automatic check for mods folder
                    if (File.Exists(slotFile))
                    {
                        using (var archive = ZipFile.OpenRead(slotFile))
                        {
                            foreach (var entry in archive.Entries)
                            {
                                string pattern = @"\bMods\b";
                                Match m = Regex.Match(entry.FullName, pattern, RegexOptions.IgnoreCase);
                                if (m.Success)
                                {
                                    containMods = true;
                                }
                                else
                                {
                                    containMods = false;
                                }
                            }
                        }

                        if (containMods == true)
                        {
                            restoreFiles(slotFile, "Backups");
                        }
                        else
                        {
                            restoreFiles(slotFile, "Backups", "Mods");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select save slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void autoBackup_CheckedChanged(object sender, EventArgs e)
        {
            //Enable auto backup
            if (autoBackup.Checked)
            {
                watcher.EnableRaisingEvents = true;
            }
            else
            {
                watcher.EnableRaisingEvents = false;
            }
        }

        private void slotsNotesSave_Click(object sender, EventArgs e)
        {
            //Replace notes in metadata file for save slots
            string[] arrLine = File.ReadAllLines(metadataPath);
            arrLine[3 - 1] = slotNotes.Text;
            File.WriteAllLines(metadataPath, arrLine);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            var vittu = new vittu();
            vittu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/xEska1337") { UseShellExecute = true });
        }
    }
}