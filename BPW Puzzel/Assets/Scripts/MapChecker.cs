using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChecker : MonoBehaviour
{
    [SerializeField] GameObject heart1;
    private bool isHeartDead = false;
    [SerializeField] GameObject wallObject1;
    Health hearthealth;

    private void Start()
    {
        hearthealth = heart1.GetComponent<Health>();
        
    }
    
    
    private void Update()
    {
        if (hearthealth.health <= 0)
        {
            Wall1Off();
            Destroy(heart1);
        }
    }

    public void Wall1Off()
    {
        wallObject1.SetActive(false);
    }


}
