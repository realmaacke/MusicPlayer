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
            string path = @"C:\Users\Marcus-Pc\Desktop\music.mp3";

            string[] sepearator = { "/", "//", "\\", " " };
            string[] pathArray = path.Split(sepearator, StringSplitOptions.RemoveEmptyEntries);

            string fileName = pathArray.Last();


            string[] divider = { "." };
            string[] fileNameArray = fileName.Split(divider, StringSplitOptions.RemoveEmptyEntries);

            playFile(path, fileNameArray[0] + ".wav");


        }

        void playFile(string path, string FileName)
        {
            SoundPlayer player = new SoundPlayer();


            string newPath = Path.GetFullPath(Path.Combine(path, ".."));

            string output = newPath + "\\" + FileName;

            Console.WriteLine(output);

            using (var reader = new Mp3FileReader(path))
            {
                WaveFileWriter.CreateWaveFile(output, reader);
            }
            string directory = Directory.GetCurrentDirectory() + "/music" + output;

            player.SoundLocation = directory;

            player.Play();

            Console.ReadKey();
        }
    }
}
