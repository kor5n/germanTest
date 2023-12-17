using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordTranslate : MonoBehaviour
{
    [Header("Components")]
    public GameObject TranslateComponents;
    public Button showTranslate;
    public Button nextWord;
    public Text wordText;
    public GameObject StartObjects;
    public Button ChooseTestBtn;
    public Dropdown TestList;

    private int practiceTest;
    private bool makeNew;
    private int wordNum;
    public static List<string> wordList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (string list in CustomizeTranslate.localNameLists)
        {
            TestList.options.Add(new Dropdown.OptionData() { text = list });
        }
        ChooseTestBtn.onClick.AddListener(ChoosePracticetest);
    }

    // Update is called once per frame
    void Update()
    {
        if (makeNew)
        {
            makeNew = false;
            NewWord();
        }
        
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
    void Showtranslate()
    {
        int translateNum = wordNum + 1;
        wordText.text = wordList[translateNum];
    }
    void ChoosePracticetest()
    {
        practiceTest = TestList.value;
        wordList = CustomizeTranslate.localWordList[practiceTest];
        StartObjects.SetActive(false);
        TranslateComponents.SetActive(true);
        nextWord.onClick.AddListener(NewWord);
        showTranslate.onClick.AddListener(Showtranslate);
        NewWord();
    }
    

}
