using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    PlayerScript playerScript;
    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (playerScript != null)
        {
            scoreText.text = "Crystals Shattered: " + playerScript.crystalCount;
        }
    }
}