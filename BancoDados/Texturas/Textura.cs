using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class Textura
    {
        public int altura;
        public int largura;
        public string textura;

        Texture2D texture2D;

        public Textura(string textura, Texture2D texture2D)
        {
            this.textura = textura;
            this.texture2D = texture2D;
            this.altura = this.texture2D.Height;
            this.largura = this.texture2D.Width;
        }

        public Texture2D Textura2D
        {
            get { return texture2D; }
        }

        public Rectangle GetRetangleIndex(int index)
        {
            int larguraFrames = (int)this.largura / Global.frameLength;
            int posy = (int)Math.Truncate((float)(index) / larguraFrames);
            int posx = index - (larguraFrames * posy);

            Rectangle imagem = new Rectangle(posx * Global.frameLength, posy * Global.frameLength, Global.frameLength, Global.frameLength);

            return imagem;
        }

        public static Textura GetTextura(string textura)
        {
            return Global.bancoDados.Texturas.Where(x => x.textura == textura).First();
        }
    }
}

