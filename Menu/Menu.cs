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

namespace TowerDefense_XNA.Menu
{
    enum EstadoMenu
    {
        MenuInicial,
        SelecaoNiveis,
        InformacoesJogo
    }

    public class Menu
    {
        #region propriedades
        bool ativo = true;
        Nivel nivelSelecionado;
        List<Botao> botoesPrincipal = new List<Botao>();
        List<Botao> botoesSelecaoNiveis = new List<Botao>();
        List<Botao> botoesSobre = new List<Botao>();
        Textura textura;
        SpriteFont fonte;
        SpriteFont fonte10;
        Grid perfilGrid;
        Grid nivelGrid;
        Box boxSobre;
        EstadoMenu estadoMenu;
        Perfil perfilSelecionado;
        Textura texturaFundo;
        ItemTexto textBoxNovoPerfil;
        Textura logo;
        

        MouseState mouseState;
        MouseState mouseStateAnterior;

        //Box boxPerfis;
        #endregion propriedades

        public bool Ativo
        {
            get { return ativo;}
            set { ativo = value; }
        }

        public Nivel NivelSelecionado
        {
            get { return nivelSelecionado; }
        }

        public Perfil PerfilSelecionado
        {
            get { return perfilSelecionado; }
        }


        #region eventos
        public event EventHandler ClickSair;
        public event EventHandler SelecionaNivel;
        public event EventHandler SelecionaPerfil;
        #endregion eventos

        #region construtor
        public Menu()
        {
            this.textura = Textura.GetTextura("texturaMenu2"); 
            this.fonte = Global.bancoDados.Fonte;
            this.fonte10 = Global.bancoDados.Fonte10;

            int alturaBotao = 32;
            int largurabotao = 130;
            int borda = 10;
            this.estadoMenu = EstadoMenu.MenuInicial;
            this.texturaFundo = Textura.GetTextura("PlanoFundo");

            CarregaPerfis();

            Botao botaoNovoPerfil = new Botao();
            botaoNovoPerfil.Area = new Rectangle(Global.LarguraJanela - largurabotao - borda, Global.AlturaJanela - (alturaBotao * 3) - borda - 4, largurabotao, alturaBotao);
            botaoNovoPerfil.NomeBotao = "Novo Perfil";
            botaoNovoPerfil.MouseClick += new System.EventHandler(this.Click_NovoPerfil);

            Botao botaoSobre = new Botao();
            botaoSobre.Area = new Rectangle(Global.LarguraJanela - largurabotao - borda, Global.AlturaJanela - (alturaBotao * 2) - borda - 2, largurabotao, alturaBotao);
            botaoSobre.NomeBotao = "Sobre";
            botaoSobre.MouseClick += new System.EventHandler(this.Click_Sobre);

            Botao botaoSair = new Botao();
            botaoSair.Area = new Rectangle(Global.LarguraJanela - largurabotao - borda, Global.AlturaJanela - alturaBotao - borda, largurabotao, alturaBotao);
            botaoSair.NomeBotao = "Sair";
            botaoSair.MouseClick += new System.EventHandler(this.Click_Sair);

            botoesPrincipal.Add(botaoNovoPerfil);
            botoesPrincipal.Add(botaoSobre);
            botoesPrincipal.Add(botaoSair);

            Botao botaoVoltar = new Botao();
            botaoVoltar.Area = new Rectangle(Global.LarguraJanela - largurabotao - borda, Global.AlturaJanela - alturaBotao - borda, largurabotao, alturaBotao);
            botaoVoltar.NomeBotao = "Voltar";
            botaoVoltar.MouseClick += new System.EventHandler(this.Click_Voltar);
            
            Botao botaoExcluirPerfil = new Botao();
            botaoExcluirPerfil.Area = new Rectangle(Global.LarguraJanela - largurabotao - borda, Global.AlturaJanela - (alturaBotao * 2) - borda - 2, largurabotao, alturaBotao);
            botaoExcluirPerfil.NomeBotao = "Excluir Perfil";
            botaoExcluirPerfil.MouseClick += new System.EventHandler(this.Click_ExcluirPerfil);

            boxSobre = new Box(new Rectangle(10, 94, 360, 300));

            Botao botaoVoltarSobre = new Botao();
            botaoVoltarSobre.Area = new Rectangle(Global.LarguraJanela - largurabotao - borda, Global.AlturaJanela - alturaBotao - borda, largurabotao, alturaBotao);
            botaoVoltarSobre.NomeBotao = "Voltar";
            botaoVoltarSobre.MouseClick += new System.EventHandler(this.Click_Voltar);
            
            botoesSelecaoNiveis.Add(botaoVoltar);
            botoesSelecaoNiveis.Add(botaoExcluirPerfil);
            botoesSobre.Add(botaoVoltarSobre);

            textBoxNovoPerfil = new ItemTexto(40, 200, 300, 40);
            textBoxNovoPerfil.EnterKeyPressed += new System.EventHandler(this.ConfirmaNovoPerfil);
            textBoxNovoPerfil.EscKeyPressed += new System.EventHandler(this.CancelaNovoPerfil);

            logo = Textura.GetTextura("Logo");
            
        }
        #endregion constructor

