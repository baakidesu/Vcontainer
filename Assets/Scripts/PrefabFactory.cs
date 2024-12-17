using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PrefabFactory : MonoBehaviour, IPrefabFactory
{
    [SerializeField] private GameObject donePrefab; 
    private IObjectResolver _objectResolver;

    [Inject]
    void Construct(IObjectResolver objectResolver)
    {
        _objectResolver = objectResolver;
        Debug.Log("adsfads");
    }
    public PrefabFactory(IObjectResolver objectResolver)
    {
        _objectResolver = objectResolver;
        Debug.Log("prefab factory");
    }

    public GameObject Create(Vector3 position, Quaternion rotation)
    {
        var instance = Object.Instantiate(donePrefab);
        _objectResolver.InjectGameObject(instance);
        return instance;
    }
        
}