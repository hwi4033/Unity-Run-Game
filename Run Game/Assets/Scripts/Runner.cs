using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 2.0f;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float speed = 25.0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void OnKeyUpdate()
    {
        if (roadLine > RoadLine.LEFT)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // if (roadLine != RoadLine.Left)
                roadLine--;
            }
        }

        if (roadLine < RoadLine.RIGHT)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // if (roadLine != RoadLine.Right)
                roadLine++;
            }
        }
    }

    void Move()
    {
        rigidBody.position = Vector3.Lerp(rigidBody.position, new Vector3(positionX * (int)roadLine, 0, 0), speed * Time.fixedDeltaTime);
    }

    private void OnDisable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }
}