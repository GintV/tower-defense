﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TowerDefense.GameEngine.Transactions
{
    public class CoinTransactionController
    {
        private const int MaxUndoDepth = 3;

        private readonly IGameEnvironment m_gameplay;
        private readonly ConcurrentQueue<Action> m_pendingTransactions;
        private readonly LinkedList<CoinTransaction> m_doneTransactions;

        public CoinTransactionController(IGameEnvironment gameplay)
        {
            m_gameplay = gameplay;
            m_pendingTransactions = new ConcurrentQueue<Action>();
            m_doneTransactions = new LinkedList<CoinTransaction>();
        }

        public void AddTransaction(CoinTransaction transaction) => m_pendingTransactions.Enqueue(() =>
        {
            if (transaction.Execute(m_gameplay))
                m_doneTransactions.AddFirst(transaction);
            if (m_doneTransactions.Count > MaxUndoDepth)
            {
                m_doneTransactions.RemoveLast();
            }
        });

        public void UndoLastTransaction() => m_pendingTransactions.Enqueue(() =>
        {
            var transaction = m_doneTransactions.First?.Value;
            if (transaction == null) return;
            if (transaction.Undo(m_gameplay))
                m_doneTransactions.RemoveFirst();
            else m_doneTransactions.Clear();
        });

        public void ExecuteTransactions()
        {
            while (!m_pendingTransactions.IsEmpty)
            {
                if (!m_pendingTransactions.TryDequeue(out var current)) continue;
                current();
            }
        }

        public bool HasUndoableTransactions() => m_doneTransactions.Count != 0;
    }
}
