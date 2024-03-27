using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiReceiver : MonoBehaviour
{
    private Coroutine Delay;
    public bool beingHit = false;
    private float offDelay = 0.1f;
    public float receiverHealth = 100;
    private SpriteRenderer sprite;

    public UnityEvent LaserHitEvent;

    public static List<GameObject> lasersThatAreHittingMe; 

    //Audio
    [SerializeField] private AudioSource bloopOn;
    private bool turntOn = false;

    [SerializeField] private Sprite spriteOff;
    [SerializeField] private Sprite spriteOn;

    private void Start()
    {
        lasersThatAreHittingMe = new List<GameObject>();

        bloopOn = gameObject.GetComponent<AudioSource>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = spriteOff;
    }

    private void FixedUpdate()
    {
            if (receiverHealth < 0 && !turntOn)
            {
                bloopOn.Play(); Debug.Log("Play Bloop");
                SwitchSpriteState();
                turntOn = true;
            }
    }

    private void Update()
    {
        CheckLaserAmount();
        lasersThatAreHittingMe.Clear();

        if (beingHit)
        {
            //Debug.Log("Im Being Hit!");
        }
        else
        {
            //Debug.Log("I'm not being Hit xx");
        }
        if (beingHit && receiverHealth <= 0) { LaserHitEvent.Invoke(); }


    }

    public void TakeDamage(float amount)
    {
        if (beingHit)
        {
            receiverHealth -= amount;
        }
    }

    public void AddToArrayLaser(GameObject toAdd)
    {
        if (lasersThatAreHittingMe.Count == 0)
        {
            lasersThatAreHittingMe.Add(toAdd);
            Debug.Log("added" + toAdd.GetInstanceID());
        }

        if (lasersThatAreHittingMe.Count >= 1)
        {
            if (lasersThatAreHittingMe[0] != toAdd)
            {
                lasersThatAreHittingMe.Add(toAdd);
                Debug.Log("added" +  toAdd.GetInstanceID());
            }
            else { Debug.Log("found existing ray."); }
        }

    }

    public  void CheckLaserAmount()
    {
        if (lasersThatAreHittingMe.Count >= 2) LaserHitEvent.Invoke();
        else { StartCoroutine("EmptyArrayRoutine"); }
    }



    IEnumerator EmptyArrayRoutine()
    {
        yield return new WaitForSeconds(offDelay);
        lasersThatAreHittingMe.Clear();
    }

    void SwitchSpriteState()
    {
        sprite.sprite = spriteOn;
    }
}
