namespace mpp_winforms
{
    partial class Form3
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            locationBox = new System.Windows.Forms.TextBox();
            tstartBox = new System.Windows.Forms.TextBox();
            tendBox = new System.Windows.Forms.TextBox();
            dataSearchLDT = new System.Windows.Forms.DataGridView();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataSearchLDT).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(48, 62);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 20);
            label1.TabIndex = 3;
            label1.Text = "Location";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(48, 107);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(102, 20);
            label2.TabIndex = 4;
            label2.Text = "Departure Time Start";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(48, 152);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(95, 20);
            label3.TabIndex = 5;
            label3.Text = "Departure Time End";
            // 
            // locationBox
            // 
            locationBox.Location = new System.Drawing.Point(185, 62);
            locationBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            locationBox.Name = "locationBox";
            locationBox.Size = new System.Drawing.Size(128, 23);
            locationBox.TabIndex = 6;
            locationBox.TextChanged += textBox1_TextChanged;
            // 
            // tstartBox
            // 
            tstartBox.Location = new System.Drawing.Point(185, 107);
            tstartBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            tstartBox.Name = "tstartBox";
            tstartBox.Size = new System.Drawing.Size(128, 23);
            tstartBox.TabIndex = 7;
            // 
            // tendBox
            // 
            tendBox.Location = new System.Drawing.Point(185, 155);
            tendBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            tendBox.Name = "tendBox";
            tendBox.Size = new System.Drawing.Size(128, 23);
            tendBox.TabIndex = 8;
            // 
            // dataSearchLDT
            // 
            dataSearchLDT.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataSearchLDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSearchLDT.Location = new System.Drawing.Point(24, 246);
            dataSearchLDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            dataSearchLDT.Name = "dataSearchLDT";
            dataSearchLDT.RowHeadersWidth = 62;
            dataSearchLDT.RowTemplate.Height = 28;
            dataSearchLDT.Size = new System.Drawing.Size(602, 113);
            dataSearchLDT.TabIndex = 9;
            dataSearchLDT.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(199, 199);
            button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(98, 25);
            button1.TabIndex = 10;
            button1.Text = "Search >>";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(652, 416);
            Controls.Add(button1);
            Controls.Add(dataSearchLDT);
            Controls.Add(tendBox);
            Controls.Add(tstartBox);
            Controls.Add(locationBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "Form3";
            Text = "Search";
            ((System.ComponentModel.ISupportInitialize)dataSearchLDT).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.TextBox tstartBox;
        private System.Windows.Forms.TextBox tendBox;
        private System.Windows.Forms.DataGridView dataSearchLDT;
        private System.Windows.Forms.Button button1;
    }
}