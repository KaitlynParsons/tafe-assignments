/* 
 *  Student Number: 450950837
 *  Name:           Kaitlyn Parsons
 *  Date:           13/09/2018 
 *  Purpose:        Nodes for binary tree
 *  Known Bugs:     None.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticChallenge
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A binary node. </summary>
    ///
    /// <remarks>   Parsons, 16-Sep-18. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class BinaryNode
    {
        /// <summary>   The equation. </summary>
        public Question equation;
        /// <summary>   The left. </summary>
        public BinaryNode left;
        /// <summary>   The right. </summary>
        public BinaryNode right;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   constructor. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="val">  . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BinaryNode(Question val)
        {
            equation = val;
            left = null;
            right = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   converts each node equation entry to string format. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string NodeToString()
        {
            return equation.answer.ToString() + "(" + equation.firstNumber.ToString() + equation.Symbol + equation.secondNumber.ToString() + "), ";
        }

    }
}
