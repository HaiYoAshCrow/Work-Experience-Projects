namespace USB_ISS_Data_Analyzer
{
    partial class Analyzer_UI
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
            this.console = new System.Windows.Forms.RichTextBox();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.sensitivity_changer = new System.Windows.Forms.TrackBar();
            this.threshadj_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivity_changer)).BeginInit();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(34, 27);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(335, 181);
            this.console.TabIndex = 0;
            this.console.Text = "";
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.timer_tick);
            // 
            // sensitivity_changer
            // 
            this.sensitivity_changer.Location = new System.Drawing.Point(34, 227);
            this.sensitivity_changer.Name = "sensitivity_changer";
            this.sensitivity_changer.Size = new System.Drawing.Size(335, 45);
            this.sensitivity_changer.TabIndex = 1;
            this.sensitivity_changer.Scroll += new System.EventHandler(this.sensitivity_changer_Scroll);
            // 
            // threshadj_label
            // 
            this.threshadj_label.AutoSize = true;
            this.threshadj_label.Location = new System.Drawing.Point(43, 211);
            this.threshadj_label.Name = "threshadj_label";
            this.threshadj_label.Size = new System.Drawing.Size(111, 13);
            this.threshadj_label.TabIndex = 2;
            this.threshadj_label.Text = "Adjust Step Threshold";
            // 
            // Analyzer_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 284);
            this.Controls.Add(this.threshadj_label);
            this.Controls.Add(this.sensitivity_changer);
            this.Controls.Add(this.console);
            this.Name = "Analyzer_UI";
            this.Text = "USB ISS Data Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sensitivity_changer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.TrackBar sensitivity_changer;
        private System.Windows.Forms.Label threshadj_label;
    }
}

