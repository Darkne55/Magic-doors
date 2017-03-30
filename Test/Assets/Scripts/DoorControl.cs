using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

    GameObject player;
    Animator animator;
    public Inventary inventary;
	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //Обьект игрока
	}
	
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == player.tag)
        {
            int count = inventary.list.Count;  // Получаем количество ключей из инвентаря

            if (count == 5) // Если собраны все - открываем дверь
            {           
                GetComponent<Animator>().enabled = true;
            }
        }
    }
}

