using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    List<IDamagealbe> things = new List<IDamagealbe>();

    private void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagealbe damageable))
        {
            things.Add(damageable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IDamagealbe damageable))
        {
            things.Remove(damageable);
        }
    }
}
