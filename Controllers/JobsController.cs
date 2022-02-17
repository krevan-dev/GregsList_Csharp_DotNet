using System.Collections.Generic;
using GL_Final.Models;
using GL_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace GL_Final.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;
    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpGet]
    public ActionResult<List<Job>> GetAll()
    {
      try
      {
        List<Job> jobs = _js.GetAll();
        return Ok(jobs);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> GetById(int id)
    {
      try
      {
        Job foundJob = _js.GetById(id);
        return Ok(foundJob);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        return Ok(_js.Create(newJob));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Job> Edit([FromBody] Job jobToUpdate, int id)
    {
      try
      {
        jobToUpdate.Id = id;
        return Ok(_js.Edit(jobToUpdate));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Job> Delete(int id)
    {
      try
      {
        _js.Delete(id);
        return Ok("Job Deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}