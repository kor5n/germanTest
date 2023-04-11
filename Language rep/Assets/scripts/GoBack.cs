using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(GoToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
