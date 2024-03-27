using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("WaitASecBeforeNextLevel");
    }

    private IEnumerator WaitASecBeforeNextLevel()
    {
        yield return new WaitForSeconds(2); // wait
        MapChecker.instance.NextLevel();    // goes to next level.
    }

}
