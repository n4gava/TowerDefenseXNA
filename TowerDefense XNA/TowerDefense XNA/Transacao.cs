using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefense_XNA.BancoDados;

namespace TowerDefense_XNA
{
    class Transacao
    {
        bool ativo;
        float tempo;
        float transparencia = 0;
        float tempoControle = 0;

        public event EventHandler OnFinalizarTransacao;

        public float Tempo
        {
            get { return tempo; }
            set { tempo = value; }
        }

        public float Transparencia
        {
            get { return transparencia; }
            set { transparencia = value; }
        }

        public Transacao()
        {
            ativo = false;
        }

        public void IniciarTransacao()
        {
            ativo = true;
            tempoControle = 0;
            transparencia = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (ativo)
            {
                tempoControle += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (tempoControle >= tempo)
                {
                    ativo = false;
                    OnFinalizarTransacao(this, new EventArgs());
                }

                if (transparencia < 0.7f)
                    transparencia += (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f;
            }


            
        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            if (ativo)
                spriteBatch.Draw(Global.texturaBranca.Textura2D,
                                 new Rectangle(0, 0, viewport.Width, viewport.Height),
                                 new Color(0, 0, 0, transparencia));
        }

    }
}
