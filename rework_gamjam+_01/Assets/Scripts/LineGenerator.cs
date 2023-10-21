using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public LayerMask drawLayer;  // A public field to specify the layer to draw on.

    Line activeLine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the clicked object is on the specified layer
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, drawLayer);
            if (hit.collider != null)
            {
                GameObject newLine = Instantiate(linePrefab);
                activeLine = newLine.GetComponent<Line>();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // activeLine.UpdateLine(mousePos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, drawLayer);
            if (hit.collider != null)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                activeLine.UpdateLine(mousePos);
            }
        }
    }
}
