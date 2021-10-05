using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomUI.Controls;
using CustomUI.Forms;
using System.Security.Cryptography;

namespace Image_Optimizer_Plus
{
    public partial class formMain : CustomForm
    {

        #region "Constructor"

        public formMain()
        {
            InitializeComponent();
        }
        #endregion

        #region "Form Events"

        private void formMain_Load(object sender, EventArgs e)
        {
            imageList = new List<ImageInfo>();
            isProcessing = false;
            compressedSpace = -1;

            updateUI();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                Application.Exit();
            }
        }

        private void customListViewLog_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void customListViewLog_DragDrop(object sender, DragEventArgs e)
        {
            string[] dragdropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            addImages(dragdropFiles);
        }

        private void customListViewLog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeSelectedImages();
            }
        }

        private void customButtonRemoveImages_Click(object sender, EventArgs e)
        {
            removeSelectedImages();
        }

        private void customButtonClearImages_Click(object sender, EventArgs e)
        {
            clearImages();
        }

        private void customButtonAddImages_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                addImages(openFileDialogImages.FileNames);
            }
        }

        private void customButtonBrowse_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(customTextBoxOutputDirectory.Text))
            {
                folderBrowserDialogBrowse.SelectedPath = customTextBoxOutputDirectory.Text;
            }

            if (folderBrowserDialogBrowse.ShowDialog() == DialogResult.OK)
            {
                customTextBoxOutputDirectory.Text = folderBrowserDialogBrowse.SelectedPath;
            }
        }

        private void customCheckBoxOverwriteOriginalFiles_CheckedChanged(object sender, EventArgs e)
        {
            updateUI();
        }

        #endregion

        #region "Variables"

        List<ImageInfo> imageList;

        bool isProcessing;

        #endregion

        #region "Functions"

        private void removeSelectedImages()
        {
            if (!isProcessing && customListViewLog.SelectedIndices.Count > 0)
            {
                List<int> indexToRemove = customListViewLog.SelectedIndices.ToList();
                indexToRemove.Sort();

                customListViewLog.SelectedIndices.Clear();

                for (int i = 0; i < indexToRemove.Count; i++)
                {
                    // The index changes everytime an item gets deleted
                    int fixedIndex = indexToRemove[i] - i;

                    customListViewLog.Items.RemoveAt(fixedIndex);
                    imageList.RemoveAt(fixedIndex);
                }

                if (imageList.Count == 0)
                {
                    compressedSpace = -1;
                }

                updateUI();
            }
        }

        private void clearImages()
        {
            if (!isProcessing && imageList.Count > 0)
            {
                customListViewLog.SelectedIndices.Clear();
                customListViewLog.Items.Clear();
                imageList.Clear();
                compressedSpace = -1;

                updateUI();
            }
        }

        private void addImages(String[] images)
        {
            if (!isProcessing && images != null)
            {
                foreach (String s in images)
                {
                    if (s.EndsWith(".png"))
                    {
                        if (imageList.Where(x => x.InputPath == s).Count() == 0)
                        {
                            ImageInfo ii = new ImageInfo(s);
                            imageList.Add(ii);

                            customListViewLog.Items.Add(new CustomListItem(String.Format("{0} [Uncompressed {1}]", ii.Name, ii.UncompressedSizeToString)));
                        }

                        updateUI();
                    }
                    else if (Directory.Exists(s))
                    {
                        foreach(String f in Directory.GetFiles(s, "*.png", SearchOption.AllDirectories))
                        {
                            if (imageList.Where(x => x.InputPath == f).Count() == 0)
                            {
                                ImageInfo ii = new ImageInfo(f);
                                imageList.Add(ii);

                                customListViewLog.Items.Add(new CustomListItem(String.Format("{0} [Uncompressed {1}]", ii.Name, ii.UncompressedSizeToString)));
                            }

                            updateUI();
                        }
                    }
                }
            }
        }

        private void updateStatus()
        {
            long uncompressedSize = 0;
            long compressedSize = 0;

            int discardedCount = 0;
            int errorCount = 0;

            foreach (ImageInfo fi in imageList)
            {
                if (fi.Status == ImageInfo.ProcessStatus.Processed)
                {
                    uncompressedSize += fi.UncompressedSize;
                    compressedSize += fi.CompressedSize;
                }
                else if (fi.Status == ImageInfo.ProcessStatus.Discarded)
                {
                    discardedCount++;
                }
                else if (fi.Status == ImageInfo.ProcessStatus.Error)
                {
                    errorCount++;
                }
                else if (!isProcessing)
                {
                    uncompressedSize += fi.UncompressedSize;
                }
            }

            if (!isProcessing)
            {
                if (compressedSpace == -1)
                {
                    customLabelStatus.Text = String.Format("{0} files [Uncompressed {1}]", imageList.Count, Util.ConvertLongToByte(uncompressedSize));
                }
                else
                {
                    double percentage = (compressedSize != 0 && uncompressedSize != 0) ? compressedSize * 100 / uncompressedSize : 0;

                    customLabelStatus.Text = String.Format("{0} files [Saved {1}] [Uncompressed {2}] [Compressed {3}] [{4}%] [Error# {5}] [Discarded# {6}]", imageList.Count, Util.ConvertLongToByte(compressedSpace), Util.ConvertLongToByte(uncompressedSize), Util.ConvertLongToByte(compressedSize), percentage, errorCount, discardedCount);
                }
            }
            else
            {
                customLabelStatus.Text = String.Format("Processed {0}/{1} [Saved {2}] [Uncompressed {3}] [Compressed {4}] [Error# {5}] [Discarded# {6}]", customProgressBarStatus.CurrentValue, imageList.Count, Util.ConvertLongToByte(compressedSpace), Util.ConvertLongToByte(uncompressedSize), Util.ConvertLongToByte(compressedSize), errorCount, discardedCount);
            }
        }

        #endregion

        private async void customButtonOptimize_Click(object sender, EventArgs e)
        {
            if (!isProcessing && checkProcessingData())
            {
                isProcessing = true;

                updateInputList();

                updateUI();

                await optimizeImages();

                isProcessing = false;

                updateUI();
            }
        }

        private void customButtonCancel_Click(object sender, EventArgs e)
        {
            isProcessing = false;

            updateUI();
        }

        private void updateInputList()
        {
            for(int i = 0; i < imageList.Count; i++)
            {
                imageList[i].Steps = 0;
                imageList[i].CompressedSize = 0;
                imageList[i].UncompressedSize = new FileInfo(imageList[i].InputPath).Length;
                imageList[i].Status = ImageInfo.ProcessStatus.NotProcessed;
                imageList[i].ErrorMessage = String.Empty;
                imageList[i].TempPath = String.Empty;

                customListViewLog.Items[i].TextColor = CustomUI.Config.Colors.Instance.LightText;
                customListViewLog.Items[i].Text = String.Format("{0} [Uncompressed {1}]", imageList[i].Name, imageList[i].UncompressedSizeToString);
            }
        }

        private Boolean checkProcessingData()
        {
            if (!customCheckBoxOverwriteOriginalFiles.Checked && !Directory.Exists(customTextBoxOutputDirectory.Text))
            {
                CustomMessageBox.ShowError("Unable to find output folder.", "ERROR", CustomDialogButton.Ok);
                return false;
            }

            if (!customCheckBoxOverwriteOriginalFiles.Checked)
            {
                List<String> fileNames = new List<String>(imageList.Count);

                foreach (ImageInfo ii in imageList)
                {
                    fileNames.Add(ii.Name);

                    if (!File.Exists(ii.InputPath))
                    {
                        CustomMessageBox.ShowError("Can't find " + ii.InputPath, "ERROR", CustomDialogButton.Ok);
                        return false;
                    }
                }

                Boolean areFilenamesKeys = (fileNames.Count == fileNames.Distinct().Count());

                if (!areFilenamesKeys)
                {
                    CustomMessageBox.ShowError("Can't process images with the same filename when 'Overwrite Original Files' is unchecked.", "ERROR", CustomDialogButton.Ok);
                }

                return areFilenamesKeys;
            }

            return true;
        }

        private void updateUI()
        {
            if (isProcessing)
            {
                customButtonOptimize.Enabled = false;
                customButtonAddImages.Enabled = false;
                customButtonRemoveImages.Enabled = false;
                customButtonBrowse.Enabled = false;
                customButtonClearImages.Enabled = false;
                customTextBoxOutputDirectory.Enabled = false;
                customCheckBoxOverwriteOriginalFiles.Enabled = false;
                customProgressBarStatus.Visible = true;

                customButtonCancel.Enabled = true;
                customButtonCancel.Visible = true;
            }
            else
            {
                customButtonAddImages.Enabled = true;
                customButtonBrowse.Enabled = !customCheckBoxOverwriteOriginalFiles.Checked;
                customTextBoxOutputDirectory.Enabled = !customCheckBoxOverwriteOriginalFiles.Checked;
                customCheckBoxOverwriteOriginalFiles.Enabled = true;

                if (imageList.Count > 0)
                {
                    customButtonOptimize.Enabled = true;
                    customButtonRemoveImages.Enabled = true;
                    customButtonClearImages.Enabled = true;
                }
                else
                {
                    customButtonOptimize.Enabled = false;
                    customButtonRemoveImages.Enabled = false;
                    customButtonClearImages.Enabled = false;
                }

                customButtonCancel.Enabled = false;
                customButtonCancel.Visible = false;
            }

            updateStatus();
        }

        private long compressedSpace;

        private async Task optimizeImages()
        {
            compressedSpace = 0;

            InvokeFunction(this, delegate {
                customProgressBarStatus.CurrentValue = 0;
                customProgressBarStatus.Maximum = imageList.Count;

                updateUI();
            });

            if (!Directory.Exists(@"/temp"))
            {
                Directory.CreateDirectory(@"/temp");
            }

            await Task.Factory.StartNew(() =>
                   Parallel.For(0, imageList.Count, new ParallelOptions { MaxDegreeOfParallelism = 16 }, (i) =>
                   {
                       ProcessImage(i);
                   })
               );
        }

        private void ProcessImage(int i)
        {
            String tempPath = GetTempFolder(imageList[i].InputPath);

            imageList[i].TempPath = $@"{tempPath}\u.png";
            imageList[i].OutputPath = customCheckBoxOverwriteOriginalFiles.Checked ? imageList[i].InputPath : Path.GetFullPath(customTextBoxOutputDirectory.Text) + @"\" + imageList[i].Name;

            File.Copy(imageList[i].InputPath, imageList[i].TempPath);

            List<ImageProcessor> imageProcessors = new List<ImageProcessor>(4);

            imageProcessors.Add(new PngOut($@"{Application.StartupPath}\proc\pngout.exe"));
            imageProcessors.Add(new OptiPng($@"{Application.StartupPath}\proc\optipng.exe"));
            imageProcessors.Add(new AdvPng($@"{Application.StartupPath}\proc\advpng.exe"));
            imageProcessors.Add(new DeflOpt($@"{Application.StartupPath}\proc\DeflOpt.exe"));

            long oldImageLength = imageList[i].UncompressedSize;
            long newImageLength = imageList[i].UncompressedSize;

            FileInfo oldInfo = new FileInfo(imageList[i].InputPath);
            DateTime oldCreationTime = oldInfo.CreationTime;
            DateTime oldLastAccessTime = oldInfo.LastAccessTime;
            DateTime oldLastWriteTime = oldInfo.LastWriteTime;

            do
            {
                imageList[i].Status = ImageInfo.ProcessStatus.Processing;

                oldImageLength = newImageLength;

                InvokeFunction(this, delegate {
                    customListViewLog.Items[i].TextColor = Color.Orange;
                });

                foreach (ImageProcessor ip in imageProcessors)
                {
                    InvokeFunction(this, delegate {
                        customListViewLog.Items[i].Text = String.Format("{0} [Uncompressed {1}] [{2} steps]", imageList[i].Name, imageList[i].UncompressedSizeToString, imageList[i].Steps);
                    });

                    if (ip.Run(imageList[i].TempPath))
                    {
                        imageList[i].Steps++;
                    }
                    else
                    {
                        imageList[i].Status = ImageInfo.ProcessStatus.Error;
                        imageList[i].ErrorMessage = ip.ErrorMessage;

                        File.Delete(imageList[i].TempPath);
                        Directory.Delete(Path.GetDirectoryName(imageList[i].TempPath), false);

                        InvokeFunction(this, delegate {
                            customListViewLog.Items[i].Text = String.Format("{0} [Uncompressed {1}] [{2} steps] [ERROR: {3}]", imageList[i].Name, imageList[i].UncompressedSizeToString, imageList[i].Steps, imageList[i].ErrorMessage);
                            customListViewLog.Items[i].TextColor = Color.IndianRed;
                            customProgressBarStatus.CurrentValue++;

                            updateStatus();
                        });

                        return;
                    }
                }

                newImageLength = new FileInfo(imageList[i].TempPath).Length;
            } while (newImageLength < oldImageLength);

            if (imageList[i].Status == ImageInfo.ProcessStatus.Processing)
            {
                imageList[i].CompressedSize = newImageLength;
                long savedSpace = imageList[i].UncompressedSize - imageList[i].CompressedSize;

                if (savedSpace >= 0)
                {
                    imageList[i].Status = ImageInfo.ProcessStatus.Processed;
                    compressedSpace += savedSpace;

                    if (savedSpace > 0)
                    {
                        File.Delete(imageList[i].OutputPath);

                        // Place the temp file in the output path
                        File.Copy(imageList[i].TempPath, imageList[i].OutputPath);
                        
                        //Restore timestamps
                        FileInfo newInfo = new FileInfo(imageList[i].OutputPath);
                        newInfo.CreationTime = oldCreationTime;
                        newInfo.LastAccessTime = oldLastAccessTime;
                        newInfo.LastWriteTime = oldLastWriteTime;
                    }

                    File.Delete(imageList[i].TempPath);
                    Directory.Delete(Path.GetDirectoryName(imageList[i].TempPath), false);

                    InvokeFunction(this, delegate {
                        customListViewLog.Items[i].Text = String.Format("{0} [Saved {1}] [Uncompressed {2}] [Compressed {3}] [{4} steps] [{5}%]", imageList[i].Name, Util.ConvertLongToByte(imageList[i].UncompressedSize - imageList[i].CompressedSize), imageList[i].UncompressedSizeToString, imageList[i].CompressedSizeToString, imageList[i].Steps, imageList[i].CompressionRate());
                        customListViewLog.Items[i].TextColor = Color.LightGreen;
                        customProgressBarStatus.CurrentValue++;

                        updateStatus();
                    });
                }
                else
                {
                    imageList[i].Status = ImageInfo.ProcessStatus.Discarded;

                    File.Delete(imageList[i].TempPath);
                    Directory.Delete(Path.GetDirectoryName(imageList[i].TempPath), false);

                    InvokeFunction(this, delegate {
                        customListViewLog.Items[i].Text = String.Format("{0} [Discarded] [Lost {1}] [Uncompressed {2}] [Compressed {3}] [{4} steps] [{5}%]", imageList[i].Name, Util.ConvertLongToByte(imageList[i].UncompressedSize - imageList[i].CompressedSize), imageList[i].UncompressedSizeToString, imageList[i].CompressedSizeToString, imageList[i].Steps, imageList[i].CompressionRate());
                        customListViewLog.Items[i].TextColor = Color.LightSalmon;

                        customProgressBarStatus.CurrentValue++;

                        updateStatus();
                    });
                }
            }
        }

        private void InvokeFunction(System.Windows.Forms.Control o, MethodInvoker mi)
        {
            if (o != null && o.InvokeRequired)
            {
                o.Invoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }

        private String GetTempFolder(String fileName)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                while (true)
                {
                    try
                    {
                        String hash = GetHash(sha256Hash, fileName + DateTime.Now.ToString());

                        String folderName = $@"{Application.StartupPath}\temp\{hash}";

                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);

                            return folderName;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception " + e.Message);
                    }

                    System.Threading.Thread.Sleep(new Random().Next(1500, 5000));
                }
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
