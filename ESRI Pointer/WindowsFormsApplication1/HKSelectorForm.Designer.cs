namespace ESRIPPTPointer
{
    partial class Hotkey_selector_form
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
            this.primary_key_label = new System.Windows.Forms.Label();
            this.secondary_key_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ok_button = new System.Windows.Forms.Button();
            this.primary_set = new System.Windows.Forms.Button();
            this.secondary_set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // primary_key_label
            // 
            this.primary_key_label.AutoSize = true;
            this.primary_key_label.Location = new System.Drawing.Point(12, 67);
            this.primary_key_label.Name = "primary_key_label";
            this.primary_key_label.Size = new System.Drawing.Size(65, 13);
            this.primary_key_label.TabIndex = 0;
            this.primary_key_label.Text = "Primary Key:";
            // 
            // secondary_key_label
            // 
            this.secondary_key_label.AutoSize = true;
            this.secondary_key_label.Location = new System.Drawing.Point(12, 105);
            this.secondary_key_label.Name = "secondary_key_label";
            this.secondary_key_label.Size = new System.Drawing.Size(82, 13);
            this.secondary_key_label.TabIndex = 1;
            this.secondary_key_label.Text = "Secondary Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "To customize your key settings, select \r\nfrom the list and press ok.";
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(196, 148);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(76, 23);
            this.ok_button.TabIndex = 5;
            this.ok_button.Text = "Ok";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // primary_set
            // 
            this.primary_set.Location = new System.Drawing.Point(98, 62);
            this.primary_set.Name = "primary_set";
            this.primary_set.Size = new System.Drawing.Size(103, 23);
            this.primary_set.TabIndex = 6;
            this.primary_set.Text = "Click to set";
            this.primary_set.UseVisualStyleBackColor = true;
            this.primary_set.Click += new System.EventHandler(this.primary_set_Click);
            // 
            // secondary_set
            // 
            this.secondary_set.Location = new System.Drawing.Point(98, 100);
            this.secondary_set.Name = "secondary_set";
            this.secondary_set.Size = new System.Drawing.Size(103, 23);
            this.secondary_set.TabIndex = 7;
            this.secondary_set.Text = "Click to set";
            this.secondary_set.UseVisualStyleBackColor = true;
            this.secondary_set.Click += new System.EventHandler(this.secondary_set_Click);
            // 
            // Hotkey_selector_form
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 194);
            this.Controls.Add(this.secondary_set);
            this.Controls.Add(this.primary_set);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondary_key_label);
            this.Controls.Add(this.primary_key_label);
            this.Name = "Hotkey_selector_form";
            this.Text = "Hotkey Selector";
            this.Load += new System.EventHandler(this.Hotkey_selector_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label primary_key_label;
        private System.Windows.Forms.Label secondary_key_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button primary_set;
        private System.Windows.Forms.Button secondary_set;
    }
}