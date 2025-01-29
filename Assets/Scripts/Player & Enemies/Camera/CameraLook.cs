using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MobileCameraControl : MonoBehaviour
{
    public CinemachineFreeLook cinemachineFreeLook;
    public float touchSensitivityX = 0.1f;
    public float touchSensitivityY = 0.1f;

    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;

    private void Update()
    {
        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check if the touch is over any UI element
                if (!IsPointerOverUIObject(touch.position))
                {
                    // Handle touch movement
                    if (touch.phase == TouchPhase.Moved)
                    {
                        // Calculate the rotation values
                        float deltaX = touch.deltaPosition.x * touchSensitivityX;
                        float deltaY = touch.deltaPosition.y * touchSensitivityY;

                        // Adjust the Cinemachine FreeLook camera's axis values
                        cinemachineFreeLook.m_XAxis.Value += deltaX;
                        cinemachineFreeLook.m_YAxis.Value -= deltaY; // Inverted Y-axis for typical camera control
                    }
                }
            }
        }
    }

    private bool IsPointerOverUIObject(Vector2 touchPosition)
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = touchPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        return results.Count > 0;
    }
}
