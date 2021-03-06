using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public enum CheckLineEnum
        {
            Row, Col, DiagonalTop, DiagonalBottom
        }

        private int squares;
        private TicTacToeModel ticTacToeModel;
        private TicTacToeEnum turn;

        public TicTacToeModel ResetGame(int squares)
        {
            this.squares = squares;
            turn = TicTacToeEnum.Cross;
            ticTacToeModel = new TicTacToeModel
            {
                Board = new List<List<TicTacToeEnum>>(),
                Winner = TicTacToeEnum.None
            };
            for (int i = 0; i < squares; i++)
            {
                var row = new List<TicTacToeEnum>();
                for (int j = 0; j < squares; j++)
                {
                    row.Add(TicTacToeEnum.None);
                }
                ticTacToeModel.Board.Add(row);
            }
            return ticTacToeModel;
        }

        public TicTacToeModel SetField(int row, int col)
        {
            ticTacToeModel = SetField(row, col, ticTacToeModel);
            if (ticTacToeModel.Winner == TicTacToeEnum.None && turn == TicTacToeEnum.Circle)
            {
                TicTacToeAi.StartTimer();
                var bestMove = TicTacToeAi.AlphaBeta(ticTacToeModel, 0, int.MinValue, int.MaxValue, TicTacToeEnum.Circle, squares);
                TicTacToeAi.StopTimer();
                ticTacToeModel = SetField(bestMove.Move.Item1, bestMove.Move.Item2, ticTacToeModel);
                ticTacToeModel.Winner = CheckWinner(ticTacToeModel, squares);
            }

            return ticTacToeModel;
        }
        private TicTacToeModel SetField(int row, int col, TicTacToeModel ticTacToeModel)
        {
            if (row >= squares || row < 0 || col >= squares || col < 0 || ticTacToeModel.Winner != TicTacToeEnum.None)
            {
                return ticTacToeModel;
            }

            if (ticTacToeModel.Board[row][col] == TicTacToeEnum.None)
            {
                ticTacToeModel.Board[row][col] = turn;
                turn = turn == TicTacToeEnum.Cross ? TicTacToeEnum.Circle : TicTacToeEnum.Cross;
            }
            ticTacToeModel.Winner = CheckWinner(ticTacToeModel, squares);

            return ticTacToeModel;
        }

        public static TicTacToeEnum CheckWinner(TicTacToeModel ticTacToeModel, int squares)
        {
            TicTacToeEnum ticTacToeEnumWinner;

            //Tjekker rows [i, j] -> [i+1, j+1]
            ticTacToeEnumWinner = CheckLine(CheckLineEnum.Row, ticTacToeModel, squares);
            if (ticTacToeEnumWinner != TicTacToeEnum.None) return ticTacToeEnumWinner;

            //Tjekker columns [j, i] -> [j+1, i+1]
            ticTacToeEnumWinner = CheckLine(CheckLineEnum.Col, ticTacToeModel, squares);
            if (ticTacToeEnumWinner != TicTacToeEnum.None) return ticTacToeEnumWinner;

            //Tjekker diagonalt [i,i] -> [i+1, i+1]
            ticTacToeEnumWinner = CheckLine(CheckLineEnum.DiagonalTop, ticTacToeModel, squares);
            if (ticTacToeEnumWinner != TicTacToeEnum.None) return ticTacToeEnumWinner;

            //Tjekker diagonalt [i,i] -> [i-1, i+1]
            ticTacToeEnumWinner = CheckLine(CheckLineEnum.DiagonalBottom, ticTacToeModel, squares);
            if (ticTacToeEnumWinner != TicTacToeEnum.None) return ticTacToeEnumWinner;

            return ticTacToeEnumWinner;
        }
        public static TicTacToeEnum CheckLine(CheckLineEnum checkLineEnum, TicTacToeModel ticTacToeModel, int squares)
        {
            TicTacToeEnum? previousElement = null;
            var gameOver = true;

            if (checkLineEnum == CheckLineEnum.Row || checkLineEnum == CheckLineEnum.Col)
            {
                for (int i = 0; i < squares; i++)
                {
                    previousElement = null;
                    gameOver = true;
                    for (int j = 0; j < squares; j++)
                    {
                        TicTacToeEnum field = ticTacToeModel.Board[i][j];
                        if (checkLineEnum == CheckLineEnum.Row)
                        {
                            field = ticTacToeModel.Board[i][j];
                        }
                        else if (checkLineEnum == CheckLineEnum.Col)
                        {
                            field = ticTacToeModel.Board[j][i];
                        }

                        if (field == TicTacToeEnum.None)
                        {
                            gameOver = false;
                            break;
                        }
                        if (!previousElement.HasValue)
                        {
                            previousElement = field;
                            continue;
                        }

                        if (field != previousElement)
                        {
                            gameOver = false;
                            break;
                        }
                        previousElement = field;
                    }
                    if (gameOver && previousElement.HasValue) return previousElement.Value;
                }
            }
            else
            {
                for (int i = 0; i < squares; i++)
                {
                    TicTacToeEnum field = ticTacToeModel.Board[i][i];
                    if (checkLineEnum == CheckLineEnum.DiagonalTop)
                    {
                        field = ticTacToeModel.Board[i][i];
                    }
                    else if (checkLineEnum == CheckLineEnum.DiagonalBottom)
                    {
                        field = ticTacToeModel.Board[squares - 1 - i][i];
                    }

                    if (field == TicTacToeEnum.None)
                    {
                        gameOver = false;
                        break;
                    }
                    if (!previousElement.HasValue)
                    {
                        previousElement = field;
                        continue;
                    }

                    if (field != previousElement)
                    {
                        gameOver = false;
                        break;
                    }
                    previousElement = field;
                }
            }

            if (gameOver && previousElement.HasValue)
            {
                return previousElement.Value;
            }
            else
            {
                return TicTacToeEnum.None;
            }
        }

    }
}
