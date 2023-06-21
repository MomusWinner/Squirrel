using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleManager : MonoBehaviour
{
    [SerializeField] private Transform wallContactPoint;
    [SerializeField] private Transform branchContactPoint;

    [SerializeField] private GameObject wallContactPs;
    [SerializeField] private GameObject branchContactPointPs;

    private string wallTag = "Wall";
    [SerializeField] private LayerMask branchLayer;
    private string branchTag = "Branch";


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == wallTag)
            Instantiate(wallContactPs, wallContactPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == branchTag)
            Instantiate(branchContactPointPs, branchContactPoint.position, Quaternion.identity);
    }
}
