using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class Animacao
    {
        #region propriedades
        int qtdeFrames;
        bool repete = false;
        private float intervalo = 0.2f;
        private List<Rectangle> frames = new List<Rectangle>();
        #endregion propriedades

        #region Atributos
        public bool Repete
        {
            get { return repete; }
            set { repete = value; }
        }

        public List<Rectangle> Frames
        {
            get { return this.frames; }
        }

        public int QtdeFrames
        {
            get { return qtdeFrames; }
        }

        public float Intervalo
        {
            get { return this.intervalo; }
            set { this.intervalo = value; }
        }
        #endregion Atributos

        #region Métodos
        public Animacao(List<Rectangle> frames, int frameInicial, int qtdeFrames, float intervalo)
        {
            this.qtdeFrames = qtdeFrames;
            this.intervalo = intervalo;
            for (int i = frameInicial; i < frameInicial + qtdeFrames; i++)
                Frames.Add(frames[i]);
        }
        #endregion Métodos
    }
}
