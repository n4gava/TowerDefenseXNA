using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Linq;

namespace TowerDefense_XNA.BancoDados
{
    partial class BancoDados
    {
        partial void CarregaPerfisPartial()
        {
            System.IO.Stream stream = TitleContainer.OpenStream(Global.localXmlPerfil);
            XDocument doc = XDocument.Load(stream);
            this.perfis = (from perfil in doc.Descendants("perfil")
                           select new Perfil()
                           { 
                               Nome = perfil.Attribute("nome").Value, 
                               UltimoNivelVitoria = Convert.ToInt32(perfil.Element("nivel").Value)
                           }).ToList();
            stream.Close();


            // TODO: carregar os perfis do XML
            /*Perfil perfil = new Perfil();
            perfil.Nome = "Guilherme";
            perfil.UltimoNivelVitoria = 1;
            

            this.perfis.Add(perfil);
            */
        }
    }
}
