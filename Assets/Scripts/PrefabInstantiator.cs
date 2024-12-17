using UnityEngine;
using VContainer;

public class PrefabInstantiator : MonoBehaviour
{
    private IPrefabFactory _prefabFactory;

    [Inject]
    public void Construct(IPrefabFactory prefabFactory)
    {
        _prefabFactory = prefabFactory;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiatePrefab();
        }
    }

    private void InstantiatePrefab()
    {
        var position = Vector3.zero;
        var rotation = Quaternion.identity;
        var instance = _prefabFactory.Create(position, rotation);
        
    }
}