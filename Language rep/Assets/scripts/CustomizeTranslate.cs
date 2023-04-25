using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeTranslate : MonoBehaviour
{
    [Header("Add Word")]
    public GameObject AddWordsComponents;
    public InputField InputSvenska;
    public InputField InputDeutsch;
    public Button SubmitBut;

    [Header("Start")]
    public GameObject StartComponents;
    public Button CreateNew;
    public Button EditExisted;

    [Header("EditExisting")]
    public GameObject EditExsistingComponents;
    public Dropdown ChooseTest;
    public Button Delete;
    public Button Edit;

    private int choosedtest;
    private bool startEdit;
    private bool startChoose;
    public static List<List<string>> localWordList = new List<List<string>>();
    public static List<string> localNameLists = new List<string> {"deafult"};
    public static List<string> defaultList = new List<string> {"der Kopf", "huvud","der Mund", "mun","das Gesichte", "ansikte","der Arm", "arm","die Hand", "hand","der Finger",

         "finger","die Schulter", "axel","der Rücken", "rygg","der Bauch", "mage","das Bein", "ben","tut weh", "gör ont","gebrochen", "brutit",

         "das Knie", "knä","der Oberschenkel", "lår","der Fuß", "fot","der Zeh", "tå","die Zehen", "tår","die Backe", "kind",

         "die Narbe", "ärr","das Ohr", "öra","die Haare", "hår","die Stirn", "panna","der Bart", "skägg","die Nase", "näsa",

         "die Lippe", "läpp","die Augenbraue", "ögonbryn","das Auge", "öga","der Ellbogen", "armbåge","der Hals", "hals"};
    // Start is called before the first frame update
    void Start()
    {
        EditExsistingComponents.SetActive(false);
        AddWordsComponents.SetActive(false);
        StartComponents.SetActive(true);
        startEdit = false;
        startChoose = false;
        localWordList.Add(defaultList);
        EditExisted.onClick.AddListener(StartChoose);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseList();
        if (startEdit)
        {
            SubmitBut.onClick.AddListener(AddTwoWords);
        }
    }
    void AddTwoWords()
    {
        if (InputDeutsch.text != null && InputDeutsch.text != "" && InputSvenska.text != null && InputSvenska.text != "")
        {
            WordTranslate.wordList = localWordList[choosedtest];
            localWordList.RemoveAt(choosedtest);
            WordTranslate.wordList.Add(InputDeutsch.text);
            WordTranslate.wordList.Add(InputSvenska.text);
            localWordList.Insert(choosedtest, WordTranslate.wordList);
            Debug.Log(WordTranslate.wordList);
            InputDeutsch.text = "";
            InputSvenska.text = "";
            SaveTranslateList();
        }

    }
    private void StartChoose()
    {
        StartComponents.SetActive(false);
        EditExsistingComponents.SetActive(true);
        ChooseTest.ClearOptions();
        foreach (string list in localNameLists)
        {
            ChooseTest.options.Add(new Dropdown.OptionData() { text = list});
        }
        startChoose = true;
    }
    void ChooseList()
    {
        if (startChoose)
        {
            Edit.onClick.AddListener(GoToAddWords);

        }
    }
    void GoToAddWords()
    {
        startChoose = false;
        AddWordsComponents.SetActive(true);
        for (int i=0; i>=localNameLists.Count(); i++)
        {
            if (localNameLists.Contains(ChooseTest.value.ToString()))
            {
                choosedtest = i;
                break;
            }
        }
        EditExsistingComponents.SetActive(false);
        startEdit = true;
    }
    public void SaveTranslateList()
    {
        SaveSystem.SaveTranslateList();
    }
    
}
