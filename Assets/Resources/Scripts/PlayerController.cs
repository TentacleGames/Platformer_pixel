using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public float speed = 2f;
    public float jumpForse = 2f;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody is null)
            Debug.Log("Can't find rigidbody for "+name);
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider is null)
            Debug.Log("Can't find boxCollider for "+name);
        circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider is null)
            Debug.Log("Can't find circleCollider for "+name);
    }


    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0){
            Vector2 trans = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0);
            transform.Translate(trans);
            Vector3 theScale = transform.localScale;
            theScale.x = Input.GetAxisRaw("Horizontal");
            transform.localScale = theScale;
            transform.position.Scale(new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1));
        }

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
        }
        
    }

    private bool IsGrounded(){
        float extraHeigh = circleCollider.radius/2;
        Vector3 center = new Vector3 (circleCollider.bounds.center.x, circleCollider.bounds.center.y - circleCollider.radius/2, 0f);
        RaycastHit2D raycastHit = Physics2D.BoxCast(center, circleCollider.bounds.size, 0f, Vector2.down, extraHeigh, platformLayerMask);

        return raycastHit.collider != null;
    }
}
