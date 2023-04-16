using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectModifyUI : MonoBehaviour
{

    public enum ObjectModifyUIState { inspector, hierarchy }

    [SerializeField] private Button inspectorbtn;
    [SerializeField] private Button hierarchybtn;
    [SerializeField] private Button openbtn;
    [SerializeField] private Button closebtn;
    [SerializeField] private Image bg;
    [SerializeField] private ObjectModifyUIState state;
    [SerializeField] private bool isClose;

    private void Start()
    {
        isClose = true;
        state = ObjectModifyUIState.inspector;

        inspectorbtn.onClick.AddListener(() => state = ObjectModifyUIState.inspector);
        hierarchybtn.onClick.AddListener(() => state = ObjectModifyUIState.hierarchy);
        openbtn.onClick.AddListener(() => isClose = false);
        closebtn.onClick.AddListener(() => isClose = true);
    }

    private void Update()
    {
        if (state == ObjectModifyUIState.inspector)
        {
            inspectorbtn.image.color = new Color(1, 1, 1, 1);
            hierarchybtn.image.color = new Color(1, 1, 1, 0.8f);
            closebtn.image.color = new Color(1, 1, 1, 1);
        }

        if (state == ObjectModifyUIState.hierarchy)
        {
            inspectorbtn.image.color = new Color(1, 1, 1, 0.8f);
            hierarchybtn.image.color = new Color(1, 1, 1, 1);
            closebtn.image.color = new Color(1, 1, 1, 1);
        }

        if (isClose)
        {
            bg.gameObject.SetActive(false);
            inspectorbtn.gameObject.SetActive(false);
            hierarchybtn.gameObject.SetActive(false);
            closebtn.gameObject.SetActive(false);

            openbtn.gameObject.SetActive(true);
        }
        else
        {
            bg.gameObject.SetActive(true);
            inspectorbtn.gameObject.SetActive(true);
            hierarchybtn.gameObject.SetActive(true);
            closebtn.gameObject.SetActive(true);
            
            openbtn.gameObject.SetActive(false);
        }
    }
}
