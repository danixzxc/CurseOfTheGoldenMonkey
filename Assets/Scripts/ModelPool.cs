using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;
public class ModelPool : MonoBehaviour
{
    [SerializeField] private GameObject _modelObject;
    public List<GameObject> pooledModels;
    public int amountToPool;
    public string modelName;

    void Start()
    {
        pooledModels = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(_modelObject);
            tmp.SetActive(false);
            pooledModels.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledModels)
        {
            if (obj.activeInHierarchy == false)
            {
                return obj;
            }
        }
        return null;
    }

    public void SetChildModel(GameObject obj)
    {
        if (obj.transform.childCount != 0)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
                obj.transform.GetChild(i).gameObject.SetActive(false);
                }
            obj.transform.DetachChildren();

        GameObject _itemModel = GetPooledObject();
        _itemModel.SetActive(true);
        _itemModel.transform.SetParent(obj.transform, false);
        _itemModel.transform.localPosition = Vector3.zero;
    }



}
