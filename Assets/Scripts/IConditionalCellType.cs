using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConditionalCellType
{
    public void UpdateEntropy<T, J>(WaveCollapseFunction<T, J> waveCollapseFunction) where T : ConditionCellBase, IConditionalCellType, new() where J : new();

    public void GetCellContent();

    public void SetCellEntropy(int entropyIndex);

    public bool IsCellCollapsed(int cellRow, int cellColumn);   

    public void SetCellCollapsed(bool isCollapsed);
}
