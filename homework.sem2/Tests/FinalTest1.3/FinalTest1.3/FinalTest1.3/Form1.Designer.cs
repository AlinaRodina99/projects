namespace FinalTest1._3
{
    partial class FormForProgressBar
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
            this.components = new System.ComponentModel.Container();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerForButton = new System.Windows.Forms.Timer(this.components);
            this.progressButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.timerForBar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Blue;
            this.progressBar.Location = new System.Drawing.Point(107, 93);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(305, 52);
            this.progressBar.TabIndex = 0;
            // 
            // timerForButton
            // 
            this.timerForButton.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // progressButton
            // 
            this.progressButton.AutoSize = true;
            this.progressButton.Location = new System.Drawing.Point(216, 181);
            this.progressButton.Name = "progressButton";
            this.progressButton.Size = new System.Drawing.Size(75, 23);
            this.progressButton.TabIndex = 1;
            this.progressButton.Text = "Click me!";
            this.progressButton.UseVisualStyleBackColor = true;
            this.progressButton.Click += new System.EventHandler(this.ProgressButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.Location = new System.Drawing.Point(216, 222);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Visible = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // timerForBar
            // 
            this.timerForBar.Tick += new System.EventHandler(this.TimerForBar_Tick);
            // 
            // FormForProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(520, 280);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.progressButton);
            this.Controls.Add(this.progressBar);
            this.Name = "FormForProgressBar";
            this.Text = "ProgressIndicator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timerForButton;
        private System.Windows.Forms.Button progressButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer timerForBar;
    }
}

