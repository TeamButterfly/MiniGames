using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TicTacToe
{
    public class TicTacToeAi
    {
        public class BestMove
        {
            public int Score { get; set; }
            public Tuple<int, int> Move { get; set; }
        }

        private static System.Timers.Timer stopAlphaBetaTimer;

        private static bool stopAlphaBeta = false;

        private static void StopAlphaBeta(Object source, ElapsedEventArgs e)
        {
            stopAlphaBeta = true;
        }

        public static void StartTimer()
        {
            //Stop med at lave Alpha Beta algoritmen efter 10 sek
            stopAlphaBetaTimer = new System.Timers.Timer(10000);
            stopAlphaBetaTimer.Elapsed += StopAlphaBeta;
            stopAlphaBetaTimer.AutoReset = true;
            stopAlphaBetaTimer.Enabled = true;
            stopAlphaBetaTimer.Start();
        }
        public static void StopTimer()
        {
            stopAlphaBetaTimer.Stop();
            stopAlphaBeta = false;
        }

        public static BestMove AlphaBeta(TicTacToeModel ticTacToeModel, int depth, int alpha, int beta, TicTacToeEnum maximizingPlayer, int squares)
        {
            // En implementering af Alpha Beta Min Max algoritmen

            var bestMove = new BestMove
            {
                Score = maximizingPlayer == TicTacToeEnum.Circle ? int.MinValue : int.MaxValue,
                Move = new Tuple<int, int>(-1, -1)
            };

            var moves = GetMoves(ticTacToeModel);

            ticTacToeModel.Winner = TicTacToeGame.CheckWinner(ticTacToeModel, squares);
            if (ticTacToeModel.Winner != TicTacToeEnum.None || moves.Count == 0 || stopAlphaBeta)
            {
                bestMove.Score = Evaluate(ticTacToeModel);
                ticTacToeModel.Winner = TicTacToeEnum.None;

                return bestMove;
            }
            ticTacToeModel.Winner = TicTacToeEnum.None;

            foreach (var move in moves)
            {
                ticTacToeModel.Board[move.Item1][move.Item2] = maximizingPlayer;
                if (maximizingPlayer == TicTacToeEnum.Circle)
                {
                    var score = AlphaBeta(ticTacToeModel, depth + 1, alpha, beta, TicTacToeEnum.Cross, squares).Score;
                    ticTacToeModel.Board[move.Item1][move.Item2] = TicTacToeEnum.None;

                    if(score > bestMove.Score)
                    {
                        bestMove.Score = score - depth * 10;
                        bestMove.Move = move;

                        alpha = Math.Max(alpha, score);

                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    var score = AlphaBeta(ticTacToeModel, depth + 1, alpha, beta, TicTacToeEnum.Circle, squares).Score;
                    ticTacToeModel.Board[move.Item1][move.Item2] = TicTacToeEnum.None;

                    if (score < bestMove.Score)
                    {
                        bestMove.Score = score + depth * 10;
                        bestMove.Move = move;

                        beta = Math.Min(beta, score);

                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }
            }
            return bestMove;
        }

        private static int Evaluate(TicTacToeModel ticTacToeModel)
        {
            int evalValue;
            if (ticTacToeModel.Winner == TicTacToeEnum.Circle)
            {
                evalValue = 1000;
            }
            else if (ticTacToeModel.Winner == TicTacToeEnum.Cross)
            {
                evalValue = -1000;
            }
            else
            {
                evalValue = 1;
            }
            return evalValue;
        }

        private static List<Tuple<int, int>> GetMoves(TicTacToeModel ticTacToeModel)
        {
            var moves = new List<Tuple<int, int>>();

            for (var i = 0; i < ticTacToeModel.Board.Count; i++)
            {
                for (var j = 0; j < ticTacToeModel.Board[i].Count; j++)
                {
                    if (ticTacToeModel.Board[i][j] == TicTacToeEnum.None)
                    {
                        moves.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            return moves;
        }
    }
}
