﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Source;

namespace TowerDefense.GameEngine
{
    internal interface IGameplay
    {
        Inventory Inventory { get; }
        Tower Tower { get; }
        void RunGame();
    }

    internal class Gameplay : IGameplay
    {
        private static readonly Lazy<Gameplay> m_gamePlay = new Lazy<Gameplay>();

        public Boolean GameStarted { get; private set; }
        public Inventory Inventory { get; }
        public Tower Tower { get; }


        public Gameplay()
        {
            GameStarted = false;
            Inventory = new Inventory();
            Tower = new Tower();
        }

        public static Gameplay GetGameplay() =>
            m_gamePlay.Value;

        public void RunGame()
        {
            GameStarted = true;
            Task.Factory.StartNew(() =>
            {
                
            });
        }
    }
}