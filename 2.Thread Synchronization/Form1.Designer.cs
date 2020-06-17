namespace _2.Thread_Synchronization
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnStartProduce = new System.Windows.Forms.Button();
            this.btnStartConsume = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.tbProduceSpeed = new System.Windows.Forms.TrackBar();
            this.tbConsumeSpeed = new System.Windows.Forms.TrackBar();
            this.lbProduceSpeed = new System.Windows.Forms.Label();
            this.lbConsumeSpeed = new System.Windows.Forms.Label();
            this.lbProduceStatus = new System.Windows.Forms.Label();
            this.lbConsumeStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnManual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbProduceSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConsumeSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(145, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(423, 256);
            this.listBox1.TabIndex = 0;
            // 
            // btnStartProduce
            // 
            this.btnStartProduce.Location = new System.Drawing.Point(206, 312);
            this.btnStartProduce.Name = "btnStartProduce";
            this.btnStartProduce.Size = new System.Drawing.Size(75, 23);
            this.btnStartProduce.TabIndex = 1;
            this.btnStartProduce.Text = "开始生产";
            this.btnStartProduce.UseVisualStyleBackColor = true;
            this.btnStartProduce.Click += new System.EventHandler(this.btnStartProduce_Click);
            // 
            // btnStartConsume
            // 
            this.btnStartConsume.Location = new System.Drawing.Point(415, 312);
            this.btnStartConsume.Name = "btnStartConsume";
            this.btnStartConsume.Size = new System.Drawing.Size(75, 23);
            this.btnStartConsume.TabIndex = 1;
            this.btnStartConsume.Text = "开始消费";
            this.btnStartConsume.UseVisualStyleBackColor = true;
            this.btnStartConsume.Click += new System.EventHandler(this.btnStartConsume_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "生产速度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "消费速度:";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(583, 46);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(11, 12);
            this.lbCount.TabIndex = 3;
            this.lbCount.Text = "0";
            // 
            // tbProduceSpeed
            // 
            this.tbProduceSpeed.Location = new System.Drawing.Point(234, 388);
            this.tbProduceSpeed.Minimum = 1;
            this.tbProduceSpeed.Name = "tbProduceSpeed";
            this.tbProduceSpeed.Size = new System.Drawing.Size(104, 45);
            this.tbProduceSpeed.TabIndex = 4;
            this.tbProduceSpeed.Value = 1;
            this.tbProduceSpeed.Scroll += new System.EventHandler(this.tbProduceSpeed_Scroll);
            // 
            // tbConsumeSpeed
            // 
            this.tbConsumeSpeed.Location = new System.Drawing.Point(442, 388);
            this.tbConsumeSpeed.Minimum = 1;
            this.tbConsumeSpeed.Name = "tbConsumeSpeed";
            this.tbConsumeSpeed.Size = new System.Drawing.Size(104, 45);
            this.tbConsumeSpeed.TabIndex = 4;
            this.tbConsumeSpeed.Value = 1;
            this.tbConsumeSpeed.Scroll += new System.EventHandler(this.tbConsumeSpeed_Scroll);
            // 
            // lbProduceSpeed
            // 
            this.lbProduceSpeed.AutoSize = true;
            this.lbProduceSpeed.Location = new System.Drawing.Point(247, 436);
            this.lbProduceSpeed.Name = "lbProduceSpeed";
            this.lbProduceSpeed.Size = new System.Drawing.Size(11, 12);
            this.lbProduceSpeed.TabIndex = 3;
            this.lbProduceSpeed.Text = "1";
            // 
            // lbConsumeSpeed
            // 
            this.lbConsumeSpeed.AutoSize = true;
            this.lbConsumeSpeed.Location = new System.Drawing.Point(440, 436);
            this.lbConsumeSpeed.Name = "lbConsumeSpeed";
            this.lbConsumeSpeed.Size = new System.Drawing.Size(11, 12);
            this.lbConsumeSpeed.TabIndex = 3;
            this.lbConsumeSpeed.Text = "1";
            // 
            // lbProduceStatus
            // 
            this.lbProduceStatus.AutoSize = true;
            this.lbProduceStatus.Location = new System.Drawing.Point(204, 297);
            this.lbProduceStatus.Name = "lbProduceStatus";
            this.lbProduceStatus.Size = new System.Drawing.Size(0, 12);
            this.lbProduceStatus.TabIndex = 5;
            // 
            // lbConsumeStatus
            // 
            this.lbConsumeStatus.AutoSize = true;
            this.lbConsumeStatus.Location = new System.Drawing.Point(413, 297);
            this.lbConsumeStatus.Name = "lbConsumeStatus";
            this.lbConsumeStatus.Size = new System.Drawing.Size(0, 12);
            this.lbConsumeStatus.TabIndex = 5;
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(12, 444);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 6;
            this.btnManual.Text = "手动添加";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.lbConsumeStatus);
            this.Controls.Add(this.lbProduceStatus);
            this.Controls.Add(this.tbConsumeSpeed);
            this.Controls.Add(this.tbProduceSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.lbConsumeSpeed);
            this.Controls.Add(this.lbProduceSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartConsume);
            this.Controls.Add(this.btnStartProduce);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbProduceSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConsumeSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnStartProduce;
        private System.Windows.Forms.Button btnStartConsume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.TrackBar tbProduceSpeed;
        private System.Windows.Forms.TrackBar tbConsumeSpeed;
        private System.Windows.Forms.Label lbProduceSpeed;
        private System.Windows.Forms.Label lbConsumeSpeed;
        private System.Windows.Forms.Label lbProduceStatus;
        private System.Windows.Forms.Label lbConsumeStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnManual;
    }
}