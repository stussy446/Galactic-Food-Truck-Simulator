using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpokenLines
{
    public int languageID;
    public List<int> lineID = new List<int>();
    public List<string> voiceLine = new List<string>();

    public SpokenLines(int langID)
    {
        languageID = langID;
    }
    public void Addline(string newLine)
    {
        voiceLine.Add(newLine);
        lineID.Add(voiceLine.Count -1);
    }

    public string GetLine(int id)
    {
        return voiceLine[id];
    }
}
