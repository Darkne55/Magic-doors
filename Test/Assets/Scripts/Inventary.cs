using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventary : MonoBehaviour {

    List<Item> list;
    public GameObject inventary;
    public GameObject containerImageCell;

    
	// Use this for initialization
	void Start () {
	    list = new List<Item>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Построить луч из текущих координат мыши
            RaycastHit hit;  //В результате столкновения с коллайдером, возвращается RaycastHit с координатами и объектом столкновения.
            if (Physics.Raycast(ray, out hit))   //Рейкаст отправляет воображаемый “лазерный луч”
            {
                Item item = hit.collider.GetComponent<Item>();
                if(item != null)
                {
                    list.Add(item);
                    Destroy(hit.collider.gameObject);
                }

            }   
        }

        if(Input.GetKey(KeyCode.I))
        {
            if(inventary.activeSelf)
            {
                inventary.SetActive(false);

                //очищаем ячейки
                for (int i = 0; i < inventary.transform.childCount; i++)  //цикл по количеству занятых ячеек
                {
                   if(inventary.transform.GetChild(i).transform.childCount > 0)
                   {
                       Destroy(inventary.transform.GetChild(i).transform.GetChild(0).gameObject);
                   }
                }
            }

            else
            {
                inventary.SetActive(true);

                int count = list.Count;

                for(int i = 0; i < count; i++)
                {
                    Item it = list[i];  //получаем список инвентаря 
                    if(inventary.transform.childCount >= i) // если еще есть свободные ячейки
                    {
                        GameObject img = Instantiate(containerImageCell);  // создаем обьект картинку
                        img.transform.SetParent(inventary.transform.GetChild(i).transform);  // делаем картинку дочерним элементом инвентаря
                        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite); //загружаем картинку
                        img.AddComponent<Button>().onClick.AddListener(() => remove(it, img));     //по клику удаляем предмет с инвентаря
                    }
                    else break;  //если ячейки заняты выходим из цикла 
                }
            }
        }
	}

    void remove(Item it, GameObject obj)
    {
        // удаление предмета с инвентаря
        GameObject nemo = Instantiate<GameObject>(Resources.Load<GameObject>(it.prefab));       
        Destroy(obj);
        list.Remove(it);
    }
}
