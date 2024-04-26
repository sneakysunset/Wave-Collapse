using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;
public class WaveCollapseExecuter : MonoBehaviour
{
    WaveCollapseFunction<CellTypeLandscape, Color> _collapseFunction;
    [SerializeField] private int _rows, _columns;
    [SerializeField] private bool _IsCollapseStartRandom;
    [HideIf("_IsCollapseStartRandom"), SerializeField] private Vector2Int _collapseStartCoordinates;
    [SerializeField] private bool _IsFirstCellEntropyRandomType;
    [HideIf("_IsFirstCellEntropyRandomType"), SerializeField] private ECellLandscape _firstCellEntropyType;
    [SerializeField] private bool _ContinueCollapse;
    [SerializeField] private bool _ContinueCollapseAuto;
    [SerializeField] private float _CollapseFrequency;
    [SerializeField] private KeyCode _ContinueCollapseInputBinding = KeyCode.Space;
    private IEnumerator _EnumInstance;


    [ContextMenu("Execute Wave Collapse Function")]
    public void ExecuteWaveCollapseFunction()
    {
        _collapseFunction = new WaveCollapseFunction<CellTypeLandscape, Color>(_rows, _columns);
        if(_EnumInstance != null)
        {
            StopCoroutine(_EnumInstance);
        }
        _EnumInstance = CollapseEnum();
        StartCoroutine(_EnumInstance);
    }

    private IEnumerator CollapseEnum()
    {
        yield return new WaitUntil(()=>_ContinueCollapse);
        if(!_ContinueCollapseAuto)  _ContinueCollapse = false;
        
        //Get Start Coordinates and first Cell Entropy
        int firstCellEntropyIndex = !_IsFirstCellEntropyRandomType ? 
            (int)_firstCellEntropyType : UnityEngine.Random.Range(0, Enum.GetNames(typeof(ECellLandscape)).Length);
        Vector2Int collapseStartCell = 
            !_IsCollapseStartRandom ? _collapseStartCoordinates : new Vector2Int(UnityEngine.Random.Range(0, _rows), UnityEngine.Random.Range(0, _columns));

        if(_collapseFunction.CollapseGrid(collapseStartCell, firstCellEntropyIndex)) // On Collapse Success
        {
            yield return new WaitForSeconds(1 / _CollapseFrequency);
            _EnumInstance = CollapseEnum();
            StartCoroutine(_EnumInstance);
        }
        else //If fail to Collapse
        {
            _EnumInstance = null;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(_ContinueCollapseInputBinding))
        {
            _ContinueCollapse = true;
        }
    }
}
