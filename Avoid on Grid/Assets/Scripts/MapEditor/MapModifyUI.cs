using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapModifyUI : MonoBehaviour
{
    public enum MapModifyUIState { obj, timeline }

    [SerializeField] private Button objbtn;
    [SerializeField] private Button timelimebtn;
    [SerializeField] private Button openbtn;
    [SerializeField] private Button closebtn;
    [SerializeField] private Image bg;
    [SerializeField] private MapModifyUIState state;
    [SerializeField] private bool isClose;

    private void Start()
    {
        isClose = true;
        state = MapModifyUIState.obj;

        objbtn.onClick.AddListener(() => state = MapModifyUIState.obj);
        timelimebtn.onClick.AddListener(() => state = MapModifyUIState.timeline);
        openbtn.onClick.AddListener(() => isClose = false);
        closebtn.onClick.AddListener(() => isClose = true);
    }

    private void Update()
    {
        if (state == MapModifyUIState.obj)
        {
            objbtn.image.color = new Color(1, 1, 1, 1);
            timelimebtn.image.color = new Color(1, 1, 1, 0.8f);
            closebtn.image.color = new Color(1, 1, 1, 1);
        }

        if (state == MapModifyUIState.timeline)
        {
            objbtn.image.color = new Color(1, 1, 1, 0.8f);
            timelimebtn.image.color = new Color(1, 1, 1, 1);
            closebtn.image.color = new Color(1, 1, 1, 1);
        }

        if (isClose)
        {
            bg.gameObject.SetActive(false);
            objbtn.gameObject.SetActive(false);
            timelimebtn.gameObject.SetActive(false);
            closebtn.gameObject.SetActive(false);

            openbtn.gameObject.SetActive(true);
        }
        else
        {
            bg.gameObject.SetActive(true);
            objbtn.gameObject.SetActive(true);
            timelimebtn.gameObject.SetActive(true);
            closebtn.gameObject.SetActive(true);
            
            openbtn.gameObject.SetActive(false);
        }
    }
}
