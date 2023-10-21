using System;
using Destructible2D.Examples;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] private D2dRepeatStamp stamp;

    public enum ColorState {
        Blue,
        Yellow,
        Red,
        Green,
        Orange,
        Violet
    }
    
    public static ColorState colorState;

    [SerializeField] private LayerMask layerMask;

    private bool canPaint;

    private void Start() {
        colorState = ColorState.Blue;
        stamp.Size.x = transform.localScale.x;
        stamp.Size.y = transform.localScale.y;
    }

    void Update()
    {
        // Get the current mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        // Ensure the object stays at the same Z position to avoid depth issues
        mousePositionWorld.z = transform.position.z;

        // Set the object's position to the mouse position
        transform.position = mousePositionWorld;

        if(Input.GetMouseButtonDown(0) && canPaint)
        {
            stamp.enabled = true;
            Debug.Log("PAINTING");
        } else Debug.Log("NOT PAINTING");

        if(Input.GetMouseButtonUp(0))
        {
            stamp.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if((layerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            // Debug.Log("This is a drawable object");
            canPaint = other.GetComponent<ColorCheck>().ColorMatch();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if((layerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            // Debug.Log("This is a drawable object");
            // canPaint = false;
            stamp.enabled = false;
        }
    }
}
