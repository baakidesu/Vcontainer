using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  VContainer;
using  VContainer.Unity;

public class script : MonoBehaviour
{
   private PrefabFactory _factory;
   
   [Inject]
   void Construct(PrefabFactory prefabFactory)
   {
      _factory = prefabFactory;
      Debug.Log("debug");
   }
}
