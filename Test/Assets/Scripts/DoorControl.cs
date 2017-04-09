﻿using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

    GameObject player;
    Animator animator;
    public Inventary inventary;

    private bool timerOn;      // флаг таймера
    private float curr_time;    // время работы таймера  (в кадрах)
	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //Обьект игрока
        timerOn = false;
        curr_time = 300;   // количество кадров
	}
	
	
	void Update () {
	    if(timerOn == true)  // отстчет
        {
            curr_time -= 0.5f;
            Debug.Log(curr_time);

            if (curr_time <= 0)   // истекло время - загружаем второй уровень
            {
                Application.LoadLevel("second");
                timerOn = false;  
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == player.tag)
        {
            int count = inventary.list.Count;  // Получаем количество ключей из инвентаря

            if (count == 0) // Если собраны все - открываем дверь
            {           
                GetComponent<Animator>().enabled = true;
                timerOn = true;   // включаем таймер параллельно анимации
            }
        }
    }
}

