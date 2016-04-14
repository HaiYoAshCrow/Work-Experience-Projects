namespace USB_Reader
{
    partial class UI_Form
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
            this.close_button = new System.Windows.Forms.Button();
            this.rec_button = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.general_tab = new System.Windows.Forms.TabPage();
            this.step_thresh_label = new System.Windows.Forms.Label();
            this.sensitivity_changer = new System.Windows.Forms.TrackBar();
            this.dist_trav_display = new System.Windows.Forms.TextBox();
            this.cardinal_disp = new System.Windows.Forms.TextBox();
            this.dist_trav_label = new System.Windows.Forms.Label();
            this.cardinal_label = new System.Windows.Forms.Label();
            this.heading_display = new System.Windows.Forms.TextBox();
            this.step_display = new System.Windows.Forms.TextBox();
            this.heading_label = new System.Windows.Forms.Label();
            this.step_label = new System.Windows.Forms.Label();
            this.dist_label = new System.Windows.Forms.Label();
            this.rot_label = new System.Windows.Forms.Label();
            this.roll_display = new System.Windows.Forms.TextBox();
            this.pitch_display = new System.Windows.Forms.TextBox();
            this.hangle_display = new System.Windows.Forms.TextBox();
            this.roll_label = new System.Windows.Forms.Label();
            this.pitch_label = new System.Windows.Forms.Label();
            this.angle = new System.Windows.Forms.Label();
            this.raw_mag_tab = new System.Windows.Forms.TabPage();
            this.final_z_display = new System.Windows.Forms.TextBox();
            this.final_y_display = new System.Windows.Forms.TextBox();
            this.final_x_display = new System.Windows.Forms.TextBox();
            this.final_z_label = new System.Windows.Forms.Label();
            this.final_y_label = new System.Windows.Forms.Label();
            this.final_x_label = new System.Windows.Forms.Label();
            this.high_z_display = new System.Windows.Forms.TextBox();
            this.high_y_display = new System.Windows.Forms.TextBox();
            this.high_x_display = new System.Windows.Forms.TextBox();
            this.high_z_label = new System.Windows.Forms.Label();
            this.high_y_label = new System.Windows.Forms.Label();
            this.high_x_label = new System.Windows.Forms.Label();
            this.tab_label = new System.Windows.Forms.Label();
            this.low_z_display = new System.Windows.Forms.TextBox();
            this.low_y_display = new System.Windows.Forms.TextBox();
            this.low_x_display = new System.Windows.Forms.TextBox();
            this.low_z_label = new System.Windows.Forms.Label();
            this.low_y_label = new System.Windows.Forms.Label();
            this.low_x_label = new System.Windows.Forms.Label();
            this.raw_accel_tab = new System.Windows.Forms.TabPage();
            this.dev_info_tab = new System.Windows.Forms.TabPage();
            this.restart_label = new System.Windows.Forms.Label();
            this.restart_button = new System.Windows.Forms.Button();
            this.dev_set_label = new System.Windows.Forms.Label();
            this.reset_desc = new System.Windows.Forms.Label();
            this.calib_desc = new System.Windows.Forms.Label();
            this.reset_button = new System.Windows.Forms.Button();
            this.calib_button = new System.Windows.Forms.Button();
            this.dev_info_label = new System.Windows.Forms.Label();
            this.ver_display = new System.Windows.Forms.TextBox();
            this.dev_found_display = new System.Windows.Forms.TextBox();
            this.serial_label = new System.Windows.Forms.Label();
            this.dev_found_label = new System.Windows.Forms.Label();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.record_status = new System.Windows.Forms.Label();
            this.clear_log_button = new System.Windows.Forms.Button();
            this.view_log_button = new System.Windows.Forms.Button();
            this.rec_all_button = new System.Windows.Forms.Button();
            this.compass_panel = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.general_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivity_changer)).BeginInit();
            this.raw_mag_tab.SuspendLayout();
            this.dev_info_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(381, 328);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(64, 22);
            this.close_button.TabIndex = 0;
            this.close_button.Text = "Close";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_Click);
            // 
            // rec_button
            // 
            this.rec_button.BackColor = System.Drawing.Color.Red;
            this.rec_button.ForeColor = System.Drawing.SystemColors.Window;
            this.rec_button.Location = new System.Drawing.Point(23, 328);
            this.rec_button.Name = "rec_button";
            this.rec_button.Size = new System.Drawing.Size(64, 22);
            this.rec_button.TabIndex = 1;
            this.rec_button.Text = "Record";
            this.rec_button.UseVisualStyleBackColor = false;
            this.rec_button.Click += new System.EventHandler(this.record_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.general_tab);
            this.tabControl.Controls.Add(this.raw_mag_tab);
            this.tabControl.Controls.Add(this.raw_accel_tab);
            this.tabControl.Controls.Add(this.dev_info_tab);
            this.tabControl.Location = new System.Drawing.Point(23, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(422, 288);
            this.tabControl.TabIndex = 2;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tab_selection);
            // 
            // general_tab
            // 
            this.general_tab.Controls.Add(this.compass_panel);
            this.general_tab.Controls.Add(this.step_thresh_label);
            this.general_tab.Controls.Add(this.sensitivity_changer);
            this.general_tab.Controls.Add(this.dist_trav_display);
            this.general_tab.Controls.Add(this.cardinal_disp);
            this.general_tab.Controls.Add(this.dist_trav_label);
            this.general_tab.Controls.Add(this.cardinal_label);
            this.general_tab.Controls.Add(this.heading_display);
            this.general_tab.Controls.Add(this.step_display);
            this.general_tab.Controls.Add(this.heading_label);
            this.general_tab.Controls.Add(this.step_label);
            this.general_tab.Controls.Add(this.dist_label);
            this.general_tab.Controls.Add(this.rot_label);
            this.general_tab.Controls.Add(this.roll_display);
            this.general_tab.Controls.Add(this.pitch_display);
            this.general_tab.Controls.Add(this.hangle_display);
            this.general_tab.Controls.Add(this.roll_label);
            this.general_tab.Controls.Add(this.pitch_label);
            this.general_tab.Controls.Add(this.angle);
            this.general_tab.Location = new System.Drawing.Point(4, 22);
            this.general_tab.Name = "general_tab";
            this.general_tab.Padding = new System.Windows.Forms.Padding(3);
            this.general_tab.Size = new System.Drawing.Size(414, 262);
            this.general_tab.TabIndex = 0;
            this.general_tab.Text = "General";
            this.general_tab.UseVisualStyleBackColor = true;
            // 
            // step_thresh_label
            // 
            this.step_thresh_label.AutoSize = true;
            this.step_thresh_label.Location = new System.Drawing.Point(100, 182);
            this.step_thresh_label.Name = "step_thresh_label";
            this.step_thresh_label.Size = new System.Drawing.Size(159, 13);
            this.step_thresh_label.TabIndex = 41;
            this.step_thresh_label.Text = "Pedometer sensitivity Threshold:";
            // 
            // sensitivity_changer
            // 
            this.sensitivity_changer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sensitivity_changer.Location = new System.Drawing.Point(103, 211);
            this.sensitivity_changer.Name = "sensitivity_changer";
            this.sensitivity_changer.Size = new System.Drawing.Size(305, 45);
            this.sensitivity_changer.TabIndex = 40;
            this.sensitivity_changer.Scroll += new System.EventHandler(this.sensitivity_changer_Scroll);
            // 
            // dist_trav_display
            // 
            this.dist_trav_display.Location = new System.Drawing.Point(282, 133);
            this.dist_trav_display.Name = "dist_trav_display";
            this.dist_trav_display.ReadOnly = true;
            this.dist_trav_display.Size = new System.Drawing.Size(96, 20);
            this.dist_trav_display.TabIndex = 39;
            // 
            // cardinal_disp
            // 
            this.cardinal_disp.Location = new System.Drawing.Point(282, 97);
            this.cardinal_disp.Name = "cardinal_disp";
            this.cardinal_disp.ReadOnly = true;
            this.cardinal_disp.Size = new System.Drawing.Size(96, 20);
            this.cardinal_disp.TabIndex = 38;
            // 
            // dist_trav_label
            // 
            this.dist_trav_label.AutoSize = true;
            this.dist_trav_label.Location = new System.Drawing.Point(183, 136);
            this.dist_trav_label.Name = "dist_trav_label";
            this.dist_trav_label.Size = new System.Drawing.Size(99, 13);
            this.dist_trav_label.TabIndex = 37;
            this.dist_trav_label.Text = "Distance Travelled:";
            // 
            // cardinal_label
            // 
            this.cardinal_label.AutoSize = true;
            this.cardinal_label.Location = new System.Drawing.Point(185, 100);
            this.cardinal_label.Name = "cardinal_label";
            this.cardinal_label.Size = new System.Drawing.Size(93, 13);
            this.cardinal_label.TabIndex = 36;
            this.cardinal_label.Text = "Cardinal Direction:";
            // 
            // heading_display
            // 
            this.heading_display.Location = new System.Drawing.Point(282, 62);
            this.heading_display.Name = "heading_display";
            this.heading_display.ReadOnly = true;
            this.heading_display.Size = new System.Drawing.Size(96, 20);
            this.heading_display.TabIndex = 35;
            // 
            // step_display
            // 
            this.step_display.Location = new System.Drawing.Point(281, 29);
            this.step_display.Name = "step_display";
            this.step_display.ReadOnly = true;
            this.step_display.Size = new System.Drawing.Size(96, 20);
            this.step_display.TabIndex = 34;
            // 
            // heading_label
            // 
            this.heading_label.AutoSize = true;
            this.heading_label.Location = new System.Drawing.Point(185, 65);
            this.heading_label.Name = "heading_label";
            this.heading_label.Size = new System.Drawing.Size(50, 13);
            this.heading_label.TabIndex = 33;
            this.heading_label.Text = "Heading:";
            // 
            // step_label
            // 
            this.step_label.AutoSize = true;
            this.step_label.Location = new System.Drawing.Point(185, 32);
            this.step_label.Name = "step_label";
            this.step_label.Size = new System.Drawing.Size(71, 13);
            this.step_label.TabIndex = 32;
            this.step_label.Text = "Steps Taken:";
            // 
            // dist_label
            // 
            this.dist_label.AutoSize = true;
            this.dist_label.Location = new System.Drawing.Point(185, 8);
            this.dist_label.Name = "dist_label";
            this.dist_label.Size = new System.Drawing.Size(49, 13);
            this.dist_label.TabIndex = 31;
            this.dist_label.Text = "Distance";
            // 
            // rot_label
            // 
            this.rot_label.AutoSize = true;
            this.rot_label.Location = new System.Drawing.Point(15, 8);
            this.rot_label.Name = "rot_label";
            this.rot_label.Size = new System.Drawing.Size(47, 13);
            this.rot_label.TabIndex = 30;
            this.rot_label.Text = "Rotation";
            // 
            // roll_display
            // 
            this.roll_display.Location = new System.Drawing.Point(77, 97);
            this.roll_display.Name = "roll_display";
            this.roll_display.ReadOnly = true;
            this.roll_display.Size = new System.Drawing.Size(96, 20);
            this.roll_display.TabIndex = 29;
            // 
            // pitch_display
            // 
            this.pitch_display.Location = new System.Drawing.Point(77, 65);
            this.pitch_display.Name = "pitch_display";
            this.pitch_display.ReadOnly = true;
            this.pitch_display.Size = new System.Drawing.Size(96, 20);
            this.pitch_display.TabIndex = 27;
            // 
            // hangle_display
            // 
            this.hangle_display.Location = new System.Drawing.Point(77, 32);
            this.hangle_display.Name = "hangle_display";
            this.hangle_display.ReadOnly = true;
            this.hangle_display.Size = new System.Drawing.Size(96, 20);
            this.hangle_display.TabIndex = 25;
            // 
            // roll_label
            // 
            this.roll_label.AutoSize = true;
            this.roll_label.Location = new System.Drawing.Point(16, 100);
            this.roll_label.Name = "roll_label";
            this.roll_label.Size = new System.Drawing.Size(28, 13);
            this.roll_label.TabIndex = 28;
            this.roll_label.Text = "Roll:";
            // 
            // pitch_label
            // 
            this.pitch_label.AutoSize = true;
            this.pitch_label.Location = new System.Drawing.Point(16, 65);
            this.pitch_label.Name = "pitch_label";
            this.pitch_label.Size = new System.Drawing.Size(34, 13);
            this.pitch_label.TabIndex = 24;
            this.pitch_label.Text = "Pitch:";
            // 
            // angle
            // 
            this.angle.AutoSize = true;
            this.angle.Location = new System.Drawing.Point(16, 32);
            this.angle.Name = "angle";
            this.angle.Size = new System.Drawing.Size(31, 13);
            this.angle.TabIndex = 22;
            this.angle.Text = "Yaw:";
            // 
            // raw_mag_tab
            // 
            this.raw_mag_tab.Controls.Add(this.final_z_display);
            this.raw_mag_tab.Controls.Add(this.final_y_display);
            this.raw_mag_tab.Controls.Add(this.final_x_display);
            this.raw_mag_tab.Controls.Add(this.final_z_label);
            this.raw_mag_tab.Controls.Add(this.final_y_label);
            this.raw_mag_tab.Controls.Add(this.final_x_label);
            this.raw_mag_tab.Controls.Add(this.high_z_display);
            this.raw_mag_tab.Controls.Add(this.high_y_display);
            this.raw_mag_tab.Controls.Add(this.high_x_display);
            this.raw_mag_tab.Controls.Add(this.high_z_label);
            this.raw_mag_tab.Controls.Add(this.high_y_label);
            this.raw_mag_tab.Controls.Add(this.high_x_label);
            this.raw_mag_tab.Controls.Add(this.tab_label);
            this.raw_mag_tab.Controls.Add(this.low_z_display);
            this.raw_mag_tab.Controls.Add(this.low_y_display);
            this.raw_mag_tab.Controls.Add(this.low_x_display);
            this.raw_mag_tab.Controls.Add(this.low_z_label);
            this.raw_mag_tab.Controls.Add(this.low_y_label);
            this.raw_mag_tab.Controls.Add(this.low_x_label);
            this.raw_mag_tab.Location = new System.Drawing.Point(4, 22);
            this.raw_mag_tab.Name = "raw_mag_tab";
            this.raw_mag_tab.Padding = new System.Windows.Forms.Padding(3);
            this.raw_mag_tab.Size = new System.Drawing.Size(414, 262);
            this.raw_mag_tab.TabIndex = 1;
            this.raw_mag_tab.Text = "Magnetometer";
            this.raw_mag_tab.UseVisualStyleBackColor = true;
            // 
            // final_z_display
            // 
            this.final_z_display.Location = new System.Drawing.Point(186, 219);
            this.final_z_display.Name = "final_z_display";
            this.final_z_display.ReadOnly = true;
            this.final_z_display.Size = new System.Drawing.Size(96, 20);
            this.final_z_display.TabIndex = 49;
            // 
            // final_y_display
            // 
            this.final_y_display.Location = new System.Drawing.Point(186, 185);
            this.final_y_display.Name = "final_y_display";
            this.final_y_display.ReadOnly = true;
            this.final_y_display.Size = new System.Drawing.Size(96, 20);
            this.final_y_display.TabIndex = 48;
            // 
            // final_x_display
            // 
            this.final_x_display.Location = new System.Drawing.Point(186, 155);
            this.final_x_display.Name = "final_x_display";
            this.final_x_display.ReadOnly = true;
            this.final_x_display.Size = new System.Drawing.Size(96, 20);
            this.final_x_display.TabIndex = 47;
            // 
            // final_z_label
            // 
            this.final_z_label.AutoSize = true;
            this.final_z_label.Location = new System.Drawing.Point(129, 222);
            this.final_z_label.Name = "final_z_label";
            this.final_z_label.Size = new System.Drawing.Size(37, 13);
            this.final_z_label.TabIndex = 46;
            this.final_z_label.Text = "final z:";
            // 
            // final_y_label
            // 
            this.final_y_label.AutoSize = true;
            this.final_y_label.Location = new System.Drawing.Point(129, 188);
            this.final_y_label.Name = "final_y_label";
            this.final_y_label.Size = new System.Drawing.Size(37, 13);
            this.final_y_label.TabIndex = 45;
            this.final_y_label.Text = "final y:";
            // 
            // final_x_label
            // 
            this.final_x_label.AutoSize = true;
            this.final_x_label.Location = new System.Drawing.Point(129, 155);
            this.final_x_label.Name = "final_x_label";
            this.final_x_label.Size = new System.Drawing.Size(37, 13);
            this.final_x_label.TabIndex = 44;
            this.final_x_label.Text = "final x:";
            // 
            // high_z_display
            // 
            this.high_z_display.Location = new System.Drawing.Point(262, 107);
            this.high_z_display.Name = "high_z_display";
            this.high_z_display.ReadOnly = true;
            this.high_z_display.Size = new System.Drawing.Size(96, 20);
            this.high_z_display.TabIndex = 43;
            // 
            // high_y_display
            // 
            this.high_y_display.Location = new System.Drawing.Point(262, 73);
            this.high_y_display.Name = "high_y_display";
            this.high_y_display.ReadOnly = true;
            this.high_y_display.Size = new System.Drawing.Size(96, 20);
            this.high_y_display.TabIndex = 42;
            // 
            // high_x_display
            // 
            this.high_x_display.Location = new System.Drawing.Point(262, 43);
            this.high_x_display.Name = "high_x_display";
            this.high_x_display.ReadOnly = true;
            this.high_x_display.Size = new System.Drawing.Size(96, 20);
            this.high_x_display.TabIndex = 41;
            // 
            // high_z_label
            // 
            this.high_z_label.AutoSize = true;
            this.high_z_label.Location = new System.Drawing.Point(205, 110);
            this.high_z_label.Name = "high_z_label";
            this.high_z_label.Size = new System.Drawing.Size(38, 13);
            this.high_z_label.TabIndex = 40;
            this.high_z_label.Text = "high z:";
            // 
            // high_y_label
            // 
            this.high_y_label.AutoSize = true;
            this.high_y_label.Location = new System.Drawing.Point(205, 76);
            this.high_y_label.Name = "high_y_label";
            this.high_y_label.Size = new System.Drawing.Size(38, 13);
            this.high_y_label.TabIndex = 39;
            this.high_y_label.Text = "high y:";
            // 
            // high_x_label
            // 
            this.high_x_label.AutoSize = true;
            this.high_x_label.Location = new System.Drawing.Point(205, 43);
            this.high_x_label.Name = "high_x_label";
            this.high_x_label.Size = new System.Drawing.Size(38, 13);
            this.high_x_label.TabIndex = 38;
            this.high_x_label.Text = "high x:";
            // 
            // tab_label
            // 
            this.tab_label.AutoSize = true;
            this.tab_label.Location = new System.Drawing.Point(20, 12);
            this.tab_label.Name = "tab_label";
            this.tab_label.Size = new System.Drawing.Size(101, 13);
            this.tab_label.TabIndex = 37;
            this.tab_label.Text = "Magnetometer Data";
            // 
            // low_z_display
            // 
            this.low_z_display.Location = new System.Drawing.Point(77, 110);
            this.low_z_display.Name = "low_z_display";
            this.low_z_display.ReadOnly = true;
            this.low_z_display.Size = new System.Drawing.Size(96, 20);
            this.low_z_display.TabIndex = 36;
            // 
            // low_y_display
            // 
            this.low_y_display.Location = new System.Drawing.Point(77, 76);
            this.low_y_display.Name = "low_y_display";
            this.low_y_display.ReadOnly = true;
            this.low_y_display.Size = new System.Drawing.Size(96, 20);
            this.low_y_display.TabIndex = 35;
            // 
            // low_x_display
            // 
            this.low_x_display.Location = new System.Drawing.Point(77, 46);
            this.low_x_display.Name = "low_x_display";
            this.low_x_display.ReadOnly = true;
            this.low_x_display.Size = new System.Drawing.Size(96, 20);
            this.low_x_display.TabIndex = 34;
            // 
            // low_z_label
            // 
            this.low_z_label.AutoSize = true;
            this.low_z_label.Location = new System.Drawing.Point(20, 113);
            this.low_z_label.Name = "low_z_label";
            this.low_z_label.Size = new System.Drawing.Size(34, 13);
            this.low_z_label.TabIndex = 33;
            this.low_z_label.Text = "low z:";
            // 
            // low_y_label
            // 
            this.low_y_label.AutoSize = true;
            this.low_y_label.Location = new System.Drawing.Point(20, 79);
            this.low_y_label.Name = "low_y_label";
            this.low_y_label.Size = new System.Drawing.Size(34, 13);
            this.low_y_label.TabIndex = 32;
            this.low_y_label.Text = "low y:";
            // 
            // low_x_label
            // 
            this.low_x_label.AutoSize = true;
            this.low_x_label.Location = new System.Drawing.Point(20, 46);
            this.low_x_label.Name = "low_x_label";
            this.low_x_label.Size = new System.Drawing.Size(34, 13);
            this.low_x_label.TabIndex = 31;
            this.low_x_label.Text = "low x:";
            // 
            // raw_accel_tab
            // 
            this.raw_accel_tab.Location = new System.Drawing.Point(4, 22);
            this.raw_accel_tab.Name = "raw_accel_tab";
            this.raw_accel_tab.Padding = new System.Windows.Forms.Padding(3);
            this.raw_accel_tab.Size = new System.Drawing.Size(414, 262);
            this.raw_accel_tab.TabIndex = 2;
            this.raw_accel_tab.Text = "Accelerometer";
            this.raw_accel_tab.UseVisualStyleBackColor = true;
            // 
            // dev_info_tab
            // 
            this.dev_info_tab.Controls.Add(this.restart_label);
            this.dev_info_tab.Controls.Add(this.restart_button);
            this.dev_info_tab.Controls.Add(this.dev_set_label);
            this.dev_info_tab.Controls.Add(this.reset_desc);
            this.dev_info_tab.Controls.Add(this.calib_desc);
            this.dev_info_tab.Controls.Add(this.reset_button);
            this.dev_info_tab.Controls.Add(this.calib_button);
            this.dev_info_tab.Controls.Add(this.dev_info_label);
            this.dev_info_tab.Controls.Add(this.ver_display);
            this.dev_info_tab.Controls.Add(this.dev_found_display);
            this.dev_info_tab.Controls.Add(this.serial_label);
            this.dev_info_tab.Controls.Add(this.dev_found_label);
            this.dev_info_tab.Location = new System.Drawing.Point(4, 22);
            this.dev_info_tab.Name = "dev_info_tab";
            this.dev_info_tab.Size = new System.Drawing.Size(414, 262);
            this.dev_info_tab.TabIndex = 3;
            this.dev_info_tab.Text = "Device Information";
            this.dev_info_tab.UseVisualStyleBackColor = true;
            // 
            // restart_label
            // 
            this.restart_label.AutoSize = true;
            this.restart_label.Location = new System.Drawing.Point(123, 226);
            this.restart_label.Name = "restart_label";
            this.restart_label.Size = new System.Drawing.Size(108, 13);
            this.restart_label.TabIndex = 46;
            this.restart_label.Text = "Restarts the program.";
            // 
            // restart_button
            // 
            this.restart_button.Location = new System.Drawing.Point(21, 221);
            this.restart_button.Name = "restart_button";
            this.restart_button.Size = new System.Drawing.Size(96, 22);
            this.restart_button.TabIndex = 45;
            this.restart_button.Text = "Restart Program";
            this.restart_button.UseVisualStyleBackColor = true;
            this.restart_button.Click += new System.EventHandler(this.restart_button_Click);
            // 
            // dev_set_label
            // 
            this.dev_set_label.AutoSize = true;
            this.dev_set_label.Location = new System.Drawing.Point(22, 110);
            this.dev_set_label.Name = "dev_set_label";
            this.dev_set_label.Size = new System.Drawing.Size(82, 13);
            this.dev_set_label.TabIndex = 44;
            this.dev_set_label.Text = "Device Settings";
            // 
            // reset_desc
            // 
            this.reset_desc.AutoSize = true;
            this.reset_desc.Location = new System.Drawing.Point(123, 185);
            this.reset_desc.Name = "reset_desc";
            this.reset_desc.Size = new System.Drawing.Size(291, 13);
            this.reset_desc.TabIndex = 43;
            this.reset_desc.Text = "If something goes wrong,  use this to restore factory settings.";
            // 
            // calib_desc
            // 
            this.calib_desc.AutoSize = true;
            this.calib_desc.Location = new System.Drawing.Point(123, 142);
            this.calib_desc.Name = "calib_desc";
            this.calib_desc.Size = new System.Drawing.Size(146, 13);
            this.calib_desc.TabIndex = 42;
            this.calib_desc.Text = "Recalibrates compass device";
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(21, 180);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(96, 22);
            this.reset_button.TabIndex = 41;
            this.reset_button.Text = "Reset Device";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // calib_button
            // 
            this.calib_button.Location = new System.Drawing.Point(21, 137);
            this.calib_button.Name = "calib_button";
            this.calib_button.Size = new System.Drawing.Size(96, 22);
            this.calib_button.TabIndex = 40;
            this.calib_button.Text = "Calibrate Device";
            this.calib_button.UseVisualStyleBackColor = true;
            this.calib_button.Click += new System.EventHandler(this.calib_button_Click);
            // 
            // dev_info_label
            // 
            this.dev_info_label.AutoSize = true;
            this.dev_info_label.Location = new System.Drawing.Point(18, 24);
            this.dev_info_label.Name = "dev_info_label";
            this.dev_info_label.Size = new System.Drawing.Size(99, 13);
            this.dev_info_label.TabIndex = 39;
            this.dev_info_label.Text = "Device Information:";
            // 
            // ver_display
            // 
            this.ver_display.Location = new System.Drawing.Point(98, 73);
            this.ver_display.Name = "ver_display";
            this.ver_display.ReadOnly = true;
            this.ver_display.Size = new System.Drawing.Size(228, 20);
            this.ver_display.TabIndex = 38;
            // 
            // dev_found_display
            // 
            this.dev_found_display.Location = new System.Drawing.Point(98, 47);
            this.dev_found_display.Name = "dev_found_display";
            this.dev_found_display.ReadOnly = true;
            this.dev_found_display.Size = new System.Drawing.Size(228, 20);
            this.dev_found_display.TabIndex = 37;
            // 
            // serial_label
            // 
            this.serial_label.AutoSize = true;
            this.serial_label.Location = new System.Drawing.Point(18, 80);
            this.serial_label.Name = "serial_label";
            this.serial_label.Size = new System.Drawing.Size(36, 13);
            this.serial_label.TabIndex = 36;
            this.serial_label.Text = "Serial:";
            // 
            // dev_found_label
            // 
            this.dev_found_label.AutoSize = true;
            this.dev_found_label.Location = new System.Drawing.Point(18, 50);
            this.dev_found_label.Name = "dev_found_label";
            this.dev_found_label.Size = new System.Drawing.Size(77, 13);
            this.dev_found_label.TabIndex = 35;
            this.dev_found_label.Text = "Device Found:";
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // record_status
            // 
            this.record_status.AutoSize = true;
            this.record_status.Location = new System.Drawing.Point(24, 309);
            this.record_status.Name = "record_status";
            this.record_status.Size = new System.Drawing.Size(120, 13);
            this.record_status.TabIndex = 3;
            this.record_status.Text = "Recording Status: False";
            // 
            // clear_log_button
            // 
            this.clear_log_button.Location = new System.Drawing.Point(163, 328);
            this.clear_log_button.Name = "clear_log_button";
            this.clear_log_button.Size = new System.Drawing.Size(77, 22);
            this.clear_log_button.TabIndex = 4;
            this.clear_log_button.Text = "Clear Logs";
            this.clear_log_button.UseVisualStyleBackColor = true;
            this.clear_log_button.Click += new System.EventHandler(this.clear_log_button_Click);
            // 
            // view_log_button
            // 
            this.view_log_button.Location = new System.Drawing.Point(246, 328);
            this.view_log_button.Name = "view_log_button";
            this.view_log_button.Size = new System.Drawing.Size(77, 22);
            this.view_log_button.TabIndex = 5;
            this.view_log_button.Text = "View Logs";
            this.view_log_button.UseVisualStyleBackColor = true;
            this.view_log_button.Click += new System.EventHandler(this.view_log_button_Click);
            // 
            // rec_all_button
            // 
            this.rec_all_button.BackColor = System.Drawing.Color.Red;
            this.rec_all_button.ForeColor = System.Drawing.SystemColors.Window;
            this.rec_all_button.Location = new System.Drawing.Point(93, 328);
            this.rec_all_button.Name = "rec_all_button";
            this.rec_all_button.Size = new System.Drawing.Size(64, 22);
            this.rec_all_button.TabIndex = 6;
            this.rec_all_button.Text = "Record All";
            this.rec_all_button.UseVisualStyleBackColor = false;
            this.rec_all_button.Click += new System.EventHandler(this.record_all_button_Click);
            // 
            // compass_panel
            // 
            this.compass_panel.Location = new System.Drawing.Point(7, 163);
            this.compass_panel.Name = "compass_panel";
            this.compass_panel.Size = new System.Drawing.Size(87, 82);
            this.compass_panel.TabIndex = 42;
            // 
            // UI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 359);
            this.Controls.Add(this.rec_all_button);
            this.Controls.Add(this.view_log_button);
            this.Controls.Add(this.clear_log_button);
            this.Controls.Add(this.record_status);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.rec_button);
            this.Controls.Add(this.close_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Form";
            this.Text = "USB-ISS/CMPS10 Data Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.general_tab.ResumeLayout(false);
            this.general_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivity_changer)).EndInit();
            this.raw_mag_tab.ResumeLayout(false);
            this.raw_mag_tab.PerformLayout();
            this.dev_info_tab.ResumeLayout(false);
            this.dev_info_tab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button rec_button;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage general_tab;
        private System.Windows.Forms.TabPage raw_mag_tab;
        private System.Windows.Forms.TabPage raw_accel_tab;
        private System.Windows.Forms.TextBox roll_display;
        private System.Windows.Forms.TextBox pitch_display;
        private System.Windows.Forms.TextBox hangle_display;
        private System.Windows.Forms.Label roll_label;
        private System.Windows.Forms.Label pitch_label;
        private System.Windows.Forms.Label angle;
        private System.Windows.Forms.Label tab_label;
        private System.Windows.Forms.TextBox low_z_display;
        private System.Windows.Forms.TextBox low_y_display;
        private System.Windows.Forms.TextBox low_x_display;
        private System.Windows.Forms.Label low_z_label;
        private System.Windows.Forms.Label low_y_label;
        private System.Windows.Forms.Label low_x_label;
        private System.Windows.Forms.TextBox high_z_display;
        private System.Windows.Forms.TextBox high_y_display;
        private System.Windows.Forms.TextBox high_x_display;
        private System.Windows.Forms.Label high_z_label;
        private System.Windows.Forms.Label high_y_label;
        private System.Windows.Forms.Label high_x_label;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.TextBox final_z_display;
        private System.Windows.Forms.TextBox final_y_display;
        private System.Windows.Forms.TextBox final_x_display;
        private System.Windows.Forms.Label final_z_label;
        private System.Windows.Forms.Label final_y_label;
        private System.Windows.Forms.Label final_x_label;
        private System.Windows.Forms.Label record_status;
        private System.Windows.Forms.Label rot_label;
        private System.Windows.Forms.Label dist_label;
        private System.Windows.Forms.Label step_label;
        private System.Windows.Forms.Label heading_label;
        private System.Windows.Forms.TextBox heading_display;
        private System.Windows.Forms.TextBox step_display;
        private System.Windows.Forms.Label dist_trav_label;
        private System.Windows.Forms.Label cardinal_label;
        private System.Windows.Forms.TextBox dist_trav_display;
        private System.Windows.Forms.TextBox cardinal_disp;
        private System.Windows.Forms.Button clear_log_button;
        private System.Windows.Forms.Button view_log_button;
        private System.Windows.Forms.TabPage dev_info_tab;
        private System.Windows.Forms.Label restart_label;
        private System.Windows.Forms.Button restart_button;
        private System.Windows.Forms.Label dev_set_label;
        private System.Windows.Forms.Label reset_desc;
        private System.Windows.Forms.Label calib_desc;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Button calib_button;
        private System.Windows.Forms.Label dev_info_label;
        private System.Windows.Forms.TextBox ver_display;
        private System.Windows.Forms.TextBox dev_found_display;
        private System.Windows.Forms.Label serial_label;
        private System.Windows.Forms.Label dev_found_label;
        private System.Windows.Forms.Button rec_all_button;
        private System.Windows.Forms.TrackBar sensitivity_changer;
        private System.Windows.Forms.Label step_thresh_label;
        private System.Windows.Forms.Panel compass_panel;
    }
}

