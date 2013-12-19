using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense_XNA.Menu
{
    public class ItemTexto
    {
        Box box;
        bool visivel;
        bool ativo;
        string valor;
        KeyboardState keyboardState;
        clsInput myclsinput = new clsInput();
        string label;
        int limite = 20;

        public event EventHandler EnterKeyPressed;
        public event EventHandler EscKeyPressed;

        public bool Visivel
        {
            get { return visivel; }
            set {
                    valor = "";
                    label = "";
                    visivel = value; 
                }
        }

        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public int LimiteCaracteres
        {
            get { return limite; }
            set { limite = value; }
        }

        public ItemTexto(int x, int y, int width, int height)
        {
            box = new Box(new Rectangle(x, y, width, height));
        }

        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            Keys[] keys = keyboardState.GetPressedKeys();
            bool isShift = myclsinput.isShiftPressed(keys);

            if (valor.Length < limite)
            {
                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    if (myclsinput.EscKeyState == "none") myclsinput.EscKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.Escape))
                {
                    if (myclsinput.EscKeyState == "down")
                    {
                        EscKeyPressed(this, new EventArgs());
                        myclsinput.EscKeyState = "none";
                    }
                }

                if (keyboardState.IsKeyDown(Keys.A))
                {
                    if (myclsinput.AKeyState == "none") myclsinput.AKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.A))
                {
                    if (myclsinput.AKeyState == "down")
                    {
                        if (isShift) valor += "A";
                        else valor += "a";
                        myclsinput.AKeyState = "none";
                    }
                }
                ////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    if (myclsinput.SpaceKeyState == "none") myclsinput.SpaceKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.Space))
                {
                    if (myclsinput.SpaceKeyState == "down")
                    {
                        valor += " ";
                        myclsinput.SpaceKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.B))
                {
                    if (myclsinput.BKeyState == "none") myclsinput.BKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.B))
                {
                    if (myclsinput.BKeyState == "down")
                    {
                        if (isShift) valor += "B";
                        else valor += "b";
                        myclsinput.BKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.Z))
                {
                    if (myclsinput.ZKeyState == "none") myclsinput.ZKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.Z))
                {
                    if (myclsinput.ZKeyState == "down")
                    {
                        if (isShift) valor += "Z";
                        else valor += "z";
                        myclsinput.ZKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.C))
                {
                    if (myclsinput.CKeyState == "none") myclsinput.CKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.C))
                {
                    if (myclsinput.CKeyState == "down")
                    {
                        if (isShift) valor += "C";
                        else valor += "c";
                        myclsinput.CKeyState = "none";
                    }
                }
                ////////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    if (myclsinput.DKeyState == "none") myclsinput.DKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D))
                {
                    if (myclsinput.DKeyState == "down")
                    {
                        if (isShift) valor += "D";
                        else valor += "d";
                        myclsinput.DKeyState = "none";
                    }
                }
                ////////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    if (myclsinput.EKeyState == "none") myclsinput.EKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.E))
                {
                    if (myclsinput.EKeyState == "down")
                    {
                        if (isShift) valor += "E";
                        else valor += "e";
                        myclsinput.EKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.F))
                {
                    if (myclsinput.FKeyState == "none") myclsinput.FKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.F))
                {
                    if (myclsinput.FKeyState == "down")
                    {
                        if (isShift) valor += "F";
                        else valor += "f";
                        myclsinput.FKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.G))
                {
                    if (myclsinput.GKeyState == "none") myclsinput.GKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.G))
                {
                    if (myclsinput.GKeyState == "down")
                    {
                        if (isShift) valor += "G";
                        else valor += "g";
                        myclsinput.GKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.H))
                {
                    if (myclsinput.HKeyState == "none") myclsinput.HKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.H))
                {
                    if (myclsinput.HKeyState == "down")
                    {
                        if (isShift) valor += "H";
                        else valor += "h";
                        myclsinput.HKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.I))
                {
                    if (myclsinput.IKeyState == "none") myclsinput.IKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.I))
                {
                    if (myclsinput.IKeyState == "down")
                    {
                        if (isShift) valor += "I";
                        else valor += "i";
                        myclsinput.IKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.J))
                {
                    if (myclsinput.JKeyState == "none") myclsinput.JKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.J))
                {
                    if (myclsinput.JKeyState == "down")
                    {
                        if (isShift) valor += "J";
                        else valor += "j";
                        myclsinput.JKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.K))
                {
                    if (myclsinput.KKeyState == "none") myclsinput.KKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.K))
                {
                    if (myclsinput.KKeyState == "down")
                    {
                        if (isShift) valor += "K";
                        else valor += "k";
                        myclsinput.KKeyState = "none";
                    }
                }
                if (keyboardState.IsKeyDown(Keys.L))
                {
                    if (myclsinput.LKeyState == "none") myclsinput.LKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.L))
                {
                    if (myclsinput.LKeyState == "down")
                    {
                        if (isShift) valor += "L";
                        else valor += "l";
                        myclsinput.LKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.M))
                {
                    if (myclsinput.MKeyState == "none") myclsinput.MKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.M))
                {
                    if (myclsinput.MKeyState == "down")
                    {
                        if (isShift) valor += "M";
                        else valor += "m";
                        myclsinput.MKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.N))
                {
                    if (myclsinput.NKeyState == "none") myclsinput.NKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.N))
                {
                    if (myclsinput.NKeyState == "down")
                    {
                        if (isShift) valor += "N";
                        else valor += "n";
                        myclsinput.NKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.O))
                {
                    if (myclsinput.OKeyState == "none") myclsinput.OKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.O))
                {
                    if (myclsinput.OKeyState == "down")
                    {
                        if (isShift) valor += "O";
                        else valor += "o";
                        myclsinput.OKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.P))
                {
                    if (myclsinput.PKeyState == "none") myclsinput.PKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.P))
                {
                    if (myclsinput.PKeyState == "down")
                    {
                        if (isShift) valor += "P";
                        else valor += "p";
                        myclsinput.PKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    if (myclsinput.QKeyState == "none") myclsinput.QKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.Q))
                {
                    if (myclsinput.QKeyState == "down")
                    {
                        if (isShift) valor += "Q";
                        else valor += "q";
                        myclsinput.QKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.R))
                {
                    if (myclsinput.RKeyState == "none") myclsinput.RKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.R))
                {
                    if (myclsinput.RKeyState == "down")
                    {
                        if (isShift) valor += "R";
                        else valor += "r";
                        myclsinput.RKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    if (myclsinput.SKeyState == "none") myclsinput.SKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.S))
                {
                    if (myclsinput.SKeyState == "down")
                    {
                        if (isShift) valor += "S";
                        else valor += "s";
                        myclsinput.SKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.T))
                {
                    if (myclsinput.TKeyState == "none") myclsinput.TKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.T))
                {
                    if (myclsinput.TKeyState == "down")
                    {
                        if (isShift) valor += "T";
                        else valor += "t";
                        myclsinput.TKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.U))
                {
                    if (myclsinput.UKeyState == "none") myclsinput.UKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.U))
                {
                    if (myclsinput.UKeyState == "down")
                    {
                        if (isShift) valor += "U";
                        else valor += "u";
                        myclsinput.UKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.V))
                {
                    if (myclsinput.VKeyState == "none") myclsinput.VKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.V))
                {
                    if (myclsinput.VKeyState == "down")
                    {
                        if (isShift) valor += "V";
                        else valor += "v";
                        myclsinput.VKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    if (myclsinput.WKeyState == "none") myclsinput.WKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.W))
                {
                    if (myclsinput.WKeyState == "down")
                    {
                        if (isShift) valor += "W";
                        else valor += "w";
                        myclsinput.WKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.Y))
                {
                    if (myclsinput.YKeyState == "none") myclsinput.YKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.Y))
                {
                    if (myclsinput.YKeyState == "down")
                    {
                        if (isShift) valor += "Y";
                        else valor += "y";
                        myclsinput.YKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.X))
                {
                    if (myclsinput.XKeyState == "none") myclsinput.XKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.X))
                {
                    if (myclsinput.XKeyState == "down")
                    {
                        if (isShift) valor += "X";
                        else valor += "x";
                        myclsinput.XKeyState = "none";
                    }
                }
                /////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemSemicolon))
                {
                    if (myclsinput.OemSemicolonKeyState == "none") myclsinput.OemSemicolonKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemSemicolon))
                {
                    if (myclsinput.OemSemicolonKeyState == "down")
                    {
                        if (isShift) valor += ":";
                        else valor += ";";
                        myclsinput.OemSemicolonKeyState = "none";
                    }
                }
                /////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemQuotes))
                {
                    if (myclsinput.OemQuotesKeyState == "none") myclsinput.OemQuotesKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemQuotes))
                {
                    if (myclsinput.OemQuotesKeyState == "down")
                    {
                        if (isShift) valor += "\"";
                        else valor += "'";
                        myclsinput.OemQuotesKeyState = "none";
                    }
                }

                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemComma))
                {
                    if (myclsinput.OemCommaKeyState == "none") myclsinput.OemCommaKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemComma))
                {
                    if (myclsinput.OemCommaKeyState == "down")
                    {
                        if (isShift) valor += "<";
                        else valor += ",";
                        myclsinput.OemCommaKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemPeriod))
                {
                    if (myclsinput.OemPeriodKeyState == "none") myclsinput.OemPeriodKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemPeriod))
                {
                    if (myclsinput.OemPeriodKeyState == "down")
                    {
                        if (isShift) valor += ">";
                        else valor += ".";
                        myclsinput.OemPeriodKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemQuestion))
                {
                    if (myclsinput.OemQuestionKeyState == "none") myclsinput.OemQuestionKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemQuestion))
                {
                    if (myclsinput.OemQuestionKeyState == "down")
                    {
                        if (isShift) valor += "?";
                        else valor += "/";
                        myclsinput.OemQuestionKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemOpenBrackets))
                {
                    if (myclsinput.OemOpenBracketsKeyState == "none") myclsinput.OemOpenBracketsKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemOpenBrackets))
                {
                    if (myclsinput.OemOpenBracketsKeyState == "down")
                    {
                        if (isShift) valor += "{";
                        else valor += "[";
                        myclsinput.OemOpenBracketsKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemCloseBrackets))
                {
                    if (myclsinput.OemCloseBracketsKeyState == "none") myclsinput.OemCloseBracketsKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemCloseBrackets))
                {
                    if (myclsinput.OemCloseBracketsKeyState == "down")
                    {
                        if (isShift) valor += "}";
                        else valor += "]";
                        myclsinput.OemCloseBracketsKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemPipe))
                {
                    if (myclsinput.OemPipeKeyState == "none") myclsinput.OemPipeKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemPipe))
                {
                    if (myclsinput.OemPipeKeyState == "down")
                    {
                        if (isShift) valor += "|";
                        else valor += "\\";
                        myclsinput.OemPipeKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D1))
                {
                    if (myclsinput.D1KeyState == "none") myclsinput.D1KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D1))
                {
                    if (myclsinput.D1KeyState == "down")
                    {
                        if (isShift) valor += "!";
                        else valor += "1";
                        myclsinput.D1KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D2))
                {
                    if (myclsinput.D2KeyState == "none") myclsinput.D2KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D2))
                {
                    if (myclsinput.D2KeyState == "down")
                    {
                        if (isShift) valor += "@";
                        else valor += "2";
                        myclsinput.D2KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D3))
                {
                    if (myclsinput.D3KeyState == "none") myclsinput.D3KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D3))
                {
                    if (myclsinput.D3KeyState == "down")
                    {
                        if (isShift) valor += "#";
                        else valor += "3";
                        myclsinput.D3KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D4))
                {
                    if (myclsinput.D4KeyState == "none") myclsinput.D4KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D4))
                {
                    if (myclsinput.D4KeyState == "down")
                    {
                        if (isShift) valor += "$";
                        else valor += "4";
                        myclsinput.D4KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D5))
                {
                    if (myclsinput.D5KeyState == "none") myclsinput.D5KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D5))
                {
                    if (myclsinput.D5KeyState == "down")
                    {
                        if (isShift) valor += "%";
                        else valor += "5";
                        myclsinput.D5KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D6))
                {
                    if (myclsinput.D6KeyState == "none") myclsinput.D6KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D6))
                {
                    if (myclsinput.D6KeyState == "down")
                    {
                        if (isShift) valor += "^";
                        else valor += "6";
                        myclsinput.D6KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D7))
                {
                    if (myclsinput.D7KeyState == "none") myclsinput.D7KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D7))
                {
                    if (myclsinput.D7KeyState == "down")
                    {
                        if (isShift) valor += "&";
                        else valor += "7";
                        myclsinput.D7KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D8))
                {
                    if (myclsinput.D8KeyState == "none") myclsinput.D8KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D8))
                {
                    if (myclsinput.D8KeyState == "down")
                    {
                        if (isShift) valor += "*";
                        else valor += "8";
                        myclsinput.D8KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D9))
                {
                    if (myclsinput.D9KeyState == "none") myclsinput.D9KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D9))
                {
                    if (myclsinput.D9KeyState == "down")
                    {
                        if (isShift) valor += "(";
                        else valor += "9";
                        myclsinput.D9KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.D0))
                {
                    if (myclsinput.D0KeyState == "none") myclsinput.D0KeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.D0))
                {
                    if (myclsinput.D0KeyState == "down")
                    {
                        if (isShift) valor += ")";
                        else valor += "0";
                        myclsinput.D0KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemTilde))
                {
                    if (myclsinput.OemTildeKeyState == "none") myclsinput.OemTildeKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemTilde))
                {
                    if (myclsinput.OemTildeKeyState == "down")
                    {
                        if (isShift) valor += "~";
                        else valor += "`";
                        myclsinput.OemTildeKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemMinus))
                {
                    if (myclsinput.OemMinusKeyState == "none") myclsinput.OemMinusKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemMinus))
                {
                    if (myclsinput.OemMinusKeyState == "down")
                    {
                        if (isShift) valor += "_";
                        else valor += "-";
                        myclsinput.OemMinusKeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (keyboardState.IsKeyDown(Keys.OemPlus))
                {
                    if (myclsinput.OemPlusKeyState == "none") myclsinput.OemPlusKeyState = "down";
                }
                if (keyboardState.IsKeyUp(Keys.OemPlus))
                {
                    if (myclsinput.OemPlusKeyState == "down")
                    {
                        if (isShift) valor += "+";
                        else valor += "=";
                        myclsinput.OemPlusKeyState = "none";
                    }
                }
            }

            ///////////////////////////////////////////////////////////
            if (keyboardState.IsKeyDown(Keys.Back))
            {
                if (myclsinput.BackKeyState == "none") myclsinput.BackKeyState = "down";
            }
            if (keyboardState.IsKeyUp(Keys.Back))
            {
                if (myclsinput.BackKeyState == "down")
                {
                    if (valor != "") valor = valor.Remove(valor.Length - 1);
                    myclsinput.BackKeyState = "none";
                }
            }
            ///////////////////////////////////////////////////////////
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                if (myclsinput.EnterKeyState == "none") myclsinput.EnterKeyState = "down";
            }
            if (keyboardState.IsKeyUp(Keys.Enter))
            {
                if (myclsinput.EnterKeyState == "down")
                {
                    EnterKeyPressed(this, new EventArgs());
                    myclsinput.EnterKeyState = "none";
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont fonte)
        {
            if (Visivel)
            {
                box.Draw(spriteBatch);
                spriteBatch.DrawString(fonte, valor, new Vector2(box.Area.X + 5, box.Area.Y + 5), Color.Black);

                if (label != null)
                    spriteBatch.DrawString(fonte, label, new Vector2(box.Area.X, box.Area.Y + box.Area.Height + 2), Color.Red);
            }
        }
    }
}
