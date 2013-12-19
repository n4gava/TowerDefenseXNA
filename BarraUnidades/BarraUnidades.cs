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

namespace TowerDefense_XNA.BarraUnidades
{
    public class BarraUnidades
    {
        Box box;
        BotaoUnidade<Guerreiro> botaoGuerreio;
        BotaoUnidade<MagoFogo> botaoMagoFogo;
        BotaoUnidade<MagoGelo> botaoMagoGelo;
        BotaoUnidade<Vampiro> botaoVampiro;
        MouseState mouseStateAnterior;

        public event EventHandler UnidadeSelecionada;

        public BarraUnidades()
        {
            int posY = 380;
            this.box = new Box(new Rectangle(0, posY, Global.LarguraJanela, 64));
            
            Guerreiro guerreiro = (Guerreiro)Global.bancoDados.Unidades.Where(x => x.Nome == "Guerreiro_1").First().Clone<Guerreiro>();
            MagoFogo magoFogo = (MagoFogo)Global.bancoDados.Unidades.Where(x => x.Nome == "MagoFogo_1").First().Clone<MagoFogo>();
            MagoGelo magoGelo = (MagoGelo)Global.bancoDados.Unidades.Where(x => x.Nome == "MagoGelo").First().Clone<MagoGelo>();

            botaoGuerreio = new BotaoUnidade<Guerreiro>(guerreiro, "BotaoGuerreiro", new Vector2(10, posY), "Alto", "Pequena", "-");
            botaoMagoFogo = new BotaoUnidade<MagoFogo>(magoFogo, "BotaoMagoFogo",new Vector2(80, posY), "Médio", "Alta", "Ataque em área");
            botaoMagoGelo = new BotaoUnidade<MagoGelo>(magoGelo, "BotaoMagoGelo", new Vector2(150, posY), "-", "Alta", "30% lentidão");
            
            botaoGuerreio.MouseDown += new System.EventHandler(this.SelecionaUnidade);
            botaoMagoFogo.MouseDown += new System.EventHandler(this.SelecionaUnidade);
            botaoMagoGelo.MouseDown += new System.EventHandler(this.SelecionaUnidade);
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            botaoGuerreio.Update(gameTime, mouseState, mouseStateAnterior);
            botaoMagoFogo.Update(gameTime, mouseState, mouseStateAnterior);
            botaoMagoGelo.Update(gameTime, mouseState, mouseStateAnterior);
            mouseStateAnterior = mouseState;
        }

        public void Draw(SpriteBatch spriteBatch, int gold)
        {
            botaoGuerreio.Draw(spriteBatch, gold);
            botaoMagoFogo.Draw(spriteBatch, gold);
            botaoMagoGelo.Draw(spriteBatch, gold);
        }

        public void SelecionaUnidade(object sender, EventArgs e) 
        {
            UnidadeSelecionada(sender, e);
        }

    }

   
    public class BotaoUnidade<T> where T:Unidade
    {
        T unidade;
        bool selecionado;
        string dano;
        string distancia;
        string especial;
        SpriteFont fonte;
        Textura texturaBotao;
        Textura texturaBotaoVermelho;
        Textura texturaBotaoDown;
        Vector2 posicao;


        public event EventHandler MouseDown;

        public bool Selecionado
        {
            get { return selecionado; }
        }

        public BotaoUnidade(T unidade, string imagem, Vector2 posicao, string dano, string distancia, string especial)
        {
            this.unidade = unidade;
            //this.unidade.TexturaUnidade.ExecutaAnimacao(Movimento.paradoBaixo);
            //this.unidade.Posicao = posicao;
            this.posicao = posicao;
            this.dano = dano;
            this.distancia = distancia;
            this.especial = especial;
            this.fonte = Global.bancoDados.Fonte8;
            this.texturaBotao = Textura.GetTextura(imagem);
            this.texturaBotaoVermelho = Textura.GetTextura(imagem+"R");
            this.texturaBotaoDown = Textura.GetTextura(imagem+"D");
        }

        public void mouseOver(MouseState mouseState)
        {
            if (mouseState.X > this.posicao.X && mouseState.X < (texturaBotao.Textura2D.Width + this.posicao.X) && mouseState.Y > this.posicao.Y && mouseState.Y < (texturaBotao.Textura2D.Height + this.posicao.Y))
            {
                selecionado = true;
            }
            else
            {
                selecionado = false;
            }

        }

        public void Update(GameTime gametime, MouseState mouseState, MouseState mouseStateAnterior)
        {
            mouseOver(mouseState);

            if (selecionado == true && mouseStateAnterior.LeftButton == ButtonState.Pressed)
            {
                MouseDown(unidade, new EventArgs());
            }
        }

        public void Draw(SpriteBatch spriteBatch, int gold)
        {
            Textura textura;

            if (gold < unidade.Custo)
                textura = this.texturaBotaoVermelho;
            else if (selecionado)
                textura = this.texturaBotaoDown;
            else
                textura = this.texturaBotao;

            spriteBatch.Draw(textura.Textura2D, posicao, Color.White);
            //spriteBatch.DrawString(fonte, "Custo: " + unidade.Custo, this.unidade.Posicao + new Vector2(35, 0), Color.Black);
            //spriteBatch.DrawString(fonte, "Dano: " + dano, this.unidade.Posicao + new Vector2(35, 10), Color.Black);
            //spriteBatch.DrawString(fonte, "Distância: " + distancia, this.unidade.Posicao + new Vector2(35, 20), Color.Black);
            //spriteBatch.DrawString(fonte, "Especial: " + especial, this.unidade.Posicao + new Vector2(35, 30), Color.Black);

            //if (selecionado)
              //  spriteBatch.Draw(texturaBranca.Textura2D, new Rectangle((int)unidade.Posicao.X, (int)unidade.Posicao.Y, 32, 32), new Color(100, 0, 0, 0.1f));
        }


    }

    
}
