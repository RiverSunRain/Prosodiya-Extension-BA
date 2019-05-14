using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Text;
using Debug = UnityEngine.Debug;

public static class SaveSystem
{
    public static Stopwatch SW = new Stopwatch();

    public static string SubjNr;
    public static string ClickedWord;
    public static float RtClick;
    public static int Result;
    public static int Score;
    public static int WordDiff;


    private static string _separator = ";";

    public static void SaveDataAndSaveToCsv()
    {
        string filename = Application.persistentDataPath + "/player" + SubjNr + ".csv";

        var csvLine = SubjNr + _separator + ClickedWord + _separator + RtClick + _separator + Result + _separator +
                      Score + _separator + WordDiff + _separator + CharacterCreator.Instance.Age + _separator + CharacterCreator.Instance.Gender +
                      _separator + CharacterCreator.Instance.Handedness + _separator + CharacterCreator.Instance.Gamification +
                      _separator + CharacterCreator.Instance.NumberOfClouds + System.Environment.NewLine;

        if (!File.Exists(filename))
        {
            var header = "SubjNr;ClickedWord;RtClick;Result;Score;Wordiff;Age;Gender;Handedness;Gamification;Subtasks" + System.Environment.NewLine;
            File.WriteAllText(filename, header, Encoding.UTF8);
        }
        File.AppendAllText(filename, csvLine, Encoding.UTF8);
    }
}