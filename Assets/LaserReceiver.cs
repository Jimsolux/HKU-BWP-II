using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserReceiver : MonoBehaviour
{
    private Coroutine Delay;
    public bool beingHit = false;
    private float offDelay;
    public float receiverHealth = 100;

    public UnityEvent LaserHitEvent;

    private void Start()
    {
        offDelay = 0.1f;
    }

    private void FixedUpdate()
    {
    }

    private void Update()
    {
        

    if(beingHit)
        {
            Debug.Log("Im Being Hit!");
        }
        else
        {
            Debug.Log("I'm not being Hit xx");
        }
    if(beingHit && receiverHealth <= 0) { LaserHitEvent.Invoke(); }
    }

    public void TakeDamage(float amount)
    {
        if(beingHit)
        {
            receiverHealth -= amount;
        }
    }
    public void SetItActive()
    {
        beingHit = true;
        StartCoroutine(DelayRoutine());
    }

    public void SetItInactive()
    {
        beingHit= false;
    }

    IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(offDelay);
        SetItInactive();
    }
}
