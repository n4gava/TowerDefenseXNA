using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense_XNA.BancoDados
{
    public class TexturaCicle
    {
        Texture2D textura;
        int raio;

        public Texture2D Textura
        {
            get { return textura; }
        }

        public int Raio
        {
            get { return raio; }
        }


        public TexturaCicle(int raio)
        {
            this.raio = raio;
            int outerRadius = raio * 2 + 2;
            Texture2D texture = new Texture2D(Global.graphicsDevice, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];

            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            double angleStep = 1f / raio;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                int x = (int)Math.Round(raio + raio * Math.Cos(angle));
                int y = (int)Math.Round(raio + raio * Math.Sin(angle));

                data[y * outerRadius + x + 1] = Color.White;
            }

            texture.SetData(data);
            this.textura = texture;
        }
    }
}
