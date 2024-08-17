using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubTime
{
    public class SubtitlePicker
    {
        private readonly string baseDirectory;

        private readonly string _filePath;
        private readonly TimeSpan _ts;

        private List<string> _filesPath;


        private SubtitlePicker()
        {
            this.baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }

        private SubtitlePicker(string filePath, TimeSpan ts)
        {
            this._filePath = filePath;
            this._ts = ts;
        }

        private SubtitlePicker(int option, List<string> list)
        {
            this._filePath = list.ElementAt(option);
        }

        public static SubtitlePicker Create()
        {
            return new SubtitlePicker();
        }

        public SubtitlePicker PickSubtitle()
        {
            this._filesPath = Directory
                .GetFiles(this.baseDirectory, "*.srt")
                .ToList();

            var count = 1;

            foreach (var filePath in this._filesPath)
            {
                Console.WriteLine($"{count++}. {Path.GetFileName(filePath)}");
            }

            Console.WriteLine("\nWaiting for input...");

            var option = Convert.ToInt32(Console.ReadLine());

            return new SubtitlePicker(option - 1, this._filesPath);
        }

        public SubtitlePicker PickTimeSpan()
        {
            Console.WriteLine("How many seconds..? (ie. 5 or -5)");

            var ts = TimeSpan.FromSeconds(
                Convert.ToInt32(
                    Console.ReadLine()
                )
            );

            return new SubtitlePicker(_filePath, ts);
        }

        public (string filePath, TimeSpan ts) GetSubtitleAndTimeSpan()
        {
            return (this._filePath, this._ts);
        }
    }
}
