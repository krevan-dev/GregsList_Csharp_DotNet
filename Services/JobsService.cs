using System;
using System.Collections.Generic;
using GL_Final.Models;
using GL_Final.Repositories;

namespace GL_Final.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;
    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal List<Job> GetAll()
    {
      List<Job> jobs = _repo.GetAll();
      return jobs;
    }

    internal Job GetById(int id)
    {
      Job foundJob = _repo.GetById(id);
      if (foundJob == null)
      {
        throw new Exception("Invalid Id Supplied. Try again.");
      }
      return foundJob;
    }

    internal Job Create(Job newJob)
    {
      Job job = _repo.Create(newJob);
      return newJob;
    }

    internal Job Edit(Job editedJob)
    {
      Job originalJob = GetById(editedJob.Id);
      originalJob.JobTitle = editedJob.JobTitle != null ? editedJob.JobTitle : originalJob.JobTitle;
      originalJob.Pay = editedJob.Pay != 0 ? editedJob.Pay : originalJob.Pay;
      originalJob.EmpType = editedJob.EmpType != null ? editedJob.EmpType : originalJob.EmpType;
      originalJob.Location = editedJob.Location != null ? editedJob.Location : originalJob.Location;
      _repo.Update(originalJob);
      return originalJob;
    }

    internal void Delete(int id)
    {
      GetById(id);
      _repo.Delete(id);
    }
  }
}