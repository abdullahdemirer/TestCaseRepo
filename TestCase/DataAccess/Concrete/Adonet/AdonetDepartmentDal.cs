using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Adonet
{
    public class AdonetDepartmentDal : IDepartmentDal
    {
        public void Add(Department department)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {

                    connection.Open();

                    string insertQuery = "INSERT INTO Departments (DepartmentCode, DepartmentName,IsDeleted) VALUES (@DepartmentCode, @DepartmentName,@IsDeleted)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                        command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                        command.Parameters.AddWithValue("@IsDeleted", 0);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding department: ");
            }
        }

        public void Delete(int departmentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {

                    connection.Open();

                    string insertQuery = "UPDATE Departments SET IsDeleted = @IsDeled_FG WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IsDeled_FG", 1);
                        command.Parameters.AddWithValue("@Id", departmentId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding department: ");
            }
        }

        public List<Department> GetAll(int? departmentId)
        {
            try
            {

                List<Department> dataList = new List<Department>();

                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("List_Department", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                      
                        command.Parameters.AddWithValue("@DepartmentId", departmentId);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    Department dataModel = new Department
                                    {
                                        Id = Convert.ToInt32(reader["Id"]),
                                        DepartmentCode = Convert.ToString(reader["DepartmentCode"]),
                                        DepartmentName = Convert.ToString(reader["DepartmentName"])

                                    };

                                    dataList.Add(dataModel);
                                }
                            }
                        }
                    }
                }

                return dataList;

            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding department: ");
            }
        }

        public void Update(Department department)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {

                    connection.Open();

                    string insertQuery = "UPDATE Departments SET DepartmentCode = @DepartmentCode, DepartmentName = @DepartmentName WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", department.Id);
                        command.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                        command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating department: ");
            }
        }
    }
}