        #region métodos
        private void CarregaPerfis()
        {
            //this.perfilGrid = new Grid(10, 74, 220, 364);
            this.perfilGrid = new Grid(10, 94, 220, 344);
            foreach (Perfil perfil in Global.bancoDados.Perfis)
            {
                this.perfilGrid.AddItem(perfil.Nome, perfil);
            }

            this.perfilGrid.Click_Item += new System.EventHandler(this.Click_SelecionaPerfil);
        }

        public void CarregaNiveis(Perfil perfil)
        {
            this.nivelGrid = new Grid(10, 94, 220, 344);

            foreach (Nivel nivel in perfil.GetNiveis())
            {
                this.nivelGrid.AddItem(nivel.Nome, nivel);
            }

            this.nivelGrid.Click_Item += new System.EventHandler(this.Click_SelecionaNivel);
        }

        private void DrawPlanoFundo(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaFundo.Textura2D, new Vector2(0, 0), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            DrawPlanoFundo(spriteBatch);

            Grid grid = this.perfilGrid;
            List<Botao> botoes = this.botoesPrincipal;

            spriteBatch.Draw(logo.Textura2D, new Vector2(10, 10), Color.White);

            if (this.estadoMenu == EstadoMenu.MenuInicial)
            {
                grid = this.perfilGrid;
                botoes = this.botoesPrincipal;
            }
            else if (this.estadoMenu == EstadoMenu.SelecaoNiveis)
            {
                grid = this.nivelGrid;
                botoes = this.botoesSelecaoNiveis;
            }
            else if (this.estadoMenu == EstadoMenu.InformacoesJogo)
            {
                botoes = this.botoesSobre;
                boxSobre.Draw(spriteBatch);
                grid = null;
                spriteBatch.DrawString(this.fonte, "Tower Defense XNA", new Vector2(100, 100), Color.White);
                spriteBatch.DrawString(this.fonte10, "Guilherme Gavazzoni", new Vector2(120, 140), Color.White);
                spriteBatch.DrawString(this.fonte10, "Trabalho de Conclusão de Curso - Ciência da Computação", new Vector2(20, 160), Color.White);
                spriteBatch.DrawString(this.fonte10, "Faculdade IDEU", new Vector2(135, 180), Color.White);
                spriteBatch.DrawString(this.fonte10, "Caxias do Sul - RS", new Vector2(125, 200), Color.White);

                spriteBatch.DrawString(this.fonte10, "Jogo desenvolvido com o objetivo de detalhar o", new Vector2(50, 250), Color.White);
                spriteBatch.DrawString(this.fonte10, "funcionamento do framework XNA utilizando", new Vector2(60, 270), Color.White);
                spriteBatch.DrawString(this.fonte10, "a linguagem de programação C#", new Vector2(95, 290), Color.White);
            }

            

            if (grid != null)
                grid.Draw(spriteBatch);

            foreach (Botao botao in botoes)
            {
                botao.Draw(spriteBatch, this.fonte);
            }

            if (textBoxNovoPerfil.Visivel)
            {
                spriteBatch.Draw(Global.texturaBranca.Textura2D,
                     new Rectangle(0, 0, viewport.Width, viewport.Height),
                     new Color(0, 0, 0, 0.5f));

                textBoxNovoPerfil.Draw(spriteBatch, fonte);
            }

            
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            Grid grid = this.perfilGrid;
            List<Botao> botoes = this.botoesPrincipal;

            if (this.estadoMenu == EstadoMenu.MenuInicial)
            {
                grid = this.perfilGrid;
                botoes = this.botoesPrincipal;
                
            }
            else if (this.estadoMenu == EstadoMenu.SelecaoNiveis)
            {
                grid = this.nivelGrid;
                botoes = this.botoesSelecaoNiveis;
            }
            else if (this.estadoMenu == EstadoMenu.InformacoesJogo)
            {
                botoes = this.botoesSobre;
            }

            if (textBoxNovoPerfil.Visivel && this.estadoMenu == EstadoMenu.MenuInicial)
            {
                textBoxNovoPerfil.Update(gameTime);
            }
            else
            {
                if (grid != null)
                    grid.Update(gameTime, mouseState, mouseStateAnterior);

                foreach (Botao botao in botoes)
                {
                    botao.Update(gameTime, mouseState, mouseStateAnterior);
                }
            }


            mouseStateAnterior = mouseState;
        }

