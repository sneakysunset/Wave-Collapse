using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollapseFunction <T, J> where T : CellBase, ICellType , new() where J : new()
{
    public T[,] _conditionalGrid;
    public J[,] _cellsContent;

    public WaveCollapseFunction(int rows, int columns)
    {
        _conditionalGrid = BuildGrid(rows, columns);
        _cellsContent = new J[rows, columns];
    }
    
    public void Rebuild(int rows, int columns)
    {
        _conditionalGrid = BuildGrid(rows, columns);
        _cellsContent = new J[rows, columns];
    }

    public T[,] BuildGrid(int rows, int columns) 
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

    public void CollapseGrid(Vector2Int firstCellCoord, int entropyIndex)
    {
        if(!IsCellInGrid(firstCellCoord))
        {
            Debug.LogError("Input coordinates or outside of grid");
            return;
        }
        _conditionalGrid[firstCellCoord.x, firstCellCoord.y].SetCellEntropy(entropyIndex);
        PropagateCollapse(firstCellCoord);
    }

    private void PropagateCollapse(Vector2Int coord)
    {
        Vector2Int rightCoord = new Vector2Int(coord.x + 1, coord.y);
        Vector2Int leftCoord = new Vector2Int(coord.x - 1, coord.y);
        Vector2Int upCoord = new Vector2Int(coord.x, coord.y + 1);
        Vector2Int downCoord = new Vector2Int(coord.x, coord.y - 1);

        if (IsCellInGrid(rightCoord))
        {
            _conditionalGrid[rightCoord.x, rightCoord.y].UpdateEntropy();
            PropagateCollapse(rightCoord);
        }

        if (IsCellInGrid(leftCoord))
        {
            _conditionalGrid[leftCoord.x, leftCoord.y].UpdateEntropy();
            PropagateCollapse(leftCoord);
        }

        if(IsCellInGrid(upCoord))
        {
            _conditionalGrid[upCoord.x, upCoord.y].UpdateEntropy();
            PropagateCollapse(upCoord);
        }

        if (IsCellInGrid(downCoord))
        {
            _conditionalGrid[downCoord.x, downCoord.y].UpdateEntropy();
            PropagateCollapse(downCoord);
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
