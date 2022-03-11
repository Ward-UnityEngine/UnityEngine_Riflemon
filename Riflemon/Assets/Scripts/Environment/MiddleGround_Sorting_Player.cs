using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleGround_Sorting_Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(this.transform.position.y * 1000f);
    }
}
