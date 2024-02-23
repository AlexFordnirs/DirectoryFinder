using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WindowsFormsApp4
{
    public class Theme
    {
        public int BgColor;
        public int FgColor;
    }
    public partial class Form1 : Form
    {

        int TextDirsWidth = 295;
        int TextDirsHeigth = 15;

        int TextFilesHeigth = 15;
        int TextFilesWidth = 300;

        long SizeFiles = 0;
        long SizeDirs = 0;

        int CountDirs = 0;
        int CountFiles = 0;

        int FileArrowIndex = 0;
        int DirArrowIndex = 0;

        int ItemsCount = 0;
        int ThemeCountClicks = 1;



        int GoClickTimes = 0;
        static string PathXml = @"C:\Users\DChaos\source\repos\Files\ThemePicker\ThemePicker\bin\Debug\Theme.xml";

        public List<string> Logs = new List<string>();
        Theme T = new Theme();


        public Form1()
        {
            InitializeComponent();

            //ThemePicker
            try
            {
                SetTheme();
            }
            catch
            {
                
            }

            Controls.Add(InfoText);
            Controls.Add(BtnGo);
            Controls.Add(Path);
            Controls.Add(InputPath);
            Controls.Add(ResultDirs);
            Controls.Add(ResultFiles);
            Controls.Add(GetFileSizeBtn);
            Controls.Add(GetDirsSizeBtn);
            Controls.Add(ChoicePathBtn);
            Controls.Add(DirArrowUp);
            Controls.Add(DirArrowDown);
            Controls.Add(FileArrowDown);
            Controls.Add(FileArrowUp);
            Controls.Add(ThemeBtn);
        }

        private void SetTheme()
        {
            T = ThemeDeserialize();
            switch (T.BgColor)
            {
                case 1: BackColor = Color.Aquamarine; break;
                case 2: BackColor = Color.Black; break;
                case 3: BackColor = Color.Violet; break;
                case 4: BackColor = Color.Green; break;
                case 5: BackColor = Color.HotPink; break;
                case 6: BackColor = Color.Lime; break;
                case 7: BackColor = Color.Yellow; break;
                case 8: BackColor = Color.White; break;
                case 9: BackColor = Color.Red; break;
                case 10: BackColor = Color.DarkMagenta; break;
                default: BackColor = Color.White; break;
            }
            switch (T.FgColor)
            {
                case 1: ForeColor = Color.Aquamarine; break;
                case 2: ForeColor = Color.Black; break;
                case 3: ForeColor = Color.Violet; break;
                case 4: ForeColor = Color.Green; break;
                case 5: ForeColor = Color.HotPink; break;
                case 6: ForeColor = Color.Lime; break;
                case 7: ForeColor = Color.Yellow; break;
                case 8: ForeColor = Color.White; break;
                case 9: ForeColor = Color.Red; break;
                case 10: ForeColor = Color.DarkMagenta; break;
                default: ForeColor = Color.White; break;
            }

        }
        private void LogSerialize(List<string> Logs)
        {
            XmlSerializer Ser = new XmlSerializer(typeof(List<string>));

            using (FileStream fs = new FileStream("Log.xml", FileMode.OpenOrCreate))
            {
                Ser.Serialize(fs, Logs);
            }
        }
        private static Theme ThemeDeserialize()
        {
            Theme ThemeColors;

            XmlSerializer serializer = new XmlSerializer(typeof(Theme));

            using (FileStream fs = new FileStream(PathXml, FileMode.OpenOrCreate))
            {
                ThemeColors = (Theme)serializer.Deserialize(fs);

                Console.WriteLine("Done!");
            }

            return ThemeColors;
        }
        private void GetFilesSizeClk(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"Files Size : {SizeFiles} bytes",
                     "Size Window",
                     MessageBoxButtons.OK
                     , MessageBoxIcon.Information);
        }
        private void GetDirsSizeClk(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"Directories Size : {SizeDirs} bytes",
                "Size Window",
                MessageBoxButtons.OK
                , MessageBoxIcon.Information);
        }
        private void GoClick(object sender, MouseEventArgs e)
        {

            if (GoClickTimes >= 8)
            {
                Controls.Add(LogCheckBtn);
            }
            CountDirs = int.Parse(this.MainRes.GetString("CountDirs"));
            CountFiles = int.Parse(this.MainRes.GetString("CountFiles"));

            SizeDirs = int.Parse(this.MainRes.GetString("SizeDirs"));
            SizeFiles = int.Parse(this.MainRes.GetString("SizeFiles"));

            this.InfoText.Text = "Directories: 0 | Last Acces:                           Files: 0 | Last A" +
    "cces: ";

            ResultDirs.Text = "";
            ResultFiles.Text = "";

            ItemsCount = 0;
            FileArrowIndex = 0;
            DirArrowIndex = 0;

            DirArrowDown.Enabled = false;
            DirArrowUp.Enabled = false;
            FileArrowDown.Enabled = false;
            FileArrowUp.Enabled = false;


            TextDirsWidth = int.Parse(this.MainRes.GetString("TextDirsWidth"));
            TextDirsHeigth = int.Parse(this.MainRes.GetString("TextDirsHeigth"));

            int WindowsSizeWidth = int.Parse(MainRes.GetString("WindowsSizeWidth"));
            int WindowsSizeHeigth = int.Parse(MainRes.GetString("WindowsSizeHeigth"));

            this.Size = new Size(WindowsSizeWidth, WindowsSizeHeigth);

            string path = InputPath.Text;
            Logs.Add($"<{path}>");
            ResultDirs.Size = new Size(int.Parse(MainRes.GetString("TextDirsWidth")), int.Parse(MainRes.GetString("TextDirsHeigth")));
            ResultFiles.Size = new Size(int.Parse(MainRes.GetString("TextFileWidth")), int.Parse(MainRes.GetString("TextFileHeigth")));
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (var item in directoryInfo.GetDirectories())
                {
                    ItemsCount++;
                    ResultDirs.Text += "-" + item.Name + " | " + item.LastAccessTime + Environment.NewLine;

                    TextDirsHeigth += 15;
                    CountDirs++;

                    foreach (var item2 in item.GetFiles())
                    {
                        SizeDirs += item2.Length;
                    }

                    if (ItemsCount >= 25)
                    {
                        DirArrowDown.Enabled = true;
                    }
                    else
                    {
                        DirArrowDown.Enabled = false;
                    }
                    //Проверка на конец списка
                    if (DirArrowIndex >= ItemsCount - 24)
                    {
                        DirArrowDown.Enabled = false;
                    }
                    else
                    {
                        DirArrowDown.Enabled = true;
                    }
                    //Проверка на нулевой индекс
                    if (DirArrowIndex <= 1)
                    {
                        DirArrowUp.Enabled = false;
                    }
                    else
                    {
                        DirArrowUp.Enabled = true;
                    }
                    GC.Collect();
                }
                ItemsCount = 0;
                foreach (var item in directoryInfo.GetFiles())
                {
                    ItemsCount++;
                    ResultFiles.Text += item.Name + " | " + item.LastAccessTime + Environment.NewLine;

                    TextFilesHeigth += 15;

                    CountFiles++;

                    SizeFiles += item.Length;
                    if (ItemsCount >= 24)
                    {
                        FileArrowDown.Enabled = true;
                    }
                    else
                    {
                        FileArrowDown.Enabled = false;
                    }
                    //Проверка на конец списка
                    if (FileArrowIndex >= ItemsCount - 24)
                    {
                        FileArrowDown.Enabled = false;
                    }
                    else
                    {
                        FileArrowDown.Enabled = true;
                    }
                    //Проверка на нулевой индекс
                    if (FileArrowIndex <= 1)
                    {
                        FileArrowUp.Enabled = false;
                    }
                    else
                    {
                        FileArrowUp.Enabled = true;
                    }
                    GC.Collect();

                }

                //////////////////////
                InfoText.Text = $"Directories: {CountDirs} | Last Acces:" +
                    $"                         Files: {CountFiles} | Last Acces: ";

                /////////////////////
                ResultDirs.Size = new Size(TextDirsWidth, TextDirsHeigth);
                ResultFiles.Size = new Size(TextFilesWidth, TextFilesHeigth);

                LogSerialize(Logs);
                GoClickTimes++;
            }
            catch (Exception ex)
            {
                if (path == "") { ResultDirs.Text = "         Введите путь"; }
                else { ResultDirs.Text = ex.Message; }
            }
        }
        private void ChoiceClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog FBO = new FolderBrowserDialog();

            if (FBO.ShowDialog() == DialogResult.OK)
            {
                InputPath.Text = FBO.SelectedPath;
            }
        }
        private void DirDownClick(object sender, MouseEventArgs e)
        {
            try
            {
                DirArrowIndex++;
                ResultDirs.Text = "";
                string path = InputPath.Text;
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                ItemsCount = 0;
                foreach (var item in directoryInfo.GetDirectories())
                {
                    ItemsCount++;
                    //Проверка на переполнение окна(включение стрелочек при переполнении)
                    if (ItemsCount < 24)
                    {
                        DirArrowDown.Enabled = false;
                        DirArrowUp.Enabled = false;
                    }
                    else
                    {
                        DirArrowDown.Enabled = true;
                        DirArrowUp.Enabled = true;
                    }
                    //Проверка Индекса местоположения экрана
                    if (ItemsCount > DirArrowIndex)
                    {
                        ResultDirs.Text += "-" + item.Name + " | " + item.LastAccessTime + Environment.NewLine;
                    }
                    //Проверка на конец списка
                    if (DirArrowIndex == ItemsCount - 24)
                    {
                        DirArrowDown.Enabled = false;
                    }
                    else
                    {
                        DirArrowDown.Enabled = true;
                    }
                    //Проверка на нулевой индекс
                    if (DirArrowIndex == 0)
                    {
                        DirArrowUp.Enabled = false;
                    }
                    else
                    {
                        DirArrowUp.Enabled = true;
                    }

                    TextDirsHeigth += 15;
                    CountDirs++;

                    foreach (var item2 in item.GetFiles())
                    {
                        SizeDirs += item2.Length;
                    }

                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DirUpClick(object sender, MouseEventArgs e)
        {
            try
            {

                DirArrowIndex--;
                ResultDirs.Text = "";
                string path = InputPath.Text;
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                ItemsCount = 0;
                foreach (var item in directoryInfo.GetDirectories())
                {
                    ItemsCount++;
                    //Проверка на переполнение окна(включение стрелочек при переполнении)
                    if (ItemsCount < 24)
                    {
                        DirArrowDown.Enabled = false;
                        DirArrowUp.Enabled = false;
                    }
                    else
                    {
                        DirArrowDown.Enabled = true;
                        DirArrowUp.Enabled = true;
                    }
                    //Проверка Индекса местоположения экрана
                    if (ItemsCount > DirArrowIndex)
                    {
                        ResultDirs.Text += "-" + item.Name + " | " + item.LastAccessTime + Environment.NewLine;
                    }
                    TextDirsHeigth += 15;
                    CountDirs++;
                    //Проверка на конец списка
                    if (DirArrowIndex >= ItemsCount - 24)
                    {
                        DirArrowDown.Enabled = false;
                    }
                    else
                    {
                        DirArrowDown.Enabled = true;
                    }
                    //Проверка на нулевой индекс
                    if (DirArrowIndex == 0)
                    {
                        DirArrowUp.Enabled = false;
                    }
                    else
                    {
                        DirArrowUp.Enabled = true;
                    }

                    foreach (var item2 in item.GetFiles())
                    {
                        SizeDirs += item2.Length;
                    }

                    GC.Collect();
                }
                ItemsCount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void FileArrowDownClick(object sender, MouseEventArgs e)
        {
            FileArrowIndex++;
            ResultFiles.Text = "";
            string path = InputPath.Text;

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            ItemsCount = 0;

            foreach (var item in directoryInfo.GetFiles())
            {
                ItemsCount++;
                //Проверка на переполнение окна(включение стрелочек при переполнении)
                if (ItemsCount < 24)
                {
                    FileArrowDown.Enabled = false;
                    FileArrowUp.Enabled = false;
                }
                else
                {
                    FileArrowDown.Enabled = true;
                    FileArrowUp.Enabled = true;
                }
                //Проверка Индекса местоположения экрана
                if (ItemsCount > FileArrowIndex)
                {
                    ResultFiles.Text += item.Name + " | " + item.LastAccessTime + Environment.NewLine;
                }
                //Проверка на конец списка
                if (FileArrowIndex == ItemsCount - 24)
                {
                    FileArrowDown.Enabled = false;
                }
                else
                {
                    FileArrowDown.Enabled = true;
                }
                //Проверка на нулевой индекс
                if (FileArrowIndex == 0)
                {
                    FileArrowUp.Enabled = false;
                }
                else
                {
                    FileArrowUp.Enabled = true;
                }
                GC.Collect();
            }
        }
        private void FileArrowUpClick(object sender, MouseEventArgs e)
        {
            FileArrowIndex--;
            ResultFiles.Text = "";
            string path = InputPath.Text;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            ItemsCount = 0;
            foreach (var item in directoryInfo.GetFiles())
            {
                ItemsCount++;
                //Проверка на переполнение окна(включение стрелочек при переполнении)
                if (ItemsCount < 24)
                {
                    FileArrowDown.Enabled = false;
                    FileArrowUp.Enabled = false;
                }
                else
                {
                    FileArrowDown.Enabled = true;
                    FileArrowUp.Enabled = true;
                }
                //Проверка Индекса местоположения экрана
                if (ItemsCount > FileArrowIndex)
                {
                    ResultFiles.Text += item.Name + " | " + item.LastAccessTime + Environment.NewLine;
                }
                //Проверка на конец списка
                if (FileArrowIndex == ItemsCount - 24)
                {
                    FileArrowDown.Enabled = false;
                }
                else
                {
                    FileArrowDown.Enabled = true;
                }
                //Проверка на нулевой индекс
                if (FileArrowIndex == 0)
                {
                    FileArrowUp.Enabled = false;
                }
                else
                {
                    FileArrowUp.Enabled = true;
                }

                SizeFiles += item.Length;

                GC.Collect();
            }
        }
        private void ThemeClick(object sender, MouseEventArgs e)
        {
            ThemeCountClicks++;
            if (ThemeCountClicks % 2 != 0)
            {
                this.ForeColor = Color.Black;
                this.BackColor = Color.White;
            }
            else
            {
                this.ForeColor = Color.Aquamarine;
                this.BackColor = Color.Black;
            }

        }
        private void LogCheckClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\DChaos\Desktop\Files\WindowsFormsApp4\WindowsFormsApp4\bin\Debug\Log.xml");
        }
    }
}
