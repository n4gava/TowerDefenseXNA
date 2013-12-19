using System;
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
    class GridItem
    {
        string texto;
        bool selecionado = false;
        Rectangle area;
        object valor;

        #region eventos
        public event EventHandler MouseClick;
        #endregion eventos

        public Rectangle Area
        {
            get { return area; } 
        }

        public bool Selecionado
        {
            get { return selecionado; }
        }

        public string Texto
        {
            get { return texto; }
        }

        public object Valor
        {
            get { return valor; }
        }

        public GridItem(string texto, Rectangle area, object valor)
        {
            this.texto = texto;
            this.area = area;
            this.valor = valor;
        }

        public void mouseOver(MouseState mouseState)
        {
            if (mouseState.X > area.X && mouseState.X < (area.Width + area.X) && mouseState.Y > area.Y && mouseState.Y < (area.Height + area.Y))
            {
                selecionado = true;
            }
            else
            {
                selecionado = false;
            }

        }

        public void Update(GameTime gameTime, MouseState mouseState, MouseState mouseStateAnterior)
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

            if (selecionado == false)
            {
                spriteBatch.DrawString(fonte, texto, new Vector2(area.X, area.Y), Color.Black);
            }
            else
            {
                spriteBatch.DrawString(fonte, texto, new Vector2(area.X, area.Y), Color.White);
            }
        }

    }
}
