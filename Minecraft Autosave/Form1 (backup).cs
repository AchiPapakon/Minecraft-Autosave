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
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Timers;

namespace Minecraft_Autosave
{
    public partial class frmMain : Form
    {
        int maxSaves = -1;
        string startPath = @"C:\Users\spy\AppData\Roaming\.minecraft\saves\2016_Apr"; // This line has to change for different worlds!
        static string zipPath = @"Z:\backup\Minecraft\2016_Apr"; // This line has to change for different worlds!
        string savesIni = Path.Combine(zipPath, "saves.ini");
        int index = -1;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maxSaves = (int) nmrMax.Value;
            parseFile();
            
        }

        bool active = false;
        Stopwatch stopwatch = new Stopwatch();
        private void btnStart_Click(object sender, EventArgs e)
        {
            active = !active;

            if (active) {
                btnStart.Text = "Stop";
                timerInterval.Start();
                timerUpdateLabel.Start();

                stopwatch.Start();
            } else {
                btnStart.Text = "Start";
                timerInterval.Stop();
                timerUpdateLabel.Stop();
                lblTime.Text = "";

                stopwatch.Reset();
            }
        }

        private void timerInterval_Tick(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => zipCurrentWorld());
            stopwatch.Restart();
        }

        private void parseFile()
        {
            // parse the ini file and retrieve the variables:
            if (File.Exists(savesIni))
            {
                string contents = System.IO.File.ReadAllText(savesIni);
                index = findValue(contents, @"index: *(\d{1,2})") ?? findLastIndex(); // index = [if not null] ?? [if null: search manually]
                maxSaves = findValue(contents, @"maxSaves: *(\d{1,2})") ?? maxSaves;
                File.Delete(savesIni);
            }
            using (StreamWriter sw = File.CreateText(savesIni)) {
                sw.WriteLine("index: " + (index = findLastIndex())   );
                sw.WriteLine("maxSaves: " + (nmrMax.Value = maxSaves));
            }
        }

        private int? findValue(string contents, string pattern)
        {
            int returnedInteger = -1;
            Match match = Regex.Match(contents, pattern);
            if (match.Success) {
                if (!int.TryParse(match.Groups[1].Value, out returnedInteger)) { // extract the 'index' value
                    MessageBox.Show("Error converting string to number!");
                }
            }
            if (returnedInteger != -1) {
                return returnedInteger;
            } else {
                return null;
            }
        }

        private int findLastIndex ()
        {
            int i;
            for (i = 1; i < maxSaves + 1; i++) { // e.g i = [1 between 10]
                if (!File.Exists(Path.Combine(zipPath, "2016_Apr_" + i + ".zip"))) { // This line has to change for different worlds!
                    //MessageBox.Show(Path.Combine(zipPath, "2016_Apr_" + i + ".zip")); //Debugging...
                    return i - 1;
                }
            }
            // If all the list is present, then start from the beginning:
            return 0;
        }

        private void zipCurrentWorld()
        {
            // try-catch if someone deletes savesIni since the program has been loaded.
            
            //ZipFile.ExtractToDirectory(zipPath, extractPath);

            // If the file saves.ini exists, then lookup the current index:
            //int index = -1;
            //MessageBox.Show(savesIni); //Debugging...

            if (index < maxSaves) {
                index++;
            } else {
                index = 0;
            }

            // Update the file 'saves.ini':
            string contents = System.IO.File.ReadAllText(savesIni);
            contents = Regex.Replace(contents, @"(index: *)(\d{1,2})", m => m.Groups[1].Value + index.ToString()); // replace only the number
            File.WriteAllText(savesIni, contents);

            // Delete the zip file if it exists:
            string targetFile = Path.Combine(zipPath, @"2016_Apr_" + index + ".zip");
            if (File.Exists(targetFile)) {
                File.Delete(targetFile);
            }

            // First, create a temporary folder:
            string tempDirectory = Path.Combine(zipPath, "temp");
            if (!System.IO.Directory.Exists(tempDirectory)) {
                System.IO.Directory.CreateDirectory(tempDirectory);
            }
            // Copy the folders to the temporary folder and overwrite (?):
            foreach (string dirPath in Directory.GetDirectories(startPath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(startPath, tempDirectory));

            // Copy all the files & Replaces any files with the same name:
            foreach (string newPath in Directory.GetFiles(startPath, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(startPath, tempDirectory), true);

            ZipFile.CreateFromDirectory(tempDirectory, targetFile, CompressionLevel.Optimal, false);

            Directory.Delete(tempDirectory, true);
        }

        private void timerUpdateLabel_Tick(object sender, EventArgs e)
        {
            // Update every second:
            // How many seconds have elapsed:
            int ms = (int) stopwatch.ElapsedMilliseconds;
            ms = (int) Math.Round(ms/1000.0);

            // How many seconds are remaining:
            int timeReversed = (int) Math.Round(timerInterval.Interval/1000.0) - ms;

            int tempSeconds = (int) Math.Floor(timeReversed % 60.0);
            string seconds = (tempSeconds < 10) ? "0" + tempSeconds.ToString() : tempSeconds.ToString();

            lblTime.Text = Math.Floor(timeReversed / 60.0).ToString() + ":" + seconds;
        }

        private void btnSaveNow_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => zipCurrentWorld());
            if (active)
            {
                stopwatch.Restart();
                timerInterval.Stop();
                timerInterval.Start();
            }
        }

        private void nmrMax_ValueChanged(object sender, EventArgs e)
        {
            maxSaves = (int) nmrMax.Value;
        }

        private void nmrMax_Leave(object sender, EventArgs e)
        {
            string contents = System.IO.File.ReadAllText(savesIni);
            contents = Regex.Replace(contents, @"(maxSaves: *)(\d{1,2})", m => m.Groups[1].Value + nmrMax.Value.ToString()); // replace only the number 
            File.WriteAllText(savesIni, contents);
        }

    }
}
