using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    private UIManager instance;
    [SerializeField] public int textIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
        UIManager.instance.DisplayExplanation(textIndex);
            
        }
    }


}
