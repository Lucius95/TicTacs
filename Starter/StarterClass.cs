using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameLogic;

namespace Starter
{
    public class StarterClass
    {
        public MathModel modelObj;
        public SizeField gameSize;
        public Thread ModelThread;

        public StarterClass()
        {           
            gameSize = new SizeField(3,3);
            modelObj = new MathModel(gameSize);
            StartMethod();
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
    }
}
