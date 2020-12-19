using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Snippets_Generator
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void formPrincipal_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = @"Snippets Generator v" + version.Major + @"." + version.Minor;

            foreach (string file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly))
            {
                Assembly assembly;
                try
                {
                    assembly = Assembly.LoadFile(file);
                }
                catch
                {
                    continue;
                }

                object instance = assembly.CreateInstance("nSnippet.cSnippet");
                MethodInfo methodInfo = instance?.GetType().GetMethod("GenerateSnippets");

                if (methodInfo == null)
                    continue;

                cboxPrograma.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (cboxPrograma.SelectedIndex == -1)
            {
                MessageBox.Show(@"É necessário selecionar um programa antes de gerar autocomplementos.", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (txtPasta.Text == string.Empty)
            {
                MessageBox.Show(@"É necessário informar a pasta que contém os arquivos de includes.", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (txtSaida.Text == string.Empty)
            {
                MessageBox.Show(@"É necessário informar a pasta onde será gerado o arquivo de autocomplemento.", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            btnGerar.Enabled = false;

            try
            {
                object instance = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + cboxPrograma.Text + ".dll").CreateInstance("nSnippet.cSnippet");
                MethodInfo methodInfo = instance?.GetType().GetMethod("GenerateSnippets");
                if (methodInfo == null)
                {
                    MessageBox.Show(@"A biblioteca " + cboxPrograma.Text + @".dll não contém métodos necessários para criar autocomplementos.", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                methodInfo.Invoke(instance, new object[] { txtPasta.Text, new[] { "native", "forward", "stock", "#define" }, txtSaida.Text, cboxDicionario.Checked });
                MessageBox.Show(@"O arquivo de autocomplemento foi gerado na pasta de saída.", @"Arquivo gerado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Ocorreu um erro ao gerar autocomplementos:" + Environment.NewLine + ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                btnGerar.Enabled = true;
            }
        }

        private void btnPasta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPasta.Text = folderBrowserDialog.SelectedPath;
                txtSaida.Text = txtPasta.Text;
            }
        }
    }
}
