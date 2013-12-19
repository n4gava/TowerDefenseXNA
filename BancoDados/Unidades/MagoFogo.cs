using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class MagoFogo : Unidade
    {
        public override void Ataque(GameTime gameTime, List<Inimigo> inimigos)
        {

            base.Ataque(gameTime, inimigos);
            List<Inimigo> inimigoslist = inimigos.ToList();
            foreach (Inimigo inimigo in inimigoslist.Where( x => x != alvo))
            {
                if (Math.Abs(Vector2.Distance(alvo.Centro, inimigo.Centro)) <= 50)
                {
                    inimigo.Vida -= this.dano;
                    if (inimigo.Vida <= 0)
                        InimigoMorto(inimigo, new EventArgs());
                }
            }
        }
    }
}
