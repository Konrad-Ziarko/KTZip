﻿namespace KTZipPresentation.View
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripChangeName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFileProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.filesGrid = new System.Windows.Forms.DataGridView();
            this.Ico = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rozmiar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modyfikowano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utworzono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filesGrid_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.contextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextRename = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filesGrid)).BeginInit();
            this.filesGrid_contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.edycjaToolStripMenuItem,
            this.widokToolStripMenuItem,
            this.inneToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNewFolder,
            this.toolStripMenuItem1,
            this.toolStripEnd});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // toolStripNewFolder
            // 
            this.toolStripNewFolder.Name = "toolStripNewFolder";
            this.toolStripNewFolder.Size = new System.Drawing.Size(140, 26);
            this.toolStripNewFolder.Text = "Utwórz...";
            this.toolStripNewFolder.Click += new System.EventHandler(this.toolStripNewFolder_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(137, 6);
            // 
            // toolStripEnd
            // 
            this.toolStripEnd.Name = "toolStripEnd";
            this.toolStripEnd.Size = new System.Drawing.Size(140, 26);
            this.toolStripEnd.Text = "Zakończ";
            this.toolStripEnd.Click += new System.EventHandler(this.toolStripEnd_Click);
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSelectAll,
            this.toolStripUnselectAll,
            this.toolStripMenuItem2,
            this.toolStripChangeName,
            this.toolStripDeleteFile,
            this.toolStripMenuItem6,
            this.toolStripFileProperties});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            // 
            // toolStripSelectAll
            // 
            this.toolStripSelectAll.Name = "toolStripSelectAll";
            this.toolStripSelectAll.Size = new System.Drawing.Size(203, 26);
            this.toolStripSelectAll.Text = "Zaznacz wszystko";
            this.toolStripSelectAll.Click += new System.EventHandler(this.toolStripSelectAll_Click);
            // 
            // toolStripUnselectAll
            // 
            this.toolStripUnselectAll.Name = "toolStripUnselectAll";
            this.toolStripUnselectAll.Size = new System.Drawing.Size(203, 26);
            this.toolStripUnselectAll.Text = "Odznacz wszystko";
            this.toolStripUnselectAll.Click += new System.EventHandler(this.toolStripUnselectAll_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // toolStripChangeName
            // 
            this.toolStripChangeName.Name = "toolStripChangeName";
            this.toolStripChangeName.Size = new System.Drawing.Size(203, 26);
            this.toolStripChangeName.Text = "Zmień nazwę...";
            this.toolStripChangeName.Click += new System.EventHandler(this.toolStripChangeName_Click);
            // 
            // toolStripDeleteFile
            // 
            this.toolStripDeleteFile.Name = "toolStripDeleteFile";
            this.toolStripDeleteFile.Size = new System.Drawing.Size(203, 26);
            this.toolStripDeleteFile.Text = "Usuń";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(200, 6);
            // 
            // toolStripFileProperties
            // 
            this.toolStripFileProperties.Name = "toolStripFileProperties";
            this.toolStripFileProperties.Size = new System.Drawing.Size(203, 26);
            this.toolStripFileProperties.Text = "Właściwości";
            this.toolStripFileProperties.Click += new System.EventHandler(this.toolStripFileProperties_Click);
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // inneToolStripMenuItem
            // 
            this.inneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOptions});
            this.inneToolStripMenuItem.Name = "inneToolStripMenuItem";
            this.inneToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.inneToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.inneToolStripMenuItem.Text = "Inne";
            // 
            // toolStripOptions
            // 
            this.toolStripOptions.Name = "toolStripOptions";
            this.toolStripOptions.Size = new System.Drawing.Size(123, 26);
            this.toolStripOptions.Text = "Opcje";
            this.toolStripOptions.Click += new System.EventHandler(this.toolStripOptions_Click);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Path.Location = new System.Drawing.Point(100, 0);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(695, 22);
            this.textBox_Path.TabIndex = 2;
            this.textBox_Path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Path_KeyDown);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.textBox_Path);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 28);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(795, 25);
            this.panelTop.TabIndex = 6;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.Controls.Add(this.buttonRefresh);
            this.panelTopLeft.Controls.Add(this.buttonBack);
            this.panelTopLeft.Controls.Add(this.buttonNext);
            this.panelTopLeft.Controls.Add(this.buttonUp);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(100, 25);
            this.panelTopLeft.TabIndex = 3;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackgroundImage = global::KTZipPresentation.Properties.Resources.refresh;
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRefresh.Location = new System.Drawing.Point(75, 0);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(25, 22);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = global::KTZipPresentation.Properties.Resources.left;
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.Location = new System.Drawing.Point(0, 0);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(25, 22);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackgroundImage = global::KTZipPresentation.Properties.Resources.rigth;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNext.Location = new System.Drawing.Point(50, 0);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(25, 22);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.BackgroundImage = global::KTZipPresentation.Properties.Resources.up;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUp.Location = new System.Drawing.Point(25, 0);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(25, 22);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelBottom.Controls.Add(this.filesGrid);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 53);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(795, 527);
            this.panelBottom.TabIndex = 7;
            // 
            // filesGrid
            // 
            this.filesGrid.AllowUserToAddRows = false;
            this.filesGrid.AllowUserToResizeRows = false;
            this.filesGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.filesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.filesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ico,
            this.Nazwa,
            this.Rozmiar,
            this.Modyfikowano,
            this.Utworzono});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filesGrid.DefaultCellStyle = dataGridViewCellStyle12;
            this.filesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesGrid.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.filesGrid.Location = new System.Drawing.Point(0, 0);
            this.filesGrid.Name = "filesGrid";
            this.filesGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.filesGrid.RowHeadersVisible = false;
            this.filesGrid.RowHeadersWidth = 12;
            this.filesGrid.RowTemplate.Height = 24;
            this.filesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filesGrid.Size = new System.Drawing.Size(795, 527);
            this.filesGrid.TabIndex = 0;
            this.filesGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.filesGrid_CellMouseClick);
            this.filesGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.filesGrid_CellMouseDoubleClick);
            this.filesGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filesGrid_KeyDown);
            this.filesGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filesGrid_MouseClick);
            // 
            // Ico
            // 
            this.Ico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Ico.Frozen = true;
            this.Ico.HeaderText = "";
            this.Ico.Name = "Ico";
            this.Ico.ReadOnly = true;
            this.Ico.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Ico.Width = 17;
            // 
            // Nazwa
            // 
            this.Nazwa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nazwa.Frozen = true;
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.MinimumWidth = 100;
            this.Nazwa.Name = "Nazwa";
            this.Nazwa.ReadOnly = true;
            this.Nazwa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Rozmiar
            // 
            this.Rozmiar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Rozmiar.DefaultCellStyle = dataGridViewCellStyle9;
            this.Rozmiar.HeaderText = "Rozmiar";
            this.Rozmiar.MinimumWidth = 80;
            this.Rozmiar.Name = "Rozmiar";
            this.Rozmiar.ReadOnly = true;
            this.Rozmiar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rozmiar.Width = 89;
            // 
            // Modyfikowano
            // 
            this.Modyfikowano.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Modyfikowano.DefaultCellStyle = dataGridViewCellStyle10;
            this.Modyfikowano.HeaderText = "Modyfikowano";
            this.Modyfikowano.MinimumWidth = 80;
            this.Modyfikowano.Name = "Modyfikowano";
            this.Modyfikowano.ReadOnly = true;
            this.Modyfikowano.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Modyfikowano.Width = 126;
            // 
            // Utworzono
            // 
            this.Utworzono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Utworzono.DefaultCellStyle = dataGridViewCellStyle11;
            this.Utworzono.HeaderText = "Utworzono";
            this.Utworzono.MinimumWidth = 80;
            this.Utworzono.Name = "Utworzono";
            this.Utworzono.ReadOnly = true;
            this.Utworzono.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Utworzono.Width = 104;
            // 
            // filesGrid_contextMenu
            // 
            this.filesGrid_contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.filesGrid_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextCreate,
            this.toolStripMenuItem4,
            this.contextCut,
            this.contextCopy,
            this.contextPaste,
            this.toolStripMenuItem3,
            this.contextRename,
            this.contextDelete,
            this.toolStripMenuItem5,
            this.contextProperties});
            this.filesGrid_contextMenu.Name = "filesGrid_contextMenu";
            this.filesGrid_contextMenu.Size = new System.Drawing.Size(182, 232);
            // 
            // contextCreate
            // 
            this.contextCreate.Name = "contextCreate";
            this.contextCreate.Size = new System.Drawing.Size(181, 26);
            this.contextCreate.Text = "Utwórz...";
            this.contextCreate.Click += new System.EventHandler(this.contextCreate_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(178, 6);
            // 
            // contextCut
            // 
            this.contextCut.Enabled = false;
            this.contextCut.Name = "contextCut";
            this.contextCut.Size = new System.Drawing.Size(181, 26);
            this.contextCut.Text = "Wytnij";
            this.contextCut.Click += new System.EventHandler(this.contextCut_Click);
            // 
            // contextCopy
            // 
            this.contextCopy.Enabled = false;
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.Size = new System.Drawing.Size(181, 26);
            this.contextCopy.Text = "Kopiuj";
            this.contextCopy.Click += new System.EventHandler(this.contextCopy_Click);
            // 
            // contextPaste
            // 
            this.contextPaste.Enabled = false;
            this.contextPaste.Name = "contextPaste";
            this.contextPaste.Size = new System.Drawing.Size(181, 26);
            this.contextPaste.Text = "Wklej";
            this.contextPaste.Click += new System.EventHandler(this.contextPaste_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 6);
            // 
            // contextRename
            // 
            this.contextRename.Name = "contextRename";
            this.contextRename.Size = new System.Drawing.Size(181, 26);
            this.contextRename.Text = "Zmień nazwę...";
            this.contextRename.Click += new System.EventHandler(this.contextRename_Click);
            // 
            // contextDelete
            // 
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Size = new System.Drawing.Size(181, 26);
            this.contextDelete.Text = "Usuń";
            this.contextDelete.Click += new System.EventHandler(this.contextDelete_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(178, 6);
            // 
            // contextProperties
            // 
            this.contextProperties.Enabled = false;
            this.contextProperties.Name = "contextProperties";
            this.contextProperties.Size = new System.Drawing.Size(181, 26);
            this.contextProperties.Text = "Właściwości";
            this.contextProperties.Click += new System.EventHandler(this.contextProperties_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 580);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KTzip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTopLeft.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filesGrid)).EndInit();
            this.filesGrid_contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripOptions;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.ToolStripMenuItem toolStripNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripEnd;
        private System.Windows.Forms.ToolStripMenuItem toolStripSelectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripUnselectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripChangeName;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripFileProperties;
        private System.Windows.Forms.DataGridView filesGrid;
        private System.Windows.Forms.ContextMenuStrip filesGrid_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextCopy;
        private System.Windows.Forms.ToolStripMenuItem contextCut;
        private System.Windows.Forms.ToolStripMenuItem contextPaste;
        private System.Windows.Forms.DataGridViewImageColumn Ico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rozmiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modyfikowano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Utworzono;
        private System.Windows.Forms.ToolStripMenuItem contextDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem contextCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem contextProperties;
        private System.Windows.Forms.ToolStripMenuItem contextRename;
    }
}

