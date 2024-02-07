using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{   
    [SerializeField] KeyCode mainMenuKey = KeyCode.Escape;

    public static Action<string> OnSceneChanged;
    private void Awake() => OnSceneChanged += (scene) => GoToScene(scene);
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(mainMenuKey)) 
        {
            MainMenu_Handler.OnSceneChanged.Invoke("MainMenu");
        }
    }

    public void GoToScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void Play() => OnSceneChanged("Game");

    public void Quit() => Application.Quit();
}
