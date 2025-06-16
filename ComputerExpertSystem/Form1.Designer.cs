namespace ComputerExpertSystem
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.labelByudzhet = new System.Windows.Forms.Label();
			this.numericByudzhet = new System.Windows.Forms.NumericUpDown();
			this.labelIspolzovanie = new System.Windows.Forms.Label();
			this.comboIspolzovanie = new System.Windows.Forms.ComboBox();
			this.labelProizvoditelnost = new System.Windows.Forms.Label();
			this.comboProizvoditelnost = new System.Windows.Forms.ComboBox();
			this.buttonPoluchit = new System.Windows.Forms.Button();
			this.textRekomendatsiya = new System.Windows.Forms.TextBox();
			this.labelResult = new System.Windows.Forms.Label();
			this.buttonSbros = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericByudzhet)).BeginInit();
			this.SuspendLayout();
			// 
			// labelByudzhet
			// 
			this.labelByudzhet.AutoSize = true;
			this.labelByudzhet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelByudzhet.Location = new System.Drawing.Point(28, 30);
			this.labelByudzhet.Name = "labelByudzhet";
			this.labelByudzhet.Size = new System.Drawing.Size(103, 16);
			this.labelByudzhet.TabIndex = 0;
			this.labelByudzhet.Text = "Бюджет (руб):";
			// 
			// numericByudzhet
			// 
			this.numericByudzhet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericByudzhet.Location = new System.Drawing.Point(232, 28);
			this.numericByudzhet.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericByudzhet.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			this.numericByudzhet.Name = "numericByudzhet";
			this.numericByudzhet.Size = new System.Drawing.Size(180, 22);
			this.numericByudzhet.TabIndex = 1;
			this.numericByudzhet.Value = new decimal(new int[] {
			75000,
			0,
			0,
			0});
			// 
			// labelIspolzovanie
			// 
			this.labelIspolzovanie.AutoSize = true;
			this.labelIspolzovanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIspolzovanie.Location = new System.Drawing.Point(28, 70);
			this.labelIspolzovanie.Name = "labelIspolzovanie";
			this.labelIspolzovanie.Size = new System.Drawing.Size(184, 16);
			this.labelIspolzovanie.TabIndex = 2;
			this.labelIspolzovanie.Text = "Основное использование:";
			// 
			// comboIspolzovanie
			// 
			this.comboIspolzovanie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboIspolzovanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboIspolzovanie.FormattingEnabled = true;
			this.comboIspolzovanie.Location = new System.Drawing.Point(232, 67);
			this.comboIspolzovanie.Name = "comboIspolzovanie";
			this.comboIspolzovanie.Size = new System.Drawing.Size(180, 24);
			this.comboIspolzovanie.TabIndex = 3;
			// 
			// labelProizvoditelnost
			// 
			this.labelProizvoditelnost.AutoSize = true;
			this.labelProizvoditelnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProizvoditelnost.Location = new System.Drawing.Point(28, 110);
			this.labelProizvoditelnost.Name = "labelProizvoditelnost";
			this.labelProizvoditelnost.Size = new System.Drawing.Size(198, 16);
			this.labelProizvoditelnost.TabIndex = 4;
			this.labelProizvoditelnost.Text = "Желаемая производит-ть:";
			// 
			// comboProizvoditelnost
			// 
			this.comboProizvoditelnost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboProizvoditelnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboProizvoditelnost.FormattingEnabled = true;
			this.comboProizvoditelnost.Location = new System.Drawing.Point(232, 107);
			this.comboProizvoditelnost.Name = "comboProizvoditelnost";
			this.comboProizvoditelnost.Size = new System.Drawing.Size(180, 24);
			this.comboProizvoditelnost.TabIndex = 5;
			// 
			// buttonPoluchit
			// 
			this.buttonPoluchit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonPoluchit.Location = new System.Drawing.Point(31, 155);
			this.buttonPoluchit.Name = "buttonPoluchit";
			this.buttonPoluchit.Size = new System.Drawing.Size(278, 45);
			this.buttonPoluchit.TabIndex = 6;
			this.buttonPoluchit.Text = "Получить рекомендацию";
			this.buttonPoluchit.UseVisualStyleBackColor = true;
			this.buttonPoluchit.Click += new System.EventHandler(this.buttonPoluchit_Click);
			// 
			// textRekomendatsiya
			// 
			this.textRekomendatsiya.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textRekomendatsiya.Location = new System.Drawing.Point(31, 240);
			this.textRekomendatsiya.Multiline = true;
			this.textRekomendatsiya.Name = "textRekomendatsiya";
			this.textRekomendatsiya.ReadOnly = true;
			this.textRekomendatsiya.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textRekomendatsiya.Size = new System.Drawing.Size(381, 185);
			this.textRekomendatsiya.TabIndex = 7;
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelResult.Location = new System.Drawing.Point(28, 221);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(189, 16);
			this.labelResult.TabIndex = 8;
			this.labelResult.Text = "Ваша конфигурация ПК:";
			// 
			// buttonSbros
			// 
			this.buttonSbros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonSbros.Location = new System.Drawing.Point(325, 155);
			this.buttonSbros.Name = "buttonSbros";
			this.buttonSbros.Size = new System.Drawing.Size(87, 45);
			this.buttonSbros.TabIndex = 9;
			this.buttonSbros.Text = "Сброс";
			this.buttonSbros.UseVisualStyleBackColor = true;
			this.buttonSbros.Click += new System.EventHandler(this.buttonSbros_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 451);
			this.Controls.Add(this.buttonSbros);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.textRekomendatsiya);
			this.Controls.Add(this.buttonPoluchit);
			this.Controls.Add(this.comboProizvoditelnost);
			this.Controls.Add(this.labelProizvoditelnost);
			this.Controls.Add(this.comboIspolzovanie);
			this.Controls.Add(this.labelIspolzovanie);
			this.Controls.Add(this.numericByudzhet);
			this.Controls.Add(this.labelByudzhet);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Экспертная система подбора ПК";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericByudzhet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelByudzhet;
		private System.Windows.Forms.NumericUpDown numericByudzhet;
		private System.Windows.Forms.Label labelIspolzovanie;
		private System.Windows.Forms.ComboBox comboIspolzovanie;
		private System.Windows.Forms.Label labelProizvoditelnost;
		private System.Windows.Forms.ComboBox comboProizvoditelnost;
		private System.Windows.Forms.Button buttonPoluchit;
		private System.Windows.Forms.TextBox textRekomendatsiya;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.Button buttonSbros;
	}
}