using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorManager : MonoBehaviour, ISerializationCallbackReceiver
{
    public static MapEditorManager manager { get; private set; }

    [SerializeField] private GameObject mapEditorObjectDetectCollider;
    [SerializeField] private List<int> mapObjectKey = new List<int>();
    [SerializeField] private List<MapObjectInfo> mapObjectValue = new List<MapObjectInfo>();
    [SerializeField] private int currentMapObjectId;
    [SerializeField] private List<int> removedMapObjectId = new List<int>();

    private Dictionary<int, MapObjectInfo> mapObjects = new Dictionary<int, MapObjectInfo>();
    private GameObject spawnPrefeb;
    private GameObject previewObject;

    public Dictionary<int, MapObjectInfo> MapObjects { get { return mapObjects; } }

    public void ChangeSpawnPrefeb(GameObject prefeb = null)
    {
        if (previewObject != null) Destroy(previewObject);
        if (prefeb != null)
        {
            spawnPrefeb = prefeb;
            previewObject = Instantiate(spawnPrefeb, MapEditorCamera.manager.WorldMousePosition, Quaternion.identity);
            previewObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    public void OnBeforeSerialize()
    {
        mapObjectKey.Clear();
        mapObjectValue.Clear();

        foreach(var kvp in mapObjects)
        {
            mapObjectKey.Add(kvp.Key);
            mapObjectValue.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        mapObjects = new Dictionary<int, MapObjectInfo>();

        for(int i = 0; i < Mathf.Min(mapObjectKey.Count, mapObjectValue.Count); i++)
            mapObjects.Add(mapObjectKey[i], mapObjectValue[i]);
    }

    private void Awake()
    {
        manager = this;
    }

    private void Update()
    {
        PreviewObjectControl();
        ObjectSpawn();
    }

    private void PreviewObjectControl()
    {
        if (previewObject == null) return;

        var pos = MapEditorCamera.manager.WorldMousePosition;
        previewObject.transform.position = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
    }

    private void ObjectSpawn()
    {
        if (spawnPrefeb != null)
        {
            if (Input.GetMouseButton(0))
            {
                var pos = MapEditorCamera.manager.WorldMousePosition;
                var spawnpos = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
                if(!Physics2D.OverlapBox(spawnpos, new Vector2(0.99f, 0.99f), 0, LayerMask.GetMask("MapEditorObjectDetectCollider")))
                {
                    var newobj = Instantiate(spawnPrefeb, spawnpos, Quaternion.identity);
                    Instantiate(mapEditorObjectDetectCollider, newobj.transform).transform.position = spawnpos;
                    
                    var comp = newobj.GetComponent<MapObject>();
                    comp.Info.id = currentMapObjectId;
                    mapObjects.Add(currentMapObjectId, comp.Info);
                    currentMapObjectId++;
                }
            }
        }
    }
}
