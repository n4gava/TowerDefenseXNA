using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class Nivel
    {
        #region propriedades

        string nome;
        int nivel;
        int ouroInicial = 300;
        List<int[,]> camadas = new List<int[,]>();
        int[,] mapaUnidades;
        Textura textura;
        List<Queue<Vector2>> pontosCaminho = new List<Queue<Vector2>>();

        Color backGroundColor = Color.White;
        float rotation = 0.0f;
        Vector2 orig = new Vector2();
        float scale = 1.0f;

        #endregion propriedades

        #region atributos
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public int PNivel
        {
            set { nivel = value; }
            get { return nivel; }
        }

        public List<int[,]> Camadas
        {
            set { camadas = value; }
        }

        public int[,] MapaUnidades
        {
            set { mapaUnidades = value; }
            get { return mapaUnidades; }
        }

        public Textura Textura
        {
            set { textura = value; }
        }

        public List<Queue<Vector2>> PontosCaminho
        {
            get { return pontosCaminho; }
            set { pontosCaminho = value; }
        }
        #endregion atributos

        #region Métodos
        public void AddCamada(int[,] camada)
        {
            camadas.Add(camada);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (int[,] camada in this.camadas)
            {
                for (int x = 0; x < camada.GetLength(1); x++)
                {
                    for (int y = 0; y < camada.GetLength(0); y++)
                    {
                        int textureIndex = camada[y, x];
                        Vector2 posicao = new Vector2(x * Global.frameLength,(y) * Global.frameLength);

                        spriteBatch.Draw(textura.Textura2D, posicao, textura.GetRetangleIndex(textureIndex), backGroundColor, rotation, orig, scale, SpriteEffects.None, 0.0f);
                    }
                }
            }
        }

        public static Nivel GetNivel(int nivel)
        {
            return Global.bancoDados.Niveis.Where(x => x.PNivel == nivel).First();
        }
        #endregion Métodos
    }
}
