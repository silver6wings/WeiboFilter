namespace Silver6wings.LabelingTools
{
    partial class LabelingForm
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
            this.cbUnlabeled = new System.Windows.Forms.CheckBox();
            this.cbNormal = new System.Windows.Forms.CheckBox();
            this.cbSpam = new System.Windows.Forms.CheckBox();
            this.txbStatusContent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txbLabelingNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbUnlabeled
            // 
            this.cbUnlabeled.AutoSize = true;
            this.cbUnlabeled.Checked = true;
            this.cbUnlabeled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUnlabeled.Location = new System.Drawing.Point(428, 14);
            this.cbUnlabeled.Name = "cbUnlabeled";
            this.cbUnlabeled.Size = new System.Drawing.Size(86, 17);
            this.cbUnlabeled.TabIndex = 0;
            this.cbUnlabeled.Text = "过滤未标记";
            this.cbUnlabeled.UseVisualStyleBackColor = true;
            // 
            // cbNormal
            // 
            this.cbNormal.AutoSize = true;
            this.cbNormal.Location = new System.Drawing.Point(428, 37);
            this.cbNormal.Name = "cbNormal";
            this.cbNormal.Size = new System.Drawing.Size(119, 17);
            this.cbNormal.TabIndex = 1;
            this.cbNormal.Text = "过滤分类：Normal";
            this.cbNormal.UseVisualStyleBackColor = true;
            // 
            // cbSpam
            // 
            this.cbSpam.AutoSize = true;
            this.cbSpam.Location = new System.Drawing.Point(428, 60);
            this.cbSpam.Name = "cbSpam";
            this.cbSpam.Size = new System.Drawing.Size(113, 17);
            this.cbSpam.TabIndex = 2;
            this.cbSpam.Text = "过滤分类：Spam";
            this.cbSpam.UseVisualStyleBackColor = true;
            // 
            // txbStatusContent
            // 
            this.txbStatusContent.Location = new System.Drawing.Point(12, 37);
            this.txbStatusContent.Multiline = true;
            this.txbStatusContent.Name = "txbStatusContent";
            this.txbStatusContent.Size = new System.Drawing.Size(401, 201);
            this.txbStatusContent.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(12, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 103);
            this.button1.TabIndex = 4;
            this.button1.Text = "<< 普通信息 Normal";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.bt1_click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(223, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 103);
            this.button2.TabIndex = 5;
            this.button2.Text = "垃圾信息 Spam >>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.bt2_click);
            // 
            // txbLabelingNum
            // 
            this.txbLabelingNum.Location = new System.Drawing.Point(428, 341);
            this.txbLabelingNum.Name = "txbLabelingNum";
            this.txbLabelingNum.Size = new System.Drawing.Size(119, 20);
            this.txbLabelingNum.TabIndex = 7;
            this.txbLabelingNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "内存中已完成的标记：";
            // 
            // txbFilePath
            // 
            this.txbFilePath.Location = new System.Drawing.Point(12, 11);
            this.txbFilePath.Name = "txbFilePath";
            this.txbFilePath.Size = new System.Drawing.Size(401, 20);
            this.txbFilePath.TabIndex = 9;
            this.txbFilePath.Text = "No File Reading...";
            // 
            // LabelingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 390);
            this.Controls.Add(this.txbFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbLabelingNum);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbStatusContent);
            this.Controls.Add(this.cbSpam);
            this.Controls.Add(this.cbNormal);
            this.Controls.Add(this.cbUnlabeled);
            this.Name = "LabelingForm";
            this.Text = "Labeling Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbUnlabeled;
        private System.Windows.Forms.CheckBox cbNormal;
        private System.Windows.Forms.CheckBox cbSpam;
        private System.Windows.Forms.TextBox txbStatusContent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbLabelingNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFilePath;
    }
}

