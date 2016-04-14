using System.Windows.Forms;
namespace ESRIPPTPointer
{
    partial class ESRIPPTForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ESRIPPTForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.instructions = new System.Windows.Forms.Label();
            this.cust_key_but = new System.Windows.Forms.Button();
            this.cust_icon = new System.Windows.Forms.Button();
            this.curr_key_label = new System.Windows.Forms.Label();
            this.primary_label = new System.Windows.Forms.Label();
            this.second_label = new System.Windows.Forms.Label();
            this.second_txt = new System.Windows.Forms.Label();
            this.primary_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Application has been minimized to tray!\r\nRight click this icon to exit this progr" +
    "am\r\nor double click to show window.";
            this.notifyIcon1.BalloonTipTitle = "Notification";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.Location = new System.Drawing.Point(12, 21);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(264, 104);
            this.instructions.TabIndex = 0;
            this.instructions.Text = resources.GetString("instructions.Text");
            // 
            // cust_key_but
            // 
            this.cust_key_but.Location = new System.Drawing.Point(16, 144);
            this.cust_key_but.Name = "cust_key_but";
            this.cust_key_but.Size = new System.Drawing.Size(97, 23);
            this.cust_key_but.TabIndex = 1;
            this.cust_key_but.Text = "Customize Keys";
            this.cust_key_but.UseVisualStyleBackColor = true;
            this.cust_key_but.Click += new System.EventHandler(this.cust_key_but_Click);
            // 
            // cust_icon
            // 
            this.cust_icon.Location = new System.Drawing.Point(143, 144);
            this.cust_icon.Name = "cust_icon";
            this.cust_icon.Size = new System.Drawing.Size(97, 23);
            this.cust_icon.TabIndex = 2;
            this.cust_icon.Text = "Customize Cursor";
            this.cust_icon.UseVisualStyleBackColor = true;
            this.cust_icon.Click += new System.EventHandler(this.cust_icon_Click);
            // 
            // curr_key_label
            // 
            this.curr_key_label.AutoSize = true;
            this.curr_key_label.Location = new System.Drawing.Point(16, 183);
            this.curr_key_label.Name = "curr_key_label";
            this.curr_key_label.Size = new System.Drawing.Size(126, 13);
            this.curr_key_label.TabIndex = 3;
            this.curr_key_label.Text = "Current Key Combination:";
            // 
            // primary_label
            // 
            this.primary_label.AutoSize = true;
            this.primary_label.Location = new System.Drawing.Point(16, 209);
            this.primary_label.Name = "primary_label";
            this.primary_label.Size = new System.Drawing.Size(65, 13);
            this.primary_label.TabIndex = 4;
            this.primary_label.Text = "Primary Key:";
            // 
            // second_label
            // 
            this.second_label.AutoSize = true;
            this.second_label.Location = new System.Drawing.Point(16, 235);
            this.second_label.Name = "second_label";
            this.second_label.Size = new System.Drawing.Size(82, 13);
            this.second_label.TabIndex = 5;
            this.second_label.Text = "Secondary Key:";
            // 
            // second_txt
            // 
            this.second_txt.AutoSize = true;
            this.second_txt.Location = new System.Drawing.Point(104, 235);
            this.second_txt.Name = "second_txt";
            this.second_txt.Size = new System.Drawing.Size(0, 13);
            this.second_txt.TabIndex = 6;
            // 
            // primary_txt
            // 
            this.primary_txt.AutoSize = true;
            this.primary_txt.Location = new System.Drawing.Point(84, 209);
            this.primary_txt.Name = "primary_txt";
            this.primary_txt.Size = new System.Drawing.Size(0, 13);
            this.primary_txt.TabIndex = 7;
            // 
            // ESRIPPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 278);
            this.Controls.Add(this.primary_txt);
            this.Controls.Add(this.second_txt);
            this.Controls.Add(this.second_label);
            this.Controls.Add(this.primary_label);
            this.Controls.Add(this.curr_key_label);
            this.Controls.Add(this.cust_icon);
            this.Controls.Add(this.cust_key_but);
            this.Controls.Add(this.instructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ESRIPPTForm";
            this.Text = "ESRI Virtual Pointer V 1.10";
            this.Resize += new System.EventHandler(this.ESRIPPTForm_Resize);
            this.MaximizeBox = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private Label instructions;
        private Button cust_key_but;
        private Button cust_icon;
        private Label curr_key_label;
        private Label primary_label;
        private Label second_label;
        private Label second_txt;
        private Label primary_txt;
    }
}

