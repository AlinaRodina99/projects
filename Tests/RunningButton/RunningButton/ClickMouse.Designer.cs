namespace RunningButton
{
    partial class ClickMouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClickMouse));
            this.Mouse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Mouse
            // 
            this.Mouse.AutoSize = true;
            this.Mouse.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Mouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mouse.Location = new System.Drawing.Point(374, 208);
            this.Mouse.Name = "Mouse";
            this.Mouse.Size = new System.Drawing.Size(69, 38);
            this.Mouse.TabIndex = 0;
            this.Mouse.Text = "Click me!";
            this.Mouse.UseVisualStyleBackColor = false;
            this.Mouse.Click += new System.EventHandler(this.Mouse_Click);
            this.Mouse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_MouseMove);
            // 
            // ClickMouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Mouse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClickMouse";
            this.Text = "ClickMouse";
            this.Resize += new System.EventHandler(this.ClickMouse_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Mouse;
    }
}

