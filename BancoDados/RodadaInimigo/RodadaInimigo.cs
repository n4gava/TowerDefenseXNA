using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class RodadaInimigo
    {
        #region propriedades
        int numeroInimigos = 0;
        int rodada;
        const int tempoSaida = 5;
        List<Inimigo> inimigos = new List<Inimigo>();
        Nivel nivel;

        int inimigosEmJogo;
        bool enviaInimigos = true;
        float tempoEnvio = 0;
        int indexPontoCaminho = 0;
        #endregion propriedades

        #region eventos
        public event EventHandler OnInimigoNoFinal;
        #endregion eventos

        #region Atributos
        public Nivel Nivel
        {
            get { return nivel; }
        }

        public int Rodada
        {
            get { return rodada; }
        }

        public List<Inimigo> Inimigos
        {
            get { return inimigos; }
        }

        public bool RodadaFinalizada
        {
            get
            {
                return inimigos.Where(x => !x.Morto).Count() == 0 && inimigosEmJogo == numeroInimigos;
            }
        }

        #endregion Atributos

        #region Métodos
        public RodadaInimigo(Nivel nivel, int rodada)
        {
            this.nivel = nivel;
            this.rodada = rodada;
        }

        public void AddInimigo(Inimigo inimigo)
        {
            inimigo.OnFinal += new System.EventHandler(this.InimigoChegaNoFinal);
            this.inimigos.Add(inimigo);
            this.numeroInimigos = numeroInimigos + 1;
        }

        public void Start()
        {
            enviaInimigos = true;
        }

        private void ProximoIndexCaminho()
        {
            indexPontoCaminho++;
            if (indexPontoCaminho > (nivel.PontosCaminho.Count() - 1))
            {
                indexPontoCaminho = 0;
            }
        }

        public void ChamaProximoInimigo()
        {
            tempoEnvio = 0;

            Inimigo inimigo = inimigos.Where(x => !x.Ativo).First();
            // adiciona 10% de vida por turno
            for (int i = 1; i < this.rodada; i++)
            {
                inimigo.Vida += inimigo.Vida * 6 / 100;    
            }

            Queue<Vector2> caminhoInimigo = nivel.PontosCaminho[indexPontoCaminho];
            inimigo.SetPontoCaminho(caminhoInimigo);
            ProximoIndexCaminho();

            inimigo.Ativo = true;
        }

        public void Update(GameTime gameTime)
        {
            inimigosEmJogo = inimigos.Where(x => x.Ativo).Count();

            if (inimigosEmJogo == numeroInimigos)
                enviaInimigos = false;

            if (enviaInimigos)
            {
                tempoEnvio += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (tempoEnvio > 1.2f)
                    ChamaProximoInimigo(); 
            }

            foreach (Inimigo inimigo in inimigos.Where(x => x.Ativo))
            {
                if (!inimigo.Morto)
                    inimigo.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Inimigo inimigo in inimigos.Where(x => x.Ativo))
                inimigo.Draw(spriteBatch);
        }

        public RodadaInimigo Clone()
        {
            RodadaInimigo newRodadaInimigo = new RodadaInimigo(this.nivel, this.rodada);
            foreach (Inimigo inimigo in this.inimigos)
            {
                newRodadaInimigo.AddInimigo(inimigo.Clone());
            }

            return newRodadaInimigo;
        }

        private void InimigoChegaNoFinal(object sender, EventArgs e)
        {
            Inimigo inimigo = (Inimigo)sender;
            inimigo.Vida = 0;
            OnInimigoNoFinal(this, new EventArgs());
        }
        #endregion Métodos
    }
}
