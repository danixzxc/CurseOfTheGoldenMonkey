using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;
using static UnityEngine.GridBrushBase;
using static UnityEditor.Progress;
public class ObjectPool : MonoBehaviour
{
    public List<Item> pooledItems;
    private GameObject itemToPool;
    private Rigidbody2D _rigidbody2d;
    private UIController _uiController;
    private TextAnimationController _textAnimationController;
    public int amountToPool;
    void Start()
    {
        _uiController = FindObjectOfType<UIController>();
        _textAnimationController = FindObjectOfType<TextAnimationController>();
        CreateItemToPull();
        pooledItems = new List<Item>();
        Item tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(itemToPool).GetComponent<Item>();
            tmp.OnItemClicked += _uiController.IncreaseScore;
            tmp.OnItemClicked += _textAnimationController.IncreaseScore;
            tmp.SetActive(false);
            itemToPool.GetComponent<CircleCollider2D>().radius = 0.5f;
            _rigidbody2d = itemToPool.GetComponent<Rigidbody2D>();
            _rigidbody2d.mass = 5.0f;
            pooledItems.Add(tmp);

        }
    }

    private void CreateItemToPull()
    {
        itemToPool = new GameObject();
        itemToPool.AddComponent<CircleCollider2D>();
        itemToPool.AddComponent<Item>();
        itemToPool.AddComponent<Rigidbody2D>();
    }

    public Item GetPooledObject()
    {
        foreach (Item item in pooledItems)
        {
            if (!item.isActiveAndEnabled)
            {
                return item;
            }
        }
        return null;
    }
  
}
