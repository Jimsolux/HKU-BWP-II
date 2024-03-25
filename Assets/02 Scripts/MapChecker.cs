using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChecker : MonoBehaviour
{
    //[SerializeField] GameObject heart1;
    private bool isHeartDead = false;
    [SerializeField] GameObject wallObject1;
    Health hearthealth;

    private void Start()
    {
        //hearthealth = heart1.TryGetComponent<Health>();
        
    }
    
    
    private void Update()
    {
        //if (hearthealth.health <= 0)
        //{
        //    Wall1Off();
        //    Destroy(heart1);
        //}
        //Debug.Log(hearthealth.health);
    }

    public void Wall1Off()
    {
        wallObject1.SetActive(false);
    }


}
