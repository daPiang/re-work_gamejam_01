using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Tilemap[] movementTilemaps; // Tilemaps the player can move on
    private Vector2 currentDirection = Vector2.zero;
    [SerializeField] Animator dustanim;
    [SerializeField] Animator charanim;
    [SerializeField] SpriteRenderer spriteRenderer;
    private bool isMoving = false;
    private float timeSinceLastInput = 0f;
    private float inputDelay = 0.2f; // Adjust this value to control the input delay.
    private int bufferTiles = 2; // Adjust this value to control how close to the edge the player can move.

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        timeSinceLastInput += Time.deltaTime;

        if (moveDirection != Vector2.zero && timeSinceLastInput >= inputDelay)
        {
            currentDirection = moveDirection;
            isMoving = true;
            UpdateAnimations();
            timeSinceLastInput = 0f;
        }
        else if (moveDirection == Vector2.zero)
        {
            currentDirection = Vector2.zero;
            isMoving = false;
            UpdateAnimations();
        }

        if (isMoving)
        {
            Vector3 newPosition = transform.position + (Vector3)currentDirection * moveSpeed * Time.deltaTime;

            // Check if the new position is within a valid tilemap and not in the last two tiles at each end
            foreach (Tilemap tilemap in movementTilemaps)
            {
                if (IsInsideTilemap(newPosition, tilemap) && !IsInLastTwoTiles(newPosition, tilemap))
                {
                    transform.position = newPosition;
                    break; // Stop checking other tilemaps
                }
            }
        }
    }

    private void UpdateAnimations()
    {
        if (currentDirection.x < 0)
        {
            // Moving left (A key)
            spriteRenderer.flipX = true; // Flip the sprite
            dustanim.SetInteger("isWalk", 1);
            charanim.SetInteger("isWalking", 3);
        }
        else if (currentDirection.x > 0)
        {
            // Moving right (D key)
            spriteRenderer.flipX = false; // Do not flip the sprite
            dustanim.SetInteger("isWalk", 1);
            charanim.SetInteger("isWalking", 4);
        }
        else if (currentDirection.y > 0)
        {
            // Moving up (W key)
            dustanim.SetInteger("isWalk", 2);
            charanim.SetInteger("isWalking", 1);
        }
        else if (currentDirection.y < 0)
        {
            // Moving down (S key)
            dustanim.SetInteger("isWalk", 2);
            charanim.SetInteger("isWalking", 2);
        }
        else
        {
            // No movement
            dustanim.SetInteger("isWalk", 0);
            charanim.SetInteger("isWalking", 0);
        }
    }

    private bool IsInsideTilemap(Vector3 position, Tilemap tilemap)
    {
        return tilemap.HasTile(tilemap.WorldToCell(position));
    }

    private bool IsInLastTwoTiles(Vector3 position, Tilemap tilemap)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(position);
        BoundsInt tilemapBounds = tilemap.cellBounds;
        int lastTileX = tilemapBounds.xMax - 1;
        int lastTileY = tilemapBounds.yMax - 1;
        int firstTileX = tilemapBounds.x + bufferTiles;
        int firstTileY = tilemapBounds.y + bufferTiles;
        return cellPosition.x >= lastTileX - bufferTiles || cellPosition.y >= lastTileY - bufferTiles ||
            cellPosition.x < firstTileX || cellPosition.y < firstTileY;
    }
}
