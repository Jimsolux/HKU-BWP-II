using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapChecker : MonoBehaviour
{

    public static MapChecker instance;
    public GameObject player;
    private Health playerHealth;
    private PlayerController playerController;
    private GameObject currentLevelRespawnPoint;

    [SerializeField] GameObject Level1;
    [SerializeField] GameObject Level2;
    [SerializeField] GameObject Level3;

    public enum Levels
    {
        Level1,
        Level2,
        Level3,
    }
    public Levels currentLevelEnum;
    public GameObject currentLevel;

    private void Start()
    {
        instance = this;
        //Playerreferences
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerHealth = player.GetComponent<Health>();
        //Initialize level 1.
        currentLevelEnum = Levels.Level1;
        currentLevel = DecideActiveLevelObjects();  // Decides the current level GameObjects.
        Level1.SetActive(true);
        Level2.SetActive(false);

    }
    
    private GameObject DecideActiveLevelObjects()
    {
        switch(currentLevelEnum)
        {
            case Levels.Level1:
                currentLevel = Level1;
                break;
            case Levels.Level2:
                currentLevel = Level2;
                break;
            case Levels.Level3:
                currentLevel = Level3;
                break;
        }
        return currentLevel;
    }
    public void NextLevel()
    {
        currentLevel = DecideActiveLevelObjects();  // Decides the current level GameObjects.
        switch (currentLevelEnum)
        {
            case Levels.Level1:
                Level1.SetActive(false);
                Level2.SetActive(true);
                currentLevelEnum = Levels.Level2;   // Now in level 2
                break;
            case Levels.Level2:
                Level2.SetActive(false);
                Level3.SetActive(true);
                currentLevelEnum = Levels.Level3;   // Now in level 3
                break;
            case Levels.Level3:
                // End game? 
                break;
        }

        currentLevelRespawnPoint = GameObject.FindGameObjectWithTag("CheckPoint1"); // After levelObject is initialized, find checkpoint.

        playerController.UpdateCheckPoint(currentLevelRespawnPoint.transform);  // Sets the new Spawnpoint after nextlevel.
        //Fake death, teleport to next startpoint.
        playerController.rb2d.velocity = Vector3.zero;
        player.transform.position = currentLevelRespawnPoint.transform.position;    // Sets the player to the new spawnpoint.
        playerHealth.ResetHealth();
    }


}
