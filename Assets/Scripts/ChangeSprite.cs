using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {

	// Use this for initialization
    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If the space bar is pushed down
        {
            ChangeTheDamnSprite(); // call method to change sprite
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ChangeTheDamnSprite();
            }
        }
        
    }

    void ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
        }
    }
}
