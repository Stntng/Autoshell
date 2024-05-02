

namespace Autoshell
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			panel1 = new Panel();
			button3 = new Button();
			button2 = new Button();
			label1 = new Label();
			maskedTextBox1 = new MaskedTextBox();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = Color.Silver;
			panel1.Controls.Add(button3);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(maskedTextBox1);
			panel1.Location = new Point(12, 25);
			panel1.Name = "panel1";
			panel1.Size = new Size(200, 164);
			panel1.TabIndex = 0;
			// 
			// button3
			// 
			button3.Location = new Point(98, 108);
			button3.Name = "button3";
			button3.Size = new Size(75, 23);
			button3.TabIndex = 5;
			button3.Text = "Джарвис";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// button2
			// 
			button2.Location = new Point(17, 108);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 4;
			button2.Text = "Грэкхэм";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(17, 11);
			label1.Name = "label1";
			label1.Size = new Size(151, 15);
			label1.TabIndex = 2;
			label1.Text = "Введите количество точек";
			// 
			// maskedTextBox1
			// 
			maskedTextBox1.Location = new Point(46, 51);
			maskedTextBox1.Name = "maskedTextBox1";
			maskedTextBox1.Size = new Size(100, 23);
			maskedTextBox1.TabIndex = 1;
			maskedTextBox1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
			maskedTextBox1.MaskInputRejected += maskedTextBox1_MaskInputRejected;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(988, 599);
			Controls.Add(panel1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			Paint += Form1_Paint;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label1;
		public MaskedTextBox maskedTextBox1;
		private Button button3;
		private Button button2;
	}
}