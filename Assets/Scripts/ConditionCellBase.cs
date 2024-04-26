using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCellBase : IConditionalCellType
{
    public ConditionCellBase() { }

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

    public virtual void GetCellContent()
    {
        throw new System.NotImplementedException();
    }

    public virtual void UpdateEntropy<T, J>(WaveCollapseFunction<T, J> waveCollapseFunction)
        where T : ConditionCellBase, IConditionalCellType, new()
        where J : new()
    {
        SetCellCollapsed(true);
    }

    public void SetCellCollapsed(bool isCollapsed)
    {
        this.isCollapsed = isCollapsed;
    }
}
