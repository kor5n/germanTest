using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TranslateData 
{
    public List<List<string>> wordLists;
    public List<string> listNames;

    public TranslateData()
    {
        wordLists = CustomizeTranslate.localWordList;
        listNames = CustomizeTranslate.localNameLists;
    }
}
