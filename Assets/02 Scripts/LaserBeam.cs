using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserBeam
{

    Vector2 pos, dir;

    public GameObject laserObj;
    LineRenderer laser;
    List<Vector2> laserIndices = new List<Vector2>();
    Ray2D ray;
    private int maxBounces = 50;
    private float laserDamage = 20f;
    private LayerMask layerMask;
    public LaserDestroySelf selfDestruct;

    public LaserBeam(Vector2 pos, Vector2 dir, Material material, LayerMask laserMask)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.selfDestruct = this.laserObj.AddComponent(typeof(LaserDestroySelf)) as LaserDestroySelf; 
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.green;
        this.layerMask = laserMask;
        this.laserObj.layer = 8;
        //LayerMask.GetMask("Default") | LayerMask.GetMask("DraggableObject") | LayerMask.GetMask("Player");
        //Debug.Log(LayerMask.NameToLayer("Laser"));

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector2 pos, Vector2 dir, LineRenderer laser )
    {
        
        laserIndices.Add( pos );

        ray = new Ray2D(pos, dir);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, 50, layerMask);

        if(Physics2D.Raycast(pos, dir, 50, layerMask))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }


    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach(Vector2 idx in laserIndices )
        {
            laser.SetPosition(count,idx);
            count++;
        }
    }


    void CheckHit(RaycastHit2D hitinfo, Vector2 direction, LineRenderer laser)
    {
        
        if (hitinfo.collider.gameObject.tag == "Mirror")
        {
            Vector2 pos2 = hitinfo.point;
            Vector2 dir2 = Vector2.Reflect(direction, hitinfo.normal);
            if (laserIndices.Count <= maxBounces)   // As long as there are less than 50 lasers, a new laser is shot with the reflected angles.
            {
                CastRay(pos2 + (dir2 / 10), dir2, laser);
            } 
        }// end mirror

        if (hitinfo.collider.gameObject.tag == "Damagable" || hitinfo.collider.gameObject.tag == "LifeHeart" || hitinfo.collider.gameObject.tag == "Player")
        {
            hitinfo.collider.gameObject.TryGetComponent<Health>( out Health health);
            health.TakeDamage(laserDamage);
            laserIndices.Add(hitinfo.point);
            UpdateLaser();
        }
        if (hitinfo.collider.gameObject.tag == "Receiver")
        {
            hitinfo.collider.gameObject.TryGetComponent<LaserReceiver>(out LaserReceiver receiver);
            //receiver.LaserHitEvent.Invoke();
            receiver.TakeDamage(laserDamage);
            receiver.SetItActive();
            laserIndices.Add(hitinfo.point);
            UpdateLaser();
            return;
        }
        if (hitinfo.collider.gameObject.tag == "MultiReceiver")
        {
            hitinfo.collider.gameObject.TryGetComponent<MultiReceiver>(out MultiReceiver receiver);
            //receiver.LaserHitEvent.Invoke();
            receiver.TakeDamage(laserDamage);
            receiver.AddToArrayLaser(laserObj);
            receiver.CheckLaserAmount();
            laserIndices.Add(hitinfo.point);
            UpdateLaser();
            return;
        }
        else
        {
            //hitinfo.collider.gameObject.TryGetComponent<LaserReceiver>(out LaserReceiver receiver);
            //receiver.IsBeingHit(false);
            laserIndices.Add(hitinfo.point);
            UpdateLaser();
        }
    }

}
