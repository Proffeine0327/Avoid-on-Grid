using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPrefebChangeButton : MonoBehaviour
{
    [SerializeField] private GameObject prefeb;
    private Button btn;

    private void Awake() 
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => MapEditorManager.manager.ChangeSpawnPrefeb(prefeb));
    }
}
