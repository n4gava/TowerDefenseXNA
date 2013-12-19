using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public enum Movimento
    {
        andandoDireita,
        andandoEsquerda,
        andandoCima,
        andandoBaixo,
        paradoDireita,
        paradoEsquerda,
        paradoCima,
        paradoBaixo,
        parado
    }

    public class TexturaMovimento
    {
        #region propriedades
        protected Textura textura;
        protected float tempoDecorrido;

        protected Vector2 posicao;
        protected int larguraFrame = 0;
        protected int alturaFrame = 0;
        protected Vector2 centro;
        protected Dictionary<string, Animacao> animacao = new Dictionary<string, Animacao>();
        protected string chaveAnimacao;
        protected int frameIndex;
        protected Movimento ultimoMovimento;
        protected bool emMovimento = false;
        protected int colunas;
        protected int linhas;
        #endregion propriedades

        #region atributos
        public Textura Textura
        {
            get { return textura; }
        }

        public Vector2 Posicao
        {
            get { return posicao; }
            set { posicao = value; }
        }

        public Vector2 Centro
        {
            get { return centro; }
            set { centro = value; }
        }


        #endregion atributos

        #region construtor
        protected TexturaMovimento(Textura textura, int colunas, int linhas)
        {
            this.colunas = colunas;
            this.linhas = linhas;
            this.textura = textura;
            this.Posicao = new Vector2(0, 0);
            this.larguraFrame = textura.Textura2D.Width / colunas;
            this.alturaFrame = textura.Textura2D.Height / linhas;
            this.ExecutaAnimacao(Movimento.paradoBaixo);

            List<Rectangle> frames = new List<Rectangle>();

            // Cria todos os quadros da imagem
            for (int i = 0; i < linhas; i++)
                for (int j = 0; j < colunas; j++)
                    frames.Add(new Rectangle(j * larguraFrame,
                        i * alturaFrame, larguraFrame, alturaFrame));

            AddAnimacoes(frames);
        }
        #endregion construtor

        #region Métodos
        protected void AddAnimation(string name, Animacao newAnimation)
        {
            animacao.Add(name, newAnimation);
        }

        protected virtual void AddAnimacoes(List<Rectangle> frames)
        {
        }

        public virtual void UpdateAnimacao(GameTime gametime)
        {
            
            tempoDecorrido += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (tempoDecorrido > animacao[chaveAnimacao].Intervalo)
            {
                if (animacao[chaveAnimacao].Repete)
                {
                    frameIndex = (frameIndex + 1) % animacao[chaveAnimacao].QtdeFrames;
                }
                else
                {
                    frameIndex = (int)MathHelper.Min(frameIndex + 1, animacao[chaveAnimacao].QtdeFrames - 1);
                }
                tempoDecorrido = 0.0f;
            }
        }


        public Movimento RetornaMovimentoParado()
        {
            switch (ultimoMovimento)
            {
                case Movimento.andandoDireita:
                    return Movimento.paradoDireita;
                case Movimento.andandoEsquerda:
                    return Movimento.paradoEsquerda;
                case Movimento.andandoCima:
                    return Movimento.paradoCima;
                case Movimento.andandoBaixo:
                    return Movimento.paradoBaixo;
                default:
                    return ultimoMovimento;
            }
        }

        public void ExecutaAnimacao(string name)
        {

            if (name == chaveAnimacao)
                return;

            this.chaveAnimacao = name;
            this.frameIndex = 0;
            this.tempoDecorrido = 0.0f;
        }

        public void ExecutaAnimacao(Movimento movimento)
        {
            ExecutaAnimacao(TexturaMovimento.RetornaMovimento(movimento));
        }


        public virtual void Update(GameTime gameTime)
        {
            UpdateAnimacao(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
              spriteBatch.Draw(textura.Textura2D,
                    posicao,
                    animacao[chaveAnimacao].Frames[frameIndex],
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    0.0f);
        }

        #endregion Métodos

        #region Métodos Estáticos
        public static string RetornaMovimento(Movimento movimento)
        {
            switch (movimento)
            {
                case Movimento.andandoDireita:
                    return "andandoDireita";
                case Movimento.andandoEsquerda:
                    return "andandoEsquerda";
                case Movimento.andandoCima:
                    return "andandoCima";
                case Movimento.andandoBaixo:
                    return "andandoBaixo";
                case Movimento.paradoDireita:
                    return "paradoDireita";
                case Movimento.paradoEsquerda:
                    return "paradoEsquerda";
                case Movimento.paradoCima:
                    return "paradoCima";
                case Movimento.paradoBaixo:
                    return "paradoBaixo";
                case Movimento.parado:
                    return "parado";
                default:
                    return "paradoBaixo";
            }
        }
        #endregion
    }
}
