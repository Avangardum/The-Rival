using System.Linq;
using UnityEngine;

public class PrefabStorage : SingletonMonoBehaviour<PrefabStorage>
{
    [SerializeField] private PrefabStoragePair[] pairs;

    public GameObject GetPrefab(string name) => pairs.Single(x => x.Name == name).Prefab;
}
