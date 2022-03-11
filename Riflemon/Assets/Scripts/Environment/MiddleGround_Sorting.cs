using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleGround_Sorting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(this.transform.position.y * 1000f);
    }
}
