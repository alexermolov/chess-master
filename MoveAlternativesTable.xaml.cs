using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

using ChessMaster.Core;
using ChessMaster.Services;

namespace ChessMaster
{
    public class NewGameMoveSelectedEventArg : System.ComponentModel.CancelEventArgs
    {
        public int NewStepIndex { get; set; }
        public int NewGameIndex { get; set; }

        public NewGameMoveSelectedEventArg(int newStepIndex, int newGameIndex) : base(false)
        {
            NewStepIndex = newStepIndex;
            NewGameIndex = newGameIndex;
        }
    }

    /// <summary>
    /// Interaction logic for MoveAlternativesTable.xaml
    /// </summary>
    public partial class MoveAlternativesTable : UserControl
    {
        public event EventHandler<NewGameMoveSelectedEventArg>? NewMoveSelected;

        private bool _ignoreChange;
        private ChessBoardControl? _chessControl;

        public ChessBoardControl? ChessControl
        {
            get => _chessControl;
            set
            {
                if (_chessControl != value)
                {
                    if (_chessControl != null)
                    {
                        _chessControl.BoardReset -= ChessCtl_BoardReset;
                    }
                    _chessControl = value;
                    if (_chessControl != null)
                    {
                        _chessControl.BoardReset += ChessCtl_BoardReset;
                    }
                }
            }
        }

        // Events
        private void ChessCtl_BoardReset(object? sender, EventArgs e) => LoadMovesToGrid();
        protected void OnNewMoveSelected(NewGameMoveSelectedEventArg e) => NewMoveSelected?.Invoke(this, e);

        public MoveAlternativesTable()
        {
            InitializeComponent();

            DataContext = this;
            MovesDataGrid.KeyUp += MovesDataGrid_KeyUp;
            MovesDataGrid.MouseUp += MovesDataGrid_MouseUp;

            var bc = (Brush)new BrushConverter().ConvertFrom("#212121");
            Background = bc;
            GridControl.Background = bc;
            MovesDataGrid.Background = bc;
        }

        private void MovesDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UpdateSelectedPosition();
        }

        private void MovesDataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key is Key.Left or Key.Right or Key.Up or Key.Down)
            {
                UpdateSelectedPosition();
            }
        }

        private void UpdateSelectedPosition()
        {
            if (MovesDataGrid.CurrentCell.Column == null)
            {
                return;
            }

            var index = MovesDataGrid.CurrentCell.Column.DisplayIndex;
            var titleIndex = MovesDataGrid.CurrentCell.Column.Header.ToString().Split(' ').Last();
            var gameIndex = int.Parse(titleIndex);

            if (MovesDataGrid.SelectedValue is MultiBinding val)
            {
                var itemIndex = MovesDataGrid.Items.IndexOf(MovesDataGrid.SelectedValue);

                var prop = val.GetType().GetProperty($"Move_{index}");
                var step = prop.GetValue(val);

                FireSelectionChangeNotifyEvent(itemIndex, gameIndex);
            }
        }

        private void FireSelectionChangeNotifyEvent(int newStepIndex, int newGameIndex)
        {
            NewGameMoveSelectedEventArg evArg;
            int curPos;
            ChessBoard chessBoard;

            if (!_ignoreChange && !_chessControl!.IsBusy && !ChessBoardControl.IsSearchEngineBusy)
            {
                _ignoreChange = true;
                chessBoard = _chessControl!.Board;
                curPos = chessBoard.MovePosStack.PositionInList;

                evArg = new NewGameMoveSelectedEventArg(newStepIndex, newGameIndex);
                OnNewMoveSelected(evArg);
                if (evArg.Cancel)
                {
                    //if (curPos == -1)
                    //{
                    //    listViewMoveList.SelectedItems.Clear();
                    //}
                    //else
                    //{
                    //    listViewMoveList.SelectedIndex = curPos;
                    //}
                }

                _ignoreChange = false;
            }
        }

        public void LoadMovesToGrid()
        {
            if (!GameService.NewlyInitialized)
            {
                return;
            }

            GameService.NewlyInitialized = false;
            MovesDataGrid.Columns.Clear();
            MovesDataGrid.Items.Clear();

            var games = GameService.Games;

            var maxMoves = games.Max(x => x.SanMoves.Count);

            var list = new List<MultiBinding>();

            for (int i = 0; i < maxMoves; i++)
            {
                list.Add(new MultiBinding());
            }

            for (int i = 0; i < games.Count; i++)
            {
                MovesDataGrid.Columns.Add(new DataGridTextColumn { Header = $"Game {i}", Binding = new Binding($"Move_{i}") });

                for (int j = 0; j < games[i].SanMoves.Count; j++)
                {
                    var item = list[j];
                    var val = games[i].SanMoves[j];

                    var prop = item.GetType().GetProperty($"Move_{i}");
                    if (prop != null && prop.CanWrite)
                    {
                        prop.SetValue(item, val, null);
                    }
                }
            }

            foreach (var item in list)
            {
                MovesDataGrid.Items.Add(item);
            }
        }
    }

    public class MultiBinding
    {
        public string Move_0 { get; set; }
        public string Move_1 { get; set; }
        public string Move_2 { get; set; }
        public string Move_3 { get; set; }
        public string Move_4 { get; set; }
        public string Move_5 { get; set; }
        public string Move_6 { get; set; }
        public string Move_7 { get; set; }
        public string Move_8 { get; set; }
        public string Move_9 { get; set; }
        public string Move_10 { get; set; }
        public string Move_11 { get; set; }
        public string Move_12 { get; set; }
        public string Move_13 { get; set; }
        public string Move_14 { get; set; }
        public string Move_15 { get; set; }
        public string Move_16 { get; set; }
        public string Move_17 { get; set; }
        public string Move_18 { get; set; }
        public string Move_19 { get; set; }
        public string Move_20 { get; set; }
        public string Move_21 { get; set; }
        public string Move_22 { get; set; }
        public string Move_23 { get; set; }
        public string Move_24 { get; set; }
        public string Move_25 { get; set; }
        public string Move_26 { get; set; }
        public string Move_27 { get; set; }
        public string Move_28 { get; set; }
        public string Move_29 { get; set; }
        public string Move_30 { get; set; }
    }
}
