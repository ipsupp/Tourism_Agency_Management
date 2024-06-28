namespace mpp_winforms
{
    partial class _5Server
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
            sendMessageButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            messageBoardTable = new System.Windows.Forms.ListBox();
            onlineFriendsTable = new System.Windows.Forms.ListBox();
            enterMessageBox = new System.Windows.Forms.TextBox();
            logOut2Button = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // sendMessageButton
            // 
            sendMessageButton.Location = new System.Drawing.Point(535, 378);
            sendMessageButton.Name = "sendMessageButton";
            sendMessageButton.Size = new System.Drawing.Size(150, 26);
            sendMessageButton.TabIndex = 0;
            sendMessageButton.Text = "Send Message";
            sendMessageButton.UseVisualStyleBackColor = true;
            sendMessageButton.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(57, 57);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 15);
            label1.TabIndex = 1;
            label1.Text = "Message Board";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(535, 57);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(102, 15);
            label2.TabIndex = 2;
            label2.Text = "Online Employees";
            // 
            // messageBoardTable
            // 
            messageBoardTable.FormattingEnabled = true;
            messageBoardTable.ItemHeight = 15;
            messageBoardTable.Location = new System.Drawing.Point(57, 87);
            messageBoardTable.Name = "messageBoardTable";
            messageBoardTable.Size = new System.Drawing.Size(439, 244);
            messageBoardTable.TabIndex = 3;
            messageBoardTable.SelectedIndexChanged += messageBoardTable_SelectedIndexChanged;
            // 
            // onlineFriendsTable
            // 
            onlineFriendsTable.FormattingEnabled = true;
            onlineFriendsTable.ItemHeight = 15;
            onlineFriendsTable.Location = new System.Drawing.Point(535, 87);
            onlineFriendsTable.Name = "onlineFriendsTable";
            onlineFriendsTable.Size = new System.Drawing.Size(150, 244);
            onlineFriendsTable.TabIndex = 4;
            onlineFriendsTable.SelectedIndexChanged += onlineFriendsTable_SelectedIndexChanged;
            // 
            // enterMessageBox
            // 
            enterMessageBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            enterMessageBox.Location = new System.Drawing.Point(57, 378);
            enterMessageBox.Name = "enterMessageBox";
            enterMessageBox.Size = new System.Drawing.Size(450, 25);
            enterMessageBox.TabIndex = 5;
            enterMessageBox.Text = "Enter Message...";
            enterMessageBox.TextChanged += enterMessageBox_TextChanged;
            // 
            // logOut2Button
            // 
            logOut2Button.Location = new System.Drawing.Point(535, 464);
            logOut2Button.Name = "logOut2Button";
            logOut2Button.Size = new System.Drawing.Size(150, 26);
            logOut2Button.TabIndex = 6;
            logOut2Button.Text = "Log Out";
            logOut2Button.UseVisualStyleBackColor = true;
            logOut2Button.Click += logOut2Button_Click;
            // 
            // _5Server
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(741, 572);
            Controls.Add(logOut2Button);
            Controls.Add(enterMessageBox);
            Controls.Add(onlineFriendsTable);
            Controls.Add(messageBoardTable);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(sendMessageButton);
            Name = "_5Server";
            Text = "_5Server";
            FormClosing += _5Server_FormClosing;
            Load += _5Server_Load;
            Click += _5Server_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox messageBoardTable;
        private System.Windows.Forms.ListBox onlineFriendsTable;
        private System.Windows.Forms.TextBox enterMessageBox;
        private System.Windows.Forms.Button logOut2Button;
    }
}