using UnityEngine;

public class Player_movement : MonoBehaviour
{

    public GameObject Player;

    public Transform Player_trans;
    public float player_size;

    public float speed;

    public float distance_y;
    public float distance_x;

    public float distance;

    public float x;
    public float y;

    public float y_value;
    public float x_value;

    public Vector3 Movement;

    //Keys
    public bool right;
    public bool left;
    public bool up;
    public bool down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        up = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);

        if (up)
        {
            y_value = 1;
        }

        if (down)
        {
            y_value = -1;
        }

        if (right)
        {
            x_value = 1;
        }

        if (left)
        {
            x_value = -1;
        }

        Movement = new Vector3 (x_value, y_value, 0);
        x_value = 0;
        y_value = 0;
    }

    private void FixedUpdate()
    {
        if (DetectWall(Movement.normalized))
        {
            transform.position += Movement.normalized * speed * Time.fixedDeltaTime;
        }
    }

    public bool DetectWall(Vector3 move)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, move, player_size);

        distance_y = player_size + 1;
        distance_x = player_size + 1;
        distance   = player_size + 1;

        if (hit)
        {
            distance_y = Mathf.Abs(hit.point.y - transform.position.y);
            distance_x = Mathf.Abs(hit.point.x - transform.position.x);

            distance = new Vector2(distance_x, distance_y).magnitude;
        }
        else
        {
            return true;
        }

        if (distance < player_size)
        {
            return false;
        }

        return true;
    }
}
