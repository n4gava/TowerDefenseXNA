using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class TexturaSpriteMovimento : TexturaMovimento
    {
        public TexturaSpriteMovimento(Textura textura, int colunas, int linhas)
            : base(textura, colunas, linhas)
        {
        }

        protected override void AddAnimacoes(List<Rectangle> frames)
        {
            base.AddAnimacoes(frames);

            float intervalo = 0.2f;
            //Baixo
            Animacao paradoBaixo = new Animacao(frames, 0, 1, intervalo);
            paradoBaixo.Repete = false;
            AddAnimation("paradoBaixo", paradoBaixo);

            Animacao andandoBaixo = new Animacao(frames, 1, 3, intervalo);
            andandoBaixo.Repete = true;
            AddAnimation("andandoBaixo", andandoBaixo);

            //Cima
            Animacao paradoCima = new Animacao(frames, 12, 1, intervalo);
            paradoCima.Repete = false;
            AddAnimation("paradoCima", paradoCima);

            Animacao andandoCima = new Animacao(frames, 13, 3, intervalo);
            andandoCima.Repete = true;
            AddAnimation("andandoCima", andandoCima);

            //Direita
            Animacao paradoDireita = new Animacao(frames, 8, 1, intervalo);
            paradoDireita.Repete = false;
            AddAnimation("paradoDireita", paradoDireita);

            Animacao andandoDireita = new Animacao(frames, 9, 3, intervalo);
            andandoDireita.Repete = true;
            AddAnimation("andandoDireita", andandoDireita);

            //Esquerda
            Animacao paradoEsquerda = new Animacao(frames, 4, 1, intervalo);
            paradoEsquerda.Repete = false;
            AddAnimation("paradoEsquerda", paradoEsquerda);

            Animacao andandoEsquerda = new Animacao(frames, 5, 3, intervalo);
            andandoEsquerda.Repete = true;
            AddAnimation("andandoEsquerda", andandoEsquerda);
        }

        public override void UpdateAnimacao(GameTime gametime)
        {
            this.centro = posicao + new Vector2(16, 16);
            base.UpdateAnimacao(gametime);
        }

        public TexturaSpriteMovimento Clone()
        {
            TexturaSpriteMovimento textura = new TexturaSpriteMovimento(this.textura, this.colunas, this.linhas);
            return textura;
        }
            
    }
}
