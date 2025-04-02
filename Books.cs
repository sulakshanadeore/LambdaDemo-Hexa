using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForLambda
{
    public class Books
    {
        //public int Bookid { get; private set; }
        //public string BookName { get; private set; }
        //public float Price { get; private set; }

        int _bookid;
            string _bookname;
        float _price;


        public void AssignBookData((int Bookid, string BookName, float BookPrice) bookdetails)
        {
            _bookid = bookdetails.Item1;
            _bookname = bookdetails.Item2;
            _price = bookdetails.Item3;
        }

        public static (int bookid, string bname, float bookprice) DisplayBookData()
        {
            Books books = new Books();
     

            return (bookid:books._bookid,bname:books._bookname,bookprice:books._price);
        }


        public void SetBookData(Tuple<int, string, float> bookData)
        {
            //Bookid = bookData.Item1;
            //    BookName = bookData.Item2;
            //    Price = bookData.Item3;


            _bookid = bookData.Item1;
            _bookname = bookData.Item2;
            _price = bookData.Item3;
        }

        public Tuple<int, string, float> GetBookData() 
        {
            Tuple<int, string, float> tuple1 = Tuple.Create<int, string, float>(_bookid, _bookname, _price);
            return tuple1;
        }
    }
}
