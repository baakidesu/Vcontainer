using System.Linq;
using Lean.Pool;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PoolFactory : MonoBehaviour, IPoolFactory
{
    [Inject]private IObjectResolver _objectResolver;
    
    public Items[] items;
    
    #region Spawn Object
    public GameObject Spawn_Object(PoolsEnum pool, Transform parent, Vector3 _localPosition, Quaternion _localRotation, bool isWorldPos = false, float _despwanTime = 0)
    {
        GameObject spawnedObject = SelectSpawnObject(pool);
        if (spawnedObject == null)
        {
            Debug.Log("Prefab null");
            return null;
        }

        GameObject gm = LeanPool.Spawn(spawnedObject, parent, isWorldPos);
        gm.transform.localPosition = _localPosition;
        gm.transform.localRotation = _localRotation;
        InjectDependencies(gm);
        
        DespawnObject(gm,_despwanTime);

        return gm;
    }
    public GameObject Spawn_Object(PoolsEnum pool, Transform parent, bool isWorldPos = false, float _despwanTime = 0)
    {
        GameObject spawnedObject = SelectSpawnObject(pool);
        if (spawnedObject == null)
        {
            Debug.Log("Prefab null");
            return null;
        }

        GameObject gm = LeanPool.Spawn(spawnedObject, parent, isWorldPos);
        InjectDependencies(gm);
        
        DespawnObject(gm,_despwanTime);

        return gm;
    }

    public GameObject Spawn_Object(PoolsEnum pool, Vector3 _position, Quaternion _rotation, float _despwanTime = 0)
    {
        Debug.Log("poolfactory metoda girdi");
        GameObject spawnedObject = SelectSpawnObject(pool);
        if (spawnedObject == null)
        {
            Debug.Log("Prefab null");
            return null;
        }

        GameObject gm = LeanPool.Spawn(spawnedObject, _position, _rotation);
        InjectDependencies(gm);
       
        DespawnObject(gm,_despwanTime);
        return gm;
    }

    void InjectDependencies(GameObject go)
    {
        _objectResolver.InjectGameObject(go);
    }

    void DespawnObject(GameObject _gameObject,float _despwanTime)
    {
        if (_despwanTime != 0)
            LeanPool.Despawn(_gameObject, _despwanTime);
    }
    
    GameObject SelectSpawnObject(PoolsEnum pool)
    {
        var obj = items.FirstOrDefault(x => x.Name == pool);
        if (obj != null)
            return obj.SpawnObject.Prefab;
        return null;
    }

    #endregion
}

[System.Serializable]
public class Items
{
    public PoolsEnum Name;
    public LeanGameObjectPool SpawnObject;
}

public enum PoolsEnum
{
    Ornek1,
    Ornek2
}