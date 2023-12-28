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
    public Button LoadTest;
    [Header("Edit Components")]
    public GameObject EditComponents;
    public Dropdown DictList;
    public Button AddWords;
    public Button DeleteTest;
    public Button DeleteWords;
    public static int myTest;
    [Header("AddWordsComponents")]
    public GameObject AddWordsComponents;
    public Button AddDieBtn;
    public Button AddDasBtn;
    public Button AddDerBtn;
    public Button AddAllBtn;
    public InputField InputDie;
    public InputField InputDer;
    public InputField InputDas;

    public static List<Dictionary<string, List<string>>> localTestList = new List<Dictionary<string, List<string>>> { };
    public static List<string> localTestNames = new List<string> {"deafult"};
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
        //CreateTest.onClick.AddListener();
        //LoadTest.onClick.AddListener();

        AddWords.onClick.AddListener(AddWordsSetup);
        //DeleteTest.onClick.AddListener();
        //DeleteWords.onClick.AddListener();

        AddDieBtn.onClick.AddListener(AddWordDie);
        AddDasBtn.onClick.AddListener(AddWordDas);
        AddDerBtn.onClick.AddListener(AddWordDer);
        AddAllBtn.onClick.AddListener(AddWordAll);


    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
    private void AddWordDas()
    {
        if (InputDas.text != null && InputDas.text != "")
        {
            localTestList[myTest]["das"].Add(InputDas.text);
        }
    }
    private void AddWordDer()
    {
        if (InputDer.text != null && InputDer.text != "")
        {
            localTestList[myTest]["der"].Add(InputDer.text);
        }
    }
    private void AddWordAll()
    {
        AddWordDie();
        AddWordDas();
        AddWordDer();
    }

}
