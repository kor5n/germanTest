using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Nominativ : MonoBehaviour
{
    [Header("Components")]
    public GameObject MainComponents;
    public Text wordText;
    public Button dieBut, dasBut, derBut, nextWordBut;
    public GameObject nextWord;

    [Header("Start Components")]
    public GameObject StartComponents;
    public Dropdown ChooseTest;
    public Button ChooseBtn;

    private string answer;
    private bool gotRight;
    public static List<string> die = new List<string>() {"Hand", "Schulter", "Zehen", "Backe", "Narbe", "Haare", "Stirn", "Nase", "Lippe",
        "Augenbraue", "Nachbarn", "Leiche"};
    public static List<string> das = new List<string>() {"Gesichte", "Bein", "Ohr", "Auge", "Knie"};
    public static List<string> der = new List<string>() { "Kopf", "Mund", "Arm", "Finger", "Rücken", "Bauch", "Oberschenkel", "Fuß", "Bart",
        "Ellbogen", "Hals", "Täter", "Flur"};
        
    private Dictionary<string, List<string>> words = new Dictionary<string, List<string>>()
    {
        {"die", die},
        {"das", das},
        {"der", der}
    };
    // Start is called before the first frame update
    void Start()
    {
        foreach(string name in CustomizeNominativ.localTestNames)
        {
            ChooseTest.options.Add(new Dropdown.OptionData {text = name});
        }
        //words = CustomizeNominativ.localTestList[CustomizeNominativ.myTest];
        dieBut.onClick.AddListener(DieBut);
        dasBut.onClick.AddListener(DasBut);
        derBut.onClick.AddListener(DerBut);
        nextWordBut.onClick.AddListener(CreateWord);
        ChooseBtn.onClick.AddListener(PlayTest);
    }

    // Update is called once per frame
    void Update()
    {
        if(gotRight == true)
        {
            nextWord.SetActive(true);
        }
    }
    void CreateWord()
    {
        gotRight = false;
        nextWord.SetActive(false);
        dieBut.image.color = Color.white;
        dasBut.image.color = Color.white;
        derBut.image.color = Color.white;
        int nominativ = Random.Range(1, 4);
        if (nominativ == 1)
        {
            answer = "die";
            wordText.text = words["die"][Random.Range(0, words["die"].Count())];
        }
        else if (nominativ == 2)
        {
            answer = "das";
            wordText.text = words["das"][Random.Range(0, words["das"].Count())];
            
        }
        else if (nominativ == 3)
        {
            answer = "der";
            wordText.text = words["der"][Random.Range(0, words["der"].Count())];
        }
    }
    void DieBut()
    {
        if (answer == "die")
        {
            dieBut.image.color = Color.green;
            gotRight = true;
        }
        else
        {
            dieBut.image.color = Color.red;
        }
    }
    void DasBut()
    {
        if (answer == "das")
        {
            dasBut.image.color = Color.green;
            gotRight = true;
        }
        else
        {
           dasBut.image.color = Color.red;
        }
    }
    void DerBut()
    {
        if (answer == "der")
        {
            derBut.image.color = Color.green;
            gotRight = true;
        }
        else
        {
            derBut.image.color = Color.red;
        }
    }
    private void PlayTest()
    {
        words = CustomizeNominativ.localTestList[ChooseTest.value];
        StartComponents.SetActive(false);
        MainComponents.SetActive(true);
        CreateWord();
    }
}
