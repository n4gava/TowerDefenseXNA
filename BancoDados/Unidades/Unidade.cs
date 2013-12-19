using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace TowerDefense_XNA.BancoDados
{
    public class Unidade 
    {
        #region propriedades

        protected string nome;
        protected float velocidadeAtaque;
        protected float distancia;
        protected float dano;
        protected int custo;
        protected int custoVenda;
        protected int retardoMovimento = 0;
        protected TexturaSpriteAtaque texturaAtaque;
        protected TexturaSpriteMovimentoAtaque texturaUnidade;
        protected Unidade unidadeEvolucao;
        protected int nivel;
        //protected Vector2 posicao = new Vector2();
        //protected Vector2 centro = new Vector2();
        protected Inimigo alvo;
        protected float tempoAtaque;
        protected Movimento movimentoUnidade = Movimento.paradoBaixo;
        protected Texture2D barraNivel = Global.texturaBranca.Textura2D;
        protected Audio audioAtaque;
        #endregion propriedades


        public event EventHandler OnClick;
        public event EventHandler MatouInimigo;

        #region atributos

        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public float VelocidadeAtaque
        {
            set { velocidadeAtaque = value; }
        }

        public float Distancia
        {
            set { distancia = value; }
            get { return distancia; }
        }


        public float Dano
        {
            set { dano = value; }
        }

        public int Custo
        {
            set { custo = value; }
            get { return custo; }
        }

        public int CustoVenda
        {
            set { custoVenda = value; }
            get { return custoVenda; }
        }

        public int RetardoMovimento
        {
            set { retardoMovimento = value; }
        }

        public TexturaSpriteAtaque TexturaAtaque
        {
            set { texturaAtaque = value; }
        }

        public TexturaSpriteMovimentoAtaque TexturaUnidade
        {
            set { texturaUnidade = value; }
            get { return texturaUnidade; }
        }

        public Unidade UnidadeEvolucao
        {
            set { unidadeEvolucao = value; }
            get { return unidadeEvolucao; }
        }

        public Vector2 Posicao
        {
            set { texturaUnidade.Posicao = value; }
            get { return texturaUnidade.Posicao; }
        }

        public int Nivel
        {
            set { nivel = value; }
            get { return nivel; }
        }

        public Inimigo Alvo
        {
            get { return alvo; }
            set { alvo = value; }
        }

        public Vector2 Centro
        {
            get { return texturaUnidade.Centro; }
        }

        public Audio AudioAtaque
        {
            get { return audioAtaque; }
            set { audioAtaque = value; }
        }
        #endregion atributos


        public bool EstaAlcance(Vector2 posicao)
        {
            return Vector2.Distance(texturaUnidade.Centro, posicao) <= (distancia/2);
        }

        public virtual void BuscaInimigoProximo(List<Inimigo> inimigos)
        {
            
            alvo = null;
            float menorAlcance = distancia / 2;
            foreach (Inimigo inimigo in inimigos)
            {
                if (Vector2.Distance(texturaUnidade.Centro, inimigo.Centro) <= menorAlcance)
                {
                    float teste = Vector2.Distance(new Vector2(100, 100), new Vector2(80, 100));
                    menorAlcance = Vector2.Distance(texturaUnidade.Centro, inimigo.Centro);
                    alvo = inimigo;
                }
            }
        }

        protected void VirarParaInimigo()
        {
            if (!alvo.Morto)
            {
                Vector2 direction = texturaUnidade.Centro - alvo.Centro;
                direction.Normalize();

                // vira a unidade
                float distanciaX = alvo.Posicao.X - this.Posicao.X;
                float distanciaY = alvo.Posicao.Y - this.Posicao.Y;

                if (Math.Abs(distanciaY) > Math.Abs(distanciaX) )
                {
                    if (distanciaY > 0)
                        this.movimentoUnidade = Movimento.paradoBaixo;
                    else
                        this.movimentoUnidade = Movimento.paradoCima;
                }
                else
                {
                    if (distanciaX > 0)
                        this.movimentoUnidade = Movimento.paradoDireita;
                    else
                        this.movimentoUnidade = Movimento.paradoEsquerda;
                }

                this.texturaUnidade.ExecutaAnimacao(movimentoUnidade);

            }
        }

        protected void InimigoMorto(object sender, EventArgs e)
        {
            MatouInimigo(sender, e);
        }

        public virtual void Ataque(GameTime gameTime, List<Inimigo> inimigos)
        {
            texturaAtaque.Ativo = true;
            texturaAtaque.ExecutaAnimacao("Ataque");
            texturaAtaque.Centro = alvo.Centro;
            audioAtaque.Play();
            alvo.Vida -= this.dano;
            if (alvo.Vida <= 0)
                InimigoMorto(alvo, new EventArgs());
        }

        public void Update(GameTime gameTime, MouseState mouseState, MouseState mouseStateAnterior, List<Inimigo> inimigos)
        {

            tempoAtaque += (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.texturaUnidade.Update(gameTime);
            bool mouseClick = mouseState.LeftButton == ButtonState.Pressed && mouseStateAnterior.LeftButton == ButtonState.Released;

            if (alvo != null)
            {
                VirarParaInimigo();

                if (!EstaAlcance(alvo.Centro) || alvo.Morto)
                {
                    alvo = null;
                    tempoAtaque = 0;
                }

                // alvo ataca inimigo
                if ((1/velocidadeAtaque) <= tempoAtaque && alvo !=null)
                {
                    // animacao ataque
                    tempoAtaque = 0;
                    Ataque(gameTime, inimigos);
                }
            }

            if (texturaAtaque.Ativo)
                texturaAtaque.Update(gameTime);


            if (mouseClick)
            {
                int cellX = (int)(mouseState.X / 32);
                int cellY = (int)(mouseState.Y / 32);

                if (this.Posicao.X == (cellX * 32) && this.Posicao.Y == (cellY * 32))
                {
                    OnClick(this, new EventArgs());
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.texturaUnidade.Draw(spriteBatch);
            this.texturaAtaque.Draw(spriteBatch);

            int posYInicial = (int)Posicao.Y + 30;
            for (int i = 1; i <= nivel; i++)
            {
                spriteBatch.Draw(this.barraNivel, new Rectangle((int)Posicao.X + 2, posYInicial, 5, 2), Color.Yellow);
                posYInicial -= 3;
            }

        }

        public void Evolucao()
        {
            Unidade unidadeEvolucao = this.unidadeEvolucao;
            if (unidadeEvolucao != null)
            {
                this.Nome = unidadeEvolucao.nome;
                this.VelocidadeAtaque = unidadeEvolucao.velocidadeAtaque;
                this.Distancia = unidadeEvolucao.distancia;
                this.Dano = unidadeEvolucao.dano;
                this.Custo = unidadeEvolucao.custo;
                this.CustoVenda = unidadeEvolucao.custoVenda;
                this.UnidadeEvolucao = unidadeEvolucao.unidadeEvolucao;
                this.Alvo = unidadeEvolucao.alvo;
                Vector2 posicao = this.texturaUnidade.Posicao;
                this.texturaUnidade = unidadeEvolucao.texturaUnidade.Clone();
                this.texturaUnidade.Posicao = posicao;
                this.Nivel = unidadeEvolucao.Nivel;
            }
        }

        public T Clone<T>() where T : Unidade, new()
        {
            T newUnidade = new T();
            newUnidade.Nome = this.nome;
            newUnidade.VelocidadeAtaque = this.velocidadeAtaque;
            newUnidade.Distancia = this.distancia;
            newUnidade.Dano = this.dano;
            newUnidade.Custo = this.custo;
            newUnidade.CustoVenda = this.custoVenda;
            newUnidade.TexturaAtaque = this.texturaAtaque;
            newUnidade.TexturaUnidade = this.texturaUnidade.Clone();
            newUnidade.UnidadeEvolucao = this.unidadeEvolucao;
            newUnidade.Nivel = this.Nivel;
            newUnidade.AudioAtaque = this.AudioAtaque;
            return newUnidade;
        }
    }
}
