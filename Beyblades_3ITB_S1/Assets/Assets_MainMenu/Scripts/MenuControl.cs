using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public int currentScene { get; private set; } = 0;
    /*
        // main menu buttons
        [SerializeField]
        Button PlayBtn, SettingBtn, ExitBtn;

        // settings menu components
        [SerializeField]
        Slider musicSlider;
        [SerializeField]
        Toggle fullscreenToggle;
        [SerializeField]
        Button backBtn;
    */


    public static Slider musicSlider;
    public static Toggle fullScreenToggle;


    private void Start()
    {
        currentScene = 0;
        /*
        Button playButton = PlayBtn.GetComponent<Button>();
        Button settingButton = SettingBtn.GetComponent<Button>();
        Button exitButton = ExitBtn.GetComponent<Button>();


       // Button backButton = backBtn.GetComponent<Button>();


        playButton.onClick.AddListener(delegate { changeSceneTo(3); });
        settingButton.onClick.AddListener(delegate { changeSceneTo(1); });
        exitButton.onClick.AddListener(exitGame);
        
       // backButton.onClick.AddListener(delegate { changeSceneTo(0); });

        */
    }

    private void Update()
    {
        Debug.Log(musicSlider.value);   
    }


    public void changeSceneTo(int newSceneIndex)
    {
        Debug.Log("changing to: " + newSceneIndex);
        SceneManager.LoadScene(newSceneIndex);

        if(newSceneIndex == 1)
        {
            getSettingComponents();
        }

        currentScene = newSceneIndex;
    }

    public void changeSceneToString(string newSceneString)
    {
        if (newSceneString != null)
        {
            SceneManager.LoadScene(newSceneString);
        }
    }

        public void getSettingComponents()
    {

        musicSlider = GameObject.Find("music").GetComponent<Slider>();
        fullScreenToggle = GameObject.Find("Fullscreen").GetComponent<Toggle>();

    }

    public void exitGame()
    {
        Application.Quit();
    }

}
