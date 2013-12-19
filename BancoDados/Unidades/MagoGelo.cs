using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TowerDefense_XNA.BancoDados
{
    public class MagoGelo : Unidade
    {
        public override void Ataque(GameTime gameTime, List<Inimigo> inimigos)
        {
            base.Ataque(gameTime, inimigos);
            this.alvo.Lentidao = 50;
            this.alvo.TempoLentidao = 10;
            this.alvo = null;
        }

        public override void BuscaInimigoProximo(List<Inimigo> inimigos)
        {
            bool encontrouInimigo = false;
            alvo = null;
            float menorAlcance = distancia / 2;
            foreach (Inimigo inimigo in inimigos.Where(x => x.Lentidao == 0))
            {
                encontrouInimigo = true;
                if (Vector2.Distance(texturaUnidade.Centro, inimigo.Centro) <= menorAlcance)
                {
                    float teste = Vector2.Distance(new Vector2(100, 100), new Vector2(80, 100));
                    menorAlcance = Vector2.Distance(texturaUnidade.Centro, inimigo.Centro);
                    alvo = inimigo;
                }
            }

            if (!encontrouInimigo)
            {
                base.BuscaInimigoProximo(inimigos);
            }
        }
    }
}
