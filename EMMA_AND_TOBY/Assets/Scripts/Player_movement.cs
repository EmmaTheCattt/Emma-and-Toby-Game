using UnityEngine;
using UnityEngine.Rendering;

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
    public bool Right;
    public bool Left;
    public bool Up;
    public bool Down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Up = Input.GetKey(KeyCode.W);
        Down = Input.GetKey(KeyCode.S);
        Left = Input.GetKey(KeyCode.A);
        Right = Input.GetKey(KeyCode.D);

        if (Up)
        {
            y_value = 1;
        }

        if (Down)
        {
            y_value = -1;
        }

        if (Right)
        {
            x_value = 1;
        }

        if (Left)
        {
            x_value = -1;
        }

        Movement = new Vector3 (x_value, y_value, 0);
    }

    private void FixedUpdate()
    {
        if (DetectWall(Movement.normalized))
        {
            transform.position += Movement.normalized * speed * Time.fixedDeltaTime;
        }

        x_value = 0;
        y_value = 0;
    }

    public bool DetectWall(Vector3 move)
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, move, player_size);
        Debug.DrawRay(transform.position, move, Color.lightPink);

        if (hit)
        {
            if (hit.distance <= player_size)
            {
                return false;
            }
        }
        

        if (x_value != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        hit = Physics2D.Raycast(transform.position, new Vector2(x_value, 0), player_size);
                        Debug.DrawRay(transform.position, new Vector2(x_value, 0), Color.lightPink);
                        break;
                    case 1:
                        hit = Physics2D.Raycast(transform.position, new Vector2(x_value, 1).normalized, player_size);
                        Debug.DrawRay(transform.position, new Vector2(x_value, 1).normalized, Color.lightPink);
                        break;
                    case 2:
                        hit = Physics2D.Raycast(transform.position, new Vector2(x_value, -1).normalized, player_size);
                        Debug.DrawRay(transform.position, new Vector2(x_value, -1).normalized, Color.lightPink);
                        break;
                }

                if (hit)
                {
                    if (hit.distance <= player_size)
                    {
                        return false;
                    }
                }
            }
        }

        if (y_value != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        hit = Physics2D.Raycast(transform.position, new Vector2(0, y_value), player_size);
                        Debug.DrawRay(transform.position, new Vector2(0, y_value), Color.lightPink);
                        break;
                    case 1:
                        hit = Physics2D.Raycast(transform.position, new Vector2(1, y_value).normalized, player_size);
                        Debug.DrawRay(transform.position, new Vector2(1, y_value).normalized, Color.lightPink);
                        break;
                    case 2:
                        hit = Physics2D.Raycast(transform.position, new Vector2(-1, y_value).normalized, player_size);
                        Debug.DrawRay(transform.position, new Vector2(-1, y_value).normalized, Color.lightPink);
                        break;
                }

                if (hit)
                {
                    if (hit.distance <= player_size)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
