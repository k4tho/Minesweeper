using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameBoard : MonoBehaviour
{
    public Cells Cells;
    public CellsPositions CellsPositions;

    void Start()
    {

    }

    public void RestartNewGame()
    {
        Cells.ResetCells();
        SetValuesForNewMineCells();
        SetNewValuesForNumberCells();
    }

    public void SetNewValuesForNumberCells()
    {
        foreach (Cell cell in Cells.GetCellsOnBoard())
        {
            if (cell.GetCellValue() != 9) 
                cell.SetCellValue(GetValueOfNumberCell(cell));
        }
    }

    public void SetValuesForNewMineCells()
    {
        List<int> newMineIndexes = GetNewMineIndexes();

        foreach (int cellIndex in newMineIndexes)
        {
            (Cells.GetCellsOnBoard())[cellIndex].SetCellValue(9);
        }
    }

    public int GetValueOfNumberCell(Cell cell)
    {
        return CheckForNearbyMines(cell);
    }


    public List<int> GetNewMineIndexes()
    {
        List<int> NewMineIndexes = new List<int>();

        while (NewMineIndexes.Count < GameParameters.NumberOfMines)
        {
            int newMineIndex = Random.Range(0, GameParameters.NumberOfCells);
            if (!(NewMineIndexes.Contains(newMineIndex)))
                NewMineIndexes.Add(newMineIndex);
        }

        return NewMineIndexes;
    }

    public int CheckForNearbyMines(Cell cell)
    {
        int cellIndex = Cells.GetCellIndex(cell);
        int nearbyMines = 0;

        
        if (CellsPositions.IsFirstColumn(cellIndex) == true)                                                
        {
            if (CheckForMineToTheRight(cellIndex) == true)
                nearbyMines += 1;
            if (CellsPositions.IsFirstRow(cellIndex) == false)                                                
            {
                if (CheckForMineToTheTopCenter(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheTopRight(cellIndex) == true)
                    nearbyMines += 1;
            }
            if (CellsPositions.IsLastRow(cellIndex) == false)                                                
            {
                if (CheckForMineToTheBottomCenter(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheBottomRight(cellIndex) == true)
                    nearbyMines += 1;
            }
        }
        
        else if (CellsPositions.IsLastColumn(cellIndex) == true)                                           
        {
            if(CheckForMineToTheLeft(cellIndex) == true)
                nearbyMines += 1;
            if (CellsPositions.IsFirstRow(cellIndex) == false)
            {
                if (CheckForMineToTheTopCenter(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheTopLeft(cellIndex) == true)
                    nearbyMines += 1;
            }
            if (CellsPositions.IsLastRow(cellIndex) == false)
            {
                if (CheckForMineToTheBottomCenter(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheBottomLeft(cellIndex) == true)
                    nearbyMines += 1;
            }
        }
   
        else
        {                                                                       
            if (CellsPositions.IsFirstRow(cellIndex) == false)
            {
                if (CheckForMineToTheTopLeft(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheTopCenter(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheTopRight(cellIndex) == true)
                    nearbyMines += 1;
            }
            if (CellsPositions.IsLastRow(cellIndex) == false)
            {
                if (CheckForMineToTheBottomLeft(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheBottomCenter(cellIndex) == true)
                    nearbyMines += 1;
                if (CheckForMineToTheBottomRight(cellIndex) == true)
                    nearbyMines += 1;
            }
            if (CheckForMineToTheLeft(cellIndex) == true)
                nearbyMines += 1;
            if (CheckForMineToTheRight(cellIndex) == true)
                nearbyMines += 1;
        }

        return nearbyMines;
    }



    public bool CheckForMineToTheLeft(int cellIndex)
    {
        int leftCellIndex = CellsPositions.GetLeftCellIndex(cellIndex);
        Cell leftCell = Cells.GetCellsOnBoard()[leftCellIndex];

        if (leftCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }

    public bool CheckForMineToTheRight(int cellIndex)
    {
        int rightCellIndex = CellsPositions.GetRightCellIndex(cellIndex);
        Cell rightCell = Cells.GetCellsOnBoard()[rightCellIndex];

        if (rightCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }

    public bool CheckForMineToTheTopLeft(int cellIndex)
    {
        int topLeftCellIndex = CellsPositions.GetTopLeftCellIndex(cellIndex);
        Cell topLeftCell = Cells.GetCellsOnBoard()[topLeftCellIndex];

        if (topLeftCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }

    public bool CheckForMineToTheTopCenter(int cellIndex)
    {
        int topCenterCellIndex = CellsPositions.GetTopCenterCellIndex(cellIndex); ;
        Cell topCenterCell = Cells.GetCellsOnBoard()[topCenterCellIndex];

        if (topCenterCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }

    public bool CheckForMineToTheTopRight(int cellIndex)
    {
        int topRightCellIndex = CellsPositions.GetTopRightCellIndex(cellIndex); ;
        Cell topRightCell = Cells.GetCellsOnBoard()[topRightCellIndex];

        if (topRightCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }

    public bool CheckForMineToTheBottomLeft(int cellIndex)
    {
        int bottomLeftCellIndex = CellsPositions.GetBottomLeftCellIndex(cellIndex);
        Cell bottomLeftCell = Cells.GetCellsOnBoard()[bottomLeftCellIndex];

        if (bottomLeftCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }

    public bool CheckForMineToTheBottomCenter(int cellIndex)
    {
        int bottomCenterCellIndex = CellsPositions.GetBottomCenterCellIndex(cellIndex);
        Cell bottomCenterCell = Cells.GetCellsOnBoard()[bottomCenterCellIndex];

        if (bottomCenterCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }

    public bool CheckForMineToTheBottomRight(int cellIndex)
    {
        int bottomCenterCellIndex = CellsPositions.GetBottomRightCellIndex(cellIndex);
        Cell bottomCenterCell = Cells.GetCellsOnBoard()[bottomCenterCellIndex];

        if (bottomCenterCell.GetCellValue() == 9)
        {
            return true;
        }
        return false;
    }
}