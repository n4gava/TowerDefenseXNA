using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class Guerreiro : Unidade
    {
        public override void Ataque(GameTime gameTime, List<Inimigo> inimigos)
        {
            base.Ataque(gameTime, inimigos);
        }
    }
}
