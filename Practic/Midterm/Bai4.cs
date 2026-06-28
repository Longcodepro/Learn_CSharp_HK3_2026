using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
}

public class UsersDapperRepository
{
    private readonly string _connectionString;

    public UsersDapperRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IList<User> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.Query<User>("SELECT * FROM dbo.Users").ToList();
    }

    public IReadOnlyList<User> FindNamesEndingWith(string name)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.Query<User>(
            "SELECT Id, Name FROM dbo.Users WHERE Name LIKE @Suffix",
            new { Suffix = "%" + name }).ToList();
    }

    public IReadOnlyList<User> GetUsersWithShortName(int maxLength)
    {

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.Query<User>(
            "SELECT Id, Name FROM dbo.Users WHERE LEN(Name) <= @MaxLength",
            new { MaxLength = maxLength }).ToList();
    }

    public int CountNamesContaining(string keyword)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.ExecuteScalar<int>(
            "SELECT COUNT(*) FROM dbo.Users WHERE Name LIKE @Keyword",
            new { Keyword = "%" + keyword + "%" });
    }

    public List<User> GetIdAndNameList()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.Query<User>("SELECT Id, Name FROM dbo.Users").ToList();
    }
}
