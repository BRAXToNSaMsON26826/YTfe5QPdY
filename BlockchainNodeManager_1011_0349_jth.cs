// 代码生成时间: 2025-10-11 03:49:19
// <summary>
//     Provides a class for managing blockchain nodes.
// </summary>
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlockchainDemo
{
    // Define a Node class to represent a single node in the blockchain network.
    public class Node
    {
        public string Id { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public Node PreviousNode { get; set; }
        public Node NextNode { get; set; }

        public Node(string id)
        {
            Id = id;
        }
    }

    // Define a Transaction class to represent a transaction within a node.
    public class Transaction
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string id, string from, string to, decimal amount)
        {
            Id = id;
            From = from;
            To = to;
            Amount = amount;
        }
    }

    // Define a BlockchainManager class to manage the blockchain nodes.
    public class BlockchainManager
    {
        private Node head;
        private Node tail;

        // Initializes a new instance of BlockchainManager with a genesis node.
        public BlockchainManager()
        {
            head = new Node("genesis");
            tail = head;
        }

        // Adds a new node to the blockchain network.
        public Node AddNode(Node newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "Node cannot be null.");
            }

            newNode.PreviousNode = tail;
            newNode.NextNode = null;
            tail.NextNode = newNode;
            tail = newNode;

            return newNode;
        }

        // Gets the head node of the blockchain network.
        public Node GetHeadNode()
        {
            return head;
        }

        // Gets the tail node of the blockchain network.
        public Node GetTailNode()
        {
            return tail;
        }
    }
}
