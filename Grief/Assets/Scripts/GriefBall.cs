using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GriefBall : MonoBehaviour
{
    public bool stopMovement = false;
    public float xSpeed;
    public float ySpeed;
    [Range(5.0f, 50.0f)]
    public float radius;

    [SerializeField ]
    private Image uiBar;
    private float uiBarHeight;
    private SpriteRenderer spriteRenderer;

    private CircleCollider2D circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 3f;
        ySpeed = 3f;
        transform.localScale = Vector3.one * radius;

        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        uiBarHeight = uiBar.rectTransform.sizeDelta.y;
    }

    // TODO:    Add grief button. maybe swipe to move button?
    // Size growth happens within a certain range in the center of the screen

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * radius;

        Vector3 speedVector = new Vector3(xSpeed, ySpeed, 0);
        transform.position += speedVector;
        Vector3 screenPos = Services.GameManager.MainCamera.WorldToScreenPoint(transform.position);

        float spriteWidth = spriteRenderer.bounds.size.x / 2;
        float spriteHeight = spriteRenderer.bounds.size.y / 2;
        if(screenPos.x < spriteWidth || screenPos.x > Screen.width - spriteWidth)
        {
            xSpeed *= -1;
        }

        if(screenPos.y < spriteHeight + (uiBarHeight * 0.95f) || screenPos.y > Screen.height - spriteHeight)
        {
            ySpeed *= -1;
        }
    }
}
