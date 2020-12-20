using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Bukapediamall.Repositories
{
    public class DBConnection
    {
        //Put your database string connection
        public SqlConnection connection = new SqlConnection(@"");
        public SqlCommand command = new SqlCommand();
    }
}
