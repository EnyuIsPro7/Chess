using ChessLogic;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    public partial class GameOverMenu : UserControl
    {

        public event Action<Option> OptionSelected;

        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "White wins!",
                Player.Black => "Black wins!",
                _ => "It's a draw!"
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "White",
                Player.Black => "Black",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason reason, Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Checkmate => $"Checkmate! - {PlayerString(currentPlayer)} LOST",
                EndReason.Stalemate => $"Stalemate! - {PlayerString(currentPlayer)} CAN'T MOVE",
                EndReason.FiftyMoveRule => "Fifty-move rule",
                EndReason.InsufficientMaterial => "Insufficient material!",
                EndReason.ThreefoldRepetition => "Three-fold repetition!",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
