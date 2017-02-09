using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RhythmEditor
{
    public class Beat
    {
        public int trackIndex;
        public int Time;
        // 0 ~ 8: none, left, up, right, down, left-air, up-air, right-air, down-air
        public int beatType;
        public string beatName;
        public int beatIndex;
        public float estimatedTime;
    }

    public class BeatTypeInput
    {
        public KeyCode pressedKey;
        public KeyCode holdKey;
        public int beatType;
        public string displayName;

        public BeatTypeInput(KeyCode _pressed, KeyCode _hold, int _beatType, string _name)
        {
            pressedKey = _pressed;
            holdKey = _hold;
            beatType = _beatType;
            displayName = _name;
        }

        public bool TryGetInputBeatType(out int _beatType, out string _name)
        {
            _beatType = 0;
            _name = "";
            if (Input.GetKeyUp(pressedKey))
            {
                if (holdKey == KeyCode.None || Input.GetKey(holdKey))
                {
                    _beatType = beatType;
                    _name = displayName;
                    return true;
                }
            }
            return false;
        }
    }

    public class ConfigObject
    {
        public List<bool> trackEnabled;
        public List<Beat> beats;
        public float ticksPerSecond;
        public int bpm;
        public int deltaTicksPerQuarterNote;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string LF = "\r\n"; // line feed

            sb.Append("ticksPerSecond:").Append(ticksPerSecond).Append(LF);
            sb.Append("bpm:").Append(bpm).Append(LF);
            sb.Append("deltaTicksPerQuarterNote:").Append(deltaTicksPerQuarterNote).Append(LF);

            sb.Append("trackEnabled:");
            for (int i = 0; i < trackEnabled.Count; i++)
            {
                sb.Append(trackEnabled[i] ? "1" : "0");
            }
            sb.Append(LF);

            for (int i = 0; i < beats.Count; i++)
            {
                var beat = beats[i];
                if (beat.beatType > 0)
                {
                    sb.Append("beat:").Append(beat.estimatedTime).Append(',')
                        .Append(beat.Time).Append(',').Append(beat.beatIndex)
                        .Append(',').Append(beat.beatType).Append(',')
                        .Append(beat.beatName).Append(LF);
                }
            }

            return sb.ToString();
        }

        public void LoadFromString(string str)
        {
            trackEnabled = new List<bool>();
            beats = new List<Beat>();
            foreach (var splittedLine in str.Split('\n'))
            {
                var line = splittedLine.Replace("\r", "");
                int colonIndex = line.IndexOf(':');
                if (colonIndex < 0)
                    continue;
                var fieldName = line.Substring(0, colonIndex);
                var dataStr = line.Substring(colonIndex + 1);

                switch (fieldName)
                {
                    case "beat":
                        var fields = dataStr.Split(',');
                        var beat = new Beat();
                        beat.estimatedTime = float.Parse(fields[0]);
                        beat.Time = int.Parse(fields[1]);
                        beat.beatIndex = int.Parse(fields[2]);
                        beat.beatType = int.Parse(fields[3]);
                        beat.beatName = fields[4];
                        beats.Add(beat);
                        break;
                    case "ticksPerSecond":
                        ticksPerSecond = float.Parse(dataStr);
                        break;
                    case "bpm":
                        bpm = int.Parse(dataStr);
                        break;
                    case "deltaTicksPerQuarterNote":
                        deltaTicksPerQuarterNote = int.Parse(dataStr);
                        break;
                    case "trackEnabled":
                        foreach (char c in dataStr)
                        {
                            trackEnabled.Add(c == '1');
                        }
                        break;
                }
            }
        }
    }

}
