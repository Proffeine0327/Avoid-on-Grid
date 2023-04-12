using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorManager : MonoBehaviour
{
    public static MapEditorManager manager { get; private set; }

    public bool isGrid;
    public GameObject spawnPrefeb;
    public GameObject previewObject;

    public void ChangeSpawnPrefeb(GameObject prefeb = null)
    {
        if(previewObject != null) Destroy(previewObject);
        if(prefeb != null)
        {
            spawnPrefeb = prefeb;
            previewObject = Instantiate(spawnPrefeb, MapEditorCamera.manager.WorldMousePosition, Quaternion.identity);
        }
    }

    private void Awake()
    {
        manager = this;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.G)) isGrid = !isGrid;

        PreviewObjectControl();
    }

    private void PreviewObjectControl()
    {
        if(previewObject == null) return;

        if(isGrid)
        {
            var pos = MapEditorCamera.manager.WorldMousePosition;
            previewObject.transform.position = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
        }
        else
        {
            previewObject.transform.position = (Vector2)MapEditorCamera.manager.WorldMousePosition;
        }
    }
}
