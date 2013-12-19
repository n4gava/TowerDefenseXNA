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
        partial void CarregaRodadasInimigo(ContentManager Content)
        {
            Inimigo abelha = Inimigo.GetInimigo("Abelha");
            Inimigo morcego = Inimigo.GetInimigo("Morcego");
            Inimigo zumbi = Inimigo.GetInimigo("Zumbi");
            Inimigo vampiro = Inimigo.GetInimigo("Vampiro");
            Inimigo dragao = Inimigo.GetInimigo("Dragao");

            #region NivelFacil
            Nivel nivelFacil = Nivel.GetNivel(1);
            RodadaInimigo rodadaInimigo1 = new RodadaInimigo(nivelFacil, 1);
            rodadaInimigo1.AddInimigo(abelha.Clone());
            rodadaInimigo1.AddInimigo(abelha.Clone());
            rodadaInimigo1.AddInimigo(abelha.Clone());

            
            RodadaInimigo rodadaInimigo2 = new RodadaInimigo(nivelFacil, 2);
            rodadaInimigo2.AddInimigo(abelha.Clone());
            rodadaInimigo2.AddInimigo(abelha.Clone());
            rodadaInimigo2.AddInimigo(abelha.Clone());
            rodadaInimigo2.AddInimigo(abelha.Clone());
            

            RodadaInimigo rodadaInimigo3 = new RodadaInimigo(nivelFacil, 3);
            rodadaInimigo3.AddInimigo(abelha.Clone());
            rodadaInimigo3.AddInimigo(abelha.Clone());
            rodadaInimigo3.AddInimigo(morcego.Clone());
            

            RodadaInimigo rodadaInimigo4 = new RodadaInimigo(nivelFacil, 4);
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(morcego.Clone());
            
            
            RodadaInimigo rodadaInimigo5 = new RodadaInimigo(nivelFacil, 5);
            rodadaInimigo5.AddInimigo(abelha.Clone());
            rodadaInimigo5.AddInimigo(abelha.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());


            RodadaInimigo rodadaInimigo6 = new RodadaInimigo(nivelFacil, 6);
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());

            RodadaInimigo rodadaInimigo7 = new RodadaInimigo(nivelFacil, 7);
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());


            RodadaInimigo rodadaInimigo8 = new RodadaInimigo(nivelFacil, 8);
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(morcego.Clone());
            rodadaInimigo8.AddInimigo(zumbi.Clone());

            RodadaInimigo rodadaInimigo9 = new RodadaInimigo(nivelFacil, 9);
            rodadaInimigo9.AddInimigo(abelha.Clone());
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(zumbi.Clone());
            rodadaInimigo9.AddInimigo(zumbi.Clone());

            RodadaInimigo rodadaInimigo10 = new RodadaInimigo(nivelFacil, 10);
            rodadaInimigo10.AddInimigo(abelha.Clone());
            rodadaInimigo10.AddInimigo(abelha.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(zumbi.Clone());
            rodadaInimigo10.AddInimigo(zumbi.Clone());

            RodadaInimigo rodadaInimigo11 = new RodadaInimigo(nivelFacil, 11);
            rodadaInimigo11.AddInimigo(abelha.Clone());
            rodadaInimigo11.AddInimigo(abelha.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(zumbi.Clone());
            rodadaInimigo11.AddInimigo(zumbi.Clone());
            rodadaInimigo11.AddInimigo(zumbi.Clone());

            RodadaInimigo rodadaInimigo12 = new RodadaInimigo(nivelFacil, 12);
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(zumbi.Clone());
            rodadaInimigo12.AddInimigo(zumbi.Clone());

            RodadaInimigo rodadaInimigo13 = new RodadaInimigo(nivelFacil, 13);
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(zumbi.Clone());

            RodadaInimigo rodadaInimigo14 = new RodadaInimigo(nivelFacil, 14);
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());


            RodadaInimigo rodadaInimigo15 = new RodadaInimigo(nivelFacil, 15);
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(zumbi.Clone());
            rodadaInimigo15.AddInimigo(zumbi.Clone());

            RodadaInimigo rodadaInimigo16 = new RodadaInimigo(nivelFacil, 16);
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(zumbi.Clone());
            rodadaInimigo16.AddInimigo(vampiro.Clone());

            RodadaInimigo rodadaInimigo17 = new RodadaInimigo(nivelFacil, 17);
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(vampiro.Clone());

            RodadaInimigo rodadaInimigo18 = new RodadaInimigo(nivelFacil, 18);
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());

            RodadaInimigo rodadaInimigo19 = new RodadaInimigo(nivelFacil, 19);
            rodadaInimigo19.AddInimigo(abelha.Clone());
            rodadaInimigo19.AddInimigo(abelha.Clone());
            rodadaInimigo19.AddInimigo(abelha.Clone());
            rodadaInimigo19.AddInimigo(morcego.Clone());
            rodadaInimigo19.AddInimigo(morcego.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(vampiro.Clone());
            rodadaInimigo19.AddInimigo(vampiro.Clone());
            rodadaInimigo19.AddInimigo(vampiro.Clone());

            RodadaInimigo rodadaInimigo20 = new RodadaInimigo(nivelFacil, 20);
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            
            this.rodadasInimigo.Add(rodadaInimigo1);
            this.rodadasInimigo.Add(rodadaInimigo2);
            this.rodadasInimigo.Add(rodadaInimigo3);
            this.rodadasInimigo.Add(rodadaInimigo4);
            this.rodadasInimigo.Add(rodadaInimigo5);
            this.rodadasInimigo.Add(rodadaInimigo6);
            this.rodadasInimigo.Add(rodadaInimigo7);
            this.rodadasInimigo.Add(rodadaInimigo8);
            this.rodadasInimigo.Add(rodadaInimigo9);
            this.rodadasInimigo.Add(rodadaInimigo10 );
            this.rodadasInimigo.Add(rodadaInimigo11 );
            this.rodadasInimigo.Add(rodadaInimigo12 );
            this.rodadasInimigo.Add(rodadaInimigo13 );
            this.rodadasInimigo.Add(rodadaInimigo14 );
            this.rodadasInimigo.Add(rodadaInimigo15 );
            this.rodadasInimigo.Add(rodadaInimigo16 );
            this.rodadasInimigo.Add(rodadaInimigo17 );
            this.rodadasInimigo.Add(rodadaInimigo18 );
            this.rodadasInimigo.Add(rodadaInimigo19 );
            this.rodadasInimigo.Add(rodadaInimigo20 );

            #endregion NivelFacil

            #region NivelMedio
            Nivel nivelMedio = Nivel.GetNivel(2);
            rodadaInimigo1 = new RodadaInimigo(nivelMedio, 1);
            rodadaInimigo1.AddInimigo(abelha.Clone());
            rodadaInimigo1.AddInimigo(abelha.Clone());
            rodadaInimigo1.AddInimigo(abelha.Clone());

            rodadaInimigo2 = new RodadaInimigo(nivelMedio, 2);
            rodadaInimigo2.AddInimigo(abelha.Clone());
            rodadaInimigo2.AddInimigo(abelha.Clone());
            rodadaInimigo2.AddInimigo(abelha.Clone());
            rodadaInimigo2.AddInimigo(abelha.Clone());

            rodadaInimigo3 = new RodadaInimigo(nivelMedio, 3);
            rodadaInimigo3.AddInimigo(abelha.Clone());
            rodadaInimigo3.AddInimigo(morcego.Clone());
            rodadaInimigo3.AddInimigo(morcego.Clone());

            rodadaInimigo4 = new RodadaInimigo(nivelMedio, 4);
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(morcego.Clone());
            rodadaInimigo4.AddInimigo(morcego.Clone());
            rodadaInimigo4.AddInimigo(zumbi.Clone());

            rodadaInimigo5 = new RodadaInimigo(nivelMedio, 5);
            rodadaInimigo5.AddInimigo(abelha.Clone());
            rodadaInimigo5.AddInimigo(abelha.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());
            rodadaInimigo5.AddInimigo(zumbi.Clone());

            rodadaInimigo6 = new RodadaInimigo(nivelMedio, 6);
            rodadaInimigo6.AddInimigo(abelha.Clone());
            rodadaInimigo6.AddInimigo(abelha.Clone());
            rodadaInimigo6.AddInimigo(abelha.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());

            rodadaInimigo7 = new RodadaInimigo(nivelMedio, 7);
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone()); 

            rodadaInimigo8 = new RodadaInimigo(nivelMedio, 8);
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(morcego.Clone());
            rodadaInimigo8.AddInimigo(morcego.Clone());
            rodadaInimigo8.AddInimigo(morcego.Clone());
            rodadaInimigo8.AddInimigo(zumbi.Clone());

            rodadaInimigo9 = new RodadaInimigo(nivelMedio, 9);
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(zumbi.Clone());
            rodadaInimigo9.AddInimigo(zumbi.Clone());

            rodadaInimigo10 = new RodadaInimigo(nivelMedio, 10);
            rodadaInimigo10.AddInimigo(abelha.Clone());
            rodadaInimigo10.AddInimigo(abelha.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(vampiro.Clone());
            rodadaInimigo10.AddInimigo(vampiro.Clone());

            rodadaInimigo11 = new RodadaInimigo(nivelMedio, 11);
            rodadaInimigo11.AddInimigo(abelha.Clone());
            rodadaInimigo11.AddInimigo(abelha.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(zumbi.Clone());
            rodadaInimigo11.AddInimigo(vampiro.Clone());

            rodadaInimigo12 = new RodadaInimigo(nivelMedio, 12);
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(zumbi.Clone());
            rodadaInimigo12.AddInimigo(zumbi.Clone());
            rodadaInimigo12.AddInimigo(vampiro.Clone());

            rodadaInimigo13 = new RodadaInimigo(nivelMedio, 13);
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(dragao.Clone());

            rodadaInimigo14 = new RodadaInimigo(nivelMedio, 14);
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());

            rodadaInimigo15 = new RodadaInimigo(nivelMedio, 15);
            rodadaInimigo15.AddInimigo(abelha.Clone());
            rodadaInimigo15.AddInimigo(abelha.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(zumbi.Clone());
            rodadaInimigo15.AddInimigo(zumbi.Clone());

            rodadaInimigo16 = new RodadaInimigo(nivelMedio, 16);
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(vampiro.Clone());
            rodadaInimigo16.AddInimigo(vampiro.Clone());
            
            rodadaInimigo17 = new RodadaInimigo(nivelMedio, 17);
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(abelha.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(vampiro.Clone());
            rodadaInimigo17.AddInimigo(vampiro.Clone());

            rodadaInimigo18 = new RodadaInimigo(nivelMedio, 18);
            rodadaInimigo18.AddInimigo(abelha.Clone());
            rodadaInimigo18.AddInimigo(abelha.Clone());
            rodadaInimigo18.AddInimigo(abelha.Clone());
            rodadaInimigo18.AddInimigo(abelha.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());
            rodadaInimigo18.AddInimigo(dragao.Clone());

            rodadaInimigo19 = new RodadaInimigo(nivelMedio, 19);
            rodadaInimigo19.AddInimigo(abelha.Clone());
            rodadaInimigo19.AddInimigo(abelha.Clone());
            rodadaInimigo19.AddInimigo(abelha.Clone());
            rodadaInimigo19.AddInimigo(abelha.Clone());
            rodadaInimigo19.AddInimigo(morcego.Clone());
            rodadaInimigo19.AddInimigo(morcego.Clone());
            rodadaInimigo19.AddInimigo(morcego.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(vampiro.Clone());
            rodadaInimigo19.AddInimigo(dragao.Clone());

            rodadaInimigo20 = new RodadaInimigo(nivelMedio, 20);
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(dragao.Clone());
            rodadaInimigo20.AddInimigo(dragao.Clone());

            this.rodadasInimigo.Add(rodadaInimigo1);
            this.rodadasInimigo.Add(rodadaInimigo2);
            this.rodadasInimigo.Add(rodadaInimigo3);
            this.rodadasInimigo.Add(rodadaInimigo4);
            this.rodadasInimigo.Add(rodadaInimigo5);
            this.rodadasInimigo.Add(rodadaInimigo6);
            this.rodadasInimigo.Add(rodadaInimigo7);
            this.rodadasInimigo.Add(rodadaInimigo8);
            this.rodadasInimigo.Add(rodadaInimigo9);
            this.rodadasInimigo.Add(rodadaInimigo10);
            this.rodadasInimigo.Add(rodadaInimigo11);
            this.rodadasInimigo.Add(rodadaInimigo12);
            this.rodadasInimigo.Add(rodadaInimigo13);
            this.rodadasInimigo.Add(rodadaInimigo14);
            this.rodadasInimigo.Add(rodadaInimigo15);
            this.rodadasInimigo.Add(rodadaInimigo16);
            this.rodadasInimigo.Add(rodadaInimigo17);
            this.rodadasInimigo.Add(rodadaInimigo18);
            this.rodadasInimigo.Add(rodadaInimigo19);
            this.rodadasInimigo.Add(rodadaInimigo20);

            #endregion NivelMedio;

            #region NivelDificil
       
            Nivel nivelDificil = Nivel.GetNivel(3);
            rodadaInimigo1 = new RodadaInimigo(nivelDificil, 1);
            rodadaInimigo1.AddInimigo(abelha.Clone());
            rodadaInimigo1.AddInimigo(abelha.Clone());
            rodadaInimigo1.AddInimigo(morcego.Clone());

            rodadaInimigo2 = new RodadaInimigo(nivelDificil, 2);
            rodadaInimigo2.AddInimigo(abelha.Clone());
            rodadaInimigo2.AddInimigo(morcego.Clone());
            rodadaInimigo2.AddInimigo(zumbi.Clone());

            rodadaInimigo3 = new RodadaInimigo(nivelDificil, 3);
            rodadaInimigo3.AddInimigo(abelha.Clone());
            rodadaInimigo3.AddInimigo(morcego.Clone());
            rodadaInimigo3.AddInimigo(morcego.Clone());
            rodadaInimigo3.AddInimigo(morcego.Clone());

            rodadaInimigo4 = new RodadaInimigo(nivelDificil, 4);
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(abelha.Clone());
            rodadaInimigo4.AddInimigo(morcego.Clone());
            rodadaInimigo4.AddInimigo(morcego.Clone());
            rodadaInimigo4.AddInimigo(morcego.Clone());

            rodadaInimigo5 = new RodadaInimigo(nivelDificil, 5);
            rodadaInimigo5.AddInimigo(abelha.Clone());
            rodadaInimigo5.AddInimigo(abelha.Clone());
            rodadaInimigo5.AddInimigo(abelha.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());
            rodadaInimigo5.AddInimigo(morcego.Clone());
            rodadaInimigo5.AddInimigo(zumbi.Clone());

            rodadaInimigo6 = new RodadaInimigo(nivelDificil, 6);
            rodadaInimigo6.AddInimigo(abelha.Clone());
            rodadaInimigo6.AddInimigo(abelha.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(morcego.Clone());
            rodadaInimigo6.AddInimigo(vampiro.Clone());

            rodadaInimigo7 = new RodadaInimigo(nivelDificil, 7);
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(abelha.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());
            rodadaInimigo7.AddInimigo(morcego.Clone());
            rodadaInimigo7.AddInimigo(zumbi.Clone());
            rodadaInimigo7.AddInimigo(zumbi.Clone());

            rodadaInimigo8 = new RodadaInimigo(nivelDificil, 8);
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(abelha.Clone());
            rodadaInimigo8.AddInimigo(morcego.Clone());
            rodadaInimigo8.AddInimigo(morcego.Clone());
            rodadaInimigo8.AddInimigo(morcego.Clone());
            rodadaInimigo8.AddInimigo(zumbi.Clone());
            rodadaInimigo8.AddInimigo(vampiro.Clone());

            rodadaInimigo9 = new RodadaInimigo(nivelDificil, 9);
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(morcego.Clone());
            rodadaInimigo9.AddInimigo(zumbi.Clone());
            rodadaInimigo9.AddInimigo(zumbi.Clone());
            rodadaInimigo9.AddInimigo(vampiro.Clone());

            rodadaInimigo10 = new RodadaInimigo(nivelDificil, 10);
            rodadaInimigo10.AddInimigo(abelha.Clone());
            rodadaInimigo10.AddInimigo(abelha.Clone());
            rodadaInimigo10.AddInimigo(abelha.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(morcego.Clone());
            rodadaInimigo10.AddInimigo(zumbi.Clone());
            rodadaInimigo10.AddInimigo(zumbi.Clone());
            rodadaInimigo10.AddInimigo(dragao.Clone());

            rodadaInimigo11 = new RodadaInimigo(nivelDificil, 11);
            rodadaInimigo11.AddInimigo(abelha.Clone());
            rodadaInimigo11.AddInimigo(abelha.Clone());
            rodadaInimigo11.AddInimigo(abelha.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());
            rodadaInimigo11.AddInimigo(morcego.Clone());

            rodadaInimigo12 = new RodadaInimigo(nivelDificil, 12);
            rodadaInimigo12.AddInimigo(abelha.Clone());
            rodadaInimigo12.AddInimigo(abelha.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(morcego.Clone());
            rodadaInimigo12.AddInimigo(zumbi.Clone());
            rodadaInimigo12.AddInimigo(zumbi.Clone());

            rodadaInimigo13 = new RodadaInimigo(nivelDificil, 13);
            rodadaInimigo13.AddInimigo(abelha.Clone());
            rodadaInimigo13.AddInimigo(abelha.Clone());
            rodadaInimigo13.AddInimigo(abelha.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(morcego.Clone());
            rodadaInimigo13.AddInimigo(zumbi.Clone());
            rodadaInimigo13.AddInimigo(vampiro.Clone());

            rodadaInimigo14 = new RodadaInimigo(nivelDificil, 14);
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(abelha.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(morcego.Clone());
            rodadaInimigo14.AddInimigo(vampiro.Clone());
            rodadaInimigo14.AddInimigo(vampiro.Clone());

            rodadaInimigo15 = new RodadaInimigo(nivelDificil, 15);
            rodadaInimigo15.AddInimigo(abelha.Clone());
            rodadaInimigo15.AddInimigo(abelha.Clone());
            rodadaInimigo15.AddInimigo(abelha.Clone());
            rodadaInimigo15.AddInimigo(abelha.Clone());
            rodadaInimigo15.AddInimigo(abelha.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(morcego.Clone());
            rodadaInimigo15.AddInimigo(vampiro.Clone());
            rodadaInimigo15.AddInimigo(dragao.Clone());

            rodadaInimigo16 = new RodadaInimigo(nivelDificil, 16);
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(abelha.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(morcego.Clone());
            rodadaInimigo16.AddInimigo(zumbi.Clone());
            rodadaInimigo16.AddInimigo(zumbi.Clone());
            rodadaInimigo16.AddInimigo(vampiro.Clone());
            rodadaInimigo16.AddInimigo(dragao.Clone());

            rodadaInimigo17 = new RodadaInimigo(nivelDificil, 17);
            rodadaInimigo17.AddInimigo(morcego.Clone());
            rodadaInimigo17.AddInimigo(zumbi.Clone());
            rodadaInimigo17.AddInimigo(zumbi.Clone());
            rodadaInimigo17.AddInimigo(zumbi.Clone());
            rodadaInimigo17.AddInimigo(vampiro.Clone());
            rodadaInimigo17.AddInimigo(vampiro.Clone());
            rodadaInimigo17.AddInimigo(vampiro.Clone());
            rodadaInimigo17.AddInimigo(dragao.Clone());
            rodadaInimigo17.AddInimigo(dragao.Clone());

            rodadaInimigo18 = new RodadaInimigo(nivelDificil, 18);
            rodadaInimigo18.AddInimigo(abelha.Clone());
            rodadaInimigo18.AddInimigo(abelha.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(morcego.Clone());
            rodadaInimigo18.AddInimigo(zumbi.Clone());
            rodadaInimigo18.AddInimigo(zumbi.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());
            rodadaInimigo18.AddInimigo(vampiro.Clone());
            rodadaInimigo18.AddInimigo(dragao.Clone());
            rodadaInimigo18.AddInimigo(dragao.Clone());

            rodadaInimigo19 = new RodadaInimigo(nivelDificil, 19);
            rodadaInimigo19.AddInimigo(morcego.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(zumbi.Clone());
            rodadaInimigo19.AddInimigo(vampiro.Clone());
            rodadaInimigo19.AddInimigo(vampiro.Clone());
            rodadaInimigo19.AddInimigo(vampiro.Clone());
            rodadaInimigo19.AddInimigo(dragao.Clone());
            rodadaInimigo19.AddInimigo(dragao.Clone());
            rodadaInimigo19.AddInimigo(dragao.Clone());

            rodadaInimigo20 = new RodadaInimigo(nivelDificil, 20);
            rodadaInimigo20.AddInimigo(morcego.Clone());
            rodadaInimigo20.AddInimigo(morcego.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(zumbi.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(vampiro.Clone());
            rodadaInimigo20.AddInimigo(dragao.Clone());
            rodadaInimigo20.AddInimigo(dragao.Clone());
            rodadaInimigo20.AddInimigo(dragao.Clone());
            rodadaInimigo20.AddInimigo(dragao.Clone());

            this.rodadasInimigo.Add(rodadaInimigo1);
            this.rodadasInimigo.Add(rodadaInimigo2);
            this.rodadasInimigo.Add(rodadaInimigo3);
            this.rodadasInimigo.Add(rodadaInimigo4);
            this.rodadasInimigo.Add(rodadaInimigo5);
            this.rodadasInimigo.Add(rodadaInimigo6);
            this.rodadasInimigo.Add(rodadaInimigo7);
            this.rodadasInimigo.Add(rodadaInimigo8);
            this.rodadasInimigo.Add(rodadaInimigo9);
            this.rodadasInimigo.Add(rodadaInimigo10);
            this.rodadasInimigo.Add(rodadaInimigo11);
            this.rodadasInimigo.Add(rodadaInimigo12);
            this.rodadasInimigo.Add(rodadaInimigo13);
            this.rodadasInimigo.Add(rodadaInimigo14);
            this.rodadasInimigo.Add(rodadaInimigo15);
            this.rodadasInimigo.Add(rodadaInimigo16);
            this.rodadasInimigo.Add(rodadaInimigo17);
            this.rodadasInimigo.Add(rodadaInimigo18);
            this.rodadasInimigo.Add(rodadaInimigo19);
            this.rodadasInimigo.Add(rodadaInimigo20);
     

            #endregion NivelDificil;
        }
    }
}
