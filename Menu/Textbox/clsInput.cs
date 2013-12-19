using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;
using System.Text;

namespace TowerDefense_XNA.Menu
{
    class clsInput
    {
        public string AKeyState = "none";
        public string BKeyState = "none";
        public string CKeyState = "none";
        public string DKeyState = "none";
        public string EKeyState = "none";
        public string FKeyState = "none";
        public string GKeyState = "none";
        public string HKeyState = "none";
        public string IKeyState = "none";
        public string JKeyState = "none";
        public string KKeyState = "none";
        public string LKeyState = "none";
        public string MKeyState = "none";
        public string NKeyState = "none";
        public string OKeyState = "none";
        public string PKeyState = "none";
        public string QKeyState = "none";
        public string RKeyState = "none";
        public string SKeyState = "none";
        public string TKeyState = "none";
        public string UKeyState = "none";
        public string VKeyState = "none";
        public string WKeyState = "none";
        public string XKeyState = "none";
        public string YKeyState = "none";
        public string ZKeyState = "none";
        public string SpaceKeyState = "none";
        public string BackKeyState = "none";
        /// //////////////////////////////////////////////
        public string OemSemicolonKeyState = "none";
        public string OemQuotesKeyState = "none";
        public string OemCommaKeyState = "none";
        public string OemPeriodKeyState = "none";
        public string OemQuestionKeyState = "none";
        /////////////////////////////////////////////////
        public string OemOpenBracketsKeyState = "none";
        public string OemCloseBracketsKeyState = "none";
        public string OemPipeKeyState = "none";
        //////////////////////////////////////////////////
        public string D1KeyState = "none";
        public string D2KeyState = "none";
        public string D3KeyState = "none";
        public string D4KeyState = "none";
        public string D5KeyState = "none";
        public string D6KeyState = "none";
        public string D7KeyState = "none";
        public string D8KeyState = "none";
        public string D9KeyState = "none";
        public string D0KeyState = "none";
        //////////////////////////////////////////////////
        public string OemTildeKeyState = "none";
        public string OemMinusKeyState = "none";
        public string OemPlusKeyState = "none";
        /// ////////////////////////////////////////////////
        public string EnterKeyState = "none";
        public string EscKeyState = "none";
        public bool isShiftPressed(Keys[] mykeys)
        {
            bool result = false;
            foreach (Keys key in mykeys)
            {
                if (key == Keys.LeftShift || key == Keys.RightShift)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool isControlPressed(Keys[] mykeys)
        {
            bool result = false;
            foreach (Keys key in mykeys)
            {
                if (key == Keys.LeftControl || key == Keys.RightControl)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}