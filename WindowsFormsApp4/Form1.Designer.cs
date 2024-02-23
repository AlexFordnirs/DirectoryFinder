using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ResourceManager MainRes;
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
            MainRes = Properties.Resources.ResourceManager;
            this.Path = new System.Windows.Forms.Label();
            this.InfoText = new System.Windows.Forms.Label();
            this.ResultDirs = new System.Windows.Forms.Label();
            this.ResultFiles = new System.Windows.Forms.Label();
            this.InputPath = new System.Windows.Forms.TextBox();
            this.BtnGo = new System.Windows.Forms.Button();
            this.GetFileSizeBtn = new System.Windows.Forms.Button();
            this.GetDirsSizeBtn = new System.Windows.Forms.Button();
            this.ChoicePathBtn = new System.Windows.Forms.Button();
            this.DirArrowUp = new Button();
            this.DirArrowDown = new Button();
            this.FileArrowUp = new Button();
            this.FileArrowDown = new Button();
            this.ThemeBtn = new Button();
            this.LogCheckBtn = new Button();
            this.SuspendLayout();
            // 
            // Path
            // 
            this.Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Path.Location = new System.Drawing.Point(0, 20);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(100, 23);
            this.Path.TabIndex = 0;
            this.Path.Text = "Input path: ";
            // 
            // InfoText
            // 
            this.InfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoText.Name = "InfoText";
            this.InfoText.Location = new System.Drawing.Point(10, 120);
            this.InfoText.Size = new System.Drawing.Size(600, 20);
            this.InfoText.TabIndex = 0;
            this.InfoText.Text = "Directories: 0 | Last Acces:                           Files: 0 | Last A" +
    "cces: ";
            // 
            // ResultDirs
            // 
            this.ResultDirs.Name = "ResultDirs";
            this.ResultDirs.Location = new System.Drawing.Point(5, 140);
            this.ResultDirs.Size = new System.Drawing.Size(265, 15);
            this.ResultDirs.TabIndex = 0;
            // 
            // ResultFiles
            // 
            this.ResultFiles.Name = "ResultFiles";
            this.ResultFiles.Location = new System.Drawing.Point(270, 140);
            this.ResultFiles.Size = new System.Drawing.Size(300, 15);
            this.ResultFiles.TabIndex = 0;
            // 
            // InputPath
            // 
            this.InputPath.Name = "InputPath";
            this.InputPath.Location = new System.Drawing.Point(100, 15);
            this.InputPath.Size = new System.Drawing.Size(250, 20);
            this.InputPath.TabIndex = 0;
            // 
            // BtnGo
            // 
            this.BtnGo.Name = "BtnGo";
            this.BtnGo.Location = new System.Drawing.Point(100, 50);
            this.BtnGo.Size = new System.Drawing.Size(120, 30);
            this.BtnGo.TabIndex = 0;
            this.BtnGo.Text = "GO!";
            // 
            // GetFileSizeBtn
            // 
            this.GetFileSizeBtn.Name = "GetFileSizeBtn";
            this.GetFileSizeBtn.Location = new System.Drawing.Point(400, 10);
            this.GetFileSizeBtn.Size = new System.Drawing.Size(50, 50);
            this.GetFileSizeBtn.TabIndex = 0;
            this.GetFileSizeBtn.Text = "Get Files Size";
            // 
            // GetDirsSizeBtn
            // 
            this.GetDirsSizeBtn.Name = "GetDirsSizeBtn";
            this.GetDirsSizeBtn.Location = new System.Drawing.Point(460, 10);
            this.GetDirsSizeBtn.Size = new System.Drawing.Size(50, 50);
            this.GetDirsSizeBtn.TabIndex = 0;
            this.GetDirsSizeBtn.Text = "Get Dirs Size";
            // 
            // ChoicePathBtn
            // 
            this.ChoicePathBtn.Name = "ChoicePathBtn";
            this.ChoicePathBtn.Location = new System.Drawing.Point(350, 15);
            this.ChoicePathBtn.Size = new System.Drawing.Size(40, 20);
            this.ChoicePathBtn.TabIndex = 0;
            this.ChoicePathBtn.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Perses";
            this.ResumeLayout(false);
            //
            // DirArrowUp
            //
            DirArrowUp.Text = @"/\";
            DirArrowUp.Location = new Point(10, 60);
            DirArrowUp.Size = new Size(25, 25);
            DirArrowUp.Enabled = false;
            //
            // DirArrowDown
            //
            DirArrowDown.Text = @"\/";
            DirArrowDown.Location = new Point(10, 90);
            DirArrowDown.Size = new Size(25, 25);
            DirArrowDown.Enabled = false;
            //
            // FileArrowUp
            //
            FileArrowUp.Text = @"/\";
            FileArrowUp.Location = new Point(270, 60);
            FileArrowUp.Size = new Size(25, 25);
            FileArrowUp.Enabled = false;
            //
            // FileArrowDown
            //
            FileArrowDown.Text = @"\/";
            FileArrowDown.Location = new Point(270, 90);
            FileArrowDown.Size = new Size(25, 25);
            FileArrowDown.Enabled = false;
            //
            // LogCheckBtn
            //
            LogCheckBtn.Text = "Check Logs";
            LogCheckBtn.Location = new Point(400, 70);
            LogCheckBtn.Size = new Size(50, 50);
            //
            // ThemeBtn
            //
            ThemeBtn.Text = "Change Theme";
            ThemeBtn.Location = new Point(460 , 70);
            ThemeBtn.Size = new Size(50, 50);
            //
            // Clicks Init
            //
            BtnGo.MouseClick += GoClick;
            GetDirsSizeBtn.MouseClick += GetDirsSizeClk;
            GetFileSizeBtn.MouseClick += GetFilesSizeClk;
            ChoicePathBtn.MouseClick += ChoiceClick;
            DirArrowUp.MouseClick += DirUpClick;
            DirArrowDown.MouseClick += DirDownClick;
            FileArrowUp.MouseClick += FileArrowUpClick;
            FileArrowDown.MouseClick += FileArrowDownClick;
            ThemeBtn.MouseClick += ThemeClick;
            LogCheckBtn.MouseClick += LogCheckClick;

        }


        Label Path;
        Label InfoText;
        Label ResultDirs;
        Label ResultFiles;

        TextBox InputPath;

       // Button SaveBtn;
        Button BtnGo;
        Button GetFileSizeBtn;
        Button GetDirsSizeBtn;
        Button ChoicePathBtn;
        Button DirArrowUp;
        Button DirArrowDown;
        Button FileArrowUp;
        Button FileArrowDown;
        Button ThemeBtn;
        Button LogCheckBtn;

        #endregion
    }
}

