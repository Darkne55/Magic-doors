using UnityEngine;
using System.Collections;

public class Tooltips : MonoBehaviour {

    // Размер меню
    public Vector2 menuSize = new Vector2(500, 300);
    public float buttonMinHeight = 30f;
    string ButtonText = "ОК";

    public bool triggered = false;
    bool MenuOpen = true;
    GameObject player;

    public int tooltipNumber;
    string LabelTextSecondTooltip = "Некоторые ключи в этой комнате могут открывать сундуки! Это один из них.";
    string LabelTextFirstTooltip = "Привет, Дорогой друг! Впереди тебя ждет много интересных приключений. Эта игра - настоящая головоломка для любителей пошевелить мозгами.  Сумеешь ли ты добраться до финиша? Давай проверим. Что бы открыть первую дверь тебе необходимо найти 5 ключей (для просмотра собраных ключей жми кнопку 'I'.)";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Обьект игрока
    }

    void OnTriggerEnter(Collider col)
    {   
        //Показываем подсказку и выключаем блок курсора
        if (col.tag == player.tag)
        {
            if (MenuOpen == true)
            {
                triggered = true;
                Screen.lockCursor = false;
            }
        }
     }

    public void OnGUI()
    {
        if (triggered == true)
        {
            if (MenuOpen == true)
            {
                Rect rect = new Rect(Screen.width / 2f - menuSize.x / 2, Screen.height / 2f - menuSize.y / 2, menuSize.x, menuSize.y);

                GUILayout.BeginArea(rect, GUI.skin.textArea);
                {
                    // создаем стиль заголовка на основе стиля label стандартного скина
                    GUIStyle captionStyle = new GUIStyle(GUI.skin.label);
                   
                    captionStyle.padding = new RectOffset(20, 20, 35, 3);
                    // Рассположение текста по центру
                    captionStyle.alignment = TextAnchor.MiddleCenter;
                    
                    // текст заголовка (отрисовка)
                    if (tooltipNumber == 1)                  
                    {
                        captionStyle.fontSize = 20;
                        GUILayout.Label(LabelTextFirstTooltip, captionStyle);
                    }
                    else if (tooltipNumber == 2)
                    {
                        captionStyle.fontSize = 25;
                        GUILayout.Label(LabelTextSecondTooltip, captionStyle);
                    }

                    // создаем стиль кнопки на основе стиля button стандартного скина
                    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
                    buttonStyle.fontSize = 20;
                    // отступы кнопок от краев
                    buttonStyle.margin = new RectOffset(20, 20, 3, 3);
                    // FlexibleSpace - автоматически рассчитанное место, необходимое для
                    // заполнения пустого пространства между элементами управления
                    GUILayout.FlexibleSpace(); // динамическоем пространство между заголовком и кнопкой старт

                    if (GUILayout.Button(ButtonText, buttonStyle, GUILayout.MinHeight(buttonMinHeight)))
                    {
                        MenuOpen = false;
                        Screen.lockCursor = true;
                    }
                    GUILayout.FlexibleSpace(); // динамическоем пространство между кнопками
                }
                GUILayout.EndArea();
            }
        }
    }
}
