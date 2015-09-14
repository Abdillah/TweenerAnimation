namespace TweenerStudio
{
    partial class Displayer
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
            this.canvas = new System.Windows.Forms.Panel();
            this.play_btn = new System.Windows.Forms.Button();
            this.progressbar = new System.Windows.Forms.TrackBar();
            this.reverse_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.progressbar)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(609, 425);
            this.canvas.TabIndex = 0;
            // 
            // play_btn
            // 
            this.play_btn.Location = new System.Drawing.Point(569, 443);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(52, 44);
            this.play_btn.TabIndex = 1;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_Click);
            // 
            // progressbar
            // 
            this.progressbar.Location = new System.Drawing.Point(77, 443);
            this.progressbar.Maximum = 100;
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(486, 45);
            this.progressbar.TabIndex = 2;
            this.progressbar.Scroll += new System.EventHandler(this.progressbar_Scroll);
            // 
            // reverse_btn
            // 
            this.reverse_btn.Location = new System.Drawing.Point(12, 444);
            this.reverse_btn.Name = "reverse_btn";
            this.reverse_btn.Size = new System.Drawing.Size(59, 44);
            this.reverse_btn.TabIndex = 3;
            this.reverse_btn.Text = "Reverse";
            this.reverse_btn.UseVisualStyleBackColor = true;
            this.reverse_btn.Click += new System.EventHandler(this.reverse_btn_Click);
            // 
            // Displayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 495);
            this.Controls.Add(this.reverse_btn);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Displayer";
            this.Text = "Tweener Studio";
            ((System.ComponentModel.ISupportInitialize)(this.progressbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.TrackBar progressbar;
        private System.Windows.Forms.Button reverse_btn;
    }
}

