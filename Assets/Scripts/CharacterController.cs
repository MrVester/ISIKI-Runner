using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using GG.Infrastructure.Utils.Swipe;

public class CharacterController : MonoBehaviour
{
    const float PI = 3.14159f;

    [SerializeField]
    private float swipeTime;
    public Camera cam;
    public Transform center;
    public float defaultRadius = 5f;
    public float radiusOffset = -1.0f;

    public float jumpHeight;
    public float gravityScale;
    public float velocity;

    private float radius;
    private float angle = 0.0f;
    private float radians;
    private float Xpos;
    private float Ypos;

    private bool isSwiping = false;
    private bool isInAir = false;
    private bool triggerJump = false;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        radius = defaultRadius;
    }

    // Update is called once per frame
    void Update()
    {

        Jump();

        Move();

    }
    private void Move()
    {
        //angle = slider.value * 360;
        radians = (angle - 90) * PI / 180;

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
        cam.transform.rotation = transform.rotation;
        Xpos = center.position.x + Mathf.Cos(radians) * (radius + radiusOffset);
        Ypos = center.position.y + Mathf.Sin(radians) * (radius + radiusOffset);


        transform.position = (new Vector2(Xpos, Ypos));
    }
    private void Jump()
    {

        if (isInAir)
        {
            velocity += Physics2D.gravity.y * gravityScale * Time.deltaTime;
            radius -= velocity * Time.deltaTime;
        }


        if (radius >= defaultRadius && velocity < 0)
        {
            animator.SetBool("IsInAir", false);
            isInAir = false;
            radius = defaultRadius;
            velocity = 0;

        }



    }
    public void TriggerJump()
    {
        if (!isInAir)
        {
            animator.SetTrigger("Jump");
            animator.SetBool("IsInAir", true);
            isInAir = true;
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
        }
    }
    public void OnLeftSwipe()
    {
        if (!isSwiping)
            StartCoroutine(MoveSmoothAngle(-45));
    }
    public void OnRightSwipe()
    {
        if (!isSwiping)
            StartCoroutine(MoveSmoothAngle(45));
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center.position, defaultRadius);
    }
    IEnumerator MoveSmoothAngle(float swipeAngle)
    {
        isSwiping = true;
        float elapsedTime = 0;
        float startAngle = angle;
        while (elapsedTime <= swipeTime)
        {

            angle = Mathf.Lerp(startAngle, startAngle + swipeAngle, (elapsedTime / swipeTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        angle = startAngle + swipeAngle;
        isSwiping = false;
        yield return null;
    }
    public void SetSwipeUp()
    {

    }
    public void SetSwipeLeft()
    {

    }
    public void SetSwipeRight()
    {

    }
}
