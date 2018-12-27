namespace ClastDots
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Tao.Platform.Windows.SimpleOpenGlControl AnT;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox Coef;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.Coef = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// AnT
			// 
			this.AnT.AccumBits = ((byte)(0));
			this.AnT.AutoCheckErrors = false;
			this.AnT.AutoFinish = false;
			this.AnT.AutoMakeCurrent = true;
			this.AnT.AutoSwapBuffers = true;
			this.AnT.BackColor = System.Drawing.Color.Black;
			this.AnT.ColorBits = ((byte)(32));
			this.AnT.DepthBits = ((byte)(16));
			this.AnT.Location = new System.Drawing.Point(12, 12);
			this.AnT.Name = "AnT";
			this.AnT.Size = new System.Drawing.Size(759, 587);
			this.AnT.StencilBits = ((byte)(0));
			this.AnT.TabIndex = 0;
			this.AnT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnTMouseClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(777, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(180, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Очистить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(778, 42);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(179, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Выйти";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(778, 71);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(179, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "Случайную точку";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(778, 101);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(179, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "Кластеризовать";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// Coef
			// 
			this.Coef.Location = new System.Drawing.Point(857, 194);
			this.Coef.Name = "Coef";
			this.Coef.Size = new System.Drawing.Size(100, 20);
			this.Coef.TabIndex = 5;
			this.Coef.Text = "20";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(778, 197);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 22);
			this.label1.TabIndex = 6;
			this.label1.Text = "Коэффициент";
			// 
			// timer1
			// 
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(969, 611);
			this.Controls.Add(this.Coef);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.AnT);
			this.Name = "MainForm";
			this.Text = "ClastDots";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
