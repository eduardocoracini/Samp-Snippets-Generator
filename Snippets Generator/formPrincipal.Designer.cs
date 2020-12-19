
namespace Snippets_Generator
{
    partial class formPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxPrograma = new System.Windows.Forms.ComboBox();
            this.txtPasta = new System.Windows.Forms.TextBox();
            this.txtSaida = new System.Windows.Forms.TextBox();
            this.cboxDicionario = new System.Windows.Forms.CheckBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnPasta = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saída:";
            // 
            // cboxPrograma
            // 
            this.cboxPrograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPrograma.FormattingEnabled = true;
            this.cboxPrograma.Location = new System.Drawing.Point(95, 17);
            this.cboxPrograma.Name = "cboxPrograma";
            this.cboxPrograma.Size = new System.Drawing.Size(211, 25);
            this.cboxPrograma.TabIndex = 3;
            // 
            // txtPasta
            // 
            this.txtPasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasta.Location = new System.Drawing.Point(95, 48);
            this.txtPasta.Name = "txtPasta";
            this.txtPasta.Size = new System.Drawing.Size(427, 25);
            this.txtPasta.TabIndex = 4;
            // 
            // txtSaida
            // 
            this.txtSaida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaida.Location = new System.Drawing.Point(95, 79);
            this.txtSaida.Name = "txtSaida";
            this.txtSaida.Size = new System.Drawing.Size(427, 25);
            this.txtSaida.TabIndex = 5;
            // 
            // cboxDicionario
            // 
            this.cboxDicionario.AutoSize = true;
            this.cboxDicionario.Location = new System.Drawing.Point(95, 110);
            this.cboxDicionario.Name = "cboxDicionario";
            this.cboxDicionario.Size = new System.Drawing.Size(130, 21);
            this.cboxDicionario.TabIndex = 6;
            this.cboxDicionario.Text = "Gerar dicionário";
            this.cboxDicionario.UseVisualStyleBackColor = true;
            // 
            // btnGerar
            // 
            this.btnGerar.ForeColor = System.Drawing.Color.Black;
            this.btnGerar.Location = new System.Drawing.Point(95, 137);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(130, 34);
            this.btnGerar.TabIndex = 7;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnPasta
            // 
            this.btnPasta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPasta.BackgroundImage")));
            this.btnPasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPasta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasta.ForeColor = System.Drawing.Color.Black;
            this.btnPasta.Location = new System.Drawing.Point(529, 48);
            this.btnPasta.Name = "btnPasta";
            this.btnPasta.Size = new System.Drawing.Size(24, 25);
            this.btnPasta.TabIndex = 8;
            this.btnPasta.UseVisualStyleBackColor = true;
            this.btnPasta.Click += new System.EventHandler(this.btnPasta_Click);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(565, 182);
            this.Controls.Add(this.btnPasta);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.cboxDicionario);
            this.Controls.Add(this.txtSaida);
            this.Controls.Add(this.txtPasta);
            this.Controls.Add(this.cboxPrograma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "formPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snippets Generator v1.0";
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxPrograma;
        private System.Windows.Forms.TextBox txtPasta;
        private System.Windows.Forms.TextBox txtSaida;
        private System.Windows.Forms.CheckBox cboxDicionario;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnPasta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

