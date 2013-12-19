using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TowerDefense_XNA.BancoDados
{
    public class Perfil
    {
        #region propriedades
        string nome;
        Nivel ultimoNivelVitoria;
        #endregion propriedades

        #region atributos
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public int UltimoNivelVitoria
        {
            set
            {
                if (value > 0 && value <= 3)
                    ultimoNivelVitoria = Nivel.GetNivel(value);
            }
        }
        #endregion atributos

        #region Métodos
        public IEnumerable<Nivel> GetNiveis()
        {
            return Global.bancoDados.Niveis.Where(x => x.PNivel  <= this.ultimoNivelVitoria.PNivel);
        }

        public void ProximoNivel(Nivel nivelVitoria)
        {
            if (ultimoNivelVitoria.PNivel == 3) // nível máximo
                return;

            int proximonivel = nivelVitoria.PNivel + 1;

            if (proximonivel > ultimoNivelVitoria.PNivel)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Global.localXmlPerfil);
                XmlNode node;
                node = doc.SelectSingleNode(String.Format("/perfis/perfil[@nome='{0}']", this.Nome));
                node.SelectSingleNode("./nivel").InnerText = proximonivel.ToString();
                doc.Save(Global.localXmlPerfil);

                this.ultimoNivelVitoria = Nivel.GetNivel(proximonivel);
            }
        }

        public void Excluir()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Global.localXmlPerfil);
            XmlNode node;
            node = doc.SelectSingleNode(String.Format("/perfis/perfil[@nome='{0}']", this.Nome));
            doc.SelectSingleNode("/perfis").RemoveChild(node);
            doc.Save(Global.localXmlPerfil);
        }

        public static Perfil GetPerfil(string nomePerfil)
        {
            return Global.bancoDados.Perfis.Where(x => x.nome == nomePerfil).First();
        }

        public static bool PerfilExistente(string nome)
        {
            try
            {
                Perfil perfil = Global.bancoDados.Perfis.Where(x => x.nome == nome).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void AddPerfil(string nome)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Global.localXmlPerfil);
            XmlNode node;
            node = doc.SelectSingleNode("/perfis");
            XmlNode nodePerfil = doc.CreateNode(XmlNodeType.Element, "perfil", null);
            XmlAttribute AtribNome = doc.CreateAttribute("", "nome", "");
            AtribNome.Value = nome;
            nodePerfil.Attributes.Append(AtribNome);
            XmlNode nodeNivel = doc.CreateNode(XmlNodeType.Element, "nivel", null);
            nodeNivel.InnerText = "1";
            nodePerfil.AppendChild(nodeNivel);
            node.AppendChild(nodePerfil);

            doc.Save(Global.localXmlPerfil);
        }
        #endregion Métodos


    }
}
