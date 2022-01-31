using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
   public Canvas canV;
    public float rad;
    private Vector2 Axis;

    public Vector2 axis
    {
        get
        {
            return Axis;
        }
    }
    public float Horizontal
    {
        get
        {
            return Axis.x;
        }
    }
    public float Vertical
    {
        get
        {
            return Axis.y;
        }
    }
    public bool isMoving
    {
        get
        {
            return Axis != Vector2.zero;
        }
    }

    Vector3 InitialPos;
    void Start()
    {
        InitialPos = transform.position;
    }

  
    void Update()
    {
       // Debug.Log(axis);
    }

    public void OnDrag(PointerEventData point)
    {
        
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canV.transform as RectTransform, point.position, canV.worldCamera, out pos);
        Vector2 newPos = canV.transform.TransformPoint(pos) - InitialPos;
        newPos.x = Mathf.Clamp(newPos.x, -rad, rad);
        newPos.y = Mathf.Clamp(newPos.y, -rad, rad);

        Axis = newPos / rad;

        transform.localPosition = newPos;
    }
    public void OnEndDrag(PointerEventData point)
    {
        transform.position = InitialPos;
        Axis = Vector2.zero;
    }
}
