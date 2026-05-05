using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalClock
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private Label clockLabel;
        private Label dateLabel;
        private Label ampmLabel;

        public Form1()
        {
            SetupClock();
        }

        private void SetupClock()
        {
            // Form settings - made larger to fit bigger numbers
            this.Text = "Digital Clock";
            this.Size = new Size(1200, 600);  // Increased from 800x400
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Time Label (Much Larger numbers)
            clockLabel = new Label();
            clockLabel.Font = new Font("Segoe UI", 140, FontStyle.Bold);  // Increased from 72 to 140
            clockLabel.ForeColor = Color.Lime;
            clockLabel.BackColor = Color.Black;
            clockLabel.TextAlign = ContentAlignment.MiddleRight;  // Changed to right alignment
            clockLabel.Dock = DockStyle.Fill;
            clockLabel.Text = "00:00:00";

            // AM/PM Label (Larger)
            ampmLabel = new Label();
            ampmLabel.Font = new Font("Segoe UI", 48, FontStyle.Bold);  // Increased from 24 to 48
            ampmLabel.ForeColor = Color.Lime;
            ampmLabel.BackColor = Color.Black;
            ampmLabel.TextAlign = ContentAlignment.MiddleLeft;
            ampmLabel.Text = "";
            ampmLabel.Dock = DockStyle.Fill;  // Changed to DockStyle.Fill for better layout

            // Date Label (Slightly larger)
            dateLabel = new Label();
            dateLabel.Font = new Font("Segoe UI", 24, FontStyle.Regular);  // Increased from 18 to 24
            dateLabel.ForeColor = Color.Lime;
            dateLabel.BackColor = Color.Black;
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;
            dateLabel.Dock = DockStyle.Bottom;
            dateLabel.Height = 80;  // Increased from 60 to 80
            dateLabel.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

            // Panel for time and AM/PM with improved proportions
            TableLayoutPanel mainPanel = new TableLayoutPanel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.ColumnCount = 2;
            mainPanel.RowCount = 1;
            mainPanel.Controls.Add(clockLabel, 0, 0);
            mainPanel.Controls.Add(ampmLabel, 1, 0);
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));  // Adjusted from 85% to 80%
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Adjusted from 15% to 20%

            // Add controls to form
            this.Controls.Add(dateLabel);
            this.Controls.Add(mainPanel);

            // Timer setup
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateClock();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            clockLabel.Text = now.ToString("hh:mm:ss");
            ampmLabel.Text = now.ToString("tt");
            dateLabel.Text = now.ToString("dddd, MMMM dd, yyyy");
        }
    }
}