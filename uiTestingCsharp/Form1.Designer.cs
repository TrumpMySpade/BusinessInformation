
namespace uiTestingCsharp
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
            this.q1Label = new System.Windows.Forms.Label();
            this.q2Label = new System.Windows.Forms.Label();
            this.q1Answer = new System.Windows.Forms.TextBox();
            this.q2Answer = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.q3Answer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // q1Label
            // 
            this.q1Label.AutoSize = true;
            this.q1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.q1Label.Location = new System.Drawing.Point(13, 13);
            this.q1Label.Name = "q1Label";
            this.q1Label.Size = new System.Drawing.Size(48, 18);
            this.q1Label.TabIndex = 0;
            this.q1Label.Text = "Name";
            // 
            // q2Label
            // 
            this.q2Label.AutoSize = true;
            this.q2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.q2Label.Location = new System.Drawing.Point(13, 56);
            this.q2Label.Name = "q2Label";
            this.q2Label.Size = new System.Drawing.Size(108, 18);
            this.q2Label.TabIndex = 1;
            this.q2Label.Text = "Phone Number";
            // 
            // q1Answer
            // 
            this.q1Answer.Location = new System.Drawing.Point(67, 14);
            this.q1Answer.Name = "q1Answer";
            this.q1Answer.Size = new System.Drawing.Size(272, 20);
            this.q1Answer.TabIndex = 2;
            this.q1Answer.TextChanged += new System.EventHandler(this.q1Answer_TextChanged);
            // 
            // q2Answer
            // 
            this.q2Answer.Location = new System.Drawing.Point(127, 54);
            this.q2Answer.Name = "q2Answer";
            this.q2Answer.Size = new System.Drawing.Size(212, 20);
            this.q2Answer.TabIndex = 3;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.submit.Location = new System.Drawing.Point(264, 393);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(12, 399);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 13);
            this.info.TabIndex = 5;
            this.info.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button2.Location = new System.Drawing.Point(183, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "loadInfo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Card Number";
            // 
            // q3Answer
            // 
            this.q3Answer.Location = new System.Drawing.Point(116, 97);
            this.q3Answer.Name = "q3Answer";
            this.q3Answer.Size = new System.Drawing.Size(223, 20);
            this.q3Answer.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 434);
            this.Controls.Add(this.q3Answer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.info);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.q2Answer);
            this.Controls.Add(this.q1Answer);
            this.Controls.Add(this.q2Label);
            this.Controls.Add(this.q1Label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label q1Label;
        private System.Windows.Forms.Label q2Label;
        private System.Windows.Forms.TextBox q1Answer;
        private System.Windows.Forms.TextBox q2Answer;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox q3Answer;
    }
}

