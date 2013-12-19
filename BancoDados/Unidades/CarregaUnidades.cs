using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TowerDefense_XNA.BancoDados
{
    partial class BancoDados
    {
        partial void CarregaUnidades(ContentManager Content)
        {
            #region Guerreiros
            Guerreiro guerreiro3 = new Guerreiro();
            guerreiro3.Nome = "Guerreiro_3";
            guerreiro3.VelocidadeAtaque = 4f;
            guerreiro3.Distancia = 96;
            guerreiro3.Dano = 1.3f;
            guerreiro3.Custo = 125;
            guerreiro3.Nivel = 3;
            guerreiro3.CustoVenda = 195;
            guerreiro3.AudioAtaque = Audio.GetAudio("AtaqueGuerreiro");
            guerreiro3.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueGuerreiro"), 4, 1);
            guerreiro3.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("Guerreiro"), 4, 4);

            Guerreiro guerreiro2 = new Guerreiro();
            guerreiro2.Nome = "Guerreiro_2";
            guerreiro2.VelocidadeAtaque = 3f;
            guerreiro2.Distancia = 96;
            guerreiro2.Dano = 1.2f;
            guerreiro2.Custo = 110;
            guerreiro2.Nivel = 2;
            guerreiro2.CustoVenda = 133;
            guerreiro2.AudioAtaque = Audio.GetAudio("AtaqueGuerreiro");
            guerreiro2.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueGuerreiro"), 4, 1);
            guerreiro2.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("Guerreiro"), 4, 4);
            guerreiro2.UnidadeEvolucao = guerreiro3;

            Guerreiro guerreiro1 = new Guerreiro();
            guerreiro1.Nome = "Guerreiro_1";
            guerreiro1.VelocidadeAtaque = 2f;
            guerreiro1.Distancia = 96;
            guerreiro1.Dano = 1f;
            guerreiro1.Custo = 155;
            guerreiro1.Nivel = 1;
            guerreiro1.CustoVenda = 78;
            guerreiro1.AudioAtaque = Audio.GetAudio("AtaqueGuerreiro");
            guerreiro1.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueGuerreiro"), 4, 1);
            guerreiro1.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("Guerreiro"), 4, 4);
            guerreiro1.UnidadeEvolucao = guerreiro2;

            this.unidades.Add(guerreiro3);
            this.unidades.Add(guerreiro2);
            this.unidades.Add(guerreiro1);
            #endregion Guerreiros

            #region MagoFogo
            MagoFogo magoFogo3 = new MagoFogo();
            magoFogo3.Nome = "MagoFogo_3";
            magoFogo3.VelocidadeAtaque = 3f;
            magoFogo3.Distancia = 160;
            magoFogo3.Dano = 1f;
            magoFogo3.Custo = 210;
            magoFogo3.Nivel = 3;
            magoFogo3.CustoVenda = 288;
            magoFogo3.AudioAtaque = Audio.GetAudio("AtaqueFogo");
            magoFogo3.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueMagoFogo"), 4, 1);
            magoFogo3.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("MagoFogo"), 4, 4);

            MagoFogo magoFogo2 = new MagoFogo();
            magoFogo2.Nome = "MagoFogo_2";
            magoFogo2.VelocidadeAtaque = 2f;
            magoFogo2.Distancia = 160;
            magoFogo2.Dano = 0.75f;
            magoFogo2.Custo = 195;
            magoFogo2.Nivel = 2;
            magoFogo2.CustoVenda = 183;
            magoFogo2.AudioAtaque = Audio.GetAudio("AtaqueFogo");
            magoFogo2.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueMagoFogo"), 4, 1);
            magoFogo2.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("MagoFogo"), 4, 4);
            magoFogo2.UnidadeEvolucao = magoFogo3;

            MagoFogo magoFogo1 = new MagoFogo();
            magoFogo1.Nome = "MagoFogo_1";
            magoFogo1.VelocidadeAtaque = 1f;
            magoFogo1.Distancia = 160;
            magoFogo1.Dano = 1f;
            magoFogo1.Custo = 170;
            magoFogo1.Nivel = 1;
            magoFogo1.CustoVenda = 85;
            magoFogo1.AudioAtaque = Audio.GetAudio("AtaqueFogo");
            magoFogo1.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueMagoFogo"), 4, 1);
            magoFogo1.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("MagoFogo"), 4, 4);
            magoFogo1.UnidadeEvolucao = magoFogo2;

            this.unidades.Add(magoFogo3);
            this.unidades.Add(magoFogo2);
            this.unidades.Add(magoFogo1);
            #endregion MagoFogo

            #region MagoGelo
            MagoGelo MagoGelo = new MagoGelo();
            MagoGelo.Nome = "MagoGelo";
            MagoGelo.VelocidadeAtaque = 1.2f;
            MagoGelo.Distancia = 160;
            MagoGelo.Dano = 0f;
            MagoGelo.Custo = 140;
            MagoGelo.RetardoMovimento = 30;
            MagoGelo.Nivel = 1;
            MagoGelo.CustoVenda = 70;
            MagoGelo.AudioAtaque = Audio.GetAudio("AtaqueGelo");
            MagoGelo.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueMagoGelo"), 4, 1);
            MagoGelo.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("MagoGelo"), 4, 4);
            this.unidades.Add(MagoGelo);
            #endregion MagoGelo

            Vampiro vampiro3 = new Vampiro();
            vampiro3.Nome = "Vampiro_3";
            vampiro3.VelocidadeAtaque = 4f;
            vampiro3.Distancia = 500;
            vampiro3.Dano = 1.3f;
            vampiro3.Custo = 100;
            vampiro3.Nivel = 3;
            vampiro3.CustoVenda = 195;
            vampiro3.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueRaio"), 4, 1);
            vampiro3.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("Dragao"), 4, 4);

            Vampiro vampiro2 = new Vampiro();
            vampiro2.Nome = "Vampiro_2";
            vampiro2.VelocidadeAtaque = 3f;
            vampiro2.Distancia = 400;
            vampiro2.Dano = 1.2f;
            vampiro2.Custo = 100;
            vampiro2.Nivel = 2;
            vampiro2.CustoVenda = 133;
            vampiro2.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueRaio"), 4, 1);
            vampiro2.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("Vampiro"), 4, 4);
            vampiro2.UnidadeEvolucao = vampiro3;

            Vampiro vampiro1 = new Vampiro();
            vampiro1.Nome = "Vampiro_1";
            vampiro1.VelocidadeAtaque = 2f;
            vampiro1.Distancia = 300;
            vampiro1.Dano = 1f;
            vampiro1.Custo = 300;
            vampiro1.Nivel = 1;
            vampiro1.CustoVenda = 78;
            vampiro1.TexturaAtaque = new TexturaSpriteAtaque(Textura.GetTextura("AtaqueRaio"), 4, 1);
            vampiro1.TexturaUnidade = new TexturaSpriteMovimentoAtaque(Textura.GetTextura("Zumbi"), 4, 4);
            vampiro1.UnidadeEvolucao = vampiro2;

            this.unidades.Add(vampiro1);
            this.unidades.Add(vampiro2);
            this.unidades.Add(vampiro3);
        }
    }
}
