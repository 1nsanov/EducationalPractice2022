namespace Task_12_04
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buildGraphic = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.endBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stepBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectFont = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(11, 85);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(447, 240);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // startBox
            // 
            this.startBox.Location = new System.Drawing.Point(11, 24);
            this.startBox.Name = "startBox";
            this.startBox.Size = new System.Drawing.Size(60, 20);
            this.startBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start X";
            // 
            // buildGraphic
            // 
            this.buildGraphic.Location = new System.Drawing.Point(12, 50);
            this.buildGraphic.Name = "buildGraphic";
            this.buildGraphic.Size = new System.Drawing.Size(210, 29);
            this.buildGraphic.TabIndex = 3;
            this.buildGraphic.Text = "Build Graphic";
            this.buildGraphic.UseVisualStyleBackColor = true;
            this.buildGraphic.Click += new System.EventHandler(this.buildGraphic_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "End X";
            // 
            // endBox
            // 
            this.endBox.Location = new System.Drawing.Point(87, 24);
            this.endBox.Name = "endBox";
            this.endBox.Size = new System.Drawing.Size(60, 20);
            this.endBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Step";
            // 
            // stepBox
            // 
            this.stepBox.Location = new System.Drawing.Point(162, 24);
            this.stepBox.Name = "stepBox";
            this.stepBox.Size = new System.Drawing.Size(60, 20);
            this.stepBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 8;
            // 
            // selectFont
            // 
            this.selectFont.Location = new System.Drawing.Point(248, 50);
            this.selectFont.Name = "selectFont";
            this.selectFont.Size = new System.Drawing.Size(210, 29);
            this.selectFont.TabIndex = 9;
            this.selectFont.Text = "Select font";
            this.selectFont.UseVisualStyleBackColor = true;
            this.selectFont.Click += new System.EventHandler(this.selectFont_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 337);
            this.Controls.Add(this.selectFont);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stepBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endBox);
            this.Controls.Add(this.buildGraphic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startBox);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "ЛР №8 Безунов Виктор";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox startBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buildGraphic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox endBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stepBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectFont;
    }
}

