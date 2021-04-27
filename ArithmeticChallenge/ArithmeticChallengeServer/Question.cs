/* 
 *  Student Number: 450950837
 *  Name:           Kaitlyn Parsons
 *  Date:           13/09/2018 
 *  Purpose:        class for the question
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
    /// <summary>   A question. </summary>
    ///
    /// <remarks>   Parsons, 16-Sep-18. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class Question
    {
        /// <summary>   The first number. </summary>
        public int firstNumber;
        /// <summary>   The second number. </summary>
        public int secondNumber;
        /// <summary>   The symbol. </summary>
        public string Symbol;
        /// <summary>   The answer. </summary>
        public int answer;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   constructor. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="firstNum">     . </param>
        /// <param name="secondNum">    . </param>
        /// <param name="symbol">       . </param>
        /// <param name="result">       . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Question(int firstNum, int secondNum, string symbol, int result)
        {
            firstNumber = firstNum;
            secondNumber = secondNum;
            Symbol = symbol;
            answer = result;
        }
    }
}
