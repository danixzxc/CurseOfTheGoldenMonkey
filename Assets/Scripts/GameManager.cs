using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ObjectPool _pool;
    [SerializeField] private List<ModelPool> _modelPools;

    [SerializeField] private TextAsset _jsonFile;
    private Items _itemsInfo;
    private TimeManager _timeManager;
    // show time ended screen, connection to time (like healh) class
    
    private void Start()
    {
        _pool = FindObjectOfType<ObjectPool>();
        _itemsInfo = JsonUtility.FromJson<Items>(_jsonFile.text);
        _timeManager = FindObjectOfType<TimeManager>();
        _timeManager.ObjectSpawned += OnSpawnTimerEnd;
    }
    public void OnSpawnTimerEnd()
    {
        Item item = _pool.GetPooledObject();
        item.GetComponent<Collider2D>().enabled = true;
        int x, y;
        Rect viewport = new Rect(0, 0, 1, 1);
        Vector3[] corners = new Vector3[4];
        float depth = 10f;
        var camera = Camera.main;
        camera.CalculateFrustumCorners(viewport, depth, Camera.MonoOrStereoscopicEye.Mono, corners);
        bool spawnOnLeft = Random.value <= 0.5;
        if (item != null)
        {
            if(spawnOnLeft) 
                item.transform.position = new Vector3(Random.Range(-3.25f, -1.75f), Random.Range(-5.75f, -3f), 0);
            else
                item.transform.position = new Vector3(Random.Range(1.75f, 3.25f), Random.Range(-5.75f, -3f), 0);

            item.transform.rotation = new Quaternion(Random.Range(1, -1), Random.Range(1, -1), Random.Range(1, -1), 0);
            item.SetActive(true);
            item.itemInfo = _itemsInfo.items[_itemsInfo.GetRandomItemIndex()];
            foreach (ModelPool pool in _modelPools)
            {
                if (pool.modelName == item.itemInfo.type)
                    pool.SetChildModel(item.gameObject);
            }
            if(spawnOnLeft)
                item.Throw(Random.Range(3, 6), Random.Range(4, 11));
            else
                item.Throw(Random.Range(-6, -3), Random.Range(4, 11));
        }

    }
}
