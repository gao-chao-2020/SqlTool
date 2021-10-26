using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTService
{
    public interface ISelectService
    {

       DataTable SelectTable(string[] arr);


       int InsertTable(string[] arr);


       int DeleteTable(string[] arr);


       int UpdateTable(string[] arr);
        
    }
}
