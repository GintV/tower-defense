﻿using System.Collections.Generic;
using TowerDefense.GameEngine.Transactions;
using TowerDefense.Source;
using TowerDefense.Source.Attacks.Projectiles;
using TowerDefense.Source.Monsters;

namespace TowerDefense.GameEngine
{
    public interface IGameEnvironment
    {
        CoinTransactionController TransactionController { get; set; }
        IGameInfo GameInfo { get; }
        Inventory Inventory { get; }
        List<IMonster> Monsters { get; }
        List<IProjectile> Projectiles { get; }
        Tower Tower { get; }

    }

    internal class GameEnvironment : IGameEnvironment
    {
        public CoinTransactionController TransactionController { get; set; }
        public IGameInfo GameInfo { get; }
        public Inventory Inventory { get; }
        public List<IMonster> Monsters { get; }
        public List<IProjectile> Projectiles { get; }
        public Tower Tower { get; }

        public GameEnvironment()
        {
            Inventory = new Inventory();
            Monsters = new List<IMonster>();
            Projectiles = new List<IProjectile>();
            Tower = new Tower();
            TransactionController = new CoinTransactionController(this);
            GameInfo = new GameInfo(Inventory.Coins, Tower.HealthPointsRemaining, Tower.HealthPoints, Tower.ManaPointsRemaining, Tower.ManaPoints);
        }
    }
}
