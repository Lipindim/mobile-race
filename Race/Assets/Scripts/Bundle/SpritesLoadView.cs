using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class SpritesLoadView : MonoBehaviour
{
    [SerializeField]
    private DataSpriteReference[] _dataSpriteReferences;
    private DateTime startTime;
    private int countCompleted;

    private void Start()
    {
        startTime = DateTime.UtcNow;
        foreach (var item in _dataSpriteReferences)
            LoadSprite(item.AssetReference, item.Image);
    }

    private void LoadSprite(AssetReference spriteReference, Image image)
    {
        var spriteHandle = Addressables.LoadAssetAsync<Sprite>(spriteReference);
        spriteHandle.Completed += (o) => OnCompleted(o, image);
    }

    private void OnCompleted(AsyncOperationHandle<Sprite> obj, Image image)
    {
        countCompleted++;
        if (countCompleted == 2)
        {
            var interval = DateTime.UtcNow - startTime;
            Debug.Log(interval.TotalMilliseconds);
        }
        var sprite = obj.Result;
        image.sprite = sprite;
    }
}
