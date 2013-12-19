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

namespace TowerDefense_XNA.BancoDados
{
    public partial class BancoDados
    {
        #region propriedades
        SpriteFont fonte;
        SpriteFont fonte10;
        SpriteFont fonte8;
        SpriteFont fonteMenuUnidade;
        List<Textura> texturas = new List<Textura>();
        List<Audio> audios = new List<Audio>();
        List<Unidade> unidades = new List<Unidade>();
        List<Nivel> niveis = new List<Nivel>();
        List<Perfil> perfis = new List<Perfil>();
        List<Inimigo> inimigos = new List<Inimigo>();
        List<RodadaInimigo> rodadasInimigo = new List<RodadaInimigo>();
        #endregion propriedades

        #region constantes
        const string CAMINHO_FONTE = @"Banco de Dados\Fontes\";
        const string CAMINHO_TEXTURAS = @"Banco de Dados\Texturas\";
        const string CAMINHO_AUDIO = @"Banco de Dados\Audio\";
        #endregion constantes

        #region atributos
        public SpriteFont Fonte
        {
            get { return fonte; }
        }

        public SpriteFont Fonte10
        {
            get { return fonte10; }
        }

        public SpriteFont Fonte8
        {
            get { return fonte8; }
        }


        public SpriteFont FonteMenuUnidade
        {
            get { return fonteMenuUnidade; }
        }
        

        public List<Textura> Texturas
        {
            get { return texturas; }
        }

        public List<Audio> Audios
        {
            get { return audios; }
        }


        public List<Unidade> Unidades
        {
            get { return unidades; }
        }

        public List<Nivel> Niveis
        {
            get { return niveis; }
        }

        public List<Perfil> Perfis
        {
            get { return perfis; }
        }

        public List<Inimigo> Inimigos
        {
            get { return inimigos; }
        }

        public List<RodadaInimigo> RodadasInimigo
        {
            get { return rodadasInimigo; }
        }

        #endregion atributos

        #region Métodos
        public void CarregaBancoDados(ContentManager Content)
        {
            CarregaTexturas(Content);
            CarregaAudios(Content);
            CarregaFontes(Content);
            CarregaUnidades(Content);
            CarregaNiveis(Content);
            CarregaPerfis();
            CarregaInimigos(Content);
            CarregaRodadasInimigo(Content);
        }

        public void CarregaPerfis()
        {
            CarregaPerfisPartial();
        }

        partial void CarregaFontes(ContentManager Content);

        partial void CarregaTexturas(ContentManager Content);

        partial void CarregaAudios(ContentManager Content);

        partial void CarregaUnidades(ContentManager Content);

        partial void CarregaNiveis(ContentManager Content);

        partial void CarregaPerfisPartial();

        partial void CarregaInimigos(ContentManager Content);

        partial void CarregaRodadasInimigo(ContentManager Content);
        #endregion Métodos
    }
}
