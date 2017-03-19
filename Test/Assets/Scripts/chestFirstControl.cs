using UnityEngine;
using System.Collections;

public class chestFirstControl : MonoBehaviour {

    public bool open = false;
    GameObject player;

	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //Обьект игрока
	}

    void OnTriggerEnter (Collider col)
    {    
        //Если игрок подошел к сундуку - открыть сундук
        if (col.tag == player.tag)
        {
            if ( open == false)
           {
                Debug.Log("Player triggered");
                gameObject.GetComponent<Animation>().Play("ChestOpen");
                open = true;
            }
            
        }
    }

    void OnTriggerExit (Collider col)
    {
        //Если игрок отошел от сундука - закрыть сундук
        if (col.tag == player.tag)
        {
            if (open == true)
            {
                Debug.Log("Player triggered");
                gameObject.GetComponent<Animation>().Play("ChestClose");
                open = false;
            }

        }
    }	
}
