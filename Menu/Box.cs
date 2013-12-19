using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefense_XNA.BancoDados;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.Menu
{
    public class Box
    {
        Rectangle area;
        Textura textura;

        public Rectangle Area
        {
            get { return area; }
            set { area = value; }
        }

        public Box(Rectangle area)
        {
            this.textura = Textura.GetTextura("texturaMenu");
            this.area = area;
        }

        void DrawBorda(SpriteBatch spriteBatch, int posX, int posY, Rectangle rectangle)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            const int indexTextura = 16;
            Rectangle imagem = textura.GetRetangleIndex(indexTextura);

            int XZero = imagem.X;
            int YZero = imagem.Y;
            int pixelsFrame = 6;

            Rectangle bordaEsquerdaSup = new Rectangle(XZero, YZero, pixelsFrame, pixelsFrame);
            Rectangle bordaDireitaSup = new Rectangle(XZero + imagem.Width - pixelsFrame, YZero, pixelsFrame, pixelsFrame);
            Rectangle bordaEsquerdaInf = new Rectangle(XZero, YZero + imagem.Height - pixelsFrame, pixelsFrame, pixelsFrame);
            Rectangle bordaDireitaInf = new Rectangle(XZero + imagem.Width - pixelsFrame, YZero + imagem.Height - pixelsFrame, pixelsFrame, pixelsFrame);
            Rectangle BordaLateralEsquerda = new Rectangle(XZero, YZero + pixelsFrame, pixelsFrame + 3, 1);
            Rectangle BordaLateralDireita = new Rectangle(XZero + imagem.Width - pixelsFrame, YZero + pixelsFrame, pixelsFrame, 1);
            Rectangle BordaLateralSuperior = new Rectangle(XZero + pixelsFrame, YZero, 1, pixelsFrame);
            Rectangle BordaLateralInferior = new Rectangle(XZero + pixelsFrame, YZero + imagem.Height - pixelsFrame, 1, pixelsFrame);
            Rectangle Centro = new Rectangle(XZero + pixelsFrame, YZero + pixelsFrame, pixelsFrame, pixelsFrame);

            int posX = area.X;
            int posY = area.Y;

            DrawBorda(spriteBatch, posX, posY, bordaEsquerdaSup);
            posY = posY + pixelsFrame;

            for (int i = 0; i < area.Height - (pixelsFrame * 2); i++)
            {
                DrawBorda(spriteBatch, posX, posY, BordaLateralEsquerda);
                posY = posY + 1;
            }

            DrawBorda(spriteBatch, posX, posY, bordaEsquerdaInf);

            posX = posX + pixelsFrame;
            posY = area.Y;
            for (int i = posX; i < (area.X + area.Width - pixelsFrame); i++)
            {
                DrawBorda(spriteBatch,i, posY, BordaLateralSuperior);
            }

            posX = area.X + pixelsFrame;
            posY = area.Y + pixelsFrame;
            for (int i = posX; i < (area.X + area.Width - pixelsFrame); i = i + pixelsFrame)
            {
                for (int j = posY; j < (area.Y + area.Height - pixelsFrame); j = j + pixelsFrame)
                {
                    DrawBorda(spriteBatch, i, j, Centro);
                }
            }

            posX = area.X + pixelsFrame;
            posY = area.Y + area.Height - pixelsFrame;
            for (int i = posX; i < (area.X + area.Width - pixelsFrame); i++)
            {
                DrawBorda(spriteBatch, i, posY, BordaLateralInferior);
            }

            posX = area.X + area.Width - pixelsFrame;
            posY = area.Y;

            DrawBorda(spriteBatch, posX, posY, bordaDireitaSup);

            posY = posY + pixelsFrame;

            for (int i = 0; i < area.Height - (pixelsFrame * 2); i++)
            {
                DrawBorda(spriteBatch,posX, posY, BordaLateralDireita);
                posY = posY + 1;
            }

            DrawBorda(spriteBatch,posX, posY, bordaDireitaInf);
        }

    }
}
