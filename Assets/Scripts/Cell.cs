
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Cells Cells;
    public Image CellImage;

    private int cellValue;
    private bool clickableCell;
    private bool isPressed;
    private bool isFlagged;


    public void OnClick()
    {
        if (CheckIfClickable() == false)
            return;

        isPressed = true;
        RevealCellImage();
    }

    public void FlagAndUnflag()
    {
        if (isFlagged == false)
        {
            isFlagged = true;
            Cells.FlagCell(this);
        }
        else
        {
            isFlagged = false;
            Cells.UnflagCell(this);
        }
    }

    public bool CheckIfClickable()
    {
        if ((isPressed == true) || (isFlagged == true))
            clickableCell = false;
        return clickableCell;
    }

    public void ResetCell()
    {
        SetCellValue(0);
        isPressed = false;
        isFlagged = false;
        clickableCell = true;
        ResetCellImage();
    }

    public void ResetCellImage()
    {
        Cells.ResetCellImage(this);
    }

    public void RevealCellImage()
    {
        CellImage.sprite = Cells.RevealCellImage(this);
    }

    public bool IsMine()
    {
        if (cellValue == 9)
            return true;
        return false;
    }

    public void SetCellImage(Sprite sprite)
    {
        CellImage.sprite = sprite;
    }

    public void SetCellValue(int cellValue)
    {
        this.cellValue = cellValue;
    }

    public void SetClickableCell(bool clickable)
    {
        clickableCell = clickable;
    }

    public int GetCellValue()
    {
        return cellValue;
    }

    public bool GetFlaggedValue()
    {
        return isFlagged;
    }
}
