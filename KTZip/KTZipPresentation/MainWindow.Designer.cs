namespace KTZipPresentation.View
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripChangeName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFileProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTurnAds = new System.Windows.Forms.ToolStripMenuItem();
            this.inneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.filesGrid = new System.Windows.Forms.DataGridView();
            this.Ico = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rozmiar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modyfikowano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utworzono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filesGrid_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextPaste = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Size = new System.Drawing.Size(689, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEdit,
            this.toolStripNewFolder,
            this.toolStripMenuItem1,
            this.toolStripEnd});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // toolStripEdit
            // 
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.Size = new System.Drawing.Size(175, 26);
            this.toolStripEdit.Text = "Edycja";
            this.toolStripEdit.Click += new System.EventHandler(this.toolStripEdit_Click);
            // 
            // toolStripNewFolder
            // 
            this.toolStripNewFolder.Name = "toolStripNewFolder";
            this.toolStripNewFolder.Size = new System.Drawing.Size(175, 26);
            this.toolStripNewFolder.Text = "Utwórz folder";
            this.toolStripNewFolder.Click += new System.EventHandler(this.toolStripNewFolder_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // toolStripEnd
            // 
            this.toolStripEnd.Name = "toolStripEnd";
            this.toolStripEnd.Size = new System.Drawing.Size(175, 26);
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
            this.toolStripChangeName.Text = "Zmień nazwę";
            this.toolStripChangeName.Click += new System.EventHandler(this.toolStripChangeName_Click);
            // 
            // toolStripDeleteFile
            // 
            this.toolStripDeleteFile.Name = "toolStripDeleteFile";
            this.toolStripDeleteFile.Size = new System.Drawing.Size(203, 26);
            this.toolStripDeleteFile.Text = "Usuń";
            this.toolStripDeleteFile.Click += new System.EventHandler(this.toolStripDeleteFile_Click);
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
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTurnAds});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // toolStripTurnAds
            // 
            this.toolStripTurnAds.Name = "toolStripTurnAds";
            this.toolStripTurnAds.Size = new System.Drawing.Size(244, 26);
            this.toolStripTurnAds.Text = "Strumienie alternatywne";
            this.toolStripTurnAds.Click += new System.EventHandler(this.toolStripTurnAds_Click);
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
            this.textBox_Path.Location = new System.Drawing.Point(77, 0);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(612, 22);
            this.textBox_Path.TabIndex = 2;
            this.textBox_Path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Path_KeyDown);
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
            // panelTop
            // 
            this.panelTop.Controls.Add(this.textBox_Path);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 28);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(689, 25);
            this.panelTop.TabIndex = 6;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.Controls.Add(this.buttonBack);
            this.panelTopLeft.Controls.Add(this.buttonNext);
            this.panelTopLeft.Controls.Add(this.buttonUp);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(77, 25);
            this.panelTopLeft.TabIndex = 3;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.filesGrid);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 53);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(689, 410);
            this.panelBottom.TabIndex = 7;
            // 
            // filesGrid
            // 
            this.filesGrid.AllowUserToAddRows = false;
            this.filesGrid.AllowUserToResizeRows = false;
            this.filesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.filesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ico,
            this.Nazwa,
            this.Rozmiar,
            this.Modyfikowano,
            this.Utworzono});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filesGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.filesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesGrid.Location = new System.Drawing.Point(0, 0);
            this.filesGrid.Name = "filesGrid";
            this.filesGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.filesGrid.RowHeadersVisible = false;
            this.filesGrid.RowHeadersWidth = 12;
            this.filesGrid.RowTemplate.Height = 24;
            this.filesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filesGrid.Size = new System.Drawing.Size(689, 410);
            this.filesGrid.TabIndex = 0;
            this.filesGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.filesGrid_CellMouseClick);
            this.filesGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.filesGrid_CellMouseDoubleClick);
            this.filesGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.filesGrid_ColumnWidthChanged);
            // 
            // Ico
            // 
            this.Ico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Ico.Frozen = true;
            this.Ico.HeaderText = "";
            this.Ico.Name = "Ico";
            this.Ico.ReadOnly = true;
            this.Ico.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Ico.Width = 20;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Rozmiar.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Modyfikowano.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Utworzono.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.contextCopy,
            this.contextCut,
            this.contextPaste});
            this.filesGrid_contextMenu.Name = "filesGrid_contextMenu";
            this.filesGrid_contextMenu.Size = new System.Drawing.Size(128, 82);
            // 
            // contextCopy
            // 
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.Size = new System.Drawing.Size(127, 26);
            this.contextCopy.Text = "Kopiuj";
            // 
            // contextCut
            // 
            this.contextCut.Name = "contextCut";
            this.contextCut.Size = new System.Drawing.Size(127, 26);
            this.contextCut.Text = "Wytnij";
            // 
            // contextPaste
            // 
            this.contextPaste.Name = "contextPaste";
            this.contextPaste.Size = new System.Drawing.Size(127, 26);
            this.contextPaste.Text = "Wklej";
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 463);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripTurnAds;
        private System.Windows.Forms.ToolStripMenuItem toolStripEdit;
        private System.Windows.Forms.DataGridView filesGrid;
        private System.Windows.Forms.DataGridViewImageColumn Ico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rozmiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modyfikowano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Utworzono;
        private System.Windows.Forms.ContextMenuStrip filesGrid_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextCopy;
        private System.Windows.Forms.ToolStripMenuItem contextCut;
        private System.Windows.Forms.ToolStripMenuItem contextPaste;
    }
}

