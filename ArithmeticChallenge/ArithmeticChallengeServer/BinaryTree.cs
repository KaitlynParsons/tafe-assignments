/* 
 *  Student Number: 450950837
 *  Name:           Kaitlyn Parsons
 *  Date:           13/09/2018 
 *  Purpose:        Methods for the binary tree
 *  Known Bugs:     None.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArithmeticChallenge
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A binary tree. </summary>
    ///
    /// <remarks>   Parsons, 16-Sep-18. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class BinaryTree
    {
        /// <summary>   The top. </summary>
        public BinaryNode top;
        /// <summary>   The print string. </summary>
        private static string printStr = "";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   print the binary tree pre order. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="tree"> . </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printPreOrder(BinaryTree tree)
        {
            printStr = "";
            PreOrder(tree.top);
            return printStr;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   binary tree pre order. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="Root"> . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PreOrder(BinaryNode Root)
        {
            if (Root == null)
            {
                return;
            }
            else
            {
                printStr += Root.NodeToString();
                PreOrder(Root.left);
                PreOrder(Root.right);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   print the binary tree in order. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="tree"> . </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printInOrder(BinaryTree tree)
        {
            printStr = "";
            InOrder(tree.top);
            return printStr;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   binary tree in order. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="Root"> . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InOrder(BinaryNode Root)
        {
            if (Root == null)
            {
                return;
            }
            else
            {
                InOrder(Root.left);
                if (!printStr.Contains(Root.NodeToString()))
                {
                    printStr += Root.NodeToString();
                }
                InOrder(Root.right);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   print the binary tree post order. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="tree"> . </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printPostOrder(BinaryTree tree)
        {
            printStr = "";
            PostOrder(tree.top);
            return printStr;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   binary tree post order. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="Root"> . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostOrder(BinaryNode Root)
        {
            if (Root == null)
            {
                return;
            }
            PreOrder(Root.left);
            PreOrder(Root.right);
            printStr += Root.NodeToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   constructor. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="answerVal">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BinaryTree(Question answerVal)
        {
            top = new BinaryNode(answerVal);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   constructor to avoid double ups. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BinaryTree()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   add to the binary tree. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="quest">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Add(Question quest)
        {
            if (top == null)
            {
                top = new BinaryNode(quest);
                return;
            }

            BinaryNode currentNode = top;
            bool insert = false;

            do
            {
                if (quest.answer < currentNode.equation.answer)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new BinaryNode(quest);
                        insert = true;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }

                    if (quest.answer >= currentNode.equation.answer)
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = new BinaryNode(quest);
                            insert = true;
                        }
                        else
                        {
                            currentNode = currentNode.right;
                        }
                    }
                }
            } while (!insert);
        }
    }
}
