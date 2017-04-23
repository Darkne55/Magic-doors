using UnityEngine;
using System.Collections;

public class orangeKeyChest : MonoBehaviour {

    GameObject player;
    public Inventary inventary;
    public string titleKey;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Обьект игрока
    }

    void OnTriggerEnter(Collider col)
    {      
        if (col.tag == player.tag)
        {           
            int count = inventary.list.Count;
            for (int i = 0; i < count; i++)
            {
                
                if (inventary.list[i].sprite == titleKey)
                {                 
                    GetComponent<chestFirstControl>().enabled = true;
                    GetComponent<chestFirstControl>().OpenChestWithKey();                   
                }
            }           
        }
    }         
}
 
          