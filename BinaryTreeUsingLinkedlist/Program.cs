using BinaryTreeUsingLinkedlist;

BinaryTree bt = new();
bt.Insert(50);
bt.Insert(30);
bt.Insert(70);
bt.Insert(20);
bt.Insert(100);

bt.PreorderTraversal(bt.Root);