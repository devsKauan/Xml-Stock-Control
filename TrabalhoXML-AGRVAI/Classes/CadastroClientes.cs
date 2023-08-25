﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TrabalhoXML_AGRVAI.Classes
{
    internal class CadastroClientes
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }

        List<string> list = new List<string>();

        public void Cliente(string nome, string cpf, string email, string fone) 
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Fone = fone;
        }
        public void Main()
        {

            XmlWriter writer = null;
            

            writer = XmlWriter.Create("Cliente.xml");

            // Write the root element.
            writer.WriteStartElement("cliente");

            // Write the xmlns:bk="urn:book" namespace declaration.
            writer.WriteAttributeString("id", "1");

            // Write the bk:ISBN="1-800-925" attribute.
            /*writer.WriteAttributeString("ISBN", "urn:book", "1-800-925");*/

            writer.WriteElementString("name", this.Nome);
            writer.WriteElementString("cpf", this.Cpf);
            writer.WriteElementString("email", this.Email);
            writer.WriteElementString("fone", this.Fone);

            // Write the close tag for the root element.
            writer.WriteEndElement();

            // Write the XML to file and close the writer.
            writer.Flush();
            writer.Close();
            MessageBox.Show("Cadastrado com sucesso");
        }
    }
}
