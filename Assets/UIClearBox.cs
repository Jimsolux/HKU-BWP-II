using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClearBox : MonoBehaviour
{
    private UIManager instance;


    private void OnTriggerEnter2D(Collider2D other)
    {
        UIManager.instance.EndDisplayExplanation();
    }
}
