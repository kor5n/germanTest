using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;
public class CustomizeNominativ : MonoBehaviour
{
    [Header("Start Components")]
    public Button EditTest;
    public GameObject StartComponents;
    public Button CreateTest;
    public GameObject Load;
    public Button LoadTestBtn;
    [Header("Edit Components")]
    public GameObject EditComponents;
    public Dropdown DictList;
    public Button AddWords;
    public Button DeleteTestBtn;
    public Button DeleteWords;
    public static int myTest;
    [Header("Add Words Components")]
    public GameObject AddWordsComponents;
    public Button AddDieBtn;
    public Button AddDasBtn;
    public Button AddDerBtn;
    public Button AddAllBtn;
    public InputField InputDie;
    public InputField InputDer;
    public InputField InputDas;
    [Header("Create Test Components")]
    public GameObject CreateNewCmoponents;
    public InputField NewTestName;
    public Button CreateNewBtn;
    [Header("Delete Words Components")]
    public GameObject RemovingWordsComponents;
    public Dropdown WordsDie;
    public Dropdown WordsDas;
    public Dropdown WordsDer;
    public Button RemoveDer;
    public Button RemoveDas;
    public Button RemoveDie;
    public Button RemoveAll;

    private bool loaded;
    public static List<Dictionary<string, List<string>>> localTestList = new List<Dictionary<string, List<string>>> { };
    public static List<string> localTestNames = new List<string> { "deafult" };
    private Dictionary<string, List<string>> deafultDict = new Dictionary<string, List<string>>()
    {
        {"die", new List<string>{"Hand", "Schulter", "Zehen", "Backe", "Narbe", "Haare", "Stirn", "Nase", "Lippe",
        "Augenbraue", "Nachbarn", "Leiche" }},
        {"das", new List<string>{"Gesichte", "Bein", "Ohr", "Auge", "Knie"}},
        {"der", new List<string>{ "Kopf", "Mund", "Arm", "Finger", "Rücken", "Bauch", "Oberschenkel", "Fuß", "Bart",
        "Ellbogen", "Hals", "Täter", "Flur"}}
    };

    // Start is called before the first frame update
    void Start()
    {
        localTestList.Add(deafultDict);

        EditTest.onClick.AddListener(EditSetup);
        CreateTest.onClick.AddListener(CreateNewSetup);
        //LoadTestBtn.onClick.AddListener(LoadTest);

        AddWords.onClick.AddListener(AddWordsSetup);
        DeleteTestBtn.onClick.AddListener(DeleteTest);
        DeleteWords.onClick.AddListener(DeleteWordsSetup);

        AddDieBtn.onClick.AddListener(AddWordDie);
        AddDasBtn.onClick.AddListener(AddWordDas);
        AddDerBtn.onClick.AddListener(AddWordDer);
        AddAllBtn.onClick.AddListener(AddWordAll);

        CreateNewBtn.onClick.AddListener(CreateNewTest);

        RemoveDie.onClick.AddListener(RemoveWordDie);
        RemoveDas.onClick.AddListener(RemoveWordDas);
        RemoveDer.onClick.AddListener(RemoveWordDer);
        RemoveAll.onClick.AddListener(DeleteAll);



    }

