using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BlocksControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targetBlocks = new List<GameObject>();
    private List<Vector2> _targetBlocksPositions = new List<Vector2>();
    void Start()
    {
        _targetBlocksPositions = GetPositions(_targetBlocks);
    }
    void Update()
    {
        // while(flag)
        // {
        //     origem.transform.position = Vector2.MoveTowards(posOrigem, posAlvo, 2 * Time.deltaTime);
        // }
    }
    public List<Vector2> GetPositions(List<GameObject> list)
    {
        List<Vector2> pos = new List<Vector2>();
        foreach (GameObject block in list)
        {
            if (block != null)
            {
                pos.Add(block.transform.position);
            }
        }
        return pos;
    }

    public void GoToTarget(GameObject origem, int alvoIndex)
    {
        // Vector2 posOrigem = origem.transform.position;
        // Vector2 posAlvo = positions[alvoIndex];
        // Debug.Log("position: " + positions[1]);
        // Debug.Log("position: " + positions[alvoIndex]);
        origem.transform.position = _targetBlocksPositions[alvoIndex];
    }
    public void ReturnPositions(GameObject origem, Vector2 originalPositions)
    {
        for(int i = 0; i < 5; i++)
        {
            if (origem != null)
            {
                origem.transform.position = originalPositions;
            }
        }
    }
}
