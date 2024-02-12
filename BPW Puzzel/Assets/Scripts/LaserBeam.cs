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

    public LaserBeam(Vector2 pos, Vector2 dir, Material material)
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

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector2 pos, Vector2 dir, LineRenderer laser )
    {
        laserIndices.Add( pos );
        Debug.Log(laserIndices.Count);
        ray = new Ray2D(pos, dir);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, 30, 1);

        if(Physics2D.Raycast(pos, dir, 30, 1))
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
            if (laserIndices.Count <= 50)   // As long as there are less than 50 lasers, a new laser is shot with the reflected angles.
            {
                CastRay(pos2 + (dir2 / 10), dir2, laser);
            } 
        }// end mirror

        if (hitinfo.collider.gameObject.tag == "Damagable")
        {
            hitinfo.collider.gameObject.TryGetComponent<Health>( out Health health);
            health.TakeDamage(1);
            laserIndices.Add(hitinfo.point);
            UpdateLaser();
        }
        else
        {   
            laserIndices.Add(hitinfo.point);
            UpdateLaser();
        }
    }

}
