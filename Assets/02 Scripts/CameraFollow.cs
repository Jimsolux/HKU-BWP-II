using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float followSpeed;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void CameraFollows()
    {
        if (gameObject.transform.position != playerTransform.position)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, playerTransform.position, followSpeed);
            //Mathf.Lerp(gameObject.transform.position.x, playerTransform.position.x, followSpeed);
            //Mathf.Lerp(gameObject.transform.position.y, playerTransform.position.y, followSpeed);
        }
    }
}
