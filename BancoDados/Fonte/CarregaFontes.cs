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
        partial void CarregaFontes(ContentManager Content)
        {
            this.fonte = Content.Load<SpriteFont>(CAMINHO_FONTE+"FontePrincipal");
            this.fonte10 = Content.Load<SpriteFont>(CAMINHO_FONTE + "Fonte10");
            this.fonte8 = Content.Load<SpriteFont>(CAMINHO_FONTE + "FOnte8");
            this.fonteMenuUnidade = Content.Load<SpriteFont>(CAMINHO_FONTE + "FonteMenuUnidade");
        }
    }
}