    // Update is called once per frame
    void Update()
    {
        if (loaded)
        {
            Load.SetActive(false);
        }
    }
    private void EditSetup()
    {
        StartComponents.SetActive(false);
        EditComponents.SetActive(true);
        DictList.ClearOptions();
        foreach (string list in localTestNames)
        {
            DictList.options.Add(new Dropdown.OptionData() { text = list });
        }
    }
    private void AddWordsSetup()
    {
        EditComponents.SetActive(false);
        AddWordsComponents.SetActive(true);
        FindTest();
        for (int i = 0; i < localTestList[myTest]["der"].Count; i++)
        {
            Debug.Log(localTestList[myTest]["das"][i]);
            Debug.Log(localTestList[myTest]["die"][i]);
            Debug.Log(localTestList[myTest]["der"][i]);
        }


    }
    private void FindTest()
    {
        myTest = DictList.value;
    }
    private void AddWordDie()
    {
        if (InputDie.text != null && InputDie.text != "")
        {
            localTestList[myTest]["die"].Add(InputDie.text);
            Debug.Log(localTestList[myTest]["die"][localTestList[myTest]["die"].Count - 1]);
            InputDie.text = "";
        }
        SaveNominativList();
    }
    private void AddWordDas()
    {
        if (InputDas.text != null && InputDas.text != "")
        {
            localTestList[myTest]["das"].Add(InputDas.text);
            Debug.Log(localTestList[myTest]["das"][localTestList[myTest]["das"].Count - 1]);

            InputDas.text = "";

        }
        SaveNominativList();
    }
    private void AddWordDer()
    {
        if (InputDer.text != null && InputDer.text != "")
        {
            localTestList[myTest]["der"].Add(InputDer.text);
            Debug.Log(localTestList[myTest]["der"][localTestList[myTest]["der"].Count - 1]);

            InputDer.text = "";

        }
        SaveNominativList();
    }
    private void AddWordAll()
    {
        AddWordDie();
        AddWordDas();
        AddWordDer();
    }
    private void CreateNewSetup()
    {
        StartComponents.SetActive(false);
        CreateNewCmoponents.SetActive(true);
    }
    private void CreateNewTest()
    {
        if (NewTestName.text != null && NewTestName.text != "" && localTestNames.Contains(NewTestName.text) != true)
        {
            localTestNames.Add(NewTestName.text);
            localTestList.Add(new Dictionary<string, List<string>>()
            {
                {"die", new List<string>{}},
                {"das", new List<string>{}},
                {"der", new List<string>{}}
            });
            NewTestName.text = "";
            myTest = localTestList.Count - 1;
        }
        SaveNominativList();
    }
    private void DeleteTest()
    {
        FindTest();
        localTestNames.RemoveAt(myTest);
        localTestList.RemoveAt(myTest);
        SaveNominativList();
        EditSetup();
    }
    private void DeleteWordsSetup()
    {
        FindTest();
        //Debug.Log("Clicked");
        StartComponents.SetActive(false);
        RemovingWordsComponents.SetActive(true);
        WordsDie.ClearOptions();
        WordsDas.ClearOptions();
        WordsDer.ClearOptions();
        //PrintAll()
        foreach (string word in localTestList[myTest]["die"])
        {
            WordsDie.options.Add(new Dropdown.OptionData() { text = word });
        }
        foreach (string word in localTestList[myTest]["das"])
        {
            WordsDas.options.Add(new Dropdown.OptionData() { text = word });
        }
        foreach (string word in localTestList[myTest]["der"])
        {
            WordsDer.options.Add(new Dropdown.OptionData() { text = word });
        }
        

    }
    private void RemoveWordDer() 
    {
        localTestList[myTest]["der"].RemoveAt(WordsDer.value);
        SaveNominativList();
        DeleteWordsSetup();
    }
    private void RemoveWordDie()
    {
        localTestList[myTest]["die"].RemoveAt(WordsDie.value);
        SaveNominativList();
        DeleteWordsSetup();
    }
    private void RemoveWordDas()
    {
        localTestList[myTest]["das"].RemoveAt(WordsDas.value);
        SaveNominativList();
        DeleteWordsSetup();
    }
    private void DeleteAll()
    {
        RemoveWordDie();
        RemoveWordDas();
        RemoveWordDer();
    }
    public void LoadTest()
    {
        NominativData data = SaveSystem.LoadNominativLists();

        CustomizeNominativ.localTestList = data.nominativLists;
        CustomizeNominativ.localTestNames= data.nominativNames;

        loaded = true;
    }
    public void SaveNominativList()
    {
        SaveSystem.SaveNominativList();
    }
}