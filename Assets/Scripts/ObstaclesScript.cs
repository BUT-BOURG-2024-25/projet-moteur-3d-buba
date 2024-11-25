using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{ 
    public GameObject[] difficulties;
    public bool isDefault;
    // Start is called before the first frame update
    void Start()
    {
        if(!isDefault)
        {
            int random_value = Random.Range(0, difficulties.Length);
            difficulties[random_value].gameObject.SetActive(true);
        }
    }
}
