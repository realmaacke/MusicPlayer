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
            Console.Write("Enter Path to mp3 file > ");
            string path = Console.ReadLine();

            

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

            // grabs olf path and cd ..
            string newPath = Path.GetFullPath(Path.Combine(path, ".."));


            // grabs the new path and adds / file.file

            string dirPath = Directory.GetCurrentDirectory() + "\\" + FileName;


            using (var reader = new Mp3FileReader(path))
            {
                WaveFileWriter.CreateWaveFile(dirPath, reader);
            }

            Console.WriteLine(dirPath);
            player.SoundLocation = dirPath;

            player.Play();

            Console.Clear();
            Console.WriteLine("Now Playing:" + path);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
