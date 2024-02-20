using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    LaserBeam beam;
    [SerializeField] private LayerMask laserMask;

    private void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));

        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material, laserMask);

        
    }
}
