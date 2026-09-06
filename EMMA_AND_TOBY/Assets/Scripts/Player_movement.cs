using UnityEngine;

public class Player_movement : MonoBehaviour
{

    public GameObject Player;

    public Transform Player_trans;

    public float speed;

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
        transform.position += Movement * speed * Time.fixedDeltaTime;
    }
}
