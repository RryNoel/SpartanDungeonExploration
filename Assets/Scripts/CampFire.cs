using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    // 데미지를 받을 수 있는 객체 리스트
    List<IDamagealbe> things = new List<IDamagealbe>();

    private void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    // 리스트에 있는 모든 객체에 데미지를 주는 메서드
    void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            // 각 객체에 데미지 적용
            things[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 들어온 객체가 IDamageable 인터페이스를 구현하는지 확인
        if (other.TryGetComponent(out IDamagealbe damageable))
        {
            things.Add(damageable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 나가는 객체가 IDamageable 인터페이스를 구현하는지 확인
        if (other.TryGetComponent(out IDamagealbe damageable))
        {
            things.Remove(damageable);
        }
    }
}
