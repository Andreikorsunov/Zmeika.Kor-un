using System;
using System.Collections.Generic;
using System.Text;
using WMPLib;

namespace Zmeika.Koršun
{
    class Sounds
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;

        public Sounds(string pathToResources)
        {

            pathToMedia = pathToResources;
        }

        public void Play(string sound)
        {
            player.URL = pathToMedia + sound;// "stardust.mp3";
            player.settings.volume = 30;
            player.controls.play();
            player.settings.setMode("loop", true); // loop mode
        }
        public void Stop(string sound)
        {
            player.URL = pathToMedia + sound;
            player.controls.stop();
        }
        public void PlayEat()
        {
            player.URL = pathToMedia + "click.mp3";
            player.settings.volume = 100;
            player.controls.play();
        }

    }
}