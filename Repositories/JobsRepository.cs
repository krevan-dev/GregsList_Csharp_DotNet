using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GL_Final.Models;

namespace GL_Final.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Job> GetAll()
    {
      string sql = "SELECT * FROM jobs";
      List<Job> jobs = _db.Query<Job>(sql).ToList();
      return jobs;
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id";
      Job job = _db.QueryFirstOrDefault<Job>(sql, new { id });
      return job;
    }

    internal Job Create(Job newJob)
    {
      string sql = @"
        INSERT INTO jobs
        (jobTitle, pay, empType, location)
        VALUES
        (@JobTitle, @Pay, @EmpType, @Location);
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newJob);
      newJob.Id = id;
      return newJob;
    }

    internal void Update(Job originalJob)
    {
      string sql = @"
        UPDATE jobs
        SET
          jobTitle = @JobTitle,
          pay = @Pay,
          empType = @EmpType,
          location = @Location
        WHERE id = @Id;
      ";
      _db.Execute(sql, originalJob);
    }

    internal void Delete(int id)
    {
      GetById(id);
      string sql = "DELETE FROM jobs WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}