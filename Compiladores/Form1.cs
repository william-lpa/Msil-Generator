using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sintatico;

namespace Compiladores
{
    public partial class Form1 : Form
    {
        public string arquivo="";
        private bool compilado = false;
        public Form1()
        {
            InitializeComponent();
            inicializarStatusStrip();
            
        }

    #region BARRA DE STATUS RODAPE
        public void inicializarStatusStrip() 
        {
            limparStatusStrip();
            this.statusStrip1.Items.Add("Não modificado");
        }
        private void limparStatusStrip()
        {
            for (int i = statusStrip1.Items.Count-1; i > -1; i--)
            {
                statusStrip1.Items.RemoveAt(i);
            }
        }
        private void adicionarTextoStatusStrip(params string []texto) 
        {
            foreach (string palavra in texto) 
            {
                statusStrip1.Items.Add(palavra);
            }
        }
        #endregion
    #region TECLA DE ATALHO
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            Action acao = null;
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        acao = novoArquivo;
                        break;
                    case Keys.A:
                        acao = abrirArquivos;
                        break;
                    case Keys.S:
                        acao = salvarArquivo;
                        break;
                    case Keys.C:
                        acao = copiarTexto;
                        break;
                    case Keys.V:
                        acao = colarTexto;
                        break;
                    case Keys.X:
                        acao = recortarTexto;
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        acao = equipe;
                        break;
                    case Keys.F8:
                        acao = compilar;
                        break;
                    case Keys.F9:
                        acao = gerarCodigo;
                        break;
                }

            }
            if (acao != null)
            {
                try
                {
                    acao.Invoke();
                    return true;
                }
                catch (Exception err)
                {
                    richTextBox2.AppendText(err.Message + Environment.NewLine);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    #region FUNCOES
    private void gerarCodigo()
    {
      
        if (richTextBox1.Text.Length <= 0)
            {
                abrirArquivos();
            }
            else
            {
                salvarArquivo();
            }
        
        if (!this.compilado)
        {
            this.compilar();
            if (this.compilado)
            {
                string diretorio = Path.GetDirectoryName(arquivo) + "\\" + Semantico.GetInstance().NomeArq + ".il";
                File.Create(diretorio).Dispose();
                File.WriteAllText(diretorio, Semantico.GetInstance().codigoGerado.ToString());
                richTextBox2.Clear();
                richTextBox2.AppendText("código objeto gerado com sucesso");
            }
        }
        else
        {
            string diretorio = Path.GetDirectoryName(arquivo) + "\\" + Semantico.GetInstance().NomeArq + ".il";
            File.Create(diretorio).Dispose();
            File.WriteAllText(diretorio, Semantico.GetInstance().codigoGerado.ToString());
            richTextBox2.Clear();
            richTextBox2.AppendText("código objeto gerado com sucesso");
        }
    }
    private void compilar()
    {
        if (arquivo == "")
        {
            salvarArquivo();
        }
        richTextBox2.Clear();
        Lexico lexico = new Lexico();
        Sintatico.Sintatico sintatico = new Sintatico.Sintatico();
        Semantico semantico = null;
        Semantico.GetLimpa();
        semantico = Semantico.GetInstance();

        lexico.setInput( richTextBox1.Text );
        string arq =Path.GetFileNameWithoutExtension(statusStrip1.Items[1].ToString());
        semantico.NomeArq = arq;
        try
        {
            sintatico.parse(lexico,new Semantico());
            richTextBox2.AppendText("programa compilado com sucesso");
            this.compilado = true;
            Token t = null;
          /*  richTextBox2.AppendText("linha\t\tclasse\t\t\tlexema"+Environment.NewLine);
           while ( (t = lexico.nextToken()) != null )
            {
                richTextBox2.AppendText(t.Position + "\t\t"+ t.getTipoToken() +"\t\t" +t.Lexeme +Environment.NewLine);
                
            }*/
        }
        catch ( LexicalError e )
        {
                richTextBox2.Clear();
                richTextBox2.AppendText(" Erro na linha " + e.getPosition() + " - " + e.Message + Environment.NewLine);
            
        }
        catch (SyntaticError e)
        {
            richTextBox2.Clear();
            richTextBox2.AppendText(" Erro na linha " + e.getPosition() + " - " + e.Message + Environment.NewLine);

        }
        catch (SemanticError e)
        {
            richTextBox2.Clear();
            richTextBox2.AppendText(e.Message + Environment.NewLine);
        }
        
    }
    private void copiarTexto()
    {
         richTextBox1.Copy();
    }
    private void recortarTexto()
    {
        richTextBox1.Cut();
    }
    private void colarTexto()
    {
        richTextBox1.Paste();
    }
    public void equipe()
        {
            richTextBox2.Clear();
            richTextBox2.AppendText("Leonard William de Azevedo Pegler" + Environment.NewLine
                                + "Luiz Cézar Coppi" + Environment.NewLine
                                + "Everton Luíz Piccoli" + Environment.NewLine);
         }
    public void novoArquivo() 
         {
             richTextBox1.Clear();
             richTextBox2.Clear();
             inicializarStatusStrip();
             arquivo = "";
             
         }
    public void abrirArquivos()
        {
          OpenFileDialog abrirArquivo = new OpenFileDialog();
          abrirArquivo.Filter = "txt arquivos|*.txt";
          DialogResult resultado=  abrirArquivo.ShowDialog();

          if (resultado == DialogResult.OK)
          {
              FileInfo file = new FileInfo(abrirArquivo.FileName);
              limparStatusStrip();
              adicionarTextoStatusStrip("Pasta:"+file.Directory, "Arquivo:"+file.Name,"Não modificado");
              this.richTextBox2.Clear();
              this.richTextBox1.Clear();
              carregarArquivo(file.FullName);
              this.arquivo = file.FullName;
              this.compilado = false;
              
          }
        }
    private void carregarArquivo(string arquivo)
        {
            try
            {
                using (StreamReader str = new StreamReader(arquivo))
                {
                    string texto = str.ReadToEnd();
                    this.richTextBox1.AppendText(texto);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\r\nStackTrace:" + err.StackTrace);
            }
        }
    private void salvarArquivo()
        {
            if (arquivo != "") 
            {
                salvarArquivoNoDisco();
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt arquivos|*.txt";
            DialogResult resultado= sfd.ShowDialog();

            if (resultado == DialogResult.OK) 
            {
                arquivo = sfd.FileName;
                salvarArquivoNoDisco();
            }
        }
    private void salvarArquivoNoDisco()
    {
        try
        {
            using (StreamWriter stw = new StreamWriter(arquivo))
            {
                string texto = richTextBox1.Text;
                stw.Write(texto);
                adicionarTextoStatusStrip(arquivo);
            }
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message + "\r\nStackTrace:" + err.StackTrace);
        }
    }

    #endregion
    #region BOTOES
    private void btCopiar_Click(object sender, EventArgs e)
    {
        try
        {
            copiarTexto();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine); 
        }
    }
    private void btNovo_Click(object sender, EventArgs e)
    {
        try
        {
            novoArquivo();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine);
        }

    }
    private void btAbrir_Click(object sender, EventArgs e)
    {
        try 
        { 
        
            abrirArquivos();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine);
        }

    }
    private void btSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            salvarArquivo();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine);
        }
    }
    private void btColar_Click(object sender, EventArgs e)
    {
        try
        {
            colarTexto();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine);
        }
    }
    private void btRecortar_Click(object sender, EventArgs e)
    {
        try
        {
            recortarTexto();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine);
        }
    }
    private void btCompilar_Click(object sender, EventArgs e)
    {
        try
        {
            salvarArquivo();
            compilar();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine);
        }
    }
    private void btGerarCodigo_Click(object sender, EventArgs e)
    {
        try
        {
            gerarCodigo();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine); 
        }
    }
    private void btEquipe_Click(object sender, EventArgs e)
    {
        try
        {
            equipe();
        }
        catch (Exception err)
        {
            richTextBox2.AppendText(err.Message + Environment.NewLine);
        }

    }
    #endregion

    }
       
    }

