using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BadgerLoadAssetFromRemote : MonoBehaviour
{
    [SerializeField] private string _label;


    // Start is called before the first frame update
    void Start()
    {
        Get(_label);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private async void Get(string label)

    {

        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;


       



        foreach (var location in locations)
        {
            await Addressables.InstantiateAsync(location).Task;


        }
    }
}
