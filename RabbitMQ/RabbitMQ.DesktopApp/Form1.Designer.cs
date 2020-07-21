namespace RabbitMQ.DesktopApp
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
            this.SendBtn = new System.Windows.Forms.Button();
            this.PublishBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(101, 32);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(137, 28);
            this.SendBtn.TabIndex = 1;
            this.SendBtn.Text = "Send Message";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // PublishBtn
            // 
            this.PublishBtn.Location = new System.Drawing.Point(101, 102);
            this.PublishBtn.Margin = new System.Windows.Forms.Padding(4);
            this.PublishBtn.Name = "PublishBtn";
            this.PublishBtn.Size = new System.Drawing.Size(137, 28);
            this.PublishBtn.TabIndex = 5;
            this.PublishBtn.Text = "Publish Message";
            this.PublishBtn.UseVisualStyleBackColor = true;
            this.PublishBtn.Click += new System.EventHandler(this.PublishBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 177);
            this.Controls.Add(this.PublishBtn);
            this.Controls.Add(this.SendBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button PublishBtn;
    }
}

