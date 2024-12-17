using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class BasicPool : MonoBehaviour
{
    #region [Injections]

    private IPoolFactory _poolFactory;

    [Inject]
    void Construct(IPoolFactory poolFactory)
    {
        _poolFactory = poolFactory;
    }
    #endregion

    #region Public
    public PoolsEnum poolsEnum;
    #endregion

    #region Private
    private float spawnInterval = 0.1f;
    private float verticalOffset = 0.5f;
    private float timer = 0f;
    #endregion

    private void Start()
    {
        SpawnPool();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPool();
            timer = 0f;
        }
    }
    void SpawnPool()
    {
        Debug.Log("basicpool metoda girdi");
        GameObject poolObject = _poolFactory.Spawn_Object(poolsEnum, new Vector3(3.5f, verticalOffset, 0f), Quaternion.identity);
        verticalOffset += 1f;
    }

    // LeanPool.Despawn(poolObject); 
}