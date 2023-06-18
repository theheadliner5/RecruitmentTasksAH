using System.Text.RegularExpressions;

namespace RecruitmentTasksAH.SecondTask
{
    public class Program
    {
        public static void Main()
        {
            ProcessSubtitles(@"C:\napisy do filmu.srt", @"C:\removed.srt", 5, 880);
        }

        public static void ProcessSubtitles(string inputFilePath, string outputFilePath, int seconds, int milliseconds)
        {
            var lines = File.ReadAllLines(inputFilePath);
            List<string> shiftedSubtitles = new();
            List<string> removedSubtitles = new();
            var counter = 1;
            var counterRemoved = 1;

            for (int i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i], out _))
                {
                    var times = lines[i + 1].Split(" --> ");
                    var shiftedStartTime = ShiftTime(times[0], seconds, milliseconds);
                    var shiftedEndTime = ShiftTime(times[1], seconds, milliseconds);

                    if (TimeSpan.Parse(shiftedStartTime.Replace(',', '.')).Milliseconds == 0)
                    {
                        removedSubtitles.Add(counterRemoved++.ToString());
                        removedSubtitles.Add($"{shiftedStartTime} --> {shiftedEndTime}");
                        var j = i + 2;
                        while (j < lines.Length && !string.IsNullOrWhiteSpace(lines[j]))
                        {
                            removedSubtitles.Add(lines[j]);
                            j++;
                        }

                        removedSubtitles.Add("");
                    }
                    else
                    {
                        shiftedSubtitles.Add(counter++.ToString());
                        shiftedSubtitles.Add($"{shiftedStartTime} --> {shiftedEndTime}");
                        var j = i + 2;
                        while (j < lines.Length && !string.IsNullOrWhiteSpace(lines[j]))
                        {
                            shiftedSubtitles.Add(lines[j]);
                            j++;
                        }

                        shiftedSubtitles.Add("");
                    }
                }
            }

            if (shiftedSubtitles.Count > 0 && string.IsNullOrEmpty(shiftedSubtitles[^1]))
            {
                shiftedSubtitles.RemoveAt(shiftedSubtitles.Count - 1);
            }

            if (removedSubtitles.Count > 0 && string.IsNullOrEmpty(removedSubtitles[^1]))
            {
                removedSubtitles.RemoveAt(removedSubtitles.Count - 1);
            }

            File.WriteAllLines(inputFilePath, shiftedSubtitles.ToArray());
            File.WriteAllLines(outputFilePath, removedSubtitles.ToArray());
        }

        private static string ShiftTime(string time, int seconds, int milliseconds)
        {
            var pattern = new Regex(@"(\d+):(\d+):(\d+),(\d+)");
            var match = pattern.Match(time);

            int hours = int.Parse(match.Groups[1].Value);
            int minutes = int.Parse(match.Groups[2].Value);
            int secs = int.Parse(match.Groups[3].Value);
            int millisecs = int.Parse(match.Groups[4].Value);

            TimeSpan originalTime = new(0, hours, minutes, secs, millisecs);
            TimeSpan shiftSpan = new(0, 0, 0, seconds, milliseconds);
            TimeSpan shiftedTime = originalTime.Add(shiftSpan);

            return $"{shiftedTime.Hours:D2}:{shiftedTime.Minutes:D2}:{shiftedTime.Seconds:D2},{shiftedTime.Milliseconds:D3}";
        }
    }
}