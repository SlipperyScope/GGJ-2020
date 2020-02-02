using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum Tools { Dick, Cock }

[System.Serializable]
public class ToolScorePair
{
    [SerializeField]
    public Tools Tool;
    public float Score;
    public string Blurb;
}
