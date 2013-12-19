using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace TowerDefense_XNA.BancoDados
{
    public class Audio
    {
        SoundEffect audio;
        string nome;

        public Audio(string nome, SoundEffect audio)
        {
            this.nome = nome;
            this.audio = audio;
        }

        public void Play()
        {
            this.audio.Play();
        }

        public static Audio GetAudio(string audio)
        {
            return Global.bancoDados.Audios.Where(x => x.nome == audio).First();
        }

    }
}
