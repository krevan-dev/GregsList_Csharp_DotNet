using System.Collections.Generic;
using GL_Final.Models;
using GL_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace GL_Final.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetAll()
    {
      try
      {
        List<Car> cars = _cs.GetAll();
        return Ok(cars);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
      try
      {
        Car foundCar = _cs.GetById(id);
        return Ok(foundCar);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        return Ok(_cs.Create(newCar));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Car> Edit([FromBody] Car editedCar, int id)
    {
      try
      {
        editedCar.Id = id;
        Car updatedCar = _cs.Edit(editedCar);
        return Ok(updatedCar);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Car> Delete(int id)
    {
      try
      {
        _cs.Delete(id);
        return Ok("Car Deleted.");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}