using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GL_Final.Models;

namespace GL_Final.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Car> GetAll()
    {
      string sql = "SELECT * FROM cars";
      List<Car> cars = _db.Query<Car>(sql).ToList();
      return cars;
    }

    internal Car GetById(int id)
    {
      string sql = "SELECT * FROM cars WHERE id = @id";
      Car car = _db.QueryFirstOrDefault<Car>(sql, new { id });
      return car;
    }

    internal Car Create(Car newCar)
    {
      string sql = @"
        INSERT INTO cars
        (year, make, model, price, color, body)
        VALUES
        (@Year, @Make, @Model, @Price, @Color, @Body);
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newCar);
      newCar.Id = id;
      return newCar;
    }

    internal void Update(Car originalCar)
    {
      string sql = @"
        UPDATE cars
        SET
          year = @Year,
          make = @Make,
          model = @Model,
          price = @Price,
          color = @Color,
          body = @Body
        WHERE id = @Id;
      ";
      _db.Execute(sql, originalCar);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM cars WHERE id = @id LIMIT 1";
      int modified = _db.Execute(sql, new { id });
      if (modified == 0)
      {
        throw new System.Exception("Sum ting wong");
      }
    }
  }
}