using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class TexturaSpriteAtaque : TexturaMovimento
    {
        bool ativo = false;
        Vector2 origem = new Vector2(96,96);

        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public TexturaSpriteAtaque(Textura textura, int colunas, int linhas)
            : base(textura, colunas, linhas)
        {
        }



        protected override void AddAnimacoes(List<Rectangle> frames)
        {
            base.AddAnimacoes(frames);
            float intervalo = 0.05f;

            Animacao ataque = new Animacao(frames, 0, 4, intervalo);
            ataque.Repete = false;
            
            AddAnimation("Ataque", ataque);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Ativo)
            {
                spriteBatch.Draw(textura.Textura2D,
                      centro,
                      animacao[chaveAnimacao].Frames[frameIndex],
                      Color.White,
                      0.0f,
                      origem,
                      0.35f,
                      SpriteEffects.None,
                      0.0f);

                if (frameIndex == 3)
                {
                    frameIndex = 0;
                    this.ativo = false;
                }
            }
        }

        public TexturaSpriteAtaque Clone()
        {
            TexturaSpriteAtaque textura = new TexturaSpriteAtaque(this.textura, this.colunas, this.linhas);
            return textura;
        }
    }
}
