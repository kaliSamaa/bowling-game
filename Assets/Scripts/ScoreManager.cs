using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private GameObject[] pins;
    public TextMeshProUGUI scoreTextTMP; 

    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        UpdateScoreText(); 
    }

    void Update()
    {
        score = 0;
        foreach (GameObject pin in pins)
        {
            if (IsPinKnockedDown(pin))
            {
                score++;
            }
        }
        UpdateScoreText(); 
    }

    private bool IsPinKnockedDown(GameObject pin)
    {
        return Vector3.Angle(pin.transform.up, Vector3.up) > 10;
    }

    

    private void UpdateScoreText()
    {
        scoreTextTMP.text = "Score: " + score;
    }
}
