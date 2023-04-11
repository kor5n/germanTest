using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordTranslate : MonoBehaviour
{
    public Button showTranslate;
    public Button nextWord;
    public static bool makeNew;
    public Text wordText;
    public static int wordNum;
    private List<string> wordList = new List<string> {"der Kopf", "huvud","der Mund", "mun","das Gesichte", "ansikte","der Arm", "arm","die Hand", "hand","der Finger",

         "finger","die Schulter", "axel","der Rücken", "rygg","der Bauch", "mage","das Bein", "ben","tut weh", "gör ont","gebrochen", "brutit",

         "das Knie", "knä","der Oberschenkel", "lår","der Fuß", "fot","der Zeh", "tå","die Zehen", "tår","die Backe", "kind",

         "die Narbe", "ärr","das Ohr", "öra","die Haare", "hår","die Stirn", "panna","der Bart", "skägg","die Nase", "näsa",

         "die Lippe", "läpp","die Augenbraue", "ögonbryn","das Auge", "öga","der Ellbogen", "armbåge","der Hals", "hals"};
    // Start is called before the first frame update
    void Start()
    {
        NewWord();
    }

    // Update is called once per frame
    void Update()
    {
        if (makeNew)
        {
            makeNew = false;
            NewWord();
        }
        nextWord.onClick.AddListener(NewWord);
        showTranslate.onClick.AddListener(Showtraslate);
    }
    void NewWord()
    {
        wordNum = Random.Range(0, wordList.Count());
        while (wordNum % 2 != 0)
        {
            wordNum = Random.Range(0, wordList.Count());
        }
        wordText.text = wordList[wordNum];
    }
    void Showtraslate()
    {
        int translateNum = wordNum + 1;
        wordText.text = wordList[translateNum];
    }
}
