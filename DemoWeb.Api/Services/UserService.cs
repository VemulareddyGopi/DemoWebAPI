using Microsoft.Data.SqlClient;
using SirIthara.Api.Models;
using System.Data;

namespace SirIthara.Api.Services;

public class UserService : IUserService
{
    private readonly string _connectionString;

    public UserService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SiritharaConnection")
            ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null.");
    }

    public async Task<List<AdoUser>> UsersAsync()
    {
        var users = new List<AdoUser>();
        using (var connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT UserId,UserName,Email,Message,Status,DOB FROM Users";
            using (var command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new AdoUser
                        {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Message = reader.GetString(3),
                            Status = reader.GetBoolean(4),
                            DOB = reader.GetDateTime(5)
                        });
                    }
                }
            }
        }

        return users;
    }

    public async Task<AdoUser> UserByIdAsync(int id)
    {
        var user = new AdoUser();
        using (var connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT UserId,UserName,Email,Message,Status,DOB FROM Users where UserId = @UserId";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", id);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        user.Id = reader.GetInt64(0);
                        user.Name = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Message = reader.GetString(3);
                        user.Status = reader.GetBoolean(4);
                        user.DOB = reader.GetDateTime(5);

                        return user;

                    }
                }
            }
        }

        return null;
    }



    public async Task<string> SaveUserAsync(AdoUser user)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // SQL query with duplicate validation using IF NOT EXISTS
                string query = @"
            IF EXISTS (SELECT 1 FROM Users WHERE LOWER(Email) = LOWER(@Email))
            BEGIN
                RAISERROR('Duplicate email address found. User registration failed.', 16, 1);
            END
            ELSE
            BEGIN
                INSERT INTO Users (UserName, Email, Message, Status, DOB) 
                VALUES (@UserName, @Email, @Message, @Status, @DOB);
            END";

                using (var command = new SqlCommand(query, connection))
                {
                    // Explicit SQL typing to keep database performance optimal
                    command.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = user.Name;
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = user.Email;
                    command.Parameters.Add("@Message", SqlDbType.NVarChar,500).Value = user.Message;
                    command.Parameters.Add("@Status", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@DOB", SqlDbType.DateTime).Value = user.DOB;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }

            return "User Created Successfully";
        }
        catch (SqlException ex) when (ex.Number == 50000) // 50000 is the default error number for RAISERROR
        {
            // This catches your specific duplicate error message
            return $"Validation Error: {ex.Message}";
        }
        catch (Exception ex)
        {
            // This catches other database failures (e.g., connection issues)
            return $"System Error: {ex.Message}";
        }
    }

    public Task<AdoUser> UpdateUserAsync(AdoUser user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }


}
