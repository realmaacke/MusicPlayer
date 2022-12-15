using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class MediaPlayer
    {

        public MediaPlayer()
        {
            start();
        }

        void start()
        {
            playFile("C:\\Users\\Marcus-PC\\Desktop\\music.mp3");
        }

        void playFile(string path)
        {
            SoundPlayer player = new SoundPlayer();

            var infile = @"C:\Users\Marcus-Pc\Desktop\music.mp3";
            var outfile = @"C:\Users\Marcus-Pc\Desktop\converted.wav";

            using (var reader = new Mp3FileReader(infile))
            {
                WaveFileWriter.CreateWaveFile(outfile, reader);
            }


            player.SoundLocation = outfile;

            player.Play();

            Console.ReadKey();
        }
    }
}
