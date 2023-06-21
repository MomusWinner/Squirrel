using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement: MonoBehaviour
{
    private float lastPos;
    [SerializeField] private float power = 10f;
    [SerializeField] private float maxDrag = 5f;

    private Rigidbody2D rb;
    //private LineRenderer lr;
    private Animator anim;

    Vector3 dragStartPos;
    Touch touch;

    [Space]
    private bool onGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float checkRadius = 0.5f;

    [Space]
    [SerializeField] private AudioSource jumpSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //lr= GetComponent<LineRenderer>();

        lastPos = this.transform.position.x - 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log(eventData.position);

    }

    private void Update()
    {
        OnGround();

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase== TouchPhase.Began) {
                DragStart();
            }

            if(touch.phase== TouchPhase.Moved) {
                Dragging();
            }

            if(touch.phase == TouchPhase.Ended) {
                DragRelease();
            }
        }

    }

    private void FixedUpdate()
    {
        CheckFlipp();
    }

    void DragStart() {
        anim.SetBool("isPreparation", true);
        //lr.positionCount = 2;
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        //lr.SetPosition(0, dragStartPos);
        //lr.SetPosition(1, dragStartPos);
    }

    void Dragging() {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        //lr.SetPosition(1, draggingPos);
    }

    void DragRelease() {
        //lr.positionCount = 0;
        if (onGround)
        {
            jumpSound.pitch = Random.Range(0.9f, 1.1f);
            jumpSound.Play();
            
            Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
            dragReleasePos.z = 0f;

            Vector3 force = dragStartPos - dragReleasePos;
            Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
            rb.AddForce(clampedForce, ForceMode2D.Impulse);
            anim.SetBool("isPreparation", false);
        }
    }
   
    void OnGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        
        anim.SetBool("onGround", onGround);
    }

    void CheckFlipp()
    {
        bool flipped = transform.position.x < lastPos;
        transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        lastPos = transform.position.x;
    }
}
