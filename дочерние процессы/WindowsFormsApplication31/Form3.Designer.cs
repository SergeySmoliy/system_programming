namespace WindowsFormsApplication31
{
    partial class Form3
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
            this.AvailableAssemblies = new System.Windows.Forms.ListBox();
            this.StartedAssemblies = new System.Windows.Forms.ListBox();
            this.Start = new System.Windows.Forms.Button();
            this.Stop_buton = new System.Windows.Forms.Button();
            this.CloseWindow = new System.Windows.Forms.Button();
            this.Runcalc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AvailableAssemblies
            // 
            this.AvailableAssemblies.FormattingEnabled = true;
            this.AvailableAssemblies.ItemHeight = 16;
            this.AvailableAssemblies.Location = new System.Drawing.Point(565, 88);
            this.AvailableAssemblies.Name = "AvailableAssemblies";
            this.AvailableAssemblies.Size = new System.Drawing.Size(213, 276);
            this.AvailableAssemblies.TabIndex = 0;
            this.AvailableAssemblies.SelectedIndexChanged += new System.EventHandler(this.AvailableAssemblies_SelectedIndexChanged);
            // 
            // StartedAssemblies
            // 
            this.StartedAssemblies.FormattingEnabled = true;
            this.StartedAssemblies.ItemHeight = 16;
            this.StartedAssemblies.Location = new System.Drawing.Point(83, 88);
            this.StartedAssemblies.Name = "StartedAssemblies";
            this.StartedAssemblies.Size = new System.Drawing.Size(212, 276);
            this.StartedAssemblies.TabIndex = 1;
        
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(403, 105);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop_buton
            // 
            this.Stop_buton.Location = new System.Drawing.Point(403, 153);
            this.Stop_buton.Name = "Stop_buton";
            this.Stop_buton.Size = new System.Drawing.Size(75, 23);
            this.Stop_buton.TabIndex = 3;
            this.Stop_buton.Text = "Stop";
            this.Stop_buton.UseVisualStyleBackColor = true;
            this.Stop_buton.Click += new System.EventHandler(this.Stop_buton_Click);
            // 
            // CloseWindow
            // 
            this.CloseWindow.Location = new System.Drawing.Point(403, 203);
            this.CloseWindow.Name = "CloseWindow";
            this.CloseWindow.Size = new System.Drawing.Size(75, 23);
            this.CloseWindow.TabIndex = 4;
            this.CloseWindow.Text = "CloseWindow";
            this.CloseWindow.UseVisualStyleBackColor = true;
            this.CloseWindow.Click += new System.EventHandler(this.CloseWindow_Click);
            // 
            // Runcalc
            // 
            this.Runcalc.Location = new System.Drawing.Point(403, 256);
            this.Runcalc.Name = "Runcalc";
            this.Runcalc.Size = new System.Drawing.Size(75, 23);
            this.Runcalc.TabIndex = 6;
            this.Runcalc.Text = "Runcalc";
            this.Runcalc.UseVisualStyleBackColor = true;
            this.Runcalc.Click += new System.EventHandler(this.Runcalc_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 627);
            this.Controls.Add(this.Runcalc);
            this.Controls.Add(this.CloseWindow);
            this.Controls.Add(this.Stop_buton);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.StartedAssemblies);
            this.Controls.Add(this.AvailableAssemblies);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AvailableAssemblies;
        private System.Windows.Forms.ListBox StartedAssemblies;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop_buton;
        private System.Windows.Forms.Button CloseWindow;
  
        private System.Windows.Forms.Button Runcalc;
    }
}