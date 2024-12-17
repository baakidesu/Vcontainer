using UnityEngine;

public interface IPrefabFactory
{
    GameObject Create(Vector3 position, Quaternion rotation);
}

