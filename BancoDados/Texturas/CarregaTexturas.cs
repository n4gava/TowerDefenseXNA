using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TowerDefense_XNA.BancoDados
{
    partial class BancoDados
    {
        private void AddTextura(ContentManager Content, string textura)
        {
            Textura texturaMenu = new Textura(textura, Content.Load<Texture2D>(CAMINHO_TEXTURAS + textura));
            this.texturas.Add(texturaMenu);
        }

        partial void CarregaTexturas(ContentManager Content)
        {
            AddTextura(Content, "Abelha");
            AddTextura(Content, "AtaqueGuerreiro");
            AddTextura(Content, "AtaqueMagoFogo");
            AddTextura(Content, "AtaqueMagoGelo");
            AddTextura(Content, "Dragao");
            AddTextura(Content, "Guerreiro");
            AddTextura(Content, "MagoFogo");
            AddTextura(Content, "MagoGelo");
            AddTextura(Content, "Morcego");
            AddTextura(Content, "texturaMapa");
            AddTextura(Content, "texturaMenu");
            AddTextura(Content, "Vampiro");
            AddTextura(Content, "Zumbi");
            AddTextura(Content, "PlanoFundo");
            AddTextura(Content, "Vida");
            AddTextura(Content, "Ouro");
            AddTextura(Content, "Rodada");
            AddTextura(Content, "FundoBranco");
            AddTextura(Content, "texturaMenu2");
            AddTextura(Content, "texturaMenu2");
            AddTextura(Content, "MenuUnidadeFundo");
            AddTextura(Content, "Up");
            AddTextura(Content, "BotaoGuerreiro");
            AddTextura(Content, "BotaoMagoFogo");
            AddTextura(Content, "BotaoMagoGelo");
            AddTextura(Content, "BotaoGuerreiroR");
            AddTextura(Content, "BotaoMagoFogoR");
            AddTextura(Content, "BotaoMagoGeloR");
            AddTextura(Content, "BotaoGuerreiroD");
            AddTextura(Content, "BotaoMagoFogoD");
            AddTextura(Content, "BotaoMagoGeloD");
            AddTextura(Content, "VoceVenceu");
            AddTextura(Content, "VocePerdeu");
            AddTextura(Content, "Logo");
            AddTextura(Content, "AtaqueRaio");
            Global.texturaBranca = Textura.GetTextura("FundoBranco");
        }
    }
}