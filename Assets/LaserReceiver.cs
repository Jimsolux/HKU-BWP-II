using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    private Coroutine karmaDelay;
    public bool beingHit = false;
    private float offDelay;

    private void Start()
    {
        offDelay = 0.1f;
    }

    private void FixedUpdate()
    {
        //IsBeingHit(false);
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

    }
    //public bool IsBeingHit(bool hitinfo)
    //{
    //    bool currentlyHit;
    //    if (hitinfo) { beingHit = true; } else { beingHit = false; }
    //    hitinfo = false;

    //    //beingHit = currentlyHit;
    //    return currentlyHit;
    //}

    public void SetItActive()
    {
        beingHit = true;
        StartCoroutine(KarmaDelayRoutine());
    }

    public void SetItInactive()
    {
        beingHit= false;
    }

    IEnumerator KarmaDelayRoutine()
    {
        yield return new WaitForSeconds(offDelay);
        SetItInactive();
    }
}
