using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isDropped;
    public bool isDragging;
    private bool moving;

    public bool draggable;

    public Vector3 LastPosition;

    private float movementTime = 15f;
    private Vector3? movementDestination;

    public SavePosition savePosition;

    private void Start()
    {
        savePosition = GetComponent<SavePosition>();
        LastPosition = transform.position;
        draggable = true;
    }

    void FixedUpdate()
    {
        if (movementDestination.HasValue)
        {
            if (isDragging)
            {
                moving = false;
                return;
            }

            if(transform.position == movementDestination)
            {
                gameObject.layer = Layer.Default;
                movementDestination = null;
                moving = false;
                savePosition.Save();
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.fixedDeltaTime);
                moving = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DropValid") && !moving)
        {
            if (collision.GetComponent<Tile>() != null) 
            {
                if (!collision.GetComponent<Tile>().taken)
                {
                    if (!isDragging)
                    {
                        collision.GetComponent<Tile>().SetValue(true);
                        Destroy(GetComponent<Draggable>());
                    }
                    else
                    {
                        movementDestination = collision.transform.position;
                    }
                }
            }
            else
                movementDestination = collision.transform.position;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        movementDestination = LastPosition;
    }

}
