using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button toNominativ, toTranslate;
    // Start is called before the first frame update
    void Start()
    {
        toNominativ.onClick.AddListener(GoToNominativ);
        toTranslate.onClick.AddListener(GoToTranslate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoToTranslate()
    {
        SceneManager.LoadScene("Translate");
    }
    void GoToNominativ()
    {
        SceneManager.LoadScene("diederdas");
    }
}
