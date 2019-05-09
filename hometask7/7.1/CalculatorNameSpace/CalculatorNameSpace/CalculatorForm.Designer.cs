namespace CalculatorNameSpace
{
    partial class CalculatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            this.NumberOne = new System.Windows.Forms.Button();
            this.NumberSeven = new System.Windows.Forms.Button();
            this.numberEight = new System.Windows.Forms.Button();
            this.numberNine = new System.Windows.Forms.Button();
            this.NumberSix = new System.Windows.Forms.Button();
            this.NumberFive = new System.Windows.Forms.Button();
            this.NumberFour = new System.Windows.Forms.Button();
            this.NumberThree = new System.Windows.Forms.Button();
            this.NumberTwo = new System.Windows.Forms.Button();
            this.expressionBox = new System.Windows.Forms.TextBox();
            this.numberZero = new System.Windows.Forms.Button();
            this.point = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.divide = new System.Windows.Forms.Button();
            this.sqrt = new System.Windows.Forms.Button();
            this.square = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.changeSign = new System.Windows.Forms.Button();
            this.clearAllExpression = new System.Windows.Forms.Button();
            this.currentExpressionBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NumberOne
            // 
            this.NumberOne.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOne.Location = new System.Drawing.Point(32, 99);
            this.NumberOne.Name = "NumberOne";
            this.NumberOne.Size = new System.Drawing.Size(53, 46);
            this.NumberOne.TabIndex = 0;
            this.NumberOne.Text = "1";
            this.NumberOne.UseVisualStyleBackColor = true;
            this.NumberOne.Click += new System.EventHandler(this.NumberOneClick);
            // 
            // NumberSeven
            // 
            this.NumberSeven.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberSeven.Location = new System.Drawing.Point(32, 203);
            this.NumberSeven.Name = "NumberSeven";
            this.NumberSeven.Size = new System.Drawing.Size(53, 46);
            this.NumberSeven.TabIndex = 1;
            this.NumberSeven.Text = "7";
            this.NumberSeven.UseVisualStyleBackColor = true;
            this.NumberSeven.Click += new System.EventHandler(this.NumberSevenClick);
            // 
            // numberEight
            // 
            this.numberEight.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberEight.Location = new System.Drawing.Point(91, 203);
            this.numberEight.Name = "numberEight";
            this.numberEight.Size = new System.Drawing.Size(53, 46);
            this.numberEight.TabIndex = 2;
            this.numberEight.Text = "8";
            this.numberEight.UseVisualStyleBackColor = true;
            this.numberEight.Click += new System.EventHandler(this.NumberEightClick);
            // 
            // numberNine
            // 
            this.numberNine.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberNine.Location = new System.Drawing.Point(150, 203);
            this.numberNine.Name = "numberNine";
            this.numberNine.Size = new System.Drawing.Size(53, 46);
            this.numberNine.TabIndex = 3;
            this.numberNine.Text = "9";
            this.numberNine.UseVisualStyleBackColor = true;
            this.numberNine.Click += new System.EventHandler(this.NumberNineClick);
            // 
            // NumberSix
            // 
            this.NumberSix.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberSix.Location = new System.Drawing.Point(150, 151);
            this.NumberSix.Name = "NumberSix";
            this.NumberSix.Size = new System.Drawing.Size(53, 46);
            this.NumberSix.TabIndex = 4;
            this.NumberSix.Text = "6";
            this.NumberSix.UseVisualStyleBackColor = true;
            this.NumberSix.Click += new System.EventHandler(this.NumberSixClick);
            // 
            // NumberFive
            // 
            this.NumberFive.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberFive.Location = new System.Drawing.Point(91, 151);
            this.NumberFive.Name = "NumberFive";
            this.NumberFive.Size = new System.Drawing.Size(53, 46);
            this.NumberFive.TabIndex = 5;
            this.NumberFive.Text = "5";
            this.NumberFive.UseVisualStyleBackColor = true;
            this.NumberFive.Click += new System.EventHandler(this.NumberFiveClick);
            // 
            // NumberFour
            // 
            this.NumberFour.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberFour.Location = new System.Drawing.Point(32, 151);
            this.NumberFour.Name = "NumberFour";
            this.NumberFour.Size = new System.Drawing.Size(53, 46);
            this.NumberFour.TabIndex = 6;
            this.NumberFour.Text = "4";
            this.NumberFour.UseVisualStyleBackColor = true;
            this.NumberFour.Click += new System.EventHandler(this.NumberFourClick);
            // 
            // NumberThree
            // 
            this.NumberThree.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberThree.Location = new System.Drawing.Point(150, 99);
            this.NumberThree.Name = "NumberThree";
            this.NumberThree.Size = new System.Drawing.Size(53, 46);
            this.NumberThree.TabIndex = 7;
            this.NumberThree.Text = "3";
            this.NumberThree.UseVisualStyleBackColor = true;
            this.NumberThree.Click += new System.EventHandler(this.NumberThreeClick);
            // 
            // NumberTwo
            // 
            this.NumberTwo.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberTwo.Location = new System.Drawing.Point(91, 99);
            this.NumberTwo.Name = "NumberTwo";
            this.NumberTwo.Size = new System.Drawing.Size(53, 46);
            this.NumberTwo.TabIndex = 8;
            this.NumberTwo.Text = "2";
            this.NumberTwo.UseVisualStyleBackColor = true;
            this.NumberTwo.Click += new System.EventHandler(this.NumberTwoClick);
            // 
            // expressionBox
            // 
            this.expressionBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expressionBox.Location = new System.Drawing.Point(32, 25);
            this.expressionBox.Name = "expressionBox";
            this.expressionBox.ReadOnly = true;
            this.expressionBox.Size = new System.Drawing.Size(313, 32);
            this.expressionBox.TabIndex = 9;
            this.expressionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numberZero
            // 
            this.numberZero.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberZero.Location = new System.Drawing.Point(91, 255);
            this.numberZero.Name = "numberZero";
            this.numberZero.Size = new System.Drawing.Size(53, 46);
            this.numberZero.TabIndex = 10;
            this.numberZero.Text = "0";
            this.numberZero.UseVisualStyleBackColor = true;
            this.numberZero.Click += new System.EventHandler(this.NumberZeroClick);
            // 
            // point
            // 
            this.point.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.point.Location = new System.Drawing.Point(32, 255);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(53, 46);
            this.point.TabIndex = 11;
            this.point.Text = ",";
            this.point.UseVisualStyleBackColor = true;
            this.point.Click += new System.EventHandler(this.PointClick);
            // 
            // plus
            // 
            this.plus.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plus.Location = new System.Drawing.Point(228, 151);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(47, 46);
            this.plus.TabIndex = 12;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.PlusClick);
            // 
            // minus
            // 
            this.minus.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minus.Location = new System.Drawing.Point(298, 151);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(47, 46);
            this.minus.TabIndex = 13;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.MinusClick);
            // 
            // multiply
            // 
            this.multiply.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiply.Location = new System.Drawing.Point(228, 203);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(47, 46);
            this.multiply.TabIndex = 14;
            this.multiply.Text = "*";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.Click += new System.EventHandler(this.MultiplyClick);
            // 
            // divide
            // 
            this.divide.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.divide.Location = new System.Drawing.Point(298, 203);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(47, 46);
            this.divide.TabIndex = 15;
            this.divide.Text = "/";
            this.divide.UseVisualStyleBackColor = true;
            this.divide.Click += new System.EventHandler(this.DivideClick);
            // 
            // sqrt
            // 
            this.sqrt.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sqrt.Location = new System.Drawing.Point(228, 255);
            this.sqrt.Name = "sqrt";
            this.sqrt.Size = new System.Drawing.Size(47, 46);
            this.sqrt.TabIndex = 16;
            this.sqrt.Text = "√";
            this.sqrt.UseVisualStyleBackColor = true;
            this.sqrt.Click += new System.EventHandler(this.SqrtClick);
            // 
            // square
            // 
            this.square.Font = new System.Drawing.Font("Times New Roman", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.square.Location = new System.Drawing.Point(298, 257);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(47, 46);
            this.square.TabIndex = 17;
            this.square.Text = "x^2";
            this.square.UseVisualStyleBackColor = true;
            this.square.Click += new System.EventHandler(this.SquareClick);
            // 
            // calculate
            // 
            this.calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculate.Location = new System.Drawing.Point(153, 255);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(50, 46);
            this.calculate.TabIndex = 18;
            this.calculate.Text = "=";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.CalculateClick);
            // 
            // changeSign
            // 
            this.changeSign.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeSign.Location = new System.Drawing.Point(298, 99);
            this.changeSign.Name = "changeSign";
            this.changeSign.Size = new System.Drawing.Size(47, 46);
            this.changeSign.TabIndex = 19;
            this.changeSign.Text = "±";
            this.changeSign.UseVisualStyleBackColor = true;
            this.changeSign.Click += new System.EventHandler(this.ChangeSignClick);
            // 
            // clearAllExpression
            // 
            this.clearAllExpression.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearAllExpression.Location = new System.Drawing.Point(228, 99);
            this.clearAllExpression.Name = "clearAllExpression";
            this.clearAllExpression.Size = new System.Drawing.Size(47, 46);
            this.clearAllExpression.TabIndex = 22;
            this.clearAllExpression.Text = "C";
            this.clearAllExpression.UseVisualStyleBackColor = true;
            this.clearAllExpression.Click += new System.EventHandler(this.ClearAllExpressionClick);
            // 
            // currentExpressionBox
            // 
            this.currentExpressionBox.Location = new System.Drawing.Point(32, 60);
            this.currentExpressionBox.Name = "currentExpressionBox";
            this.currentExpressionBox.Size = new System.Drawing.Size(313, 36);
            this.currentExpressionBox.TabIndex = 24;
            this.currentExpressionBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(376, 320);
            this.Controls.Add(this.currentExpressionBox);
            this.Controls.Add(this.clearAllExpression);
            this.Controls.Add(this.changeSign);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.square);
            this.Controls.Add(this.sqrt);
            this.Controls.Add(this.divide);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.point);
            this.Controls.Add(this.numberZero);
            this.Controls.Add(this.expressionBox);
            this.Controls.Add(this.NumberTwo);
            this.Controls.Add(this.NumberThree);
            this.Controls.Add(this.NumberFour);
            this.Controls.Add(this.NumberFive);
            this.Controls.Add(this.NumberSix);
            this.Controls.Add(this.numberNine);
            this.Controls.Add(this.numberEight);
            this.Controls.Add(this.NumberSeven);
            this.Controls.Add(this.NumberOne);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CalculatorFormKeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NumberOne;
        private System.Windows.Forms.Button NumberSeven;
        private System.Windows.Forms.Button numberEight;
        private System.Windows.Forms.Button numberNine;
        private System.Windows.Forms.Button NumberSix;
        private System.Windows.Forms.Button NumberFive;
        private System.Windows.Forms.Button NumberFour;
        private System.Windows.Forms.Button NumberThree;
        private System.Windows.Forms.Button NumberTwo;
        private System.Windows.Forms.TextBox expressionBox;
        private System.Windows.Forms.Button numberZero;
        private System.Windows.Forms.Button point;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button multiply;
        private System.Windows.Forms.Button divide;
        private System.Windows.Forms.Button sqrt;
        private System.Windows.Forms.Button square;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button changeSign;
        private System.Windows.Forms.Button clearAllExpression;
        private System.Windows.Forms.Label currentExpressionBox;
    }
}

