
namespace findObject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewAllData = new System.Windows.Forms.DataGridView();
            this.dataGridViewSelectedData = new System.Windows.Forms.DataGridView();
            this.textBoxInputObject = new System.Windows.Forms.RichTextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.comboBoxSelectTime = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxCamID = new System.Windows.Forms.ListBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAllData
            // 
            this.dataGridViewAllData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllData.Location = new System.Drawing.Point(12, 37);
            this.dataGridViewAllData.Name = "dataGridViewAllData";
            this.dataGridViewAllData.RowTemplate.Height = 25;
            this.dataGridViewAllData.Size = new System.Drawing.Size(637, 392);
            this.dataGridViewAllData.TabIndex = 0;
            // 
            // dataGridViewSelectedData
            // 
            this.dataGridViewSelectedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectedData.Location = new System.Drawing.Point(12, 472);
            this.dataGridViewSelectedData.Name = "dataGridViewSelectedData";
            this.dataGridViewSelectedData.RowTemplate.Height = 25;
            this.dataGridViewSelectedData.Size = new System.Drawing.Size(637, 163);
            this.dataGridViewSelectedData.TabIndex = 1;
            // 
            // textBoxInputObject
            // 
            this.textBoxInputObject.Location = new System.Drawing.Point(672, 55);
            this.textBoxInputObject.Name = "textBoxInputObject";
            this.textBoxInputObject.Size = new System.Drawing.Size(290, 73);
            this.textBoxInputObject.TabIndex = 3;
            this.textBoxInputObject.Text = "";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(1139, 105);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(74, 23);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Location = new System.Drawing.Point(672, 134);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(541, 389);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMap.TabIndex = 21;
            this.pictureBoxMap.TabStop = false;
            // 
            // comboBoxSelectTime
            // 
            this.comboBoxSelectTime.FormattingEnabled = true;
            this.comboBoxSelectTime.Location = new System.Drawing.Point(968, 55);
            this.comboBoxSelectTime.Name = "comboBoxSelectTime";
            this.comboBoxSelectTime.Size = new System.Drawing.Size(245, 23);
            this.comboBoxSelectTime.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "AllData";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "SearchData";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Please input object name want to find";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(968, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Select Time";
            // 
            // listBoxCamID
            // 
            this.listBoxCamID.FormattingEnabled = true;
            this.listBoxCamID.ItemHeight = 15;
            this.listBoxCamID.Location = new System.Drawing.Point(672, 541);
            this.listBoxCamID.Name = "listBoxCamID";
            this.listBoxCamID.Size = new System.Drawing.Size(461, 94);
            this.listBoxCamID.TabIndex = 26;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(1139, 612);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(74, 23);
            this.buttonSelect.TabIndex = 27;
            this.buttonSelect.Text = "select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 647);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.listBoxCamID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxMap);
            this.Controls.Add(this.comboBoxSelectTime);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxInputObject);
            this.Controls.Add(this.dataGridViewSelectedData);
            this.Controls.Add(this.dataGridViewAllData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAllData;
        private System.Windows.Forms.DataGridView dataGridViewSelectedData;
        private System.Windows.Forms.RichTextBox textBoxInputObject;
        private System.Windows.Forms.Button buttonSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBoxSelectTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.ListBox listBoxCamID;
        private System.Windows.Forms.Button buttonSelect;
    }
}

