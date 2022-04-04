using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class CreateAddressableLoader
{
    // Start is called before the first frame update
  public static async Task InitAsset<T>(string assetLabel,List<T> createOBJs)

        where T : Object

    {
        var locations = await Addressables.LoadResourceLocationsAsync(assetLabel).Task;

        foreach (var location in locations)
            createOBJs.Add(await Addressables.InstantiateAsync(location).Task as T);
    }


}
