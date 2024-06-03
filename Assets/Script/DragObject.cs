using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (!isDragging)
        {
            isDragging = true;
            offset = gameObject.transform.position - GetMouseWorldPos();
        }
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPos() + offset;
            transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
