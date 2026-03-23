using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText; // drag your TMP text here
    public int lives = 3;
    public RestartLevel restartLevelScript;

    public float immunityDuration = 1.5f; // Duration of invincibility
    private bool isInvincible = false;

    void Start()
    {
        UpdateLivesUI();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;
        lives -= damage;
        UpdateLivesUI();
        if(lives <= 0)
        {
            restartLevelScript.LoadSceneByIndex(2);
        }        
        else
        {
            
            StartCoroutine(BecomeTemporarilyInvincible());
        }
        
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }

        private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;
        
       

        // Wait for the specified duration
        yield return new WaitForSeconds(immunityDuration);



        isInvincible = false;
    }
}
