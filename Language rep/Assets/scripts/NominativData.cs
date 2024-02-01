using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NominativData
{
    public List<Dictionary<string, List<string>>> nominativLists;
    public List<string> nominativNames;

    public NominativData()
    {
        nominativLists = CustomizeNominativ.localTestList;
        nominativNames = CustomizeNominativ.localTestNames;
    }
}