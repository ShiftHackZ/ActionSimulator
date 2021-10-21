using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput.Native;
using WindowsInput;

namespace MouseSimulator
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private Logger logger = new Logger();
        private InputSimulator inputSimilator = new InputSimulator();

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int x, int y);

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbKey.SelectedIndex = 0;
            cmbPeriod.SelectedIndex = 1;
            logger.write(txtLog, "Program loaded");
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            if (chkMouse.Checked)
            {
                int x = rand.Next(0, 800);
                int y = rand.Next(0, 600);
                SetCursorPos(x, y);
                logger.write(txtLog, "Moving cursor to: x = " + x.ToString() + ", y = " + y.ToString());
            }
            if (chkKeyPress.Checked)
            { 
                inputSimilator.Keyboard.KeyPress(getKey());
                logger.write(txtLog, "Pressed [" + cmbKey.Text + "] button");
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkMouse.Checked || chkKeyPress.Checked)
            {
                timerMain.Interval = Convert.ToInt32(numPeriod.Value) * getIntervalMultiplier();
                logger.write(txtLog, "Setting period to " + numPeriod.Value.ToString() + " " + cmbPeriod.Text);
                timerMain.Enabled = true;
                logger.write(txtLog, "Simulation started!");
                changeUiState(false);
            } 
            else
            {
                logger.write(txtLog, "Error: You need select at least one action to start");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timerMain.Enabled = false;
            changeUiState(true);
            logger.write(txtLog, "Simulation stopped!");
        }

        private void changeUiState(Boolean active)
        {
            btnStop.Enabled = !active;
            btnStart.Enabled = active;
            chkKeyPress.Enabled = active;
            chkMouse.Enabled = active;
            cmbKey.Enabled = active;
            cmbPeriod.Enabled = active;
            numPeriod.Enabled = active;
        }

        private int getIntervalMultiplier()
        {
            switch (cmbPeriod.SelectedIndex)
            {
                case 0:
                    return 1;
                case 1:
                    return 1000;
                case 2:
                    return 60 * 1000;
                case 3:
                    return 60 * 60 * 1000;
                default:
                    return 1;
            }
        }

        private VirtualKeyCode getKey()
        {
            switch (cmbKey.SelectedIndex)
            {
                case 1:
                    return VirtualKeyCode.LWIN;
                case 2:
                    return VirtualKeyCode.RWIN;
                case 3:
                    return VirtualKeyCode.F1;
                case 4:
                    return VirtualKeyCode.F2;
                case 5:
                    return VirtualKeyCode.F3;
                case 6:
                    return VirtualKeyCode.F4;
                case 7:
                    return VirtualKeyCode.F5;
                case 8:
                    return VirtualKeyCode.F6;
                case 9:
                    return VirtualKeyCode.F7;
                case 10:
                    return VirtualKeyCode.F8;
                case 11:
                    return VirtualKeyCode.F9;
                case 12:
                    return VirtualKeyCode.F10;
                case 13:
                    return VirtualKeyCode.F11;
                case 14:
                    return VirtualKeyCode.F12;
                default:
                    return VirtualKeyCode.LWIN;
            }
        }
    }
}
