using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefense_XNA.BancoDados;


namespace TowerDefense_XNA
{
    class AnimacaoInicial
    {
        bool ativo = true;
        List<TextoAnimacao> textos = new List<TextoAnimacao>();
        float tempoPercorrido;


        public bool Ativo
        {
            get { return ativo; }
        }

        public AnimacaoInicial()
        {
            textos.Add(new TextoAnimacao("Guilherme Gavazzoni", 3f, new Vector2(20, 20)));
            textos.Add(new TextoAnimacao("Apresenta", 3f, new Vector2(20, 20)));
        }

        public void Update(GameTime gameTime)
        {
            tempoPercorrido += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (tempoPercorrido >= 1000)
                

            foreach (TextoAnimacao texto in textos)
            {
                texto.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (TextoAnimacao texto in textos)
            {
                texto.Draw(spriteBatch);   
            }
        }
    }

    class TextoAnimacao
    {
        string texto;
        float tempo;
        Vector2 posicao;
        float transparencia;
        SpriteFont fonte;
        bool ativo = true;
        bool sumindo = false;
        float tempoPercorrido;
        bool start = false;

        public bool Start
        {
            get { return start; }
            set { start = value; }
        }

        public TextoAnimacao(string texto, float tempo, Vector2 posicao)
        {
            this.texto = texto;
            this.tempo = tempo;
            this.posicao = posicao;
            this.fonte = Global.bancoDados.Fonte;
            this.transparencia = 0f;
        }

        public void Update(GameTime gameTime)
        {
            if (start)
                if (sumindo)
                    transparencia -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.0003f;
                else
                    transparencia += (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.0003f;
                posicao.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.003f;

                tempoPercorrido += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (tempoPercorrido / 1000 >= this.tempo)
                    sumindo = true;

                if (sumindo && transparencia <= 0)
                    ativo = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (ativo && start)
                spriteBatch.DrawString(fonte, texto, posicao, Color.White * transparencia);
        }


    }
}
