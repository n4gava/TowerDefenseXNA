using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefense_XNA.BancoDados;

namespace TowerDefense_XNA
{
    class MenuUnidade
    {
        Unidade unidade;
        Textura fundo;
        Textura up;
        Textura gold;
        Vector2 posicao;
        Vector2 posicaoUp;
        Vector2 posicaoSell;
        Vector2 centro;
        SpriteFont fonte;
        MouseState mouseStateAnterior;
        Rectangle selecaoSell;
        Rectangle selecaoUp;
        bool MouseOverUp = false;
        bool MouseOverSell = false;

        public event EventHandler OnSellUnidade;
        public event EventHandler OnUpUnidade;

        public MenuUnidade(Unidade unidade)
        {
            this.unidade = unidade;
            fundo = Textura.GetTextura("MenuUnidadeFundo");
            up = Textura.GetTextura("Up");
            gold = Textura.GetTextura("Ouro");
            int raiodif = (fundo.Textura2D.Width / 2) - 16;
            posicao = unidade.Posicao - new Vector2(raiodif, raiodif);
            centro = unidade.Centro;
            fonte = Global.bancoDados.FonteMenuUnidade;
            posicaoSell = centro - new Vector2(60, 30);
            posicaoUp = centro + new Vector2(25, -20);
            selecaoSell = new Rectangle((int)posicaoSell.X, (int)posicaoSell.Y, 40, 50);
            selecaoUp = new Rectangle((int)posicaoUp.X, (int)posicaoSell.Y, 40, 50);
        }

        public MenuUnidade Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Released && mouseStateAnterior.LeftButton == ButtonState.Pressed)
            {
                if (MouseOverUp)
                    OnUpUnidade(unidade, new EventArgs());
                else if (MouseOverSell)
                    OnSellUnidade(unidade, new EventArgs());
                
                return null;
            }

            // Mouse sobre Up
            if (unidade.UnidadeEvolucao != null)
            {
                if (mouseState.X > selecaoUp.X && mouseState.X < (selecaoUp.Width + selecaoUp.X) && mouseState.Y > selecaoUp.Y && mouseState.Y < (selecaoUp.Height + selecaoUp.Y))
                    MouseOverUp = true;
                else
                    MouseOverUp = false;
            }

            // Mouse sobre sell
            if (mouseState.X > selecaoSell.X && mouseState.X < (selecaoSell.Width + selecaoSell.X) && mouseState.Y > selecaoSell.Y && mouseState.Y < (selecaoSell.Height + selecaoSell.Y))
                MouseOverSell = true;
            else
                MouseOverSell = false;


            
            mouseStateAnterior = mouseState;
            return this;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            float escalaUp = 1f;
            if (MouseOverUp)
                escalaUp = 1.2f;

            float escalaGold = 0.12f;
            float escalaGoldFont = 1f;
            if (MouseOverSell)
            {
                escalaGold = 0.14f;
                escalaGoldFont = 1.2f;
            }

            spriteBatch.Draw(fundo.Textura2D, posicao, Color.White * 0.2f);
            // draw Venda
            spriteBatch.Draw(gold.Textura2D, posicaoSell, null, Color.White, 0f, Vector2.Zero, escalaGold, SpriteEffects.None, 1f);
            spriteBatch.DrawString(fonte, unidade.CustoVenda.ToString(), posicaoSell + new Vector2(0, 30), Color.Black, 0f, Vector2.Zero, escalaGoldFont, SpriteEffects.None, 0f);



            // draw evolução
            if (unidade.UnidadeEvolucao != null)
            {
                //spriteBatch.Draw(up.Textura2D, posicaoUp, null, Color.White);
                spriteBatch.Draw(up.Textura2D, posicaoUp, null, Color.White, 0f, Vector2.Zero, escalaUp, SpriteEffects.None, 1f);
                spriteBatch.DrawString(fonte, unidade.UnidadeEvolucao.Custo.ToString(), posicaoUp + new Vector2(0, 20), Color.Black, 0f, Vector2.Zero, escalaUp, SpriteEffects.None, 0f);
            }
            unidade.Draw(spriteBatch);
        }
    }
}
