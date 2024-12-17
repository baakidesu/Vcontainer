using UnityEngine;

public interface IPoolFactory
{
    GameObject Spawn_Object(PoolsEnum pool, Transform parent, Vector3 _localPosition, Quaternion _localRotation, bool isWorldPos = false, float _despwanTime = 0);
    GameObject Spawn_Object(PoolsEnum pool, Transform parent, bool isWorldPos = false, float _despwanTime = 0);
    GameObject Spawn_Object(PoolsEnum pool, Vector3 _position, Quaternion _rotation, float _despwanTime = 0);
}