using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using KnightsTale.Models;

namespace KnightsTale.Repositories
{
  public class KnightsRepository
  {
    private readonly IDbConnection _db;
    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Knight Create(Knight knightData)
    {
      var sql = @"
      INSERT INTO knights(
        name,
        sword,
        skill,
        type
      )
      Values (
        @Name,
        @Sword,
        @Skill,
        @Type
      );
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, knightData);
      knightData.Id = id;
      return knightData;
    }
    public List<Knight> Get()
    {
      return _db.Query<Knight>("SELECT * FROM knights").ToList();
    }
    public Knight Get(int id)
    {
      return _db.QueryFirstOrDefault<Knight>("SELECT * FROM knights WHERE id = @id", new { id });
    }
    public Knight Edit(int id, Knight knightData)
    {
      knightData.Id = id;
      var sql = @" 
      UPDATE knights
      SET
      name = @Name,
      sword = @Sword,
      skill = @Skill,
      type = @Type
      WHERE id = @Id
      ";
      var rowsAffected = _db.Execute(sql, knightData);
      if (rowsAffected > 1)
      {
        throw new System.Exception("Somethings wrong in the DB");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("Update Failed");
      }
      return knightData;
    }
    public void Delete(int id)
    {
      var rowsAffected = _db.Execute("DELETE FROM knights WHERE id = @id", new { id });
      if (rowsAffected > 1)
      {
        throw new System.Exception("Somethings wrong in the DB");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("Update Failed");
      }
    }
  }
}