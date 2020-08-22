using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public GameObject leftBorder, rightBorder;
    public bool isRightDirection;
    private Rigidbody2D rigidbody;
    private GroundDetector groundDetecor;

    public float speed;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        if (leftBorder is null || rightBorder is null){
            string msg = "There is a problem with borders in unit " + this.name;
            Debug.Log(msg);
        }
        groundDetecor = GetComponent<GroundDetector>();
        if (groundDetecor is null)
            Debug.Log("Can't find groundDetecor for "+name);
            
        
    }

    // Update is called once per frames
    void Update()
    {
        if (groundDetecor.isGrounded){
            float k = speed * (isRightDirection ? 1 : -1);
            rigidbody.velocity = new Vector2(k, 0);

            if (isRightDirection && transform.position.x >= rightBorder.transform.position.x ||
                !isRightDirection && transform.position.x <= leftBorder.transform.position.x
                )
                isRightDirection = !isRightDirection;
        }
    }
}
