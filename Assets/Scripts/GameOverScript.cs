using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI best_score_text;

    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = Player.transform.position.z.ToString("0.00") + "m";
        best_score_text.text = PlayerPrefs.GetFloat("high_score", 0).ToString("0.00") + "m";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
