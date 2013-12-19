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
    class Grid
    {
        List<GridItem> itens;
        SpriteFont fonte;
        Box box;
        object itemSelecionado;

        #region eventos
        public event EventHandler Click_Item;
        #endregion eventos

        public object ItemSelecionado
        {
            get { return itemSelecionado; } 
        }

        public Grid(int x, int y, int width, int height )
        {
            this.itens = new List<GridItem>();
            this.fonte = Global.bancoDados.Fonte;
            this.box = new Box(new Rectangle(x, y, width, height));
        }

        public void AddItem(GridItem gridItem)
        {
            this.itens.Add(gridItem);
        }

        public void AddItem(string texto, object valor)
        {
            Rectangle area;
            GridItem ultimoItem;

            try
            {
                ultimoItem = itens.Last();
            }
            catch (Exception) { ultimoItem = null; }

            if (ultimoItem == null)
                area = new Rectangle(box.Area.X + 10, box.Area.Y + 10, box.Area.Width - 20, 25);
            else
                area = new Rectangle(ultimoItem.Area.X, ultimoItem.Area.Y + ultimoItem.Area.Height , ultimoItem.Area.Width, 25);

            GridItem gridItem = new GridItem(texto, area, valor);
            gridItem.MouseClick += new System.EventHandler(this.Click_ItemSelecionado);

            AddItem(gridItem);
        }

        public void Update(GameTime gameTime, MouseState mouseState, MouseState mouseStateAnterior)
        {
            foreach (GridItem gridItem in itens)
            {
                gridItem.Update(gameTime, mouseState, mouseStateAnterior);
            }            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            box.Draw(spriteBatch);

            foreach (GridItem gridItem in itens)
            {
                gridItem.Draw(spriteBatch, fonte);
            }
        }

        private void Click_ItemSelecionado(object sender, EventArgs e)
        {
            foreach (GridItem gridItem in itens)
            {
                if (gridItem.Selecionado)
                {
                    itemSelecionado = gridItem.Valor;
                    Click_Item(this, new EventArgs());
                }
                
            }
        }
    }
}
