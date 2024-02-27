using UnityEngine;
using System.Collections.Generic;


public class ShootLaser : MonoBehaviour
{
    public Material material;
    LaserBeam beam;
    [SerializeField] private LayerMask laserMask;
    List<LaserBeam> Laserbeams = new();

    private void Awake()
    {
        
    }

    private void Update()
    {
        foreach (LaserBeam laser in Laserbeams)
        {
            Destroy(laser.laserObj);
        }

        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material, laserMask);
        Laserbeams.Add(beam);
    }
}
