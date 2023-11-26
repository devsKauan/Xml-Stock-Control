using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = tx_usuario.Text;
            string senha = mtx_senha.Text;
            
            if(string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, insira nome de usuário e senha.");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("clientes.xml");

            XmlNode userNode = xmlDoc.SelectSingleNode($"//CadastroClientes[Nome='{nome}']");

            if (userNode != null)
            {
                string senhaxml = userNode.SelectSingleNode("Senha").InnerText;

                if (senha == senhaxml)
                {
                   /* MessageBox.Show("Login bem-sucedido! Acesso concedido.");*/
                    TelaVenda venda= new TelaVenda();
                    this.Dispose();
                    venda.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Senha incorreta. Tente novamente.");
                }
            }
            else
            {
                MessageBox.Show("Usuário não encontrado. Verifique o nome de usuário.");
            }
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
