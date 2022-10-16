using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBlock : MonoBehaviour
{
    public Draggable LastDragged => lastDragged;

    private bool dragActive = false;

    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private Draggable lastDragged;

    // Start is called before the first frame update
    void Awake()
    {
        DragBlock[] controllers = FindObjectsOfType<DragBlock>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (dragActive)
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else return;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (dragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    if (draggable.draggable)
                    {
                        lastDragged = draggable;
                        InitDrag();
                    }
                }
            }
        }

    }

    void InitDrag()
    {
        lastDragged.LastPosition = lastDragged.transform.position;
        UpdateDragStatus(true);
    }
    
    void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPosition.x, worldPosition.y);
        lastDragged.isDropped = false;
    }

    void Drop()
    {
        UpdateDragStatus(false);
        lastDragged.isDropped = true;
    }

    void UpdateDragStatus(bool isDraggin)
    {
        dragActive = lastDragged.isDragging = isDraggin;
        gameObject.layer = isDraggin ? Layer.Dragging : Layer.Default;
    }
}
