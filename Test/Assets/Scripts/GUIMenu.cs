using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {

    public Texture2D backGroundMenu;
    public GUISkin MenuSkin;
    private int windows;
    private bool window;

    [Header("Графика")]
    private byte graphicsValue;


    void Update()
    {
        QualitySettings.SetQualityLevel(graphicsValue);
       // Screen.fullScreen = window;
    }
    void OnGUI()
    {
        GUI.skin = MenuSkin;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backGroundMenu);
        /*---------------------Главное меню---------------------*/
        if (windows == 0)
        {
            if(GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 25, 200, 50), "Играть"))
            {
                Application.LoadLevel("first");
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 30, 200, 50), "Настройки"))
            {
                windows = 1;
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 85, 200, 50), "Выход"))
            {
                Application.Quit();
            }
        }

        /*---------------------Настройки---------------------*/
        if(windows == 1)
        {
            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 55, 200, 50), "Управление"))
            {
                windows = 2;
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 0, 200, 50), "Видео"))
            {
                windows = 3;
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 55, 200, 50), "Звук"))
            {
                windows = 4;
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 110, 200, 50), "Назад"))
            {
                windows = 0;
            }
        }

        /*---------------------Управление---------------------*/
        if(windows == 2)
        {

        }

        /*---------------------Видео---------------------*/
        if (windows == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 130, 300, 45), "Качество");
            graphicsValue = (byte)GUI.HorizontalScrollbar(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 45), graphicsValue, 1, 0, 6);

           // GUI.Toggle(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 70, 300, 45), window, " Оконный режим");

            
            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 110, 200, 50), "Назад"))
            {
                windows = 0;
            }
        }

        /*---------------------Звук---------------------*/
        if(windows == 4)
        {

        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	
}
