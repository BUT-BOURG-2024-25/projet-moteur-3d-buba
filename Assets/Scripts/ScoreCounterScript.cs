using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounterScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI total_coins_text;
    [SerializeField] TextMeshProUGUI total_distance_text;

    [SerializeField] Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        total_coins_text.text = PlayerPrefs.GetInt("total_coins", 0).ToString("0");
        total_distance_text.text = Player.transform.position.z.ToString("00.0") + "m";

        if(Player.transform.position.z >= PlayerPrefs.GetFloat("high_score", 0f))
        {
            PlayerPrefs.SetFloat("high_score", Player.transform.position.z);
        }
    }
}
