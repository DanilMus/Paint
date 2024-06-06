namespace NewPaint
{
    partial class PluginProcessingForm
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
            label1 = new Label();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 34);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(24, 62);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(345, 23);
            progressBar1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(294, 102);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = true;
            // 
            // PluginProcessingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 149);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Name = "PluginProcessingForm";
            Text = "PluginProcessingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ProgressBar progressBar1;
        private Button button1;
    }
}