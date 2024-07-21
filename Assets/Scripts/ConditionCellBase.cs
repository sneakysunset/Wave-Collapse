using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionCellBase<V> where V : new()
{
    public List<V> cellTypes;
    public ConditionCellBase() { }

    public ConditionCellBase(int _row, int _column) 
    {
        row = _row; column = _column;
        cellTypes = new List<V>();
    }

    public int row, column;
    public bool isCollapsed;

    public virtual bool IsCellCollapsed(int cellRow, int cellColumn)
    {
        return isCollapsed;
    }

    public virtual bool SetCellEntropy(int entropyIndex)
    {
        SetCellCollapsed(true);
        return true;
    }

    public List<V> GetCellContent()
    {
        return cellTypes;
    }


    public void SetCellCollapsed(bool isCollapsed)
    {
        this.isCollapsed = isCollapsed;
    }

    public virtual void UpdateEntropy<T>(T[,] conditionArray)
       where T : ConditionCellBase<V>
    {
        SetCellCollapsed(true);
    }


}
