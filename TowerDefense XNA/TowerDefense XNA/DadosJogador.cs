using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TowerDefense_XNA.BancoDados;
using TowerDefense_XNA.Menu;
using TowerDefense_XNA.BarraInformacoes;
using TowerDefense_XNA.BarraUnidades;

namespace TowerDefense_XNA
{
    class DadosJogador
    {
        #region propriedades
        int ouro;
        int vida;
        float tempoUltimaRodada;
        RodadaInimigo rodadaInimigo;
        const int ouroTurno = 50;
        Nivel nivelAtual;
        List<Unidade> unidades = new List<Unidade>();
        List<AnimacaoOuro> animacoesOuro = new List<AnimacaoOuro>();
 
        int rodadaAtual;
        bool rodadaFinalizada;
        bool nivelCompleto = false;
        bool pause = false;
        bool nivelCompletado = false;

        Transacao transacaoFinal;
        Textura texturaFinal;

        BarraInformacoes.BarraInformacoes barraInfo;
        BarraUnidades.BarraUnidades barraUnidades;

        MouseState mouseState;
        MouseState oldMouseState;

        Unidade unidadeCompra;
        TexturaCicle texturaCicle;

        MenuUnidade menuUnidade;
        #endregion propriedades

        #region eventos
        public event EventHandler OnNivelFracassado;
        public event EventHandler OnNivelSucesso;
        #endregion eventos

        #region Atributos
        public int Ouro
        {
            get { return ouro; }
            set { ouro = value; }
        }

        public int Vida
        {
            get { return vida; }
            set { vida = value; }
        }

        public Nivel NivelAtual
        {
            set { nivelAtual = value;}
        }

        public bool Pause
        {
            set { pause = value; }
            get { return pause; }
        }
        #endregion Atributos

        #region Métodos
        public DadosJogador()
        {
            this.tempoUltimaRodada = 0;
            this.rodadaAtual = 0;
            barraInfo = new BarraInformacoes.BarraInformacoes();
            barraUnidades = new BarraUnidades.BarraUnidades();
            barraUnidades.UnidadeSelecionada += new System.EventHandler(this.SelecionaUnidadeCompra);
            transacaoFinal = new Transacao();
            transacaoFinal.Tempo = 5;
            transacaoFinal.OnFinalizarTransacao += new System.EventHandler(this.NivelTerminado);
            animacoesOuro = new List<AnimacaoOuro>();
        }

        public void AtualizaBarraInfo()
        {
            this.barraInfo.Ouro = this.Ouro;
            this.barraInfo.Vida = this.Vida;
            this.barraInfo.RodadaAtual = this.rodadaAtual;
        }

        private void ProximaRodada()
        {
            rodadaAtual = rodadaAtual + 1;
            tempoUltimaRodada = 0;
            rodadaFinalizada = false;
            IEnumerable<RodadaInimigo> rodadasInimigo = Global.bancoDados.RodadasInimigo.Where(x => x.Rodada == rodadaAtual && x.Nivel == this.nivelAtual);

            if (rodadasInimigo.Count() > 0)
            {
                rodadaInimigo = rodadasInimigo.First().Clone();
                rodadaInimigo.OnInimigoNoFinal += new System.EventHandler(this.DiminuiVidaJogador);
                if (rodadaAtual > 1)
                    this.ouro += 50;
            }
            else
                NivelSucesso();
                
        }

