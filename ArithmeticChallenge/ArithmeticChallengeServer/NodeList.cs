/* 
 *  Student Number: 450950837
 *  Name:           Kaitlyn Parsons
 *  Date:           13/09/2018 
 *  Purpose:        Methods for the double link list
 *  Known Bugs:     None.
 */
using System.Collections;
using System.Text;

namespace ArithmeticChallenge
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   List of nodes. </summary>
    ///
    /// <remarks>   Parsons, 16-Sep-18. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class NodeList
    {

        /// <summary>   The tail node. </summary>
        public Node CurrentNode = null, HeadNode = null, TailNode = null;

        /// <summary>   Number of. </summary>
        static int count = 0;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   constructor. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public NodeList()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   set head, current and tail to aNode. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="aNode">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public NodeList(Node aNode)
        {
            HeadNode = aNode;
            CurrentNode = aNode;
            TailNode = aNode;
            count++;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets current node. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <returns>   The current node. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Node getCurrentNode() { return CurrentNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets head node. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <returns>   The head node. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Node getHeadNode() { return HeadNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets tail node. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <returns>   The tail node. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Node getTailNode() { return TailNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets current node. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="aNode">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setCurrentNode(Node aNode) { CurrentNode = aNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets head node. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="aNode">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setHeadNode(Node aNode) { HeadNode = aNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets tail node. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="aNode">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setTailNode(Node aNode) { TailNode = aNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   inserts at the front of the list. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="aNode">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void addAtFrontOfNodeList(Node aNode)
        {
            if (HeadNode == null && CurrentNode == null && TailNode == null)
            {
                HeadNode = aNode;
                CurrentNode = aNode;
                TailNode = aNode;
                count++;
            }
            else
            {
                CurrentNode = aNode;
                HeadNode.setPrevious(aNode);
                CurrentNode.setNext(HeadNode);
                setHeadNode(CurrentNode);
                count++;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   sort the double link list. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SortList()
        {
            Node current = HeadNode;
            for (Node i = current; i.getNext() != null; i = i.getNext())
            {
                for (Node j = i.getNext(); j != null; j = j.getNext())
                {
                    if (i.getValue() > j.getValue())
                    {
                        int Temp = j.getValue();
                        j.setMyValue(i.getValue());
                        i.setMyValue(Temp);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   binary search the sorted double link list. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="searchValue">  . </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int binarySearch(int searchValue)
        {
            this.SortList();
            Node current = HeadNode;
            ArrayList myTempList = new ArrayList();
            for (Node i = current; i != null; i = i.getNext())
            {
                myTempList.Add(i.getValue());
            }
            return myTempList.BinarySearch(searchValue);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   prints the double link list. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="aNode">    . </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printLinkList(NodeList aNode)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("HEAD");
            if (aNode.HeadNode.getNext() == null)
            {
                sb.Append(" <-> " + aNode.HeadNode.tostring());
            }
            else if (aNode.HeadNode.getNext() != null)
            {
                sb.Append(" <-> " + aNode.HeadNode.tostring());
                aNode.CurrentNode = aNode.HeadNode.getNext();
                while (aNode.CurrentNode != null)
                {
                    sb.Append(" <-> " + aNode.CurrentNode.tostring());
                    aNode.CurrentNode = aNode.CurrentNode.getNext();
                }
            }
            sb.Append(" <-> TAIL");
            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   inserts all the nodes from the link list into the hashtable. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="aNode">    . </param>
        ///
        /// <returns>   A Hashtable. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Hashtable linkListTable(NodeList aNode)
        {
            Hashtable table = new Hashtable();
            int counter = 1;

            for (Node i = aNode.HeadNode; i.getNext() != null; i = i.getNext())
            {
                table.Add(count.ToString(), i);
                counter++;
            }
            return table;
        }
    }
}
