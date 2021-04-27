/*
 * Student Number: 450950837
 *  Name:                  Kaitlyn Parsons
 *  Date:                    5/09/2018 
 *  Purpose:              Student Class for Random Access File
 *  Known Bugs:       None.
 */
namespace CarolinesClassroomRobots
{
    /// <summary>
    /// <see cref="Student"/> Class
    /// </summary>
    class Student
    {
        private string stnumber;
        private string stname;
        private int recordsize;

        /// <summary>
        /// string for students number in the raf
        /// </summary>
        public string stunumber
        { 
            //stunumber property
            set { stnumber = value; }
            get { return stnumber; }
        }

        /// <summary>
        /// string for students name in the raf
        /// </summary>
        public string stuname
        { 
            //stuname property
            set { stname = value; }
            get { return stname; }
        }

        /// <summary>
        /// int for size of raf
        /// </summary>
        public int size
        {
            get { return calsize(); }
        }

        /// <summary>
        /// max record of raf
        /// </summary>
        /// <returns></returns>
        private int calsize()
        {
            // max record size
            recordsize = 30;
            return recordsize;
        }
    }
}