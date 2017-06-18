using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Minecraft_Autosave
{
    public partial class frmMain : Form
    {
        Paths paths = new Paths();
        bool active = false;
        Stopwatch stopwatch = new Stopwatch();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize values
            paths.zipDir = @"C:\Minecraft Autosave\saves";
            txtZipDir.Text = paths.zipDir; // @"C:\Minecraft Autosave\saves"
            nmrMax.Value = paths.maxSaves;
            flowPanelHide.Size = new System.Drawing.Size(674, 112);

            // Populate the combo box list with the world names found under Minecraft's save location:
            populateList(ref cmbWorld);
        }

        private void populateList(ref ComboBox cmb)
        {
            // I have created an empty list called 'items' which is the data source for the combo box world selector.
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";
            var items = new[] { new { Text = "one", Value = "ONE" } }.ToList();
            items.Remove(items[0]);

            // Read the directories (worlds) of the '%AppData%\.minecraft\saves'
            try
            {
                foreach (var world in Directory.GetDirectories(paths.worldsDirectory))
                {
                    items.Add(new { Text = MyClasses.getCurrentDirectory(world), Value = world });
                }
                cmb.DataSource = items;
                // Select the first world (alphabetically?) as default and set the variables:
                paths.GetWorldPaths(cmbWorld, nmrMax);
                flowPanelHide.Visible = false;
                Text = "Minecraft Autosave - " + paths.startPath;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //MessageBox.Show("Minecraft save folder not found: " + paths.worldsDirectory);
            }
        }

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
            Task.Factory.StartNew(() => paths.ZipCurrentWorld());
            stopwatch.Restart();
        }

        private void timerUpdateLabel_Tick(object sender, EventArgs e)
        {
            // Update every second:
            // How many seconds have elapsed:
            int ms = (int) stopwatch.ElapsedMilliseconds;
            // I use Math.Round because sometimes it skips 1 second.
            ms = (int) Math.Round(ms/1000.0);

            // How many seconds are remaining:
            int timeReversed = (int) Math.Round(timerInterval.Interval/1000.0) - ms;

            int tempSeconds = (int) Math.Floor(timeReversed % 60.0);
            string seconds = (tempSeconds < 10) ? "0" + tempSeconds.ToString() : tempSeconds.ToString();

            lblTime.Text = Math.Floor(timeReversed / 60.0).ToString() + ":" + seconds;
        }

        private void btnSaveNow_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(paths.ToString()); // Debug
            Task.Factory.StartNew(() => paths.ZipCurrentWorld());
            if (active)
            {
                stopwatch.Restart();
                timerInterval.Stop();
                timerInterval.Start();
            }
        }

        private void nmrMax_ValueChanged(object sender, EventArgs e)
        {
            paths.maxSaves = (int) nmrMax.Value;
        }

        private void nmrMax_Leave(object sender, EventArgs e)
        {
            string contents = File.ReadAllText(paths.savesIni);
            contents = Regex.Replace(contents, @"(maxSaves: *)(\d{1,2})", m => m.Groups[1].Value + nmrMax.Value.ToString()); // replace only the number 
            File.WriteAllText(paths.savesIni, contents);
        }

        private void cmbWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            paths.GetWorldPaths(cmbWorld, nmrMax);
            Text = "Minecraft Autosave - " + paths.startPath;
        }

        private void picZipDir_Click(object sender, EventArgs e)
        {
            opnBackupLocation.SelectedPath = paths.zipDir;
            opnBackupLocation.Description = "Choose the backup location:";
            if (opnBackupLocation.ShowDialog() == DialogResult.OK)
            {
                paths.zipDir = opnBackupLocation.SelectedPath;
                paths.GetWorldPaths(cmbWorld, nmrMax);
            }
        }

        private void picWorldsDirectory_Click(object sender, EventArgs e)
        {
            opnWorld.RootFolder = Environment.SpecialFolder.ApplicationData;
            opnWorld.SelectedPath = paths.worldsDirectory;
            opnWorld.Description = "Choose which world you want create backups for:";
            opnWorld.ShowNewFolderButton = false;
            if (opnWorld.ShowDialog() == DialogResult.OK)
            {
                paths.maxSaves = 20;
                paths.index = -1;
                paths.worldsDirectory = opnWorld.SelectedPath;
                populateList(ref cmbWorld);
                paths.GetWorldPaths(cmbWorld, nmrMax);
                Text = "Minecraft Autosave - " + paths.startPath;
            }
            //MessageBox.Show(paths.ToString());
        }

        private void picRefreshWorlds_Click(object sender, EventArgs e)
        {
            populateList(ref cmbWorld);
        }
    }
}
