using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;


public class CreatedAssets : MonoBehaviour
{


    [SerializeField] private string _label;

    [SerializeField] private string _assetName;

    [SerializeField] private Vector3 origin;


    private List<GameObject> Assets { get; } = new List<GameObject>();



    private async Task CreateAndWaitUntilComplete()
    {
        await CreateAddressableLoader.InitAsset(_label, Assets);
        await CreateAddressableLoader.InitAsset(_assetName, Assets);


        foreach (var asset in Assets)

        {
            asset.transform.position = origin;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
