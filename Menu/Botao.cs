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

namespace TowerDefense_XNA.Menu
{
    class Botao
    {
        #region propriedades
        bool selecionado = false;
        string nomeBotao = "Botao";

        Rectangle area;
        Textura textura;
        #endregion propriedades


        #region eventos
        public event EventHandler MouseClick;
        #endregion eventos

        #region atributos
        public string NomeBotao
        {
            set { nomeBotao = value; }
        }

        public Rectangle Area
        {
            set { area = value; area.Height = 32; }
            get { return area; }
        }
        #endregion atributos

        public Botao()
        {
            this.textura = Textura.GetTextura("texturaMenu");
        }

        #region métodos
        public void mouseOver(MouseState mouseState)
        {
            if (mouseState.X > Area.X && mouseState.X < (Area.Width + Area.X) && mouseState.Y > Area.Y && mouseState.Y < (Area.Height + Area.Y))
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
            if (selecionado == true && mouseState.LeftButton == ButtonState.Pressed && mouseStateAnterior.LeftButton == ButtonState.Released)
            {
                // ativa o evento
                MouseClick(this, new EventArgs());
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont fonte)
        {
            //box.Draw(spriteBatch);
            DrawFundoBotao(spriteBatch);

            int posXText = Area.X + 10;
            int posYText = Area.Y + 5;

            if (selecionado)
                posXText += 2;

            spriteBatch.DrawString(fonte, nomeBotao, new Vector2(posXText, posYText), Color.Black);

        }

        private void SpriteDraw(SpriteBatch spriteBatch, int posX, int posY, Rectangle rectangle)
        {
            spriteBatch.Draw(textura.Textura2D,
                new Vector2(posX, posY),
                rectangle,
                Color.White,
                0.0f,
                Vector2.Zero,
                1f,
                SpriteEffects.None,
                0.0f);
        }

        private void DrawFundoBotao(SpriteBatch spriteBatch)
        {
            int indexTextura = 17;
            if (selecionado)
                indexTextura = 11;

            Rectangle imagem = textura.GetRetangleIndex(indexTextura);

            int XZero = imagem.X;
            int YZero = imagem.Y;
            int pixelsFrame = 6;

            Rectangle bordaEsquerda = new Rectangle(XZero, YZero, pixelsFrame, 32);
            Rectangle bordaDireita = new Rectangle(XZero + (32 - pixelsFrame), YZero, pixelsFrame, 32);
            Rectangle texturaMeio = new Rectangle(XZero + pixelsFrame, YZero, 1, 32);

            int posX = area.X;
            int posY = area.Y;

            SpriteDraw(spriteBatch, posX, posY, bordaEsquerda);

            posX += pixelsFrame;
            for (int i = 0; i < area.Width - (pixelsFrame * 2); i++)
            {
                SpriteDraw(spriteBatch, posX, posY, texturaMeio);
                posX++;
            }
            
            SpriteDraw(spriteBatch, posX, posY, bordaDireita);




        }

    }
    #endregion métodos

}
