using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Starter;
using GameLogic;
using System.Threading;

namespace TicTacs.ViewModel
{
    class Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
    }

    class MainViewModel : INotifyPropertyChanged
    {
        public MathModel modelObj;
        public SizeField gameSize;
        public Thread ModelThread;

        public bool[,] PlayingField;

        private ICommand _buttonAdd;

        public ICommand ButtonAdd
        {
            get
            {                
                return _buttonAdd ??
                      (_buttonAdd = new DelegateCommand((obj) =>
                      {
                          Coordinate coordinate = obj as Coordinate;
                          if (coordinate != null)
                          {                              
                              modelObj.UiMoveCell = new UiMove(coordinate.X, coordinate.Y, true);
                          }
                      }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #region Binding Coordinate
        public Coordinate _field00 = new Coordinate(0, 0);
        public Coordinate _field01 = new Coordinate(0, 1);
        public Coordinate _field02 = new Coordinate(0, 2);
        public Coordinate _field10 = new Coordinate(1, 0);
        public Coordinate _field11 = new Coordinate(1, 1);
        public Coordinate _field12 = new Coordinate(1, 2);
        public Coordinate _field20 = new Coordinate(2, 0);
        public Coordinate _field21 = new Coordinate(2, 1);
        public Coordinate _field22 = new Coordinate(2, 2);

        public Coordinate Field00
        {
            get { return _field00; }

        }
        public Coordinate Field01
        {
            get { return _field01; }

        }
        public Coordinate Field02
        {
            get { return _field02; }

        }
        public Coordinate Field10
        {
            get { return _field10; }

        }
        public Coordinate Field11
        {
            get { return _field11; }

        }
        public Coordinate Field12
        {
            get { return _field12; }

        }
        public Coordinate Field20
        {
            get { return _field20; }

        }
        public Coordinate Field21
        {
            get { return _field21; }

        }
        public Coordinate Field22
        {
            get { return _field22; }

        }
        #endregion Binding Coordinate

        #region Binding Field

        private string _playingField00;
        private string _playingField01;
        private string _playingField02;
        private string _playingField10;
        private string _playingField11;
        private string _playingField12;
        private string _playingField20;
        private string _playingField21;
        private string _playingField22;

        public string PlayingField00
        {
            get
            {
                switch(modelObj?.playingField?.PlayingCell[0, 0]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField00 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField01
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[0, 1]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField01 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField02
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[0, 2]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField02 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField10
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[1, 0]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField10 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField11
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[1, 1]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField11 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField12
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[1, 2]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField12 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField20
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[2, 0]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField20 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField21
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[2, 1]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField21 = value;
                OnPropertyChanged();
            }
        }

        public string PlayingField22
        {
            get
            {
                switch (modelObj?.playingField?.PlayingCell[2, 2]?.GameCell)
                {
                    case EnumGameCell.EnumCross:
                        return "X";
                        break;
                    case EnumGameCell.EnumZero:
                        return "0";
                        break;
                    case EnumGameCell.EnumEmpty:
                        return "";
                        break;
                    default:
                        return "";
                        break;
                };
                return "";
            }
            set
            {
                _playingField22 = value;
                OnPropertyChanged();
            }
        }

        #endregion Binding Field

        #region Binding Winner
        private string _winner;

        public string Winner
        {
            get
            {
                if (modelObj?.flagFinish == true)
                {
                    switch (modelObj?.ResultGame)
                    {
                        case EnumResultGame.Winner:
                            return "Result Game - Winner " + modelObj?.winner.ToString();
                        case EnumResultGame.Draw:
                            return "Result Game - Draw";
                        default:
                            return "Result Game - Game";
                    };
                }
                return "Result Game - ";
            }
            set
            {
                _winner = value;
                OnPropertyChanged();
            }
        }
        #endregion Binding Winner

        public MainViewModel()
        {
            gameSize = new SizeField(3, 3);
            modelObj = new MathModel(gameSize);

            StartUpdateGraph();
        }

        public void StartMethod()
        {
            //Пуск потока с игровой моделью
            ModelThread = new Thread(modelObj.ModelThread)
            {
                IsBackground = true,
                Name = $"Game Model"
            };
            ModelThread.Start();           

        }

        public void StartUpdateGraph()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    Change();
                }
            });
        }    

        public void Change()
        {
            PlayingField00 = "";
            PlayingField01 = "";
            PlayingField02 = "";
            PlayingField10 = "";
            PlayingField11 = "";
            PlayingField12 = "";
            PlayingField20 = "";
            PlayingField21 = "";
            PlayingField22 = "";
            Winner = "";
        }
    }
}
