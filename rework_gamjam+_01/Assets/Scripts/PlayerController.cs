using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Tilemap[] movementTilemaps; // Tilemaps the player can move on
    private Vector2 currentDirection = Vector2.zero;

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Check if the player is trying to move
        if (moveDirection != Vector2.zero){
            currentDirection = moveDirection;
        }else{
            currentDirection = Vector2.zero;
        }

        Vector3 newPosition = transform.position + (Vector3)currentDirection * moveSpeed * Time.deltaTime;

        // Check if the new position is within a valid tilemap with a buffer of -1 tile
        foreach (Tilemap tilemap in movementTilemaps){
            if (IsInsideTilemap(newPosition, tilemap, 1)){
                transform.position = newPosition;
                break; // Stop checking other tilemaps
            }
        }
    }
    private bool IsInsideTilemap(Vector3 position, Tilemap tilemap, int bufferTiles = 0){
        Vector3Int cellPosition = tilemap.WorldToCell(position);
        BoundsInt tilemapBounds = tilemap.cellBounds;
        tilemapBounds.x += bufferTiles;
        tilemapBounds.y += bufferTiles;
        tilemapBounds.size = new Vector3Int(tilemapBounds.size.x - 2 * bufferTiles, tilemapBounds.size.y - 2 * bufferTiles, tilemapBounds.size.z);
        return tilemapBounds.Contains(cellPosition);
    }
}