using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class SizeField
    {
        public uint Width;
        public uint Height;

        public SizeField(uint width_, uint height_)
        {
            Width = width_;
            Height = height_;
        }
    }

    public class PlayingField
    {
        private SizeField _sizeFile;

        public Player[,] PlayingCell;
        public bool[,] PlayingCellBinary;
        public Player Winner;

        public PlayingField(SizeField sizeFile)
        {
            _sizeFile = sizeFile;

            PlayingCell = new Player[_sizeFile.Width, _sizeFile.Height];
            PlayingCellBinary = new bool[_sizeFile.Width, _sizeFile.Height];
            for (int i = 0; i < _sizeFile.Width; i++)
            {
                for (int j = 0; j < _sizeFile.Height; j++)
                {
                    PlayingCell[i, j] = null;
                    PlayingCellBinary[i, j] = false;
                }
            }
        }

        public void GameMove(int x, int y, Player playerCell)
        {
            PlayingCell[x, y] = playerCell;
            PlayingCellBinary[x, y] = true;
        }

        public Player DetermineWinner()
        {
            return PlayingCell[0, 0];
        }

        public Player GetWinner()
        {
            Player[] playerLine = new Player[8];
            playerLine[0] = (PlayingCell[0, 0] == PlayingCell[0, 1]) && (PlayingCell[0, 0] == PlayingCell[0, 2]) ? PlayingCell[0, 0] : null;
            playerLine[1] = (PlayingCell[1, 0] == PlayingCell[1, 1]) && (PlayingCell[1, 0] == PlayingCell[1, 2]) ? PlayingCell[1, 0] : null;
            playerLine[2] = (PlayingCell[2, 0] == PlayingCell[2, 1]) && (PlayingCell[2, 0] == PlayingCell[2, 2]) ? PlayingCell[2, 0] : null;
            playerLine[3] = (PlayingCell[0, 0] == PlayingCell[1, 0]) && (PlayingCell[0, 0] == PlayingCell[2, 0]) ? PlayingCell[0, 0] : null;
            playerLine[4] = (PlayingCell[0, 1] == PlayingCell[1, 1]) && (PlayingCell[0, 1] == PlayingCell[2, 1]) ? PlayingCell[0, 1] : null;
            playerLine[5] = (PlayingCell[0, 2] == PlayingCell[1, 2]) && (PlayingCell[0, 2] == PlayingCell[2, 2]) ? PlayingCell[0, 2] : null;
            playerLine[6] = (PlayingCell[0, 0] == PlayingCell[1, 1]) && (PlayingCell[0, 0] == PlayingCell[2, 2]) ? PlayingCell[0, 0] : null;
            playerLine[7] = (PlayingCell[0, 2] == PlayingCell[1, 1]) && (PlayingCell[2, 0] == PlayingCell[0, 2]) ? PlayingCell[0, 2] : null;

            for (int i = 0; i < 8; i++)
            {
                if (playerLine[i] != null)
                {
                    Winner = playerLine[i];
                    return playerLine[i];
                }
            }

            return null;
        }

        public EnumResultGame IsFinished()
        {
            if (GetWinner() != null)
                return EnumResultGame.Winner;

            var flag = true;
            for (int i = 0; i < _sizeFile.Width; i++)
            {
                for (int j = 0; j < _sizeFile.Height; j++)
                {
                    flag = flag & PlayingCellBinary[i, j];
                }
            }

            if (flag)
                return EnumResultGame.Draw;

            return EnumResultGame.Game;
        }
    }


    public class Player
    {
        public EnumGameCell GameCell;

        public Player(EnumGameCell gameCell_)
        {
            GameCell = gameCell_;
        }

        public override string ToString()
        {
            switch (GameCell)
            {
                case EnumGameCell.EnumZero:
                    return "0";
                case EnumGameCell.EnumCross:
                    return "X";
                default:
                    return "Unknown";
            };
        }
    }

    public class PointerPlayer
    {
        private Player[] _players;

        public Player currentPlayer;

        public PointerPlayer(Player[] players)
        {
            _players = players;
            currentPlayer = _players[0];
        }

        public void NextPlayer()
        {
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i] != currentPlayer)
                {
                    currentPlayer = _players[i];
                    break;
                }
            }
        }
    }

    public enum EnumResultGame
    { 
        Winner = 1,
        Draw = 2,
        Game = 3
    }

    //Виды игровых ячеек
    public enum EnumGameCell
    {
        EnumCross = 1,
        EnumZero = 2,
        EnumEmpty = 3
    }
}
