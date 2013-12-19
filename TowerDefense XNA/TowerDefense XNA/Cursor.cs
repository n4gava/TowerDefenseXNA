using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefense_XNA.BancoDados;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense_XNA
{
    public class Cursor
    {
        #region Propriedades
        Textura textura;
        public bool pressionado = false;
        #endregion Propriedades

        #region Atributos
        public Cursor()
        {
            this.textura = Textura.GetTextura("texturaMenu"); 
        }
        #endregion Atributos

        #region Métodos
        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
                pressionado = true;
            else
                pressionado = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = Mouse.GetState();
            Rectangle imagem;
            if (pressionado)
                imagem = textura.GetRetangleIndex(23);
            else
                imagem = textura.GetRetangleIndex(22);

            spriteBatch.Draw(textura.Textura2D,
                new Vector2(mouseState.X, mouseState.Y),
                imagem,
                Color.White,
                0.0f,
                Vector2.Zero,
                1f,
                SpriteEffects.None,
                0.0f);
        }
        #endregion Métodos
    }
}
