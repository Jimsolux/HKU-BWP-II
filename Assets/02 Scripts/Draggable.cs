using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Draggable : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 mousePositionOffset;
    private Vector3 targetPosition;
    [SerializeField] private float pullForceStart = 15f;
    [SerializeField] private float pullForce;
    private bool isDraggable = true;
    private bool isDragging = false;


    private void Start()
    {
        pullForce = pullForceStart;
        rb = GetComponent<Rigidbody2D>();
    }


    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void FixedUpdate()
    {
        if (isDragging)
        { //Rotatie
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(0, 0, 1), 0.5f);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(new Vector3(0, 0, -1), 0.5f);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                transform.Rotate(new Vector3(0, 0, 1), 2f);
            }
            if (Input.GetKey(KeyCode.C))
            {
                transform.Rotate(new Vector3(0, 0, -1), 2f);
            }

        }
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();  //MousePos + offset where you grab item.
    }


    private void OnMouseDrag()
    {
        targetPosition = GetMouseWorldPosition() + mousePositionOffset; // Target is mouse pos - offset
        if (isDraggable == true)   // If draggable, 
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, pullForce * Time.deltaTime) ); // ;    // Move towards mouse with pullforce.
            rb.gravityScale = 0;
            rb.freezeRotation = true;

            isDragging = true;
            

        }
    }
    

    private void OnMouseUp()    // releasing mouse re enables the grabbing and gravity.
    {
        rb.gravityScale = .5f;
        isDraggable = true;
        rb.freezeRotation = false;
        isDragging = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    { // Check collision, if you are allowed to move.
        if(collision.gameObject.CompareTag("Map"))
        {
            //isDraggable = false;
        }
    }
}
