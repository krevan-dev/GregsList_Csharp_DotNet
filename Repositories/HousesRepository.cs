using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GL_Final.Models;

namespace GL_Final.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }


    internal List<House> GetAll()
    {
      string sql = "SELECT * FROM houses";
      List<House> houses = _db.Query<House>(sql).ToList();
      return houses;
    }

    internal House GetById(int id)
    {
      string sql = "SELECT * FROM houses WHERE id = @id";
      House house = _db.QueryFirstOrDefault<House>(sql, new { id });
      return house;
    }

    internal House Create(House newHouse)
    {
      string sql = @"
        INSERT INTO houses
        (year, type, bed, bath, sqft, location, price)
        VALUES
        (@Year, @Type, @Bed, @Bath, @Sqft, @Location, @Price);
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newHouse);
      newHouse.Id = id;
      return newHouse;
    }

    internal void Update(House originalHouse)
    {
      string sql = @"
        UPDATE houses
        SET
          year = @Year,
          type = @Type,
          bed = @Bed,
          bath = @Bath,
          sqft = @Sqft,
          location = @Location,
          price = @Price
        WHERE id = @Id;
      ";
      _db.Execute(sql, originalHouse);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM houses WHERE id = @id LIMIT 1";
      int modified = _db.Execute(sql, new { id });
      if (modified == 0)
      {
        throw new System.Exception("Sum ting wong");
      }
    }
  }
}