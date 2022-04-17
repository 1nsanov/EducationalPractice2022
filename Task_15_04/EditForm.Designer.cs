namespace Task_15_04
{
    partial class EditForm
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
            this.buttonAcceptEdit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonCancelAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAcceptEdit
            // 
            this.buttonAcceptEdit.Location = new System.Drawing.Point(150, 104);
            this.buttonAcceptEdit.Name = "buttonAcceptEdit";
            this.buttonAcceptEdit.Size = new System.Drawing.Size(125, 35);
            this.buttonAcceptEdit.TabIndex = 45;
            this.buttonAcceptEdit.Text = "Accept";
            this.buttonAcceptEdit.UseVisualStyleBackColor = true;
            this.buttonAcceptEdit.Click += new System.EventHandler(this.buttonAcceptEdit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 44;
            this.label7.Text = "Min value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 43;
            this.label6.Text = "Max value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Value:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 23);
            this.textBox1.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 44);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 23);
            this.textBox2.TabIndex = 40;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(101, 76);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(174, 23);
            this.textBox3.TabIndex = 39;
            // 
            // buttonCancelAccept
            // 
            this.buttonCancelAccept.Location = new System.Drawing.Point(12, 104);
            this.buttonCancelAccept.Name = "buttonCancelAccept";
            this.buttonCancelAccept.Size = new System.Drawing.Size(125, 35);
            this.buttonCancelAccept.TabIndex = 46;
            this.buttonCancelAccept.Text = "Cancel";
            this.buttonCancelAccept.UseVisualStyleBackColor = true;
            this.buttonCancelAccept.Click += new System.EventHandler(this.buttonCancelAccept_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 148);
            this.Controls.Add(this.buttonCancelAccept);
            this.Controls.Add(this.buttonAcceptEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Name = "EditForm";
            this.Text = "Редактирование счетчика";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonAcceptEdit;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button buttonCancelAccept;
    }
}