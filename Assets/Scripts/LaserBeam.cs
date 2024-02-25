using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserBeam
{

    Vector2 pos, dir;

    GameObject laserObj;
    LineRenderer laser;
    List<Vector2> laserIndices = new List<Vector2>();
    Ray2D ray;
    private int maxBounces = 10;
    private LayerMask layerMask;

    public LaserBeam(Vector2 pos, Vector2 dir, Material material, LayerMask laserMask)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.green;
        this.layerMask = laserMask;
            //LayerMask.GetMask("Default") | LayerMask.GetMask("DraggableObject") | LayerMask.GetMask("Player");


        CastRay(pos, dir, laser);
    }

    void CastRay(Vector2 pos, Vector2 dir, LineRenderer laser )
    {
        laserIndices.Add( pos );
        //Debug.Log(laserIndices.Count);
        ray = new Ray2D(pos, dir);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, 30, layerMask);

        if(Physics2D.Raycast(pos, dir, 30, layerMask))
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

        //string layerMaskName = layerMask.LayerToName(layerMask.value);
        //Debug.Log(layerMask.value);

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
            if (laserIndices.Count <= 50)   // As long as there are less than 50 lasers, a new laser is shot with the reflected angles.
            {
                CastRay(pos2 + (dir2 / 10), dir2, laser);
            } 
        }// end mirror

        if (hitinfo.collider.gameObject.tag == "Damagable" || hitinfo.collider.gameObject.tag == "LifeHeart")
        {
            hitinfo.collider.gameObject.TryGetComponent<Health>( out Health health);
            health.TakeDamage(1);
            laserIndices.Add(hitinfo.point);
            UpdateLaser();
        }
        if (hitinfo.collider.gameObject.tag == "Piercable") // Creates a new laser in the same direction after collision.
        {
            //CastRay(pos, dir, laser);
            
            //laserIndices.Add(ray.GetPoint(30));
            //UpdateLaser();
        }
        if (hitinfo.collider.gameObject.tag == "Receiver")
        {
            hitinfo.collider.gameObject.TryGetComponent<LaserReceiver>(out LaserReceiver receiver);
            receiver.SetItActive();
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
