
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesweeperGame : MonoBehaviour
{
    public Cells Cells;
    public NewGameBoard NewGameBoard;

    public Image RestartButtonImage;
    public Text TimerText;
    public Text FlagText;

    public Sprite SmileyFace;
    public Sprite SadFace;

    private Coroutine addingSecondCoroutine;

    private bool addingSecond = false;
    private bool gameHasEnded = false;
    private bool firstCellClicked = false;

    private int numCellsRemaining;
    private int numFlagsRemaining;
    private int timeElapsed;


    void Start()
    {
        RestartGame();
    }

    void Update()
    {
        ShowTimer();
        ShowNumFlagsRemaining();
    }

    public void RestartGame()
    {
        if (addingSecondCoroutine != null)
            StopCoroutine(addingSecondCoroutine);
        gameHasEnded = false;
        firstCellClicked = false;
        SetSmileyRestartButton();
        NewGameBoard.RestartNewGame();
        timeElapsed = 0;
        addingSecond = false;
        numCellsRemaining = GameParameters.NumberOfSafeCells;
        numFlagsRemaining = GameParameters.NumberOfFlags;
    }

    public void MineIsClicked()
    {
        PlayerLoses();
    }

    public void MineWasNotClicked()
    {
        if (firstCellClicked == false)
            firstCellClicked = true;
        numCellsRemaining -= 1;
        CheckForEndOfGame();
    }

    public void CheckForEndOfGame()
    {
        if (numCellsRemaining == 0)
            PlayerWins();
    }

    public void PlayerWins()
    {
        EndGame();
    }

    public void PlayerLoses()
    {
        SetSadFaceRestartButton();
        EndGame();
    }

    public void EndGame()
    {
        gameHasEnded = true;
        Cells.RevealMines();
        StopCellClicking();
        StopTimer();
    }



    public void StopCellClicking()
    {
        foreach (Cell cell in Cells.GetCellsOnBoard())
        {
            Cells.MakeCellNonClickable(cell);
        }
    }

    public void StopTimer()
    {
        gameHasEnded = true;
    }

    public void ShowTimer()
    {
        TimerText.text = timeElapsed.ToString();
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (gameHasEnded == true)
            return;
        if (timeElapsed == 999)
            return;
        if (firstCellClicked == false)
            return;
        else if (addingSecond == false)
             addingSecondCoroutine =  StartCoroutine(pauseForASecond());
    }

    IEnumerator pauseForASecond()
    {
        addingSecond = true;
        yield return new WaitForSeconds(1);
        timeElapsed += 1;
        addingSecond = false;
    }

    public void CellWasFlagged()
    {
        numFlagsRemaining -= 1;
    }

    public void CellWasUnflagged()
    {
        numFlagsRemaining += 1;
    }

    public void ShowNumFlagsRemaining()
    {
        FlagText.text = numFlagsRemaining.ToString();
    }

    public void SetSmileyRestartButton()
    {
        RestartButtonImage.sprite = SmileyFace;
    }

    public void SetSadFaceRestartButton()
    {
        RestartButtonImage.sprite = SadFace;
    }

}

