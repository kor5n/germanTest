using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomizeTranslate : MonoBehaviour
{
    [Header("Delete Words")]
    public GameObject RemovingWords;
    public Dropdown Words;
    public Button RemoveWords;

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
    public Button DeleteWords;

    [Header("Create new test")]
    public GameObject CreatingNew;
    public InputField NewTestName;
    public Button CreateNewTest;

    private bool nowDelete;
    private bool startDelete;
    public static int choosedtest;
    private bool startEdit;
    private bool startChoose;
    public static List<List<string>> localWordList = new List<List<string>>();
    public static List<string> localNameLists = new List<string> {"deafult"};
    public static List<string> defaultList = new List<string> {};
    // Start is called before the first frame update
    void Start()
    {
        startDelete = false;
        EditExsistingComponents.SetActive(false);
        AddWordsComponents.SetActive(false);
        StartComponents.SetActive(true);
        startEdit = false;
        startChoose = false;
        //localWordList.Add(defaultList);
        EditExisted.onClick.AddListener(StartChoose);
        CreateNew.onClick.AddListener(CreateNewSetup);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseList();
        if (startEdit)
        {
            SubmitBut.onClick.AddListener(AddTwoWords);
        }
        if (startDelete)
        {
            RemoveWords.onClick.AddListener(NowDelete);
        }
        if (nowDelete)
        {
            WordsDelete();
        }
    }
    void AddTwoWords()
    {
        
        if (InputDeutsch.text != null && InputDeutsch.text != "" && InputSvenska.text != null && InputSvenska.text != "")
        {
            FindTest();
            Debug.Log(choosedtest);
            WordTranslate.wordList = localWordList[choosedtest];
            localWordList[choosedtest].Add(InputDeutsch.text);
            localWordList[choosedtest].Add(InputSvenska.text);
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
            Delete.onClick.AddListener(DeleteList);
            DeleteWords.onClick.AddListener(WordsDeleteSetup);
        }
        
    }
    void GoToAddWords()
    {
        startChoose = false;
        AddWordsComponents.SetActive(true);
        FindTest();
        EditExsistingComponents.SetActive(false);
        startEdit = true;
    }
    void DeleteList()
    {
        FindTest();
        localNameLists.RemoveAt(choosedtest);
        Debug.Log("Deleted");
        localWordList.RemoveAt(choosedtest);

        SaveTranslateList();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void WordsDeleteSetup()
    {
        startChoose = false;

        FindTest();
        //Debug.Log("Clicked");
        EditExsistingComponents.SetActive(false);
        RemovingWords.SetActive(true);
        Words.ClearOptions();
        PrintAll();
        foreach (string word in localWordList[choosedtest])
        {
            if(localWordList[choosedtest].IndexOf(word) % 2 != 0)
            {
                Words.options.Add(new Dropdown.OptionData() { text = localWordList[choosedtest][localWordList[choosedtest].IndexOf(word)-1] + '-' + word});
            }
        }
        
        
        startDelete = true;


    }
    void WordsDelete()
    {

        Debug.Log(Words.options[Words.value].text + ":OPTION");
        string[] deletingWords = Words.options[Words.value].text.Split("-");
        Debug.Log(deletingWords[0]);
        Debug.Log(deletingWords[1]);

        localWordList[choosedtest].Remove(deletingWords[0]);
        localWordList[choosedtest].Remove(deletingWords[1]);
        PrintAll();
        SaveTranslateList();

        nowDelete = false;

        WordTranslate.wordList = localWordList[choosedtest];

        WordsDeleteSetup();


    }
    
    void FindTest()
    {
        choosedtest = ChooseTest.value;
    }
    public void SaveTranslateList()
    {
        SaveSystem.SaveTranslateList();
        PrintAll();

    }
    void PrintAll()
    {
        Debug.Log(choosedtest);
        foreach(string word in localWordList[choosedtest])
        {
            Debug.Log(word);
        }
        foreach (string list in localNameLists)
        {
            Debug.Log(list);
        }
        Debug.Log(localWordList.SelectMany(list => list).Distinct().Count());

    }
    
    void NowDelete()
    {
        nowDelete = true;
    }
    void CreateNewSetup()
    {
        FindTest();
        StartComponents.SetActive(false);
        CreatingNew.SetActive(true);

        CreateNewTest.onClick.AddListener(Create);
    }
    void Create()
    {

        localNameLists.Add(NewTestName.text);
        localWordList.Add(new List<string> {});
        NewTestName.text = "";
        choosedtest = localNameLists.Count - 1;
        SaveTranslateList();
        
    }

}
