using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTypeLandscape : ConditionCellBase
{
    public List<ECellLandscape> cellTypes;

    public CellTypeLandscape()
    {
        cellTypes = new List<ECellLandscape>()
        {
            ECellLandscape.Sea,
            ECellLandscape.Land,
            ECellLandscape.Sand,
            ECellLandscape.Mountain
        };
    }

    public override void SetCellEntropy(int entropyIndex)
    {
        cellTypes = new List<ECellLandscape>() { (ECellLandscape)entropyIndex };
        base.SetCellEntropy(entropyIndex);
    }

    public override void UpdateEntropy<T, J>(WaveCollapseFunction<T, J> waveCollapseFunction)
    {
        CellTypeLandscape[,] landscapeGrid = waveCollapseFunction._conditionalGrid as CellTypeLandscape[,];
        for (int i = cellTypes.Count - 1; i >= 0; i--)
        {
            if (!LandscapeCellConversions.IsLandscapeValid(cellTypes[i], landscapeGrid, new Vector2Int(row, column)))
            {
                cellTypes.RemoveAt(i);
            }
        }
        base.UpdateEntropy(waveCollapseFunction);
    }
}
