using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class FreelookCamControl : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Image LookPanel;
    [SerializeField] CinemachineFreeLook camFreeLook;
    string strMouseX = "Mouse X", strMouseY = "Mouse Y";

    // Start is called before the first frame update
    void Start()
    {
        LookPanel = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            LookPanel.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 posOut))
        {
            //Debug.Log(posOut);
            camFreeLook.m_XAxis.m_InputAxisName = strMouseX;
            camFreeLook.m_YAxis.m_InputAxisName = strMouseY;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        camFreeLook.m_XAxis.m_InputAxisName = null;
        camFreeLook.m_YAxis.m_InputAxisName = null;
        camFreeLook.m_XAxis.m_InputAxisValue = 0;
        camFreeLook.m_YAxis.m_InputAxisValue = 0;

    }
}
