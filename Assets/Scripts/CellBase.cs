using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBase : ICellType
{
    public CellBase() { }

    public int row, column;
    public void GetCellContent()
    {
        throw new System.NotImplementedException();
    }

    public bool IsCellCollapsed(int cellRow, int cellColumn)
    {
        throw new System.NotImplementedException();
    }

    public void SetCellEntropy(int entropyIndex)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEntropy()
    {
        throw new System.NotImplementedException();
    }
}
