namespace LicensePlatePOCClient
{
    partial class Form1
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
            this.btnGetProcessedPlates = new System.Windows.Forms.Button();
            this.lvProcessedTags = new System.Windows.Forms.ListView();
            this.PlateText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetProcessedPlates
            // 
            this.btnGetProcessedPlates.Location = new System.Drawing.Point(557, 721);
            this.btnGetProcessedPlates.Name = "btnGetProcessedPlates";
            this.btnGetProcessedPlates.Size = new System.Drawing.Size(123, 39);
            this.btnGetProcessedPlates.TabIndex = 0;
            this.btnGetProcessedPlates.Text = "Get Processed Plates";
            this.btnGetProcessedPlates.UseVisualStyleBackColor = true;
            this.btnGetProcessedPlates.Click += new System.EventHandler(this.btnGetProcessedPlates_Click);
            // 
            // lvProcessedTags
            // 
            this.lvProcessedTags.AllowColumnReorder = true;
            this.lvProcessedTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvProcessedTags.CheckBoxes = true;
            this.lvProcessedTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PlateText,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvProcessedTags.FullRowSelect = true;
            this.lvProcessedTags.GridLines = true;
            this.lvProcessedTags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProcessedTags.Location = new System.Drawing.Point(12, 12);
            this.lvProcessedTags.MultiSelect = false;
            this.lvProcessedTags.Name = "lvProcessedTags";
            this.lvProcessedTags.Size = new System.Drawing.Size(668, 703);
            this.lvProcessedTags.TabIndex = 1;
            this.lvProcessedTags.UseCompatibleStateImageBehavior = false;
            this.lvProcessedTags.View = System.Windows.Forms.View.Details;
            this.lvProcessedTags.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvProcessedTags_ItemCheck);
            this.lvProcessedTags.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvProcessedTags_ItemSelectionChanged);
            // 
            // PlateText
            // 
            this.PlateText.Text = "Plate Text";
            this.PlateText.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "State";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bobdy Type";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Color";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Make";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Make Model";
            this.columnHeader6.Width = 150;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(686, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(918, 758);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1616, 782);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lvProcessedTags);
            this.Controls.Add(this.btnGetProcessedPlates);
            this.Name = "Form1";
            this.Text = "License Plate POC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetProcessedPlates;
        private System.Windows.Forms.ListView lvProcessedTags;
        private System.Windows.Forms.ColumnHeader PlateText;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

