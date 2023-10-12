using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public Button toNominativ, toTranslate, toCustomTranslate;
    // Start is called before the first frame update
    void Start()
    {
        toNominativ.onClick.AddListener(GoToNominativ);
        toTranslate.onClick.AddListener(GoToTranslate);
        toCustomTranslate.onClick.AddListener(GoTOCustomTranslate);
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
    void GoTOCustomTranslate()
    {
        SceneManager.LoadScene("CustomTranslate");
    }

    public void LoadTranslate()
    {
        TranslateData data = SaveSystem.LoadWordLists();

        CustomizeTranslate.localWordList = data.wordLists;
        CustomizeTranslate.localNameLists = data.listNames;
    }
    
}
