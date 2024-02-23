using UnityEngine;
using AntoineFoucault.Utilities;
using System;
using static Puyo;
using System.Drawing;
using System.Collections.Generic;

public class MainGame : MonoBehaviour
{
    public static MainGame Instance;

    public Puyo CurrentPuyo => _currentPuyo;

    [Header("References")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Puyo[] _puyoPrefabs;
    [SerializeField] private Transform _puyoParent;

    [Header("Grid")]
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private float _cellSize;
    [SerializeField] private float _puyoFallSpeed;
    [SerializeField] private float _comboPuyoCount = 4;


    [Header("Debug")]
    [SerializeField] private bool _drawPuyoGizmo;

    private Puyo[,] _grid;
    private bool[,] _checkedPuyosGrid;
    private Puyo _currentPuyo;
    private float _puyoFallTimer;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitGrid();
        CreateNewPuyo();
    }

    private void InitGrid()
    {
        _grid = new Puyo[_gridSize.x, _gridSize.y];
        _checkedPuyosGrid = new bool[_gridSize.x, _gridSize.y];

        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                _grid[x, y] = null;
                _checkedPuyosGrid[x, y] = false;
            }
        }
    }

    private void ResetNeighboursGrid()
    {
        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                _checkedPuyosGrid[x, y] = false;
            }
        }
    }

    private int GetVisitedCellls()
    {
        int count = 0;
        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                if (_checkedPuyosGrid[x,y]) count++;
            }
        }
        return count;
    }

    private void Update()
    {
        UpdatePuyoFall();
    }

    private void UpdatePuyoFall()
    {
        _puyoFallTimer -= Time.deltaTime;
        if (_puyoFallTimer < 0)
        {
            Vector2Int targetPosition = new Vector2Int(_currentPuyo.GridPosition.x, _currentPuyo.GridPosition.y - 1);
            _puyoFallTimer += _puyoFallSpeed;

            if ((targetPosition.y < 0) || (_grid[targetPosition.x, targetPosition.y] != null))
            {
                SetPuyoInGridAt(_currentPuyo);
                CheckForCombo();
                CreateNewPuyo();
            }
            else
            {
                _currentPuyo?.Fall();
            }
        }
    }

    private void CheckForCombo()
    {
        if (_currentPuyo == null) return;

        ResetNeighboursGrid();
        List<Puyo> puyosInCombo = new List<Puyo>();
        int puyoCombo = PuyoNeighboursCount(_currentPuyo.GridPosition.x, _currentPuyo.GridPosition.y, 0, _currentPuyo.Color, puyosInCombo);





        Debug.Log("combo " + GetVisitedCellls());
        if (GetVisitedCellls() < _comboPuyoCount) return;

        foreach (var puyo in puyosInCombo)
        {
            RemovePuyoFromGridAt(puyo.GridPosition);
            Destroy(puyo.gameObject);
        }
    }

    private int PuyoNeighboursCount(int x, int y, int count, PuyoColor color, List<Puyo> puyos)
    {
        // Exit
        if (IsPositionOutOfBounds(x, y)) return count;
        if (_grid[x, y] == null) return count;
        if (_checkedPuyosGrid[x, y]) return count;
        if (_grid[x,y].Color != color) return count;

        // Action
        // Mark
        count++;
        puyos.Add(_grid[x,y]);
        _checkedPuyosGrid[x, y] = true;

        // Neighbours
        return Mathf.Max(PuyoNeighboursCount(x + 1, y, count, color, puyos), 
                         PuyoNeighboursCount(x - 1, y, count, color, puyos),
                         PuyoNeighboursCount(x, y + 1, count, color, puyos),
                         PuyoNeighboursCount(x, y - 1, count, color, puyos));
    }

    private void CreateNewPuyo()
    {
        Vector2Int puyoStartPosition = new Vector2Int((int)(_gridSize.x / 2), _gridSize.y - 1);
        Puyo newPuyo = Instantiate(CollectionsExtensions.GetRandomItem(_puyoPrefabs), GridToWorldPosition(puyoStartPosition), Quaternion.identity);
        newPuyo.Initialize(puyoStartPosition);
        _currentPuyo = newPuyo;
    }

    //public void MovePuyoInGrid(Vector2Int oldPosition, Vector2Int newPosition, Puyo puyo)
    //{
    //    ReplacePuyoAt(newPosition, puyo);
    //    RemovePuyoFromGridAt(oldPosition);
    //}

    //private void ReplacePuyoAt(Vector2Int gridPosition, Puyo puyo)
    //{
    //    RemovePuyoFromGridAt(gridPosition);
    //    SetPuyoInGridAt(gridPosition, puyo);
    //}

    private void RemovePuyoFromGridAt(Vector2Int gridPosition)
    {
        _grid[gridPosition.x, gridPosition.y] = null;
    }

    private void SetPuyoInGridAt(Puyo puyo)
    {
        _grid[puyo.GridPosition.x, puyo.GridPosition.y] = puyo;
    }

    /// <summary>
    /// Converts a grid position to a world position
    /// </summary>
    /// <param name="gridPosition"></param>
    /// <returns></returns>
    public Vector3 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector3(_puyoParent.position.x + _cellSize * gridPosition.x, _puyoParent.position.y + _cellSize * gridPosition.y, 0);
    }

    /// <summary>
    /// Converts a grid position to a world position
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Vector3 GridToWorldPosition(int x, int y)
    {
        return new Vector3(_puyoParent.position.x + _cellSize * x, _puyoParent.position.y + _cellSize * y, 0);
    }

    public bool IsPositionOutOfBounds(Vector2Int position)
    {
        return (IsXOutOfBounds(position.x) || IsYOutOfBounds(position.y));
    }

    public bool IsPositionOutOfBounds(int x, int y)
    {
        return (IsXOutOfBounds(x) || IsYOutOfBounds(y));
    }

    public bool IsXOutOfBounds(int x)
    {
        return (x < 0 || x > _gridSize.x - 1);
    }

    public bool IsYOutOfBounds(int y)
    {
        return (y < 0 || y > _gridSize.y - 1);
    }


    private void DebugGrid()
    {
        //for (int y = 0; y < _gridSize.y; y++)
        //{
        //    for (int x = 0; x < _gridSize.x; x++)
        //    {
        //        Instantiate(_puyoPrefab, GridToWorldPosition(new Vector2Int(x, y)), Quaternion.identity, _puyoParent);
        //    }
        //}
    }

    private void OnDrawGizmos()
    {

        if (_grid == null || !_drawPuyoGizmo) return;

        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                if (_grid[x, y] != null)
                {
                    Gizmos.DrawSphere(GridToWorldPosition(new Vector2Int(x, y)), 0.1f);
                }

            }
        }
    }

}
