namespace mpp_winforms
{
    partial class Form4
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
            attempt_rez = new System.Windows.Forms.Button();
            labelTripId = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            idTripBox = new System.Windows.Forms.TextBox();
            nameBox = new System.Windows.Forms.TextBox();
            ntickBox = new System.Windows.Forms.TextBox();
            pnBox = new System.Windows.Forms.TextBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // attempt_rez
            // 
            attempt_rez.Location = new System.Drawing.Point(191, 171);
            attempt_rez.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            attempt_rez.Name = "attempt_rez";
            attempt_rez.Size = new System.Drawing.Size(114, 24);
            attempt_rez.TabIndex = 0;
            attempt_rez.Text = "Book tickets";
            attempt_rez.UseVisualStyleBackColor = true;
            attempt_rez.Click += attempt_rez_Click;
            // 
            // labelTripId
            // 
            labelTripId.AutoSize = true;
            labelTripId.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelTripId.Location = new System.Drawing.Point(51, 21);
            labelTripId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelTripId.Name = "labelTripId";
            labelTripId.Size = new System.Drawing.Size(37, 20);
            labelTripId.TabIndex = 1;
            labelTripId.Text = "Trip Id";
            labelTripId.Click += labelTripId_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Agency FB", 12F);
            label2.Location = new System.Drawing.Point(51, 57);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 20);
            label2.TabIndex = 2;
            label2.Text = "Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Agency FB", 12F);
            label3.Location = new System.Drawing.Point(51, 92);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 20);
            label3.TabIndex = 3;
            label3.Text = "Phone Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Agency FB", 12F);
            label4.Location = new System.Drawing.Point(51, 128);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 20);
            label4.TabIndex = 4;
            label4.Text = "No. Tickets";
            // 
            // idTripBox
            // 
            idTripBox.Location = new System.Drawing.Point(191, 22);
            idTripBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            idTripBox.Name = "idTripBox";
            idTripBox.Size = new System.Drawing.Size(114, 23);
            idTripBox.TabIndex = 5;
            // 
            // nameBox
            // 
            nameBox.Location = new System.Drawing.Point(191, 57);
            nameBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            nameBox.Name = "nameBox";
            nameBox.Size = new System.Drawing.Size(114, 23);
            nameBox.TabIndex = 6;
            // 
            // ntickBox
            // 
            ntickBox.Location = new System.Drawing.Point(191, 128);
            ntickBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            ntickBox.Name = "ntickBox";
            ntickBox.Size = new System.Drawing.Size(114, 23);
            ntickBox.TabIndex = 8;
            // 
            // pnBox
            // 
            pnBox.Location = new System.Drawing.Point(191, 94);
            pnBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            pnBox.Name = "pnBox";
            pnBox.Size = new System.Drawing.Size(114, 23);
            pnBox.TabIndex = 7;
            pnBox.TextChanged += textBox4_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(37, 219);
            dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.Size = new System.Drawing.Size(541, 163);
            dataGridView1.TabIndex = 9;
            dataGridView1.Visible = false;
            // 
            // Form4
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(622, 437);
            Controls.Add(dataGridView1);
            Controls.Add(pnBox);
            Controls.Add(ntickBox);
            Controls.Add(nameBox);
            Controls.Add(idTripBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelTripId);
            Controls.Add(attempt_rez);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "Form4";
            Text = "Reservation";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button attempt_rez;
        private System.Windows.Forms.Label labelTripId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox idTripBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox ntickBox;
        private System.Windows.Forms.TextBox pnBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}