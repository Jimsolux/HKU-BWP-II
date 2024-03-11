using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointUpdater : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            collision.gameObject.TryGetComponent<PlayerController>(out PlayerController controller);
            controller.UpdateCheckPoint(gameObject.transform);
        }
    }
}
