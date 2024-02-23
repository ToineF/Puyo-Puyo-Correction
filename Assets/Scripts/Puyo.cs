using UnityEngine;

public class Puyo : MonoBehaviour
{
    public enum PuyoColor
    {
        BLUE,
        RED,
        GREEN,
    }

    public Vector2Int GridPosition => _gridPosition;

    [field:SerializeField] public PuyoColor Color { get; private set; }

    private Vector2Int _gridPosition;

    public void Initialize(Vector2Int startPosition)
    {
        _gridPosition = startPosition;
    }

    public void Fall()
    {
        _gridPosition.y--;
        UpdatePosition();
    }

    public void MoveX(int x)
    {
        _gridPosition.x += x;
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = MainGame.Instance.GridToWorldPosition(GridPosition);
    }

}