        private void Click_Sobre(object sender, EventArgs e)
        {
            this.estadoMenu = EstadoMenu.InformacoesJogo;
        }

        private void Click_NovoPerfil(object sender, EventArgs e)
        {
            textBoxNovoPerfil.Visivel = true;
        }

        private void Click_Sair(object sender, EventArgs e)
        {
            ClickSair(this, new EventArgs());
        }

        private void Click_Voltar(object sender, EventArgs e)
        {
            this.estadoMenu = EstadoMenu.MenuInicial;
        }

        private void Click_ExcluirPerfil(object sender, EventArgs e)
        {
            this.perfilSelecionado.Excluir();
            this.estadoMenu = EstadoMenu.MenuInicial;
            Global.bancoDados.CarregaPerfis();
            CarregaPerfis();
        }
        
        private void Click_SelecionaPerfil(object sender, EventArgs e)
        {
            perfilSelecionado = (Perfil)perfilGrid.ItemSelecionado;
            CarregaNiveis(perfilSelecionado);
            SelecionaPerfil(this, new EventArgs());
            this.estadoMenu = EstadoMenu.SelecaoNiveis;
        }

        private void Click_SelecionaNivel(object sender, EventArgs e)
        {
            nivelSelecionado = (Nivel)nivelGrid.ItemSelecionado;
            ativo = false;
            SelecionaNivel(this, new EventArgs());
        }

        private void ConfirmaNovoPerfil(object sender, EventArgs e)
        {
            if (textBoxNovoPerfil.Valor == "")
                textBoxNovoPerfil.Visivel = false;
            else
            {
                if (Perfil.PerfilExistente(textBoxNovoPerfil.Valor))
                {
                    textBoxNovoPerfil.Label = "Perfil já existente";
                }
                else
                {
                    Perfil.AddPerfil(textBoxNovoPerfil.Valor);
                    Global.bancoDados.CarregaPerfis();
                    CarregaPerfis();
                    textBoxNovoPerfil.Visivel = false;
                }
            }

        }
     
        private void CancelaNovoPerfil(object sender, EventArgs e)
        {
            textBoxNovoPerfil.Valor = "";
            textBoxNovoPerfil.Visivel = false;
        }
        
        #endregion métodos

    }
}
