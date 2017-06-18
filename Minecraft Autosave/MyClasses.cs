using System;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace Minecraft_Autosave
{
    class MyClasses
    {
        public static string getCurrentDirectory(string dir)
        {
            // Return the data after the last '\' (which is a file or a directory)
            return dir.Substring(dir.LastIndexOf('\\') + 1);
        }

        public static int? findValue(string contents, string pattern)
        {
            int returnedInteger = -1;
            Match match = Regex.Match(contents, pattern);
            if (match.Success)
            {
                if (!int.TryParse(match.Groups[1].Value, out returnedInteger))
                { // extract the 'index' value
                    throw new System.Exception("Error converting string to number!");
                }
            }
            if (returnedInteger != -1)
                return returnedInteger;
            else
                return null;
        }
    }

    class Paths
    {
        public int maxSaves = 20;
        public string worldsDirectory = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft", "saves");
        public string startPath = ""; // Full path of the world. (the above plus the worldName)
        public string worldName = ""; // Just the world name.
        public string zipDir = ""; // The directory where we'll zip the worlds.
        public string zipDirWorld = ""; // World-specific zip directory. (the above plus the world name)
        public string savesIni = ""; // = Path.Combine(zipDir, "saves.ini");
        public int index = -1;

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("maxSaves: " + maxSaves)
            .AppendLine("index: " + index)
            .AppendLine("worldName: " + worldName)
            .AppendLine("zipDir: " + zipDir)
            .AppendLine("zipDirWorld: " + zipDirWorld)
            .AppendLine("savesIni: " + savesIni);
            return output.ToString();
        }

        public void GetWorldPaths(ComboBox cmb, NumericUpDown nmr)
        {
            worldName = cmb.Text;  // just the name of the directory
            startPath = cmb.SelectedValue.ToString(); // Full path name
            zipDirWorld = Path.Combine(zipDir, worldName);
            savesIni = Path.Combine(zipDirWorld, "saves.ini");
            ParseSavesIni(nmr);
        }
        
        public void ParseSavesIni(NumericUpDown nmr) //Parsing savesIni
        {
            // parse the ini file and retrieve the variables:
            if (!Directory.Exists(Path.GetDirectoryName(savesIni)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(savesIni));
            }
            if (File.Exists(savesIni))
            {
                string contents = File.ReadAllText(savesIni);
                index = MyClasses.findValue(contents, @"index: *(\d{1,2})") ?? findLastIndex(); // index = [if not null] ?? [if null: search manually]
                maxSaves = MyClasses.findValue(contents, @"maxSaves: *(\d{1,2})") ?? maxSaves;
                File.Delete(savesIni);
            }
            using (StreamWriter sw = File.CreateText(savesIni))
            {
                sw.WriteLine("index: " + (index = findLastIndex()));
                sw.WriteLine("maxSaves: " + (nmr.Value = maxSaves));
            }
        }

        public int findLastIndex()
        {
            int i;
            for (i = 1; i < maxSaves + 1; i++)
            { // e.g i = [1 between 10]
                if (!File.Exists(Path.Combine(zipDirWorld, worldName + "_" + i + ".zip")))
                { // This line has to change for different worlds!
                    //MessageBox.Show(Path.Combine(zipDir, "2016_Apr_" + i + ".zip")); //Debugging...
                    return i - 1;
                }
            }
            // If all the list is present, then start from the beginning:
            return 0;
        }

        public void ZipCurrentWorld()
        {
            // try-catch if someone deletes savesIni since the program has been loaded.

            //ZipFile.ExtractToDirectory(zipDir, extractPath);

            // If the file saves.ini exists, then lookup the current index:
            //int index = -1;
            //MessageBox.Show(savesIni); //Debugging...

            if (index < maxSaves)
                index++;
            else
                index = 1;

            // Update the file 'saves.ini':
            string contents = File.ReadAllText(savesIni);
            contents = Regex.Replace(contents, @"(index: *)(\d{1,2})", m => m.Groups[1].Value + index.ToString()); // replace only the number
            File.WriteAllText(savesIni, contents);

            // Delete the zip file if it exists:
            string targetFile = Path.Combine(zipDirWorld, worldName + "_" + index + ".zip");
            if (File.Exists(targetFile))
                File.Delete(targetFile);

            // First, create a temporary folder:
            string tempDirectory = Path.Combine(zipDirWorld, "temp");
            if (!Directory.Exists(tempDirectory))
                Directory.CreateDirectory(tempDirectory);

            // Copy the folders to the temporary folder and overwrite (?):
            foreach (string dirPath in Directory.GetDirectories(startPath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(startPath, tempDirectory));

            // Copy all the files & Replaces any files with the same name:
            foreach (string newPath in Directory.GetFiles(startPath, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(startPath, tempDirectory), true);

            ZipFile.CreateFromDirectory(tempDirectory, targetFile, CompressionLevel.Optimal, false);

            Directory.Delete(tempDirectory, true);
        }
    }
}
