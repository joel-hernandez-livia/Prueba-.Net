using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using ProductApi.BLL.Interfaces;
using ProductApi.Entities;

namespace ProductApi.DAL;

public class ProductRepository : IProductRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public ProductRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> CreateAsync(Product product)
    {
        const string sql = @"
INSERT INTO Products
(
    Name,
    Status,
    Stock,
    Description,
    Price
)
OUTPUT INSERTED.ProductId
VALUES
(
    @Name,
    @Status,
    @Stock,
    @Description,
    @Price
);";

        using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Status", product.Status);
        command.Parameters.AddWithValue("@Stock", product.Stock);
        command.Parameters.AddWithValue("@Description", product.Description);
        command.Parameters.AddWithValue("@Price", product.Price);

        var productId = (int)await command.ExecuteScalarAsync();

        return productId;
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        const string sql = @"
UPDATE Products
SET
    Name = @Name,
    Status = @Status,
    Stock = @Stock,
    Description = @Description,
    Price = @Price
WHERE ProductId = @ProductId;";

        using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@ProductId", product.ProductId);
        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Status", product.Status);
        command.Parameters.AddWithValue("@Stock", product.Stock);
        command.Parameters.AddWithValue("@Description", product.Description);
        command.Parameters.AddWithValue("@Price", product.Price);

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }

    public async Task<Product?> GetByIdAsync(int productId)
    {
        const string sql = @"
SELECT
    ProductId,
    Name,
    Status,
    Stock,
    Description,
    Price
FROM Products
WHERE ProductId = @ProductId;";

        using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@ProductId", productId);

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return new Product
        {
            ProductId = reader.GetInt32(0),
            Name = reader.GetString(1),
            Status = reader.GetByte(2),
            Stock = reader.GetInt32(3),
            Description = reader.GetString(4),
            Price = reader.GetDecimal(5)
        };
    }
}