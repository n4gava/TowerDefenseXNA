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
        partial void CarregaInimigos(ContentManager Content)
        {
            int teste = 1;
            #region abelha
            Inimigo abelha = new Inimigo();
            abelha.Nome = "Abelha";
            abelha.Ouro = 6;
            abelha.Vida = 4;
            abelha.Velocidade = 32 * teste;
            inimigos.Add(abelha);
            #endregion abelha

            #region morcego
            Inimigo morcego = new Inimigo();
            morcego.Nome = "Morcego";
            morcego.Ouro = 8;
            morcego.Vida = 8;
            morcego.Velocidade = 32 * teste;
            inimigos.Add(morcego);
            #endregion morcego

            #region zumbi
            Inimigo zumbi = new Inimigo();
            zumbi.Nome = "Zumbi";
            zumbi.Ouro = 12;
            zumbi.Vida = 16;
            zumbi.Velocidade = 24 * teste;
            inimigos.Add(zumbi);
            #endregion zumbi

            #region vampiro
            Inimigo vampiro = new Inimigo();
            vampiro.Nome = "Vampiro";
            vampiro.Ouro = 18;
            vampiro.Vida = 8;
            vampiro.Velocidade = 64 * teste;
            inimigos.Add(vampiro);
            #endregion zumbi

            #region dragao
            Inimigo dragao = new Inimigo();
            dragao.Nome = "Dragao";
            dragao.Ouro = 25;
            dragao.Vida = 40;
            dragao.Velocidade = 16 * teste;
            inimigos.Add(dragao);
            #endregion zumbi

        }
    }
}
