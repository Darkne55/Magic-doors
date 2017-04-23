using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour {

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
