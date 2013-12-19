using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TowerDefense_XNA.BancoDados
{
    public class Inimigo
    {
        #region propriedades
        string nome;
        float vida;
        float vidaTotal = 0;
        int velocidade;
        int ouro;
        bool ativo = false;
        int lentidao = 0;
        int tempoLentidao = 0;
        float tempoLentidaoPercorrido;
        TexturaSpriteMovimento texturaInimigo;
        Movimento movimentoInimigo = Movimento.andandoBaixo;
        Queue<Vector2> pontosCaminho = new Queue<Vector2>();
        Texture2D texturaBranca;

        Vector2 posicao_anterior = new Vector2();
        float rotacao = 0;

        Vector2 velocity;
        #endregion propriedades

        #region Atributos
        public string Nome
        {
            get { return nome; }
            set { nome = value;
                  TexturaInimigo = new TexturaSpriteMovimento(Textura.GetTextura(this.Nome), 4, 4);
                }
        }

        public float Vida
        {
            get { return vida; }
            set
            {
                if (value > vidaTotal)
                {
                    vidaTotal = value;
                }
                vida = value; 
            }
        }

        public int Velocidade
        {
            get { return velocidade; }
            set { velocidade = value; }
        }

        public int Ouro
        {
            get { return ouro; }
            set { ouro = value; }
        }

        public bool Morto
        {
            get { return vida <= 0; }
        }

        public Vector2 Centro
        {
            get { return texturaInimigo.Centro; }
        }

        public TexturaSpriteMovimento TexturaInimigo
        {
            set { texturaInimigo = value;}
        }

        public Vector2 Posicao
        {
            set { texturaInimigo.Posicao = value; }
            get { return texturaInimigo.Posicao; }
        }

        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public int Lentidao
        {
            get { return lentidao; }
            set { lentidao = value; tempoLentidaoPercorrido = 0; }
        }

        public int TempoLentidao
        {
            get { return tempoLentidao; }
            set { tempoLentidao = value; }
        }
        

        #endregion Atributos

        #region eventos
        public event EventHandler OnFinal;
        #endregion eventos


        public Inimigo()
        {
            texturaBranca = Global.texturaBranca.Textura2D;
        }

        #region Métodos
        public void SetPontoCaminho(Queue<Vector2> pontoCaminho)
        {
            foreach (Vector2 pCaminho in pontoCaminho)
                this.pontosCaminho.Enqueue(pCaminho);

            this.texturaInimigo.Posicao = this.pontosCaminho.Dequeue();            
        }

        public float DistanciaDoDestino
        {
            get { return Vector2.Distance(this.texturaInimigo.Posicao, pontosCaminho.Peek()); }
        }

        public void Update(GameTime gameTime)
        {
            //this.centro = new Vector2(posicao.X + texturaInimigo.Textura.Textura2D.Width / 2, posicao.Y + texturaInimigo.Textura.Textura2D.Height / 2);

            if (pontosCaminho.Count > 0)
            {
                tempoLentidaoPercorrido += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (tempoLentidaoPercorrido >= this.tempoLentidao)
                    Lentidao = 0;

                int velocidadeReal = this.velocidade - (this.lentidao * velocidade / 100);

                if (DistanciaDoDestino < ((float)velocidadeReal / 64))
                {
                    this.texturaInimigo.Posicao = pontosCaminho.Peek();
                    pontosCaminho.Dequeue();
                }

                else
                {
                    Vector2 direction = pontosCaminho.Peek() - this.texturaInimigo.Posicao;
                    direction.Normalize();

                    velocity = Vector2.Multiply(direction, ((float)velocidadeReal / 64));

                    this.texturaInimigo.Posicao += velocity;
                }
            }
            else
                OnFinal(this, new EventArgs());

            if (this.texturaInimigo.Posicao.X > posicao_anterior.X)
                movimentoInimigo = Movimento.andandoDireita;
            else if (this.texturaInimigo.Posicao.X < posicao_anterior.X)
                movimentoInimigo = Movimento.andandoEsquerda;
            else if (this.texturaInimigo.Posicao.Y > posicao_anterior.Y)
                movimentoInimigo = Movimento.andandoBaixo;
            else if (this.texturaInimigo.Posicao.Y < posicao_anterior.Y)
                movimentoInimigo = Movimento.andandoCima;


            this.texturaInimigo.ExecutaAnimacao(movimentoInimigo);
            this.texturaInimigo.Posicao = this.texturaInimigo.Posicao;
            this.texturaInimigo.Update(gameTime);

            this.posicao_anterior = this.texturaInimigo.Posicao;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Morto)
            {
                this.texturaInimigo.Draw(spriteBatch);
                if (vida > 0)
                {
                    Color corVida;
                    int larguraVida = (int)((this.vida * 20) / vidaTotal);
                    if (larguraVida > 12)
                        corVida = Color.Green;
                    else if (larguraVida > 6)
                        corVida = Color.Yellow;
                    else 
                        corVida = Color.Red;

                    spriteBatch.Draw(texturaBranca, new Rectangle((int)this.texturaInimigo.Posicao.X + 6, (int)this.texturaInimigo.Posicao.Y, larguraVida, 2), corVida);

                    if (Lentidao > 0)
                        spriteBatch.Draw(texturaBranca, new Rectangle((int)this.Posicao.X + 2, (int)this.Posicao.Y + 30, 5,2), Color.Aqua);
                }
                
            }

        }

        public Inimigo Clone()
        {
            Inimigo newInimigo = new Inimigo();
            newInimigo.Nome = this.Nome;
            newInimigo.Ouro = this.Ouro;
            newInimigo.Vida = this.Vida;
            newInimigo.Velocidade = this.Velocidade;

            return newInimigo;
        }
         
        public static Inimigo GetInimigo(string nome)
        {

            return Global.bancoDados.Inimigos.Where(x => x.nome == nome).First();

        }
        #endregion Métodos
    }
}
