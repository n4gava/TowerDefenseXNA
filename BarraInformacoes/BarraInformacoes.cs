using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TowerDefense_XNA;
using TowerDefense_XNA.BancoDados;
using TowerDefense_XNA.Menu;

namespace TowerDefense_XNA.BarraInformacoes
{
    public class BarraInformacoes
    {

        Textura textura;
        SpriteFont fonte;
        Box box;
        int vida;
        int rodadaAtual;
        int ouro;
        Textura texturaVida;
        Textura texturaOuro;
        Textura texturaRodada;

        public int Vida
        {
            set { vida = value; }
        }

        public int RodadaAtual
        {
            set { rodadaAtual = value; }
        }

        public int Ouro
        {
            set { ouro = value; }
        }

        public BarraInformacoes()
        {
            this.textura = Textura.GetTextura("texturaMenu2");
            this.texturaOuro = Textura.GetTextura("Ouro");
            this.texturaVida = Textura.GetTextura("Vida");
            this.texturaRodada = Textura.GetTextura("Rodada");
            this.fonte = Global.bancoDados.Fonte;
            this.box = new Box(new Rectangle(0,0,Global.LarguraJanela,32));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //this.box.Draw(spriteBatch);
            spriteBatch.Draw(this.texturaVida.Textura2D,
                new Vector2(4,4),
                null,
                Color.White,
                0.0f,
                Vector2.Zero,
                0.1f,
                SpriteEffects.None,
                0.0f);

            spriteBatch.Draw(this.texturaOuro.Textura2D,
                new Vector2(104, 4),
                null,
                Color.White,
                0.0f,
                Vector2.Zero,
                0.1f,
                SpriteEffects.None,
                0.0f);

            spriteBatch.Draw(this.texturaRodada.Textura2D,
                new Vector2(204, 6),
                null,
                Color.White,
                0.0f,
                Vector2.Zero,
                0.07f,
                SpriteEffects.None,
                0.0f);

            spriteBatch.DrawString(fonte, this.vida.ToString(), new Vector2(35, 3), Color.Black);
            spriteBatch.DrawString(fonte, this.ouro.ToString(), new Vector2(135, 3), Color.Black);
            spriteBatch.DrawString(fonte, this.rodadaAtual.ToString(), new Vector2(235, 3), Color.Black);
            
        }
        
    }
}
