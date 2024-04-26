using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollapseFunction <T, J> where T : ConditionCellBase, IConditionalCellType , new() where J : new()
{
    public T[,] _conditionalGrid;
    public J[,] _cellsContent;

    public WaveCollapseFunction(int rows, int columns)
    {
        _conditionalGrid = BuildConditionalGrid(rows, columns);
        _cellsContent = BuildContentGrid(rows, columns);
    }
    
    ~WaveCollapseFunction()
    {
        foreach(var cell in _conditionalGrid)
        {

        }
    }

    public J[,] BuildContentGrid(int rows, int columns)
    {
        _cellsContent = new J[rows, columns];
        foreach(var cell in _cellsContent)
        {
            
        }
        return _cellsContent;
    }

    public T[,] BuildConditionalGrid(int rows, int columns) 
    {
        T[,] grid = new T[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                grid[i, j] = new T();
                grid[i, j].row = i;
                grid[i, j].column = j;
            }
        }

        return grid;
    }

    public bool CollapseGrid(Vector2Int firstCellCoord, int entropyIndex)
    {
        if(!IsCellInGrid(firstCellCoord))
        {
            Debug.LogError("Input coordinates or outside of grid");
            return false;
        }
        _conditionalGrid[firstCellCoord.x, firstCellCoord.y].SetCellEntropy(entropyIndex);
        PropagateCollapse(firstCellCoord);

        foreach(var cell in _conditionalGrid)
        {
            cell.SetCellCollapsed(false);
        }
        return true;
    }

    private void PropagateCollapse(Vector2Int coord)
    {
        Vector2Int rightCoord = new Vector2Int(coord.x + 1, coord.y);
        Vector2Int leftCoord = new Vector2Int(coord.x - 1, coord.y);
        Vector2Int upCoord = new Vector2Int(coord.x, coord.y + 1);
        Vector2Int downCoord = new Vector2Int(coord.x, coord.y - 1);

        List<Vector2Int> coordsToPropagateNext = new List<Vector2Int>();

        if (IsCellInGrid(rightCoord))
        {
            _conditionalGrid[rightCoord.x, rightCoord.y].UpdateEntropy(this);
            coordsToPropagateNext.Add(rightCoord);
        }

        if (IsCellInGrid(leftCoord))
        {
            _conditionalGrid[leftCoord.x, leftCoord.y].UpdateEntropy(this);
            coordsToPropagateNext.Add(leftCoord);
        }

        if(IsCellInGrid(upCoord))
        {
            _conditionalGrid[upCoord.x, upCoord.y].UpdateEntropy(this);
            coordsToPropagateNext.Add(upCoord);
        }

        if (IsCellInGrid(downCoord))
        {
            _conditionalGrid[downCoord.x, downCoord.y].UpdateEntropy(this);
            coordsToPropagateNext.Add(downCoord);
        }

        if(coordsToPropagateNext.Count == 0)
        {
            Debug.Log("End Of Propagation");
            return;
        }

        foreach(var newCoord in coordsToPropagateNext)
        {
            PropagateCollapse(newCoord);
        }
    }

    private bool IsCellInGrid(Vector2Int coord)
    {
        int row = coord.x;
        int column = coord.y;
        if(row < 0 || column < 0 
          || row >= _conditionalGrid.GetLength(0) 
          || column >= _conditionalGrid.GetLength(1) 
          || !_conditionalGrid[row, column].IsCellCollapsed(row, column))
            return false;

        return true;
    }
}
