using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum Tools {
    Cash,
    Drugs,
    Gun,
    Ladder,
    Molotov,
    Pills,
    Search,
    Talk,
    Wrench,
    Yell,
}

[System.Serializable]
public class ToolScorePair
{
    [SerializeField]
    public Tools Tool;
    public float Score;
    public string Blurb;
}
