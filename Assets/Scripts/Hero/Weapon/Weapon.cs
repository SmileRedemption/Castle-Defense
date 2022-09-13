using System;
using UnityEngine;


public class Weapon : ObjectsPool<Gunfire>
{
    [SerializeField] private Gunfire _gunfirePrefab;

    private void Start()
    {
        Initialize(_gunfirePrefab);
    }

    public void Shoot(Enemy enemyTarget)
    {
        if (TryGetObject(out Gunfire gunfire))
        {
            SetGunfire(gunfire, enemyTarget.transform);
        }
    }

    private void SetGunfire(Gunfire gunfire, Transform enemyPosition)
    {
        gunfire.SetActive(true);
        gunfire.Init(enemyPosition);
        gunfire.transform.position = GetPositionOfContainer();
    }

    
}