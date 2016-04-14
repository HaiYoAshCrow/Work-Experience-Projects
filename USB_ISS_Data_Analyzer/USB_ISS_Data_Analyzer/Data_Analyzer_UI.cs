using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace USB_ISS_Data_Analyzer
{
    public partial class Analyzer_UI : Form
    {
        Data_Analyzer m_analyzer;
        bool m_isRunning = false;
        Stopwatch m_stopwatch;
        public Analyzer_UI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_analyzer = new Data_Analyzer();
            m_stopwatch = new Stopwatch();
            m_timer.Start();

            sensitivity_changer.TickFrequency = 1;
            sensitivity_changer.Maximum = 100;
            sensitivity_changer.Value = (int)m_analyzer.step_thresh;
            m_stopwatch.Start();
        }

        private void Display_Data(string s)
        {
            console.Text = s;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            TimeSpan ts = m_stopwatch.Elapsed;
            m_analyzer.CalculateSteps(ts.Seconds);
            //Display_Data("Number of steps taken:" + m_analyzer.steps.ToString() +
            //             "\nDistance:" + m_analyzer.distance.ToString() +
            //             "\nVelocity:" + m_analyzer.velocity.ToString() + 
            //             "\nStep Threshold: " + m_analyzer.step_thresh + 
            //             "\nYaw: " + m_analyzer.m_angle_data[0] + 
            //             "\nPitch: " + m_analyzer.m_angle_data[1] + 
            //             "\nRoll: " + m_analyzer.m_angle_data[2]);

            Display_Data("Number of steps taken:" + m_analyzer.steps.ToString() +
                         "\nStep Threshold: " + m_analyzer.step_thresh +
                         "\nDistance:" + m_analyzer.distance.ToString() +
                         "\nOld Average:" + m_analyzer.oldavg.ToString() +
                         "\nNew Average:" + m_analyzer.newavg.ToString()
                         + "\nMin Average:" + m_analyzer.minavg.ToString()
                         + "\nMax Average:" + m_analyzer.maxavg.ToString()
                         + "\nSum:" + m_analyzer.sum.ToString()
                         + "\nx: " + m_analyzer.m_accel_raw_data[0]
                         + "\ny: " + m_analyzer.m_accel_raw_data[1]
                         + "\nz: " + m_analyzer.m_accel_raw_data[2]);
        }

        private void sensitivity_changer_Scroll(object sender, EventArgs e)
        {
            m_analyzer.step_thresh = sensitivity_changer.Value;
        }

    }
}
