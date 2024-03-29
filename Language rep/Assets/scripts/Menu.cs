using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Menu : MonoBehaviour
{
    
    public Button toNominativ, toTranslate, toCustomTranslate, toCustomNominativ;
    // Start is called before the first frame update
    void Start()
    {
        toNominativ.onClick.AddListener(GoToNominativ);
        toTranslate.onClick.AddListener(GoToTranslate);
        toCustomTranslate.onClick.AddListener(GoToCustomTranslate);
        toCustomNominativ.onClick.AddListener(GoToCustomNominativ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoToTranslate()
    {
        LoadTranslate();
        SceneManager.LoadScene("Translate");
    }
    void GoToNominativ()
    {
        SceneManager.LoadScene("diederdas");
    }
    void GoToCustomTranslate()
    {
        SceneManager.LoadScene("CustomTranslate");
    }
    void GoToCustomNominativ()
    {
        SceneManager.LoadScene("CustomizeNominativ");
    }
    public void LoadTranslate()
    {
        TranslateData data = SaveSystem.LoadWordLists();

        CustomizeTranslate.localWordList = data.wordLists;
        CustomizeTranslate.localNameLists = data.listNames;

        
        foreach (string word in CustomizeTranslate.localWordList[CustomizeTranslate.choosedtest])
        {
            Debug.Log(word);
        }
    
        foreach (string list in CustomizeTranslate.localNameLists)
        {
            Debug.Log(list);
        }
        Debug.Log(CustomizeTranslate.localWordList.SelectMany(list => list).Distinct().Count());
        CustomizeTranslate.testLoaded = true;
    }

}
