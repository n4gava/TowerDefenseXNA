using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TowerDefense_XNA.BancoDados;
using TowerDefense_XNA.Menu;


namespace TowerDefense_XNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TowerDefenseXNA : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu.Menu menu;
        Cursor cursor;
        DadosJogador dadosJogador;
        Perfil perfil;
        //AnimacaoInicial animacaoInicial;

        public TowerDefenseXNA()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Global.AlturaJanela;
            graphics.PreferredBackBufferWidth = Global.LarguraJanela;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            //graphics.IsFullScreen = true;
            
        }

        internal DadosJogador DadosJogador
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            Global.graphicsDevice = this.GraphicsDevice;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.bancoDados = new BancoDados.BancoDados();
            Global.bancoDados.CarregaBancoDados(Content);

            cursor = new Cursor();

            menu = new Menu.Menu();
            menu.ClickSair += new System.EventHandler(this.Click_Sair);
            menu.SelecionaNivel += new System.EventHandler(this.Click_SelecionaNivel);
            menu.SelecionaPerfil += new System.EventHandler(this.Click_SelecionaPerfil);

            //animacaoInicial = new AnimacaoInicial();

            //botoesMenu = new List<Botao>();
            //botoesMenu.Add(new Botao(new Rectangle(20, 20, 100, 40), "Jogar"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            cursor.Update(gameTime);

            /*if (animacaoInicial.Ativo)
            {
                animacaoInicial.Update(gameTime);
            }
            else */
            if (menu.Ativo)
            {
                menu.Update(gameTime);
            }
            else
            {
                dadosJogador.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin();

            /*if (animacaoInicial.Ativo)
            {
                animacaoInicial.Draw(spriteBatch);
            }
            else*/ 
            if (menu.Ativo)
            {
                menu.Draw(spriteBatch, GraphicsDevice.Viewport);
            }
            else
            {
                // Código do jogo
                dadosJogador.Draw(spriteBatch, GraphicsDevice.Viewport);
            }

            spriteBatch.End();


            spriteBatch.Begin();
            cursor.Draw(spriteBatch);
            spriteBatch.End();
            


            base.Draw(gameTime);
        }

        private void Click_Sair(object sender, System.EventArgs e)
        {
            this.Exit();
        }

        private void Click_SelecionaNivel(object sender, System.EventArgs e)
        {
            dadosJogador = new DadosJogador();
            dadosJogador.Ouro = 300;
            dadosJogador.Vida = 10;
            dadosJogador.NivelAtual = menu.NivelSelecionado;
            dadosJogador.OnNivelFracassado += new System.EventHandler(this.On_NivelFracassado);
            dadosJogador.OnNivelSucesso += new System.EventHandler(this.On_NivelSucesso);
        }


        private void On_NivelFracassado(object sender, System.EventArgs e)
        {
            menu.Ativo = true;
        }

        private void On_NivelSucesso(object sender, System.EventArgs e)
        {
            menu.Ativo = true;
            perfil.ProximoNivel(menu.NivelSelecionado);
            menu.CarregaNiveis(perfil);
        }

        private void Click_SelecionaPerfil(object sender, System.EventArgs e)
        {
            perfil = menu.PerfilSelecionado;
        }
    }
}
