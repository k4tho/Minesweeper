using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsPositions : MonoBehaviour
{
    public List<int> GetNearbyCellsIndexes(int currentCellIndex)
    {
        List<int> nearbyCellsIndexes = new List<int>();

        if (IsFirstColumn(currentCellIndex) == true)
        {
            nearbyCellsIndexes.Add(GetRightCellIndex(currentCellIndex));
            if (IsFirstRow(currentCellIndex) == false)
            {
                nearbyCellsIndexes.Add(GetTopRightCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetTopCenterCellIndex(currentCellIndex));
            }
            if (IsLastRow(currentCellIndex) == false)
            {
                nearbyCellsIndexes.Add(GetBottomRightCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetBottomCenterCellIndex(currentCellIndex));
            }
        }
        else if (IsLastColumn(currentCellIndex) == true)
        {
            nearbyCellsIndexes.Add(GetLeftCellIndex(currentCellIndex));
            if (IsFirstRow(currentCellIndex) == false)
            {
                nearbyCellsIndexes.Add(GetTopLeftCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetTopCenterCellIndex(currentCellIndex));
            }
            if (IsLastRow(currentCellIndex) == false)
            {
                nearbyCellsIndexes.Add(GetBottomLeftCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetBottomCenterCellIndex(currentCellIndex));
            }
        }
        else
        {
            nearbyCellsIndexes.Add(GetLeftCellIndex(currentCellIndex));
            nearbyCellsIndexes.Add(GetRightCellIndex(currentCellIndex));
            if (IsFirstRow(currentCellIndex) == false)
            {
                nearbyCellsIndexes.Add(GetTopLeftCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetTopCenterCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetTopRightCellIndex(currentCellIndex));
            }
            if (IsLastRow(currentCellIndex) == false)
            {
                nearbyCellsIndexes.Add(GetBottomLeftCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetBottomCenterCellIndex(currentCellIndex));
                nearbyCellsIndexes.Add(GetBottomRightCellIndex(currentCellIndex));
            }
        }

        return nearbyCellsIndexes;
    }



    public int GetLeftCellIndex(int currentCellIndex)
    {
        int leftCellIndex = currentCellIndex - 1;
        return leftCellIndex;
    }

    public int GetRightCellIndex(int currentCellIndex)
    {
        int rightCellIndex = currentCellIndex + 1;
        return rightCellIndex;
    }

    public int GetTopLeftCellIndex(int currentCellIndex)
    {
        int topLeftCellIndex = currentCellIndex - 21;
        return topLeftCellIndex;
    }

    public int GetTopCenterCellIndex(int currentCellIndex)
    {
        int topCenterCellIndex = currentCellIndex - 20;
        return topCenterCellIndex;
    }

    public int GetTopRightCellIndex(int currentCellIndex)
    {
        int topRightCellIndex = currentCellIndex - 19;
        return topRightCellIndex;
    }

    public int GetBottomLeftCellIndex(int currentCellIndex)
    {
        int bottomLeftCellIndex = currentCellIndex + 19;
        return bottomLeftCellIndex;
    }

    public int GetBottomCenterCellIndex(int currentCellIndex)
    {
        int bottomCenterCellIndex = currentCellIndex + 20;
        return bottomCenterCellIndex;
    }

    public int GetBottomRightCellIndex(int currentCellIndex)
    {
        int bottomRightCellIndex = currentCellIndex + 21;
        return bottomRightCellIndex;
    }





    public bool IsFirstColumn(int currentCellIndex)
    {
        if (currentCellIndex % 20 == 0)
            return true;
        return false;
    }

    public bool IsLastColumn(int currentCellIndex)
    {
        if (currentCellIndex % 20 == 19)
            return true;
        return false;
    }

    public bool IsFirstRow(int currentCellIndex)
    {
        if (currentCellIndex < 20)
            return true;
        return false;
    }
    public bool IsLastRow(int currentCellIndex)
    {
        if (currentCellIndex >= 240)
            return true;
        return false;
    }
}
