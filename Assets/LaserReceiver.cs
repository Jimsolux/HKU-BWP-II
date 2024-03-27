using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserReceiver : MonoBehaviour
{
    private Coroutine Delay;
    public bool beingHit = false;
    private float offDelay = 0.1f;
    public float receiverHealth = 100;
    private SpriteRenderer sprite;

    public UnityEvent LaserHitEvent;

    //Audio
    [SerializeField] private AudioSource bloopOn;
    private bool turntOn = false;

    [SerializeField] private Sprite spriteOff;
    [SerializeField] private Sprite spriteOn;

    private void Start()
    {
        bloopOn = gameObject.GetComponent<AudioSource>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = spriteOff;
    }

    private void FixedUpdate()
    {
        if (receiverHealth < 0)
        if (receiverHealth < 0 && turntOn == false)
        {
            bloopOn.Play(); Debug.Log("Play Bloop");
            SwitchSpriteState();
            turntOn = true;
        }
    }

    private void Update()
    {
        

    if(beingHit)
        {
            //Debug.Log("Im Being Hit!");
        }
        else
        {
            //Debug.Log("I'm not being Hit xx");
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

    void SwitchSpriteState()
    {
        sprite.sprite = spriteOn;
    }
}
