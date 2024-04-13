using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollapsExecuter : MonoBehaviour
{
    WaveCollapseFunction<CellType1, Color> _collapseFunction;
    [SerializeField] private int _rows, _columns;
    [SerializeField] private Vector2Int _collapseStartCoordinates;
    [SerializeField] private ECellType _firstCellEntropyType;

    [ContextMenu("Execute Wave Collapse Function")]
    public void ExecuteWaveCollapseFunction()
    {
        _collapseFunction = new WaveCollapseFunction<CellType1, Color>(_rows, _columns);
        int firstCellEntropyIndex = (int)_firstCellEntropyType;
        _collapseFunction.CollapseGrid(_collapseStartCoordinates, firstCellEntropyIndex);
    }
}
