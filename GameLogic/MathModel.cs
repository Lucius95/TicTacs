using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class MyEventArgs : EventArgs
    {
        public int X;
        public int Y;
    }

    public class UiMove
    {
        public int x;
        public int y;
        public bool val;

        public UiMove(int x_, int y_, bool val_)
        {
            x = x_;
            y = y_;
            val = val_;
        }
    }

    public class MathModel : IDisposable
    {
        private bool[,] _uiMoveCell;

        public UiMove UiMoveCell
        {
            set
            {
                _uiMoveCell[value.x, value.y] = value.val;
                EventСhangeOfState?.Invoke(value.x, value.y);
            }
        }

        public bool flagFinish;
        public bool flagStart;
        public SizeField sizeFile;
        public Player[] Players = new Player[2];
        public Player player0;
        public Player player1;
        public Player winner;
        public EnumResultGame ResultGame;
        public PointerPlayer pointerPlayer;
        public bool dispose;
        public PlayingField playingField;

        public delegate void EventHandler(int x, int y);
        public event EventHandler EventСhangeOfState;

        public MathModel(SizeField sizeFile_)
        {
            EventСhangeOfState += UpdateModel;
            player0 = new Player(EnumGameCell.EnumZero);
            player1 = new Player(EnumGameCell.EnumCross);
            Players[0] = player0;
            Players[1] = player1;
            sizeFile = sizeFile_;

            pointerPlayer = new PointerPlayer(Players);
            playingField = new PlayingField(sizeFile);
            _uiMoveCell = new bool[sizeFile.Width, sizeFile.Height];
            for (int i = 0; i < sizeFile.Width; i++)
            {
                for (int j = 0; j < sizeFile.Height; j++)
                {
                    _uiMoveCell[i, j] = false;
                }
            }
        }

        public void ModelThread()
        {
            //Мониторинг событий
            while (!dispose)
            {
                //if (IsNewState())
                //{
                //    EventСhangeOfState?.Invoke();
                //}
            }
        }

        public void UpdateModel(int x, int y)
        {
            //Сделаный ход
            if (!EqualArr(_uiMoveCell, playingField.PlayingCellBinary))
            {
                playingField.GameMove(x, y, pointerPlayer.currentPlayer);
                pointerPlayer.NextPlayer();
            }

            //Условие конца
            if (playingField.IsFinished() != EnumResultGame.Game)
            {
                ResultGame = playingField.IsFinished();
                winner = playingField.Winner;
                flagFinish = true;
            }
        }

        public bool EqualArr(bool[,] arr1, bool[,] arr2)
        {
            var flag = true;
            
            if (arr1.GetLength(0) == arr2.GetLength(0))
            {
                if (arr1.GetLength(1) != arr2.GetLength(1))
                    return false;
            }
            else
                return false;

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    flag = flag & (arr1[i, j] == arr2[i, j]);
                }
            }
            return flag;
        }

        public void Dispose()
        {
            dispose = true;
        }
    }
}
