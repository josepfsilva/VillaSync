namespace VillaSync
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tab1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TabPag2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.tabPage1);
            this.Tab1.Controls.Add(this.TabPag2);
            this.Tab1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Tab1.Location = new System.Drawing.Point(245, 148);
            this.Tab1.Name = "Tab1";
            this.Tab1.SelectedIndex = 0;
            this.Tab1.Size = new System.Drawing.Size(644, 337);
            this.Tab1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Todas";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // TabPag2
            // 
            this.TabPag2.Location = new System.Drawing.Point(4, 25);
            this.TabPag2.Name = "TabPag2";
            this.TabPag2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPag2.Size = new System.Drawing.Size(1072, 408);
            this.TabPag2.TabIndex = 1;
            this.TabPag2.Text = "Adicionar";
            this.TabPag2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 70);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 641);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tab1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Tab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tab1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage TabPag2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

