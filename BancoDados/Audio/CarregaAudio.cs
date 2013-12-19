using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace TowerDefense_XNA.BancoDados
{
    partial class BancoDados
    {
        private void AddAudio(ContentManager Content, string audioName)
        {
            Audio audio = new Audio(audioName, Content.Load<SoundEffect>(CAMINHO_AUDIO + audioName));
            this.audios.Add(audio);
        }

        partial void CarregaAudios(ContentManager Content)
        {
            AddAudio(Content, "AtaqueGuerreiro");
            AddAudio(Content, "AtaqueFogo");
            AddAudio(Content, "AtaqueGelo");
        }
    }
}
