using SubTime.Contracts;
using SubTime.Factories;
using System.Text;

namespace SubTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fileName = args[0];
            //int seconds = Convert.ToInt32(args[1]);

            //string fileName = "Alex and Emma (2003).sub";
            //int seconds = 5;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var options = SubtitlePicker
                .Create()
                .PickSubtitle()
                .PickTimeSpan()
                .GetSubtitleAndTimeSpan();

            var subtitleFactory = new SubtitleFactory();
            ISubtitle subtitle = subtitleFactory.GetSubtitle(options.filePath);

            subtitle?.SyncTime(
                options.filePath, 
                Convert.ToInt32(options.ts.TotalSeconds)
            );
        }
    }
}
