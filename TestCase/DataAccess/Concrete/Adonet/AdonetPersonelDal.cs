using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Adonet
{
    public class AdonetPersonelDal : IPersonelDal
    {
        public void Add(Personel personel)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {

                    connection.Open();

                    string insertQuery = "INSERT INTO Personels (RegistrationNumber,PersonelName,PersonelSurname,Department,StartDate,EndDate,Mail,Gender,MobilePhoneNumber,HomePhoneNumber,IsDeleted)" +
                        " VALUES (@RegistrationNumber,@PersonelName,@PersonelSurname,@Department,@StartDate,@EndDate,@Mail,@Gender,@MobilePhoneNumber,@HomePhoneNumber,@IsDeleted)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RegistrationNumber", personel.RegistrationNumber);
                        command.Parameters.AddWithValue("@PersonelName", personel.PersonelName);
                        command.Parameters.AddWithValue("@PersonelSurname", personel.PersonelSurname);
                        command.Parameters.AddWithValue("@Department", personel.Department);
                        command.Parameters.AddWithValue("@StartDate", personel.StartDate);
                        command.Parameters.AddWithValue("@EndDate", personel.EndDate == null ? DBNull.Value : personel.EndDate);
                        command.Parameters.AddWithValue("@Mail", personel.Mail);
                        command.Parameters.AddWithValue("@Gender", personel.Gender);
                        command.Parameters.AddWithValue("@MobilePhoneNumber", personel.MobilePhoneNumber);
                        command.Parameters.AddWithValue("@HomePhoneNumber", personel.HomePhoneNumber == null ? DBNull.Value : personel.HomePhoneNumber);
                        command.Parameters.AddWithValue("@IsDeleted", 0);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding personel: ");
            }
        }

        public void Delete(int personelId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {

                    connection.Open();

                    string insertQuery = "UPDATE Personels SET IsDeleted = @IsDeled_FG WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IsDeled_FG", 1);
                        command.Parameters.AddWithValue("@Id", personelId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting personel: ");
            }

        }

        public List<PersonelDto> GetAll(int? departmentId, DateTime? startDate, int? personelId)
        {
            try
            {

                List<PersonelDto> employees = new List<PersonelDto>();

                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("List_Personel", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DepartmentId", departmentId);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@PersonelId", personelId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    PersonelDto peronel = new PersonelDto
                                    {
                                        Id = Convert.ToInt32(reader["Id"]),
                                        RegistrationNumber = Convert.ToString(reader["RegistrationNumber"]),
                                        PersonelName = Convert.ToString(reader["PersonelName"]),
                                        PersonelSurname = Convert.ToString(reader["PersonelSurname"]),
                                        Department = Convert.ToInt32(reader["Department"]),
                                        StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                        EndDate =  reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : (DateTime?)null,
                                        Mail = Convert.ToString(reader["Mail"]),
                                        Gender = Convert.ToString(reader["Gender"]),
                                        MobilePhoneNumber = Convert.ToString(reader["MobilePhoneNumber"]),
                                        HomePhoneNumber = Convert.ToString(reader["HomePhoneNumber"]),
                                        DepartmentName = Convert.ToString(reader["DepartmentName"]),
                                        DepartmentCode = Convert.ToString(reader["DepartmentCode"]),

                                    };

                                    employees.Add(peronel);
                                }
                            }
                        }
                    }
                }

                return employees;

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fething personel: ");
            }
        }

        public void Update(Personel personel)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessConfig.ConnectionString))
                {

                    connection.Open();

                    string insertQuery = "UPDATE Personels SET RegistrationNumber =  @RegistrationNumber, PersonelName = @PersonelName, PersonelSurname = @PersonelSurname," +
                        "Department = @Department, StartDate = @StartDate, EndDate = @EndDate, Mail = @Mail, Gender = @Gender,MobilePhoneNumber = @MobilePhoneNumber," +
                        "HomePhoneNumber = @HomePhoneNumber WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        
                        command.Parameters.AddWithValue("@RegistrationNumber", personel.RegistrationNumber);
                        command.Parameters.AddWithValue("@PersonelName", personel.PersonelName);
                        command.Parameters.AddWithValue("@PersonelSurname", personel.PersonelSurname);
                        command.Parameters.AddWithValue("@Department", personel.Department);
                        command.Parameters.AddWithValue("@StartDate", personel.StartDate);
                        command.Parameters.AddWithValue("@EndDate", personel.EndDate == null ? DBNull.Value : personel.EndDate);
                        command.Parameters.AddWithValue("@Mail", personel.Mail);
                        command.Parameters.AddWithValue("@Gender", personel.Gender);
                        command.Parameters.AddWithValue("@MobilePhoneNumber", personel.MobilePhoneNumber);
                        command.Parameters.AddWithValue("@HomePhoneNumber", personel.HomePhoneNumber == null ? DBNull.Value : personel.HomePhoneNumber);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating personel: ");
            }
        }
    }
}
