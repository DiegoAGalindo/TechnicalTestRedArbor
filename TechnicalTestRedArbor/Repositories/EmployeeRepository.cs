using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TechnicalTestRedArbor.Models;

namespace TechnicalTestRedArbor.Repositories
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task DeleteById(int id)
        {
            await using var sql = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("DeleteEmployeeById", sql)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            await sql.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<ResponseEmployee>> GetAll()
        {
            await using var sql = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("SpGetEmployees", sql)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            var response = new List<ResponseEmployee>();
            await sql.OpenAsync();

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                response.Add(MapToValue(reader));
            }

            return response;
        }

        public async Task<ResponseEmployee> GetById(int id)
        {
            await using var sql = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("GetEmployeeById", sql)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            ResponseEmployee response = null;
            await sql.OpenAsync();

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                response = MapToValue(reader);
            }

            return response;
        }

        public async Task<int> Insert(RequestEmployee requestEmployee)
        {
            await using var sql = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("SpInsertEmployees", sql)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@CompanyId", requestEmployee.CompanyId));
            cmd.Parameters.Add(new SqlParameter("@CreatedOn", requestEmployee.CreatedOn));
            cmd.Parameters.Add(new SqlParameter("@DeletedOn", requestEmployee.DeletedOn));
            cmd.Parameters.Add(new SqlParameter("@Email", requestEmployee.Email));
            cmd.Parameters.Add(new SqlParameter("@Fax", requestEmployee.Fax));
            cmd.Parameters.Add(new SqlParameter("@LastLogin", requestEmployee.LastLogin));
            cmd.Parameters.Add(new SqlParameter("@Name", requestEmployee.Name));
            cmd.Parameters.Add(new SqlParameter("@Password", requestEmployee.Password));
            cmd.Parameters.Add(new SqlParameter("@PortalId", requestEmployee.PortalId));
            cmd.Parameters.Add(new SqlParameter("@RoleId", requestEmployee.RoleId));
            cmd.Parameters.Add(new SqlParameter("@StatusId", requestEmployee.StatusId));
            cmd.Parameters.Add(new SqlParameter("@Telephone", requestEmployee.Telephone));
            cmd.Parameters.Add(new SqlParameter("@UpdatedOn", requestEmployee.UpdatedOn));
            cmd.Parameters.Add(new SqlParameter("@Username", requestEmployee.Username));
            await sql.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();
            var id = 0;
            while (await reader.ReadAsync())
            {
                id = Convert.ToInt32(reader["Id"]);
            }

            return id;
        }

        public async Task Update(RequestEmployee requestEmployee, int id)
        {
            await using var sql = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("SpUpdateEmployees", sql)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            cmd.Parameters.Add(new SqlParameter("@CompanyId", requestEmployee.CompanyId));
            cmd.Parameters.Add(new SqlParameter("@CreatedOn", requestEmployee.CreatedOn));
            cmd.Parameters.Add(new SqlParameter("@DeletedOn", requestEmployee.DeletedOn));
            cmd.Parameters.Add(new SqlParameter("@Email", requestEmployee.Email));
            cmd.Parameters.Add(new SqlParameter("@Fax", requestEmployee.Fax));
            cmd.Parameters.Add(new SqlParameter("@LastLogin", requestEmployee.LastLogin));
            cmd.Parameters.Add(new SqlParameter("@Name", requestEmployee.Name));
            cmd.Parameters.Add(new SqlParameter("@Password", requestEmployee.Password));
            cmd.Parameters.Add(new SqlParameter("@PortalId", requestEmployee.PortalId));
            cmd.Parameters.Add(new SqlParameter("@RoleId", requestEmployee.RoleId));
            cmd.Parameters.Add(new SqlParameter("@StatusId", requestEmployee.StatusId));
            cmd.Parameters.Add(new SqlParameter("@Telephone", requestEmployee.Telephone));
            cmd.Parameters.Add(new SqlParameter("@UpdatedOn", requestEmployee.UpdatedOn));
            cmd.Parameters.Add(new SqlParameter("@Username", requestEmployee.Username));
            await sql.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        private static ResponseEmployee MapToValue(IDataRecord reader)
        {
            return new ResponseEmployee()
            {
                Id = (int)reader["Id"],
                CompanyId = (int)reader["CompanyId"],
                CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? new DateTime() : (DateTime)reader["CreatedOn"],
                DeletedOn = (reader["DeletedOn"] == DBNull.Value) ? new DateTime() : (DateTime)reader["DeletedOn"],
                Email = reader["Email"].ToString(),
                Fax = reader["Fax"].ToString(),
                LastLogin = (reader["LastLogin"] == DBNull.Value) ? new DateTime() : (DateTime)reader["LastLogin"],
                Name = reader["Name"].ToString(),
                Password = reader["Password"].ToString(),
                PortalId = (int)reader["PortalId"],
                RoleId = (int)reader["RoleId"],
                StatusId = (int)reader["StatusId"],
                Telephone = reader["Telephone"].ToString(),
                UpdatedOn = (reader["UpdatedOn"] == DBNull.Value) ? new DateTime() : (DateTime)reader["UpdatedOn"],
                Username = reader["Username"].ToString()
            };
        }
    }
}