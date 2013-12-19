using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense_XNA.BancoDados
{
    public class Global
    {
        public static int frameLength = 32;
        public static int framesHeight = 14;
        public static int framesWidth = 12;
        public static int LarguraJanela = Global.framesWidth * Global.frameLength;
        public static int AlturaJanela = Global.framesHeight * Global.frameLength;
        public static string localXmlPerfil = @"Content\Banco de Dados\Perfis.xml";
        public static BancoDados bancoDados;
        public static GraphicsDevice graphicsDevice;
        public static Textura texturaBranca;
    }
}
