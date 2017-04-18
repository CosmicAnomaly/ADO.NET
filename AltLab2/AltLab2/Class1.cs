class CustomerUtil
{
    private static string connectionStringName = "DemoLocalDB.Properties.Settings.DemoLocalDBConnectionString";
    public List<Customer> readCustomers()
    {
        SqlCommand cmdRead;
        SqlDataReader rdrReader;
        String strSql;
        SqlConnection conn = null;
        List<Customer> customers = new List<Customer>();
        try
        {
            string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            conn = new SqlConnection(connectString);
            strSql = "select CustomerId, FirstName, LatName, Phone, Email from Customer";
            conn.Open();
            cmdRead = new SqlCommand(strSql, conn);
            rdrReader = cmdRead.ExecuteReader();
            while (rdrReader.Read())
            {
                customers.Add(new Customer(Convert.ToInt32(rdrReader[0].ToString()), rdrReader[1].ToString(), rdrReader[2].ToString(), rdrReader[3].ToString(), rdrReader[4].ToString()));
            }
        }
        catch (SqlException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
        return customers;
    }
    //==============================
    public Customer insertCustomer(Customer customer)
    {
        SqlCommand cmdInsert;
        String strSql;
        SqlConnection conn = null;
        try
        {
            string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            conn = new SqlConnection(connectString);
            strSql = "insert into Customer(FirstName, LatName, Phone, Email) values(@FirstName, @LastName, @Phone, @Email); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            SqlParameter parFirstName = new SqlParameter("@FirstName", customer.FirstName);
            parFirstName.SqlDbType = System.Data.SqlDbType.VarChar;
            SqlParameter parLastName = new SqlParameter("@LastName", customer.LastName);
            parLastName.SqlDbType = System.Data.SqlDbType.VarChar;
            SqlParameter parPhone = new SqlParameter("@Phone", customer.Phone);
            parPhone.SqlDbType = System.Data.SqlDbType.Char;
            SqlParameter parEmail = new SqlParameter("@Email", customer.Email);
            parEmail.SqlDbType = System.Data.SqlDbType.VarChar;
            conn.Open();
            cmdInsert = new SqlCommand(strSql, conn);
            cmdInsert.Parameters.Add(parFirstName);
            cmdInsert.Parameters.Add(parLastName);
            cmdInsert.Parameters.Add(parPhone);
            cmdInsert.Parameters.Add(parEmail);
            customer.CustomerId = (int)cmdInsert.ExecuteScalar();
        }
        catch (SqlException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
        return customer;
    }
    //==============================
    public Customer getCustomerById(int id)
    {
        SqlCommand cmdRead;
        SqlDataReader rdrReader;
        String strSql;
        SqlConnection conn = null;
        Customer customer = null;
        try
        {
            string connectString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            conn = new SqlConnection(connectString);
            strSql = "select CustomerId, FirstName, LatName, Phone, Email from Customer where CustomerId = @custId";
            conn.Open();
            cmdRead = new SqlCommand(strSql, conn);
            SqlParameter parCustId = new SqlParameter("@custId", id);
            parCustId.SqlDbType = System.Data.SqlDbType.Int;
            cmdRead.Parameters.Add(parCustId);
            rdrReader = cmdRead.ExecuteReader();
            if (rdrReader.Read())
            {
                customer = new Customer(Convert.ToInt32(rdrReader[0].ToString()), rdrReader[1].ToString(), rdrReader[2].ToString(), rdrReader[3].ToString(), rdrReader[4].ToString());
            }
        }
        catch (SqlException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
        return customer;
    }
}
//==============================



static void Main(string[] args)
{
    CustomerUtil custUtil = new CustomerUtil();
    List<Customer> customers = custUtil.readCustomers();
    foreach (Customer cust in customers)
        Console.WriteLine(cust.ToString());
    Customer customer = custUtil.insertCustomer(new Customer("Sammy", "King", "2271995", "sk@gmail.com"));
    Console.WriteLine("Generated ID:" + customer.CustomerId.ToString());
    customers = custUtil.readCustomers();
    foreach (Customer cust in customers)
        Console.WriteLine(cust.ToString());
    Customer foundCustomer = custUtil.getCustomerById(6);
    if (foundCustomer != null)
        Console.WriteLine("Found Customer 6, First Name:" + foundCustomer.FirstName);
    Console.ReadLine();
}