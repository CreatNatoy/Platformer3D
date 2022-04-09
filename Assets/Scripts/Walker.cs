using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _pointLeft;
    [SerializeField] private Transform _pointRight;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopTime;
    [SerializeField] private Direction _currentDirection;
    [SerializeField] private Transform _rayStart; 

    private bool _isStopped;

    public UnityEvent EventLeftPoint; 
    public UnityEvent EventRightPoint;

    private void Start()
    {
        _pointLeft.parent = null; 
        _pointRight.parent = null;
    }

    private void Update()
    {
        if (_isStopped)
            return;

        Move();

        AttractionToGround();
    }

    private void AttractionToGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(_rayStart.position, Vector3.down, out hit))
            transform.position = hit.point;
    }

    private void Move()
    {
        if (_currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x < _pointLeft.position.x)
                ChangeDirection(Direction.Right, EventLeftPoint);
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x > _pointRight.position.x)
                ChangeDirection(Direction.Left, EventRightPoint);
        }
    }

    private void ChangeDirection(Direction direction, UnityEvent eventPoint)
    {
        _currentDirection = direction;
        _isStopped = true;
        Invoke("ContinueWalk", _stopTime);
        eventPoint?.Invoke();

    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}
