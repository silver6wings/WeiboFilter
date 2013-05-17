using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using WeiboCrawler;

namespace LabelingTools
{
    public partial class Form1 : Form
    {
        private bool isLabeling;
        private string labelingPath;
        private string labelingName;

        private Recorder statusRecorder, labelRecorder;
        private Status status;
        private List<Labeling> existLabeling;

        public Form1()
        {
            InitializeComponent();

            labelingPath = "../../_Data/Labeling/";

            statusRecorder = new Recorder(false);
            labelRecorder = new Recorder(false);
            existLabeling = new List<Labeling>();
            
            // Set menu item
            MenuItem mi = new MenuItem("Load File");
            mi.Click += new EventHandler(menu_click);

            this.Menu = new MainMenu();
            this.Menu.MenuItems.Add(mi);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshCheckedBoxes(false);
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

            string filePath = "";
            string fileName = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.SafeFileName.ToString();
                filePath = ofd.FileName.ToString();
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                startLabeling(filePath, fileName);
            }
            else
            {
                this.Text = "_(:3」∠)_ Loading failed....";
            }
        }
        
        private void bt1_click(object s, EventArgs e)
        {
            if (!isLabeling) return;

            Labeling tlb = findLabeling(status.ID);
            if (tlb != null) existLabeling.Remove(tlb);

            existLabeling.Add(new Labeling("Normal", status.Text, status.ID, status.UserID));

            if (!refreshNextStatus()) finishLabeling();
        }

        private void bt2_click(object s, EventArgs e)
        {
            if (!isLabeling) return;

            Labeling tlb = findLabeling(status.ID);
            if (tlb != null) existLabeling.Remove(tlb);

            existLabeling.Add(new Labeling("Spam", status.Text, status.ID, status.UserID));

            if (!refreshNextStatus()) finishLabeling();
        }

        // ### Custom ###

        private void startLabeling(string sourcePath, string sourceName)
        {
            refreshCheckedBoxes(true);

            // 打开标记读取数据流
            labelingName = "Result_" + sourceName;
            string recordPath = labelingPath + labelingName;  

            // 载入已存在的
            if(File.Exists(recordPath))
            {
                labelRecorder.ReadStream(recordPath);            
                existLabeling.Clear();  
                Labeling tl = (Labeling)labelRecorder.ReadObject();
                while(tl != null){
                    existLabeling.Add(tl);
                    tl = (Labeling)labelRecorder.ReadObject();
                }
                labelRecorder.CloseStream();
            }

            // 打开微博读取数据流
            this.Text = sourcePath;
            statusRecorder.ReadStream(sourcePath);

            if (!refreshNextStatus()) finishLabeling();
        }

        private void finishLabeling()
        {
            refreshCheckedBoxes(false);

            // 记录最新的标记结果然后关闭
            string recordPath = labelingPath + labelingName;

            labelRecorder.OverWriteStream(recordPath);
            foreach (Labeling tl in existLabeling)            
                labelRecorder.WriteObject(tl);            
            labelRecorder.CloseStream();
            labelingName = "";

            // 关闭微博读取流
            statusRecorder.CloseStream();

            txb1.Text = "";
            this.Text = "No File Reading";
        }
       
        private bool refreshNextStatus()
        {
            status = null;
            bool foundNext = false;

            // 找到下一个符合过滤需求的Status
            while (!foundNext)
            {
                status = (Status)statusRecorder.ReadObject();

                if (status == null) break;
                else
                {
                    Labeling tlb = findLabeling(status.ID);

                    if (cbUnlabeled.Checked == true && tlb == null)
                        foundNext = true;
                    else if (cbNormal.Checked == true && tlb.Category == "Normal")
                        foundNext = true;
                    else if (cbSpam.Checked == true && tlb.Category == "Spam")
                        foundNext = true;
                }
            }

            // 找到了就显示出来等代标记
            if (foundNext)
            {
                txb1.Text = "Status ID:";
                txb1.Text += status.UserID;
                txb1.Text += "\r\n";
                txb1.Text += status.Text;
            }

            return foundNext;
        }

        private Labeling findLabeling(string statusID)
        {
            foreach (Labeling lb in existLabeling)            
                if (lb.StatusID == status.ID)                
                    return lb;                            
            return null;
        }

        private void refreshCheckedBoxes(bool isDoingLabeling)
        {
            isLabeling = isDoingLabeling;
            cbUnlabeled.Enabled = !isLabeling;
            cbNormal.Enabled = !isLabeling;
            cbSpam.Enabled = !isLabeling;
        }
    }
}
