using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MissionControlCenter
{
    public partial class Dashboard : Form
    {
        Image _snapshot;

        public Dashboard()
        {
            InitializeComponent();

            timer1.Interval = (int)numericUpDown_interval.Value;
            timer1.Enabled = true;
            timer1.Stop();
        }
        
        bool _toggleConnect;
        private void button_connect_Click(object sender, EventArgs e)
        {
            if (_toggleConnect)
            {
                _toggleConnect = false;
                TCPClient.Utility.Disconnect();
                button_connect.Text = "Connect to server";
                button_connect.BackColor = Color.YellowGreen;
            }
            else
            {
                _toggleConnect = true;
                var ip = System.Net.IPAddress.Parse(textBox_ip.Text);
                int port = int.Parse(textBox_port.Text);
                TCPClient.Utility.Connect(ip, port);
                button_connect.Text = "Disconnect from the server";
                button_connect.BackColor = Color.Red;
            }
        }

        private void comboBox_windowTitle_DropDown(object sender, EventArgs e)
        {
            object response = TCPClient.Utility.Dialogue("<titles>");
            string[] titles = response as string[];
            if (titles != null)
            {
                comboBox_windowTitle.Items.Clear();
                comboBox_windowTitle.Items.AddRange(titles);
            }
        }

        private void Snapshot()
        {
            object response = TCPClient.Utility.Dialogue("<image>" + (string)comboBox_windowTitle.SelectedItem);
            var snapshot = response as Image;
            if (snapshot != null)
            {
                pictureBox_snapshot.Image = snapshot;
            }
            _snapshot = snapshot;
        }

        private void comboBox_windowTitle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox_windowTitle.SelectedItem as string))
            {
                Snapshot();
            }
        }

        private void textBox_simulated_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                object response = TCPClient.Utility.Dialogue("<press>" + textBox_simulated.Text);
            }
        }

        bool _toggleLoop;
        private void loop_Click(object sender, EventArgs e)
        {
            if (_toggleLoop)
            {
                _toggleLoop = false;
                timer1.Stop();
                button_loop.Text = "LOOP";
            }
            else
            {
                _toggleLoop = true;
                timer1.Start();
                button_loop.Text = "STOP";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Snapshot();
        }

        private void button_updateImage_Click(object sender, EventArgs e)
        {
            Snapshot();
        }

        private void numericUpDown_interval_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown_interval.Value;
        }

        private void label_help_Click(object sender, EventArgs e)
        {
            string message =
                "FORMAT: <SYMBOL> or <HEX_CODE+SYMBOL>\n" +
                "You can see the HEX_CODE here: https://msdn.microsoft.com/en-us/library/dd375731(v=vs.85).aspx\n\n" +
                "For example, we need to open a notepad and write something into it.\n" +
                "The sequence of keystrokes for this:\n" +
                "\tWIN+R -> NOTEPAD -> Enter -> HI\n" +
                "The format for this operation:\n" +
                "\t<0x5B+R><N><O><T><E><P><A><D><0x0D><H><I>\n";
            MessageBox.Show(message, "Format", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_saveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                _snapshot.Save(sfd.FileName, format);
            }
        }
    }
}
