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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.endToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.changeNameToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.inneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(697, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStrip,
            this.createFolderToolStrip,
            this.toolStripMenuItem1,
            this.endToolStrip,
            this.copyToolStrip,
            this.cutToolStrip});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // editToolStrip
            // 
            this.editToolStrip.Name = "editToolStrip";
            this.editToolStrip.Size = new System.Drawing.Size(181, 26);
            this.editToolStrip.Text = "Edycja";
            this.editToolStrip.Click += new System.EventHandler(this.editToolStrip_Click);
            // 
            // createFolderToolStrip
            // 
            this.createFolderToolStrip.Name = "createFolderToolStrip";
            this.createFolderToolStrip.Size = new System.Drawing.Size(181, 26);
            this.createFolderToolStrip.Text = "Utwórz folder";
            this.createFolderToolStrip.Click += new System.EventHandler(this.createFolderToolStrip_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // endToolStrip
            // 
            this.endToolStrip.Name = "endToolStrip";
            this.endToolStrip.Size = new System.Drawing.Size(181, 26);
            this.endToolStrip.Text = "Zakończ";
            this.endToolStrip.Click += new System.EventHandler(this.endToolStrip_Click);
            // 
            // copyToolStrip
            // 
            this.copyToolStrip.Name = "copyToolStrip";
            this.copyToolStrip.Size = new System.Drawing.Size(181, 26);
            this.copyToolStrip.Text = "Kopiuj...";
            this.copyToolStrip.Click += new System.EventHandler(this.copyToolStrip_Click);
            // 
            // cutToolStrip
            // 
            this.cutToolStrip.Name = "cutToolStrip";
            this.cutToolStrip.Size = new System.Drawing.Size(181, 26);
            this.cutToolStrip.Text = "Wytnij...";
            this.cutToolStrip.Click += new System.EventHandler(this.cutToolStrip_Click);
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStrip,
            this.unselectAllToolStrip,
            this.toolStripMenuItem2,
            this.changeNameToolStrip,
            this.deleteToolStrip,
            this.propertiesToolStrip});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            // 
            // selectAllToolStrip
            // 
            this.selectAllToolStrip.Name = "selectAllToolStrip";
            this.selectAllToolStrip.Size = new System.Drawing.Size(203, 26);
            this.selectAllToolStrip.Text = "Zaznacz wszystko";
            this.selectAllToolStrip.Click += new System.EventHandler(this.selectAllToolStrip_Click);
            // 
            // unselectAllToolStrip
            // 
            this.unselectAllToolStrip.Name = "unselectAllToolStrip";
            this.unselectAllToolStrip.Size = new System.Drawing.Size(203, 26);
            this.unselectAllToolStrip.Text = "Odznacz wszystko";
            this.unselectAllToolStrip.Click += new System.EventHandler(this.unselectAllToolStrip_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // changeNameToolStrip
            // 
            this.changeNameToolStrip.Name = "changeNameToolStrip";
            this.changeNameToolStrip.Size = new System.Drawing.Size(203, 26);
            this.changeNameToolStrip.Text = "Zmień nazwę";
            this.changeNameToolStrip.Click += new System.EventHandler(this.changeNameToolStrip_Click);
            // 
            // deleteToolStrip
            // 
            this.deleteToolStrip.Name = "deleteToolStrip";
            this.deleteToolStrip.Size = new System.Drawing.Size(203, 26);
            this.deleteToolStrip.Text = "Usuń";
            this.deleteToolStrip.Click += new System.EventHandler(this.deleteToolStrip_Click);
            // 
            // propertiesToolStrip
            // 
            this.propertiesToolStrip.Name = "propertiesToolStrip";
            this.propertiesToolStrip.Size = new System.Drawing.Size(203, 26);
            this.propertiesToolStrip.Text = "Właściwości";
            this.propertiesToolStrip.Click += new System.EventHandler(this.propertiesToolStrip_Click);
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adsToolStrip});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // adsToolStrip
            // 
            this.adsToolStrip.Name = "adsToolStrip";
            this.adsToolStrip.Size = new System.Drawing.Size(244, 26);
            this.adsToolStrip.Text = "Strumienie alternatywne";
            this.adsToolStrip.Click += new System.EventHandler(this.adsToolStrip_Click);
            // 
            // inneToolStripMenuItem
            // 
            this.inneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStrip});
            this.inneToolStripMenuItem.Name = "inneToolStripMenuItem";
            this.inneToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.inneToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.inneToolStripMenuItem.Text = "Inne";
            // 
            // optionsToolStrip
            // 
            this.optionsToolStrip.Name = "optionsToolStrip";
            this.optionsToolStrip.Size = new System.Drawing.Size(181, 26);
            this.optionsToolStrip.Text = "Opcje";
            this.optionsToolStrip.Click += new System.EventHandler(this.optionsToolStrip_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(697, 369);
            this.treeView1.TabIndex = 1;
            // 
            // textBox_Path
            // 
            this.textBox_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Path.Location = new System.Drawing.Point(77, 0);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(620, 22);
            this.textBox_Path.TabIndex = 2;
            this.textBox_Path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Path_KeyDown);
            // 
            // buttonBack
            // 
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
            this.buttonNext.Enabled = false;
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
            this.panelTop.Size = new System.Drawing.Size(697, 25);
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
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(697, 422);
            this.panelBottom.TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 422);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelBottom);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KTzip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTopLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStrip;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem endToolStrip;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStrip;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem changeNameToolStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStrip;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStrip;
        private System.Windows.Forms.ToolStripMenuItem adsToolStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStrip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStrip;
    }
}

