using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    public MinesweeperGame MinesweeperGame;
    public CellsPositions CellsPositions;

    public Sprite ExplodedMine;
    public Sprite UnexplodedMine;
    public Sprite UnknownSprite;
    public Sprite FlaggedSprite;

    public List<Sprite> CellSprites = new List<Sprite>();
    public List<Cell> CellsOnBoard = new List<Cell>();

    private Coroutine revealingExplodingMine;

    private bool mineClicked;
    private int mineExplodingIndex = 0;
    private List<int> MinesIndex;


    void Start()
    {

    }

    public void FlagCell(Cell cell)
    {
        ChangeToFlaggedSprite(cell);
        MakeCellNonClickable(cell);
        MinesweeperGame.CellWasFlagged();
    }

    public void UnflagCell(Cell cell)
    {
        ChangeToUnflaggedSprite(cell);
        MakeCellClickable(cell);
        MinesweeperGame.CellWasUnflagged();
    }

    public Sprite RevealCellImage(Cell cell)
    {
        CellIsClicked(cell);

        int cellValue = cell.GetCellValue();
        return CellSprites[cellValue];
    }

    public void CellIsClicked(Cell cell)
    {
        if (CheckIfClickedOnMine(cell) == true)
        {
            MinesweeperGame.MineIsClicked();
        }
        else
        {
            MinesweeperGame.MineWasNotClicked();
            ClearNearbyEmptyCells(cell);
        }
    }

    public void ShowNumbersAroundEmptyCell(Cell cell)
    {
        int currentCellIndex = CellsOnBoard.IndexOf(cell);
        List<int> nearbyCellsIndexes = GetNearbyCellsIndexes(currentCellIndex);

        foreach (int index in nearbyCellsIndexes)
        {
            Cell cellAtIndex = CellsOnBoard[index];
            if (cellAtIndex.GetCellValue() != 9)
                cellAtIndex.OnClick();
        }
    }

    public void ClearNearbyEmptyCells(Cell cell)
    {
        int currentCellIndex = CellsOnBoard.IndexOf(cell);
        List<int> nearbyCellsIndexes = GetNearbyCellsIndexes(currentCellIndex);
        
        
        foreach (int index in nearbyCellsIndexes){
            Cell cellAtIndex = CellsOnBoard[index];
            if (cellAtIndex.GetCellValue() == 0)
            {
                cellAtIndex.OnClick();
                ShowNumbersAroundEmptyCell(cellAtIndex);
            }                                      
        }
    }
    
    public List<int> GetNearbyCellsIndexes(int currentCellIndex)
    {
        return CellsPositions.GetNearbyCellsIndexes(currentCellIndex);
    }
    

    public bool CheckIfClickedOnMine(Cell cell)
    {
        if (cell.IsMine() == true)
            mineClicked = true;
        return mineClicked;
    }

    public List<int> FindAllMinesIndex()
    {
        List<int> MinesIndex = new List<int>();

        foreach (Cell cell in CellsOnBoard)
        {
            if (cell.GetCellValue() == 9)
                MinesIndex.Add(CellsOnBoard.IndexOf(cell));
        }

        return MinesIndex;
    }

    public void RevealMines()
    {
        MinesIndex = FindAllMinesIndex();
        mineExplodingIndex = 0;
        revealingExplodingMine = StartCoroutine(PauseForMineExplosion(CellsOnBoard[MinesIndex[mineExplodingIndex]]));
    }

    IEnumerator PauseForMineExplosion(Cell cell)
    {
        yield return new WaitForSeconds(.1f);

        if (mineClicked == true)
            RevealExplodedMine(cell);
        else
            RevealUnexplodedMine(cell);
        mineExplodingIndex = mineExplodingIndex + 1;
        if (mineExplodingIndex < MinesIndex.Count)
            revealingExplodingMine = StartCoroutine(PauseForMineExplosion(CellsOnBoard[MinesIndex[mineExplodingIndex]]));
    }

    public void RevealExplodedMine(Cell cell)
    {
        cell.SetCellImage(ExplodedMine);
    }

    public void RevealUnexplodedMine(Cell cell)
    {
        cell.SetCellImage(UnexplodedMine);
    }

    public void ChangeToFlaggedSprite(Cell cell)
    {
        cell.SetCellImage(FlaggedSprite);
    }

    public void ChangeToUnflaggedSprite(Cell cell)
    {
        ResetCellImage(cell);
    }

    public void MakeCellClickable(Cell cell)
    {
        cell.SetClickableCell(true);
    }

    public void MakeCellNonClickable(Cell cell)
    {
        cell.SetClickableCell(false);
    }

    public List<Cell> GetCellsOnBoard()
    {
        return CellsOnBoard;
    }

    public int GetCellIndex(Cell cell)
    {
        return CellsOnBoard.IndexOf(cell);
    }

    public void ResetCells()
    {
        if (revealingExplodingMine != null)
            StopCoroutine(revealingExplodingMine);
        mineClicked = false;

        foreach (Cell cell in CellsOnBoard)
        {
            cell.ResetCell();
        }
    }

    public void ResetCellImage(Cell cell)
    {
        cell.SetCellImage(UnknownSprite);
    }
}
