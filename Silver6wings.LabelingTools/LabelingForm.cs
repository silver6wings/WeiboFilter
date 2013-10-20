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

using Silver6wings.WeiboTools;

namespace Silver6wings.LabelingTools
{
    public partial class LabelingForm : Form
    {
        private bool isLabeling;

        private Serializer labelingSerializer;
        private Serializer statusSerializer;
        private List<Labeling> doneLabeling; // 记录已经完成的标记l列表  

        private Status status;
        
        public LabelingForm()
        {
            InitializeComponent();

            labelingSerializer = new Serializer(false);
            statusSerializer = new Serializer(false); 
            doneLabeling = new List<Labeling>();
            
            // Set menu item
            MenuItem miLoad = new MenuItem("Load");
            miLoad.Click += new EventHandler(menuLoad_click);

            MenuItem miSave = new MenuItem("Save");
            miSave.Click += new EventHandler(menuSave_click);

            MenuItem miClear = new MenuItem("Clear");
            miClear.Click += new EventHandler(menuClear_click);

            MenuItem miFiltering = new MenuItem("Filtering");
            miFiltering.Click += new EventHandler(menuFiltering_click);

            this.Menu = new MainMenu();
            this.Menu.MenuItems.Add(miLoad);
            this.Menu.MenuItems.Add(miSave);
            this.Menu.MenuItems.Add(miClear);
            this.Menu.MenuItems.Add(miFiltering);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshCheckedBoxes(false);
        }

        private void menuLoad_click(object s, EventArgs e)
        {
            if (isLabeling) return;

            // 选择要标记的Status文件
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt;*.doc)|*.txt;*.doc";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            ofd.InitialDirectory = Application.StartupPath;

            string filePath = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //fileName = ofd.SafeFileName.ToString();
                filePath = ofd.FileName.ToString();
                Console.WriteLine(filePath);
            }

            // 如果文件路径没问题，就开始读
            if (File.Exists(filePath)) 
            {
                startLabeling(filePath);
                return;
            } else MessageBox.Show("_(:3」∠)_ Load failed....");
        }

        private void menuSave_click(object s, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(*.txt;*.doc)|*.txt;*.doc";
            sfd.FilterIndex = 1;
            sfd.FileName = "";
            sfd.InitialDirectory = Application.StartupPath;

            string filePath = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //fileName = ofd.SafeFileName.ToString();
                filePath = sfd.FileName.ToString();
                Console.WriteLine(filePath);
            }

            // 覆盖记录最新的标记结果然后关闭
            try
            {
                labelingSerializer.OverWriteStream(filePath);

                foreach (Labeling tl in doneLabeling)
                {
                    labelingSerializer.WriteObject(tl);
                }
                labelingSerializer.CloseStream();

                MessageBox.Show("Save finished.");
            }
            catch
            {
                MessageBox.Show("_(:3」∠)_ Save failed....");
            }
        }

        private void menuClear_click(object s, EventArgs e)
        {
            // 清空内存
            doneLabeling.Clear();
            refreshRecord(doneLabeling.Count);
        }

        private void menuFiltering_click(object s, EventArgs e)
        {
        }

        private void bt1_click(object s, EventArgs e)
        {
            if (!isLabeling) return;

            // 标记为普通
            doneLabeling.Add(new Labeling("Normal", status.Text, status.ID, status.UserID));
            refreshRecord(doneLabeling.Count);

            if (!refreshNextStatus()) finishLabeling();
        }

        private void bt2_click(object s, EventArgs e)
        {          
            if (!isLabeling) return;

            // 标记为垃圾信息
            doneLabeling.Add(new Labeling("Spam", status.Text, status.ID, status.UserID));
            refreshRecord(doneLabeling.Count);

            if (!refreshNextStatus()) finishLabeling();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left) bt1_click(null, null);
            if (keyData == Keys.Right) bt2_click(null, null);
            return false;
        }

        // ### Custom ###

        private void startLabeling(string sourcePath)
        {
            // 锁上CheckBoxes
            refreshCheckedBoxes(true);

            // 打开微博读取数据流
            txbFilePath.Text = sourcePath;
            statusSerializer.ReadStream(sourcePath);

            // 找文件中第一条微博
            if (!refreshNextStatus()) finishLabeling();
        }

        private void finishLabeling()
        {
            // 解锁CheckBoxes
            refreshCheckedBoxes(false);

            // 关闭微博读取流
            statusSerializer.CloseStream();

            // 清空内容显示
            txbStatusContent.Text = "";
            txbFilePath.Text = "No File Reading...";
        }

        private bool refreshNextStatus()
        {
            // 找到下一个符合过滤需求的Status
            status = (Status)statusSerializer.ReadNextObject();
            if (status == null) return false;

            // 找到了就显示出来等代标记
            txbStatusContent.Text = "Status ID:";
            txbStatusContent.Text += status.UserID;
            txbStatusContent.Text += "\r\n";
            txbStatusContent.Text += status.Text;

            return true;
        }

        private void refreshCheckedBoxes(bool isDoingLabeling)
        {
            isLabeling = isDoingLabeling;
            cbUnlabeled.Enabled = !isLabeling;
            cbNormal.Enabled = !isLabeling;
            cbSpam.Enabled = !isLabeling;
        }

        private void refreshRecord(int num)
        {
            txbLabelingNum.Text = num.ToString();
        }

    }
}