        public bool EstaFrameLimpo(int cellY, int cellX)
        {
            try
            {
                if (this.nivelAtual.MapaUnidades[cellY, cellX] == 1)
                {
                    foreach (Unidade unidade in this.unidades)
                    {
                        if (unidade.Posicao.X == (cellX * 32) && unidade.Posicao.Y == (cellY * 32))
                            return false;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateCompraUnidade(MouseState mouseState, int cellY, int cellX)
        {
            if (unidadeCompra != null)
            {
                unidadeCompra.Posicao = new Vector2(Mouse.GetState().X - 8, Mouse.GetState().Y - 8);

                if (mouseState.LeftButton == ButtonState.Released)
                {


                    if (EstaFrameLimpo(cellY, cellX))
                    {
                        
                        //Guerreiro guerreiro = (Guerreiro)Global.bancoDados.Unidades.Where(x => x.Nome == "Guerreiro_1").First();
                        if (this.Ouro >= unidadeCompra.Custo)
                        {

                            
                            this.Ouro -= unidadeCompra.Custo;
                            if (unidadeCompra is Guerreiro)
                            {
                                unidadeCompra = unidadeCompra.Clone<Guerreiro>();
                            }
                            else if (unidadeCompra is MagoFogo)
                            {
                                unidadeCompra = unidadeCompra.Clone<MagoFogo>();
                            }
                            else if (unidadeCompra is MagoGelo)
                            {
                                unidadeCompra = unidadeCompra.Clone<MagoGelo>();
                            }

                            unidadeCompra.Posicao = new Vector2(cellX * 32, cellY * 32);
                            unidadeCompra.MatouInimigo += new System.EventHandler(this.AoMatarInimigo);
                            unidadeCompra.OnClick += new System.EventHandler(this.SelecionaUnidade);


                            unidades.Add(unidadeCompra);
                        }
                        
                    }

                    unidadeCompra = null;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (!Pause)
            {
                // busca a posicao do Mouse dentro dos quadros
                int cellX = (int)(mouseState.X / 32);
                int cellY = (int)(mouseState.Y / 32);
                // busca qual quadro o mouse se encontra
                int tileX = cellX * 32;
                int tileY = cellY * 32;

                if (!nivelCompleto)
                {
                    if (rodadaInimigo != null)
                    {
                        rodadaInimigo.Update(gameTime);

                        if (rodadaInimigo.RodadaFinalizada)
                        {
                            rodadaFinalizada = true;
                        }
                    }
                    else
                        rodadaFinalizada = true;

                    if (rodadaFinalizada)
                    {
                        tempoUltimaRodada += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }

                    if (tempoUltimaRodada > 2.5f)
                    {
                        ProximaRodada();
                    }
                }

                foreach (Unidade unidade in unidades)
                {
                    if (unidade.Alvo == null && rodadaInimigo != null)
                        unidade.BuscaInimigoProximo(this.rodadaInimigo.Inimigos.Where(x=> x.Ativo && !(x.Morto)).ToList());

                    List<Inimigo> inimigos;
                    if (rodadaInimigo != null)
                        inimigos = this.rodadaInimigo.Inimigos.Where( x=> x.Ativo && !x.Morto).ToList();
                    else
                        inimigos = new List<Inimigo>();

                    unidade.Update(gameTime, mouseState, oldMouseState, inimigos);

                }

                List<AnimacaoOuro> animacoes = new List<AnimacaoOuro>(animacoesOuro);

                foreach (AnimacaoOuro animacao in animacoes)
                    animacao.Update(gameTime);


                AtualizaBarraInfo();
                UpdateCompraUnidade(mouseState, cellY, cellX);
                if (menuUnidade != null)
                    menuUnidade = menuUnidade.Update(gameTime);

            }
            
            barraUnidades.Update(gameTime);
            transacaoFinal.Update(gameTime);

            oldMouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            nivelAtual.Draw(spriteBatch);
            if (rodadaInimigo != null)
                rodadaInimigo.Draw(spriteBatch);

            foreach (Unidade unidade in unidades)
                unidade.Draw(spriteBatch);

            foreach (AnimacaoOuro animacao in animacoesOuro)
                animacao.Draw(spriteBatch);

            DrawCompraUnidade(spriteBatch);

            if (menuUnidade != null)
                menuUnidade.Draw(spriteBatch);
             
            barraInfo.Draw(spriteBatch);
            barraUnidades.Draw(spriteBatch, this.ouro);


            transacaoFinal.Draw(spriteBatch, viewport);
            if (texturaFinal != null)
            {
                Vector2 posicao = new Vector2((Global.LarguraJanela - texturaFinal.Textura2D.Width) / 2 + 5, 
                                             (((Global.AlturaJanela - texturaFinal.Textura2D.Height) / 2) - 10));
                spriteBatch.Draw(texturaFinal.Textura2D, posicao, Color.White * this.transacaoFinal.Transparencia );
            }


        }

        private void DrawCompraUnidade(SpriteBatch spriteBatch)
        {
            if (unidadeCompra != null)
            {
                spriteBatch.Draw(texturaCicle.Textura, unidadeCompra.Posicao - new Vector2(texturaCicle.Raio - 16, texturaCicle.Raio - 16), Color.White);
                unidadeCompra.Draw(spriteBatch);
                Color corFundo;
                if (unidadeCompra.Custo > this.Ouro)
                    corFundo = Color.Red;
                else
                    corFundo = Color.Green;

                for (int x = 0; x < nivelAtual.MapaUnidades.GetLength(1); x++)
                {
                    for (int y = 0; y < nivelAtual.MapaUnidades.GetLength(0); y++)
                    {
                        if (EstaFrameLimpo(y, x))
                        {
                            spriteBatch.Draw(Global.texturaBranca.Textura2D, new Rectangle(x * 32, y * 32, 30, 30), corFundo * 0.2f);
                        }
                    }
                }
            }
        }

        private void DiminuiVidaJogador(object sender, EventArgs e)
        {
            this.vida--;

            if (this.vida == 0)
            {
                NivelFracassado();
            }
        }   

        private void AoMatarInimigo(object sender, EventArgs e)
        {
            Inimigo inimigo = (Inimigo)sender;

            this.ouro += inimigo.Ouro;
            AnimacaoOuro animacaoOuro = new AnimacaoOuro(inimigo.Ouro, inimigo);
            animacaoOuro.FinalizouAnimacao += new System.EventHandler(this.AoFinalizarAnimacaoOuro);
            animacoesOuro.Add(animacaoOuro);
        }

        private void AoFinalizarAnimacaoOuro(object sender, EventArgs e)
        {
            animacoesOuro.Remove((AnimacaoOuro)sender);
        }

        private void SelecionaUnidadeCompra(object sender, EventArgs e)
        {
            if (unidadeCompra == null)
            {
                if (sender is Guerreiro)
                {
                    Guerreiro guerreiro = ((Guerreiro)sender).Clone<Guerreiro>();
                    unidadeCompra = guerreiro;
                }
                else if (sender is MagoFogo)
                {
                    MagoFogo magoFogo = ((MagoFogo)sender).Clone<MagoFogo>();
                    unidadeCompra = magoFogo;
                }
                else if (sender is MagoGelo)
                {
                    MagoGelo magoGelo = ((MagoGelo)sender).Clone<MagoGelo>();
                    unidadeCompra = magoGelo;
                }
                else if (sender is Vampiro)
                {
                    Vampiro vampiro = ((Vampiro)sender).Clone<Vampiro>();
                    unidadeCompra = vampiro;
                }

                MouseState mouseState = Mouse.GetState();
                unidadeCompra.Posicao = new Vector2(mouseState.X, mouseState.Y);
                unidadeCompra.TexturaUnidade.ExecutaAnimacao(Movimento.paradoBaixo);
                int raio = (int)unidadeCompra.Distancia / 2;
                texturaCicle = new TexturaCicle(raio);
            }
            
        }

        private void SelecionaUnidade(object sender, EventArgs e)
        {
            if (menuUnidade == null)
            {
                menuUnidade = new MenuUnidade((Unidade)sender);
                menuUnidade.OnSellUnidade += new System.EventHandler(VenderUnidade);
                menuUnidade.OnUpUnidade += new System.EventHandler(UpUnidade);
            }
        }

        private void VenderUnidade(object sender, EventArgs e)
        {
            Unidade unidade = (Unidade)sender;
            this.Ouro += unidade.CustoVenda;
            unidades.Remove(unidade);
             
        }

        private void UpUnidade(object sender, EventArgs e)
        {
            Unidade unidade = (Unidade)sender;
            if (this.Ouro >= unidade.UnidadeEvolucao.Custo)
            {
                unidade.Evolucao();
                this.Ouro -= unidade.Custo;
            }
        }

        private void NivelSucesso()
        {
            transacaoFinal.IniciarTransacao();
            pause = true;
            texturaFinal = Textura.GetTextura("VoceVenceu");

            nivelCompletado = true;
        }

        private void NivelFracassado()
        {
            transacaoFinal.IniciarTransacao();
            pause = true;
            texturaFinal = Textura.GetTextura("VocePerdeu");
        }

        private void NivelTerminado(object sender, EventArgs e)
        {
            if (nivelCompletado)
                OnNivelSucesso(this, new EventArgs());
            else
                OnNivelFracassado(this, new EventArgs());
        }

        #endregion Métodos
    }

    public class AnimacaoOuro
    {
        int ouro;
        Vector2 posicao;
        float tempoControle;
        float tempo = 2;
        SpriteFont fonte;

        public event EventHandler FinalizouAnimacao;

        public AnimacaoOuro(int ouro, Inimigo inimigo)
        {
            this.ouro = ouro;
            this.posicao = new Vector2(inimigo.Posicao.X + 3, inimigo.Posicao.Y - 2);
            this.fonte = Global.bancoDados.Fonte10;
        }

        public void Update(GameTime gameTime)
        {
            tempoControle += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (tempoControle > tempo)
                FinalizouAnimacao(this, new EventArgs());
            else
                posicao.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.005f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(fonte, "+ " + ouro.ToString(), posicao, Color.Black); //new Color(255, 153, 0));
        }
    }
}
