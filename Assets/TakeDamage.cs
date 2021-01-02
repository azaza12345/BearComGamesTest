using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private float particleLifeTime;

    public void InstantiateParticle()
    {
        GameObject particle = Instantiate(this.particle, transform.position, Quaternion.identity);
        Destroy(particle, particleLifeTime);
    }
}
