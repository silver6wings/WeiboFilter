using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeiboCrawler;

namespace LabelingTools
{
    public partial class Form1 : Form
    {
        private Button bt1, bt2;
        private TextBox txb1;

        private bool isLabeling;
        private string fileName;
        private string filePath;
        private Recorder statusRecorder, labelRecorder;
        private Status status;

        public Form1()
        {
            InitializeComponent();

            statusRecorder = new Recorder(false);
            labelRecorder = new Recorder(false);

            this.Width = 800;
            this.Height = 600;
            this.Text = "No File Reading...";

            bt1 = new Button();
            bt1.Text = "普通信息";
            bt1.BackColor = Color.SkyBlue;
            bt1.Location = new Point(50, 450);
            bt1.Size = new Size(300, 80);
            bt1.Click += new EventHandler(bt1_click);
            this.Controls.Add(bt1);

            bt2 = new Button();
            bt2.Text = "垃圾信息";
            bt2.BackColor = Color.Red;
            bt2.ForeColor = Color.White;
            bt2.Location = new Point(400, 450);
            bt2.Size = new Size(300, 80);
            bt2.Click += new EventHandler(bt2_click);
            this.Controls.Add(bt2);

            txb1 = new TextBox();
            txb1.Location = new Point(50, 80);
            txb1.Size = new Size(600, 300);
            txb1.Multiline = true;
            txb1.ScrollBars = ScrollBars.Vertical;
            txb1.WordWrap = true;
            this.Controls.Add(txb1);

            // Set menu item
            MenuItem mi = new MenuItem("Load File");
            mi.Click += new EventHandler(menu_click);

            this.Menu = new MainMenu();
            this.Menu.MenuItems.Add(mi);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isLabeling = false;
        }

        // ### Keyboard Operation ###

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                bt1_click(null, null);
            }
            else if (keyData == Keys.Right)
            {
                bt2_click(null, null);
            }
            return false;
        }

        // ### Control Event ###

        private void menu_click(object s, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt;*.doc)|*.txt;*.doc";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.SafeFileName.ToString();
                filePath = ofd.FileName.ToString();
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                fireLabeling(filePath);
            }
            else
            {
                this.Text = "_(:3」∠)_ Loading failed....";
            }
        }

        private void bt1_click(object s, EventArgs e)
        {
            if (!isLabeling) return;

            refreshNextStatus();
            //normal status do nothing
        }

        private void bt2_click(object s, EventArgs e)
        {
            if (!isLabeling) return;

            if (refreshNextStatus())
            {
                Labeling lbl = new Labeling("Spam", status.Text, status.ID, status.UserID);
                labelRecorder.WriteObject(lbl);
            }
        }

        // ### Custom ###

        private void fireLabeling(string filePath)
        {
            this.Text = filePath;
            statusRecorder.ReadStream(filePath);

            
            string recordPath = "../../_Data/Labeling/" + fileName;
            Console.WriteLine(recordPath);
            labelRecorder.WriteStream(recordPath);
            
            refreshNextStatus();
        }

        // if has next return true
        private bool refreshNextStatus()
        {
            try
            {
                status = (Status)statusRecorder.ReadObject();
                if (status != null)
                {
                    isLabeling = true;
                    txb1.Text = status.Text;
                    txb1.Text += status.UserID;
                    return true;
                }
                else
                {
                    statusRecorder.CloseStream();
                    labelRecorder.CloseStream();
                    isLabeling = false;
                    fileName = "";
                    filePath = "";
                    txb1.Text = "";
                    this.Text = "No File Reading";
                    return false;
                }
            }
            catch
            {
                statusRecorder.CloseStream();
                labelRecorder.CloseStream();
                isLabeling = false;
                fileName = "";
                filePath = "";
                txb1.Text = "";
                this.Text = "No File Reading... Error";
                return false;
            }
        }

    }
}
