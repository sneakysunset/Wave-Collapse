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
    }

    public int row, column;
    public bool isCollapsed;

    public virtual bool IsCellCollapsed(int cellRow, int cellColumn)
    {
        throw new System.NotImplementedException();
    }

    public virtual void SetCellEntropy(int entropyIndex)
    {
        SetCellCollapsed(true);
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
