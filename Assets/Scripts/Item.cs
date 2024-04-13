using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

[Serializable]
public class Item : MonoBehaviour
{
    public ItemInfo itemInfo;
    private Camera _camera = Camera.main;

    public event Action<Item> OnItemClicked;
    public void OnClick()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
        OnItemClicked?.Invoke(this);
    }
    private void Update()
    {
       if (Camera.main)
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
            if (!(viewPos.x >= -0.1 && viewPos.x <= 1.1 && viewPos.y >= -0.1 && viewPos.y <= 1.1 && viewPos.z > 0 ))
                gameObject.SetActive(false);
        }
    }


    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void Throw(float d, float h) {
        float g = - Physics2D.gravity.y;
        float t = Mathf.Sqrt(2.0f * h / g);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(d / (2.0f * t), t * g);
    }
}
 