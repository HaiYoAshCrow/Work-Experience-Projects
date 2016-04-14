using System.Windows.Forms;
namespace SerialPortMonitor
{
    partial class logger_form
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
            this.time_set_box_custom = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.custom_page = new System.Windows.Forms.TabPage();
            this.set_time_custom_label = new System.Windows.Forms.Label();
            this.set_time_cust_but = new System.Windows.Forms.Button();
            this.file_save_custom = new System.Windows.Forms.CheckBox();
            this.enable_FCS = new System.Windows.Forms.CheckBox();
            this.custom_callback_checkbox = new System.Windows.Forms.CheckBox();
            this.save_custom = new System.Windows.Forms.Button();
            this.stop_custom = new System.Windows.Forms.Button();
            this.timelog_checkbox_custom = new System.Windows.Forms.CheckBox();
            this.custom_clear_display = new System.Windows.Forms.Button();
            this.send_button_custom = new System.Windows.Forms.Button();
            this.query_input = new System.Windows.Forms.RichTextBox();
            this.custom_log_display = new System.Windows.Forms.RichTextBox();
            this.logger_page = new System.Windows.Forms.TabPage();
            this.set_time_label = new System.Windows.Forms.Label();
            this.time_set_button = new System.Windows.Forms.Button();
            this.time_set_box = new System.Windows.Forms.TextBox();
            this.file_save = new System.Windows.Forms.CheckBox();
            this.callback_check_box_logger = new System.Windows.Forms.CheckBox();
            this.timelog_checkbox_logger = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.remove_logging = new System.Windows.Forms.Button();
            this.add_logging = new System.Windows.Forms.Button();
            this.query_collection = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.query_selector = new System.Windows.Forms.ComboBox();
            this.data_viewer = new System.Windows.Forms.RichTextBox();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.serial_selector = new System.Windows.Forms.ComboBox();
            this.stop_button = new System.Windows.Forms.Button();
            this.capture_button = new System.Windows.Forms.Button();
            this.tab_control = new System.Windows.Forms.TabControl();
            this.custom_page.SuspendLayout();
            this.logger_page.SuspendLayout();
            this.tab_control.SuspendLayout();
            this.SuspendLayout();
            // 
            // time_set_box_custom
            // 
            this.time_set_box_custom.Location = new System.Drawing.Point(312, 395);
            this.time_set_box_custom.Name = "time_set_box_custom";
            this.time_set_box_custom.Size = new System.Drawing.Size(83, 20);
            this.time_set_box_custom.TabIndex = 20;
            this.time_set_box_custom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.check_numeric_keydown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // custom_page
            // 
            this.custom_page.Controls.Add(this.set_time_custom_label);
            this.custom_page.Controls.Add(this.set_time_cust_but);
            this.custom_page.Controls.Add(this.time_set_box_custom);
            this.custom_page.Controls.Add(this.file_save_custom);
            this.custom_page.Controls.Add(this.enable_FCS);
            this.custom_page.Controls.Add(this.custom_callback_checkbox);
            this.custom_page.Controls.Add(this.save_custom);
            this.custom_page.Controls.Add(this.stop_custom);
            this.custom_page.Controls.Add(this.timelog_checkbox_custom);
            this.custom_page.Controls.Add(this.custom_clear_display);
            this.custom_page.Controls.Add(this.send_button_custom);
            this.custom_page.Controls.Add(this.query_input);
            this.custom_page.Controls.Add(this.custom_log_display);
            this.custom_page.Location = new System.Drawing.Point(4, 22);
            this.custom_page.Name = "custom_page";
            this.custom_page.Size = new System.Drawing.Size(800, 427);
            this.custom_page.TabIndex = 0;
            this.custom_page.Text = "Custom";
            this.custom_page.UseVisualStyleBackColor = true;
            // 
            // set_time_custom_label
            // 
            this.set_time_custom_label.AutoSize = true;
            this.set_time_custom_label.Location = new System.Drawing.Point(309, 373);
            this.set_time_custom_label.Name = "set_time_custom_label";
            this.set_time_custom_label.Size = new System.Drawing.Size(67, 13);
            this.set_time_custom_label.TabIndex = 22;
            this.set_time_custom_label.Text = "Set time(ms):";
            // 
            // set_time_cust_but
            // 
            this.set_time_cust_but.Location = new System.Drawing.Point(402, 393);
            this.set_time_cust_but.Name = "set_time_cust_but";
            this.set_time_cust_but.Size = new System.Drawing.Size(75, 23);
            this.set_time_cust_but.TabIndex = 21;
            this.set_time_cust_but.Text = "Set";
            this.set_time_cust_but.UseVisualStyleBackColor = true;
            this.set_time_cust_but.Click += new System.EventHandler(this.set_time_cust_but_Click);
            // 
            // file_save_custom
            // 
            this.file_save_custom.AutoSize = true;
            this.file_save_custom.Location = new System.Drawing.Point(483, 397);
            this.file_save_custom.Name = "file_save_custom";
            this.file_save_custom.Size = new System.Drawing.Size(82, 17);
            this.file_save_custom.TabIndex = 18;
            this.file_save_custom.Text = "Save to File";
            this.file_save_custom.UseVisualStyleBackColor = true;
            this.file_save_custom.Click += new System.EventHandler(this.file_save_custom_CheckedChanged);
            // 
            // enable_FCS
            // 
            this.enable_FCS.AutoSize = true;
            this.enable_FCS.Location = new System.Drawing.Point(483, 374);
            this.enable_FCS.Name = "enable_FCS";
            this.enable_FCS.Size = new System.Drawing.Size(137, 17);
            this.enable_FCS.TabIndex = 17;
            this.enable_FCS.Text = "Enable FCS Calculation";
            this.enable_FCS.UseVisualStyleBackColor = true;
            this.enable_FCS.Click += new System.EventHandler(this.enable_FCS_CheckedChanged);
            // 
            // custom_callback_checkbox
            // 
            this.custom_callback_checkbox.AutoSize = true;
            this.custom_callback_checkbox.Location = new System.Drawing.Point(626, 397);
            this.custom_callback_checkbox.Name = "custom_callback_checkbox";
            this.custom_callback_checkbox.Size = new System.Drawing.Size(103, 17);
            this.custom_callback_checkbox.TabIndex = 16;
            this.custom_callback_checkbox.Text = "Enable Callback";
            this.custom_callback_checkbox.UseVisualStyleBackColor = true;
            this.custom_callback_checkbox.Click += new System.EventHandler(this.custom_callback_checkbox_CheckedChanged);
            // 
            // save_custom
            // 
            this.save_custom.Location = new System.Drawing.Point(116, 391);
            this.save_custom.Name = "save_custom";
            this.save_custom.Size = new System.Drawing.Size(85, 23);
            this.save_custom.TabIndex = 8;
            this.save_custom.Text = "Save Log";
            this.save_custom.UseVisualStyleBackColor = true;
            this.save_custom.Click += new System.EventHandler(this.save_custom_Click);
            // 
            // stop_custom
            // 
            this.stop_custom.Location = new System.Drawing.Point(207, 391);
            this.stop_custom.Name = "stop_custom";
            this.stop_custom.Size = new System.Drawing.Size(85, 23);
            this.stop_custom.TabIndex = 7;
            this.stop_custom.Text = "Stop";
            this.stop_custom.UseVisualStyleBackColor = true;
            this.stop_custom.Click += new System.EventHandler(this.stop_custom_Click);
            // 
            // timelog_checkbox_custom
            // 
            this.timelog_checkbox_custom.AutoSize = true;
            this.timelog_checkbox_custom.Location = new System.Drawing.Point(626, 374);
            this.timelog_checkbox_custom.Name = "timelog_checkbox_custom";
            this.timelog_checkbox_custom.Size = new System.Drawing.Size(132, 17);
            this.timelog_checkbox_custom.TabIndex = 5;
            this.timelog_checkbox_custom.Text = "Enable Timed Logging";
            this.timelog_checkbox_custom.UseVisualStyleBackColor = true;
            this.timelog_checkbox_custom.Click += new System.EventHandler(this.timelog_checkbox_CheckedChanged);
            // 
            // custom_clear_display
            // 
            this.custom_clear_display.Location = new System.Drawing.Point(22, 391);
            this.custom_clear_display.Name = "custom_clear_display";
            this.custom_clear_display.Size = new System.Drawing.Size(88, 23);
            this.custom_clear_display.TabIndex = 4;
            this.custom_clear_display.Text = "Clear Display";
            this.custom_clear_display.UseVisualStyleBackColor = true;
            this.custom_clear_display.Click += new System.EventHandler(this.custom_clear_display_Click);
            // 
            // send_button_custom
            // 
            this.send_button_custom.Location = new System.Drawing.Point(683, 15);
            this.send_button_custom.Name = "send_button_custom";
            this.send_button_custom.Size = new System.Drawing.Size(75, 23);
            this.send_button_custom.TabIndex = 2;
            this.send_button_custom.Text = "Send";
            this.send_button_custom.UseVisualStyleBackColor = true;
            this.send_button_custom.Click += new System.EventHandler(this.send_button_custom_Click);
            // 
            // query_input
            // 
            this.query_input.Location = new System.Drawing.Point(22, 17);
            this.query_input.Name = "query_input";
            this.query_input.Size = new System.Drawing.Size(636, 46);
            this.query_input.TabIndex = 1;
            this.query_input.Text = "";
            // 
            // custom_log_display
            // 
            this.custom_log_display.BackColor = System.Drawing.Color.White;
            this.custom_log_display.Location = new System.Drawing.Point(22, 83);
            this.custom_log_display.Name = "custom_log_display";
            this.custom_log_display.Size = new System.Drawing.Size(736, 285);
            this.custom_log_display.TabIndex = 0;
            this.custom_log_display.Text = "";
            this.custom_log_display.TextChanged += new System.EventHandler(this.custom_log_display_TextChanged);
            // 
            // logger_page
            // 
            this.logger_page.Controls.Add(this.set_time_label);
            this.logger_page.Controls.Add(this.time_set_button);
            this.logger_page.Controls.Add(this.time_set_box);
            this.logger_page.Controls.Add(this.file_save);
            this.logger_page.Controls.Add(this.callback_check_box_logger);
            this.logger_page.Controls.Add(this.timelog_checkbox_logger);
            this.logger_page.Controls.Add(this.button2);
            this.logger_page.Controls.Add(this.button1);
            this.logger_page.Controls.Add(this.remove_logging);
            this.logger_page.Controls.Add(this.add_logging);
            this.logger_page.Controls.Add(this.query_collection);
            this.logger_page.Controls.Add(this.label2);
            this.logger_page.Controls.Add(this.query_selector);
            this.logger_page.Controls.Add(this.data_viewer);
            this.logger_page.Controls.Add(this.save);
            this.logger_page.Controls.Add(this.label1);
            this.logger_page.Controls.Add(this.clear);
            this.logger_page.Controls.Add(this.serial_selector);
            this.logger_page.Controls.Add(this.stop_button);
            this.logger_page.Controls.Add(this.capture_button);
            this.logger_page.Location = new System.Drawing.Point(4, 22);
            this.logger_page.Name = "logger_page";
            this.logger_page.Size = new System.Drawing.Size(800, 427);
            this.logger_page.TabIndex = 0;
            this.logger_page.Text = "Logger";
            this.logger_page.UseVisualStyleBackColor = true;
            // 
            // set_time_label
            // 
            this.set_time_label.AutoSize = true;
            this.set_time_label.Location = new System.Drawing.Point(476, 367);
            this.set_time_label.Name = "set_time_label";
            this.set_time_label.Size = new System.Drawing.Size(67, 13);
            this.set_time_label.TabIndex = 19;
            this.set_time_label.Text = "Set time(ms):";
            // 
            // time_set_button
            // 
            this.time_set_button.Location = new System.Drawing.Point(569, 387);
            this.time_set_button.Name = "time_set_button";
            this.time_set_button.Size = new System.Drawing.Size(75, 23);
            this.time_set_button.TabIndex = 18;
            this.time_set_button.Text = "Set";
            this.time_set_button.UseVisualStyleBackColor = true;
            this.time_set_button.Click += new System.EventHandler(this.time_set_button_Click);
            // 
            // time_set_box
            // 
            this.time_set_box.Location = new System.Drawing.Point(479, 389);
            this.time_set_box.Name = "time_set_box";
            this.time_set_box.Size = new System.Drawing.Size(83, 20);
            this.time_set_box.TabIndex = 17;
            this.time_set_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.check_numeric_keydown);
            // 
            // file_save
            // 
            this.file_save.AutoSize = true;
            this.file_save.Location = new System.Drawing.Point(568, 367);
            this.file_save.Name = "file_save";
            this.file_save.Size = new System.Drawing.Size(82, 17);
            this.file_save.TabIndex = 16;
            this.file_save.Text = "Save to File";
            this.file_save.UseVisualStyleBackColor = true;
            this.file_save.Click += new System.EventHandler(this.file_save_CheckedChanged);
            // 
            // callback_check_box_logger
            // 
            this.callback_check_box_logger.AutoSize = true;
            this.callback_check_box_logger.Location = new System.Drawing.Point(660, 367);
            this.callback_check_box_logger.Name = "callback_check_box_logger";
            this.callback_check_box_logger.Size = new System.Drawing.Size(103, 17);
            this.callback_check_box_logger.TabIndex = 15;
            this.callback_check_box_logger.Text = "Enable Callback";
            this.callback_check_box_logger.UseVisualStyleBackColor = true;
            this.callback_check_box_logger.Click += new System.EventHandler(this.callback_check_box_logger_CheckedChanged);
            // 
            // timelog_checkbox_logger
            // 
            this.timelog_checkbox_logger.AutoSize = true;
            this.timelog_checkbox_logger.Location = new System.Drawing.Point(660, 390);
            this.timelog_checkbox_logger.Name = "timelog_checkbox_logger";
            this.timelog_checkbox_logger.Size = new System.Drawing.Size(132, 17);
            this.timelog_checkbox_logger.TabIndex = 14;
            this.timelog_checkbox_logger.Text = "Enable Timed Logging";
            this.timelog_checkbox_logger.UseVisualStyleBackColor = true;
            this.timelog_checkbox_logger.Click += new System.EventHandler(this.timelog_checkbox_logger_CheckedChanged_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.close_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.open_Click);
            // 
            // remove_logging
            // 
            this.remove_logging.Location = new System.Drawing.Point(660, 185);
            this.remove_logging.Name = "remove_logging";
            this.remove_logging.Size = new System.Drawing.Size(75, 23);
            this.remove_logging.TabIndex = 11;
            this.remove_logging.Text = "Remove";
            this.remove_logging.UseVisualStyleBackColor = true;
            this.remove_logging.Click += new System.EventHandler(this.remove_logging_Click);
            // 
            // add_logging
            // 
            this.add_logging.Location = new System.Drawing.Point(660, 154);
            this.add_logging.Name = "add_logging";
            this.add_logging.Size = new System.Drawing.Size(75, 23);
            this.add_logging.TabIndex = 10;
            this.add_logging.Text = "Add";
            this.add_logging.UseVisualStyleBackColor = true;
            this.add_logging.Click += new System.EventHandler(this.add_logging_Click);
            // 
            // query_collection
            // 
            this.query_collection.FormattingEnabled = true;
            this.query_collection.Location = new System.Drawing.Point(467, 185);
            this.query_collection.Name = "query_collection";
            this.query_collection.Size = new System.Drawing.Size(186, 169);
            this.query_collection.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 39);
            this.label2.TabIndex = 8;
            this.label2.Text = "You can select queries below. You can also add\r\nthem to the queue to be queried u" +
                "sing the\r\nbuttons on the right.\r\n";
            // 
            // query_selector
            // 
            this.query_selector.FormattingEnabled = true;
            this.query_selector.Location = new System.Drawing.Point(467, 157);
            this.query_selector.Name = "query_selector";
            this.query_selector.Size = new System.Drawing.Size(186, 21);
            this.query_selector.TabIndex = 7;
            // 
            // data_viewer
            // 
            this.data_viewer.BackColor = System.Drawing.Color.White;
            this.data_viewer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.data_viewer.Location = new System.Drawing.Point(14, 10);
            this.data_viewer.Name = "data_viewer";
            this.data_viewer.Size = new System.Drawing.Size(432, 382);
            this.data_viewer.TabIndex = 0;
            this.data_viewer.Text = "";
            this.data_viewer.TextChanged += new System.EventHandler(this.data_viewer_TextChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(568, 78);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(85, 20);
            this.save.TabIndex = 6;
            this.save.Text = "Save Log";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(462, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial port:";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(467, 78);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(85, 20);
            this.clear.TabIndex = 5;
            this.clear.Text = "Clear Data";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // serial_selector
            // 
            this.serial_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serial_selector.FormattingEnabled = true;
            this.serial_selector.Location = new System.Drawing.Point(526, 10);
            this.serial_selector.Name = "serial_selector";
            this.serial_selector.Size = new System.Drawing.Size(127, 21);
            this.serial_selector.TabIndex = 2;
            this.serial_selector.SelectedIndexChanged += new System.EventHandler(this.serial_selector_SelectedIndexChanged);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(568, 43);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(85, 20);
            this.stop_button.TabIndex = 4;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // capture_button
            // 
            this.capture_button.Location = new System.Drawing.Point(467, 43);
            this.capture_button.Name = "capture_button";
            this.capture_button.Size = new System.Drawing.Size(85, 20);
            this.capture_button.TabIndex = 3;
            this.capture_button.Text = "Capture Data";
            this.capture_button.UseVisualStyleBackColor = true;
            this.capture_button.Click += new System.EventHandler(this.capture_button_Click);
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.logger_page);
            this.tab_control.Controls.Add(this.custom_page);
            this.tab_control.Location = new System.Drawing.Point(12, 11);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(808, 453);
            this.tab_control.TabIndex = 0;
            // 
            // logger_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 476);
            this.Controls.Add(this.tab_control);
            this.Name = "logger_form";
            this.Text = "ESRI CC2431 RSSI Logger v. 1.51";
            this.custom_page.ResumeLayout(false);
            this.custom_page.PerformLayout();
            this.logger_page.ResumeLayout(false);
            this.logger_page.PerformLayout();
            this.tab_control.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage custom_page;
        private System.Windows.Forms.CheckBox enable_FCS;
        private System.Windows.Forms.CheckBox custom_callback_checkbox;
        private System.Windows.Forms.Button save_custom;
        private System.Windows.Forms.Button stop_custom;
        private System.Windows.Forms.CheckBox timelog_checkbox_custom;
        private System.Windows.Forms.Button custom_clear_display;
        private System.Windows.Forms.Button send_button_custom;
        private System.Windows.Forms.RichTextBox query_input;
        private System.Windows.Forms.RichTextBox custom_log_display;
        private System.Windows.Forms.TabPage logger_page;
        private System.Windows.Forms.CheckBox file_save;
        private System.Windows.Forms.CheckBox callback_check_box_logger;
        private System.Windows.Forms.CheckBox timelog_checkbox_logger;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button remove_logging;
        private System.Windows.Forms.Button add_logging;
        private System.Windows.Forms.CheckedListBox query_collection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox query_selector;
        private System.Windows.Forms.RichTextBox data_viewer;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.ComboBox serial_selector;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button capture_button;
        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.CheckBox file_save_custom;
        private System.Windows.Forms.Button time_set_button;
        private System.Windows.Forms.TextBox time_set_box;
        private System.Windows.Forms.Label set_time_label;
        private Label set_time_custom_label;
        private Button set_time_cust_but;
        private TextBox time_set_box_custom;
    }
}

