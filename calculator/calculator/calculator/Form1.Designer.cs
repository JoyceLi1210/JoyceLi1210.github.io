namespace calculator
{
    partial class calculator
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.formula_print = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.preorder_print = new System.Windows.Forms.TextBox();
            this.bin_print = new System.Windows.Forms.TextBox();
            this.ten_print = new System.Windows.Forms.TextBox();
            this.postorder_print = new System.Windows.Forms.TextBox();
            this.button15 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("新細明體", 16F);
            this.button1.Location = new System.Drawing.Point(25, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "7";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Number_click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("新細明體", 16F);
            this.button2.Location = new System.Drawing.Point(268, 351);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 75);
            this.button2.TabIndex = 1;
            this.button2.Text = "/";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Operation_click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("新細明體", 16F);
            this.button3.Location = new System.Drawing.Point(25, 270);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 75);
            this.button3.TabIndex = 2;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Number_click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("新細明體", 16F);
            this.button4.Location = new System.Drawing.Point(187, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 75);
            this.button4.TabIndex = 3;
            this.button4.Text = "6";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Number_click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("新細明體", 16F);
            this.button5.Location = new System.Drawing.Point(106, 189);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 75);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Number_click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("新細明體", 16F);
            this.button6.Location = new System.Drawing.Point(25, 189);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 75);
            this.button6.TabIndex = 5;
            this.button6.Text = "4";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Number_click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("新細明體", 16F);
            this.button7.Location = new System.Drawing.Point(187, 108);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 75);
            this.button7.TabIndex = 6;
            this.button7.Text = "9";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Number_click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("新細明體", 16F);
            this.button8.Location = new System.Drawing.Point(106, 108);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 75);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Number_click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button9.Font = new System.Drawing.Font("新細明體", 16F);
            this.button9.Location = new System.Drawing.Point(268, 270);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 75);
            this.button9.TabIndex = 8;
            this.button9.Text = "*";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.Operation_click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button10.Font = new System.Drawing.Font("新細明體", 16F);
            this.button10.Location = new System.Drawing.Point(268, 189);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 75);
            this.button10.TabIndex = 9;
            this.button10.Text = "-";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Operation_click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button11.Font = new System.Drawing.Font("新細明體", 16F);
            this.button11.Location = new System.Drawing.Point(268, 108);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 75);
            this.button11.TabIndex = 10;
            this.button11.Text = "+";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.Operation_click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button12.Font = new System.Drawing.Font("新細明體", 16F);
            this.button12.Location = new System.Drawing.Point(187, 270);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 75);
            this.button12.TabIndex = 11;
            this.button12.Text = "3";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.Number_click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Font = new System.Drawing.Font("新細明體", 16F);
            this.button13.Location = new System.Drawing.Point(106, 270);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 75);
            this.button13.TabIndex = 12;
            this.button13.Text = "2";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.Number_click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button14.Font = new System.Drawing.Font("新細明體", 16F);
            this.button14.Location = new System.Drawing.Point(25, 351);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(237, 75);
            this.button14.TabIndex = 13;
            this.button14.Text = "0";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.Zero_click);
            // 
            // formula_print
            // 
            this.formula_print.Font = new System.Drawing.Font("新細明體", 26F);
            this.formula_print.Location = new System.Drawing.Point(25, 43);
            this.formula_print.Name = "formula_print";
            this.formula_print.Size = new System.Drawing.Size(399, 59);
            this.formula_print.TabIndex = 15;
            this.formula_print.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("新細明體", 16F);
            this.button16.Location = new System.Drawing.Point(349, 108);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 75);
            this.button16.TabIndex = 16;
            this.button16.Text = "C";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Delete_click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("新細明體", 16F);
            this.button17.Location = new System.Drawing.Point(349, 189);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 75);
            this.button17.TabIndex = 17;
            this.button17.Text = "AC";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.DeleteAll_click);
            // 
            // preorder_print
            // 
            this.preorder_print.Font = new System.Drawing.Font("新細明體", 26F);
            this.preorder_print.Location = new System.Drawing.Point(674, 61);
            this.preorder_print.Name = "preorder_print";
            this.preorder_print.Size = new System.Drawing.Size(374, 59);
            this.preorder_print.TabIndex = 19;
            this.preorder_print.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bin_print
            // 
            this.bin_print.Font = new System.Drawing.Font("新細明體", 26F);
            this.bin_print.Location = new System.Drawing.Point(674, 352);
            this.bin_print.Name = "bin_print";
            this.bin_print.Size = new System.Drawing.Size(374, 59);
            this.bin_print.TabIndex = 20;
            this.bin_print.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ten_print
            // 
            this.ten_print.Font = new System.Drawing.Font("新細明體", 26F);
            this.ten_print.Location = new System.Drawing.Point(674, 256);
            this.ten_print.Name = "ten_print";
            this.ten_print.Size = new System.Drawing.Size(374, 59);
            this.ten_print.TabIndex = 21;
            this.ten_print.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // postorder_print
            // 
            this.postorder_print.Font = new System.Drawing.Font("新細明體", 26F);
            this.postorder_print.Location = new System.Drawing.Point(674, 157);
            this.postorder_print.Name = "postorder_print";
            this.postorder_print.Size = new System.Drawing.Size(374, 59);
            this.postorder_print.TabIndex = 22;
            this.postorder_print.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("新細明體", 16F);
            this.button15.Location = new System.Drawing.Point(349, 270);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 156);
            this.button15.TabIndex = 31;
            this.button15.Text = "=";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Enter_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(524, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 44);
            this.label1.TabIndex = 32;
            this.label1.Text = "前序";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(524, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 44);
            this.label2.TabIndex = 33;
            this.label2.Text = "後序";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("標楷體", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(509, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 44);
            this.label4.TabIndex = 35;
            this.label4.Text = "十進位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("標楷體", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(509, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 44);
            this.label5.TabIndex = 36;
            this.label5.Text = "二進位";
            // 
            // calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1077, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.postorder_print);
            this.Controls.Add(this.ten_print);
            this.Controls.Add(this.bin_print);
            this.Controls.Add(this.preorder_print);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.formula_print);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "calculator";
            this.Text = "Calculator-怡靜";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox formula_print;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.TextBox preorder_print;
        private System.Windows.Forms.TextBox bin_print;
        private System.Windows.Forms.TextBox ten_print;
        private System.Windows.Forms.TextBox postorder_print;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

