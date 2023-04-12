using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeTranslate : MonoBehaviour
{
    [Header("Components")]
    public GameObject AddWordsComponents;
    public InputField InputSvenska;
    public InputField InputDeutsch;
    public Button SubmitBut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SubmitBut.onClick.AddListener(AddTwoWords);
    }
    void AddTwoWords()
    {
        if(InputDeutsch.text != null && InputDeutsch.text != "" && InputSvenska.text != null && InputSvenska.text != "")
        {
            WordTranslate.wordList.Add(InputDeutsch.text);
            WordTranslate.wordList.Add(InputSvenska.text);
            Debug.Log(WordTranslate.wordList);
            InputDeutsch.text = "";
            InputSvenska.text = "";
        }
    }
}
