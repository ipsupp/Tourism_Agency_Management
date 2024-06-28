namespace mpp_winforms
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new System.Windows.Forms.Label();
            mppDataSet = new mppDataSet();
            tripBindingSource = new System.Windows.Forms.BindingSource(components);
            tripTableAdapter = new mppDataSetTableAdapters.TripTableAdapter();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            button1 = new System.Windows.Forms.Button();
            make_rez = new System.Windows.Forms.Button();
            logout_button = new System.Windows.Forms.Button();
            serverButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)mppDataSet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tripBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            label1.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(12, 32);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 24);
            label1.TabIndex = 0;
            label1.Text = "Trips";
            // 
            // mppDataSet
            // 
            mppDataSet.DataSetName = "mppDataSet";
            mppDataSet.Namespace = "http://tempuri.org/mppDataSet.xsd";
            mppDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tripBindingSource
            // 
            tripBindingSource.DataMember = "Trip";
            tripBindingSource.DataSource = mppDataSet;
            // 
            // tripTableAdapter
            // 
            tripTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 74);
            dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 30;
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.Size = new System.Drawing.Size(887, 212);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            button1.Location = new System.Drawing.Point(154, 306);
            button1.Margin = new System.Windows.Forms.Padding(2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(261, 36);
            button1.TabIndex = 2;
            button1.Text = "Search by location and departure time";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // make_rez
            // 
            make_rez.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            make_rez.Location = new System.Drawing.Point(496, 306);
            make_rez.Margin = new System.Windows.Forms.Padding(2);
            make_rez.Name = "make_rez";
            make_rez.Size = new System.Drawing.Size(269, 36);
            make_rez.TabIndex = 3;
            make_rez.Text = "Make reservation";
            make_rez.UseVisualStyleBackColor = false;
            make_rez.Click += make_rez_Click;
            // 
            // logout_button
            // 
            logout_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            logout_button.Location = new System.Drawing.Point(496, 379);
            logout_button.Margin = new System.Windows.Forms.Padding(2);
            logout_button.Name = "logout_button";
            logout_button.Size = new System.Drawing.Size(269, 36);
            logout_button.TabIndex = 4;
            logout_button.Text = "Log Out";
            logout_button.UseVisualStyleBackColor = false;
            logout_button.Click += logout_button_Click;
            // 
            // serverButton
            // 
            serverButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            serverButton.Location = new System.Drawing.Point(154, 379);
            serverButton.Name = "serverButton";
            serverButton.Size = new System.Drawing.Size(261, 36);
            serverButton.TabIndex = 5;
            serverButton.Text = "Server";
            serverButton.UseVisualStyleBackColor = false;
            serverButton.Click += serverButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(916, 454);
            Controls.Add(serverButton);
            Controls.Add(logout_button);
            Controls.Add(make_rez);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Form2";
            Text = "Menu";
            Load += Form2_Load;
            Click += Form2_Click;
            MouseDown += Form2_MouseDown;
            ((System.ComponentModel.ISupportInitialize)mppDataSet).EndInit();
            ((System.ComponentModel.ISupportInitialize)tripBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private mppDataSet mppDataSet;
        private System.Windows.Forms.BindingSource tripBindingSource;
        private mppDataSetTableAdapters.TripTableAdapter tripTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button make_rez;
        private System.Windows.Forms.Button logout_button;
        private System.Windows.Forms.Button serverButton;
    }
}