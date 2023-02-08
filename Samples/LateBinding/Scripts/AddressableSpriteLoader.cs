using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Adressables and async operations namespaces
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// For sprite atlases
using UnityEngine.U2D;

public class AddressableSpriteLoader : MonoBehaviour
{
    // The fields if you want to use adresses
    public string newSpriteAddress;
    public bool useAddress;
    
    // Data fields
    public AssetReferenceSprite newSprite;
    private SpriteRenderer _spriteRenderer;
    private AsyncOperationHandle<Sprite> _spriteOperation;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (useAddress)
        {
            // Assets/LateBinding/Sprites/UnityGirl_Sprite.png[UnityGirl_Sprite]
            _spriteOperation = Addressables.LoadAssetAsync<Sprite>(newSpriteAddress);
            _spriteOperation.Completed += SpriteLoaded;
        }
        else
        {
            _spriteOperation = newSprite.LoadAssetAsync();
            _spriteOperation.Completed += SpriteLoaded;
        }
        // 
    }

    private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                _spriteRenderer.sprite = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.LogError("Sprite load failed.");
                break;
            default:
                // case Async None
                break;
        }
    }
    
    // On destroy operation
    private void OnDestroy()
    {
        if (_spriteOperation.IsValid())
        {
            Addressables.Release(_spriteOperation);
            Debug.Log("Sprite load operation.");
        }
    }
}
