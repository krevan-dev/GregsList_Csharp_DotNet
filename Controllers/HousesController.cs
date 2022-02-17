using System.Collections.Generic;
using GL_Final.Models;
using GL_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace GL_Final.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HousesController : ControllerBase
  {
    private readonly HousesService _hs;
    public HousesController(HousesService hs)
    {
      _hs = hs;
    }

    [HttpGet]
    public ActionResult<List<House>> GetAll()
    {
      try
      {
        List<House> houses = _hs.GetAll();
        return Ok(houses);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<House> GetById(int id)
    {
      try
      {
        House foundHouse = _hs.GetById(id);
        return Ok(foundHouse);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<House> Create([FromBody] House newHouse)
    {
      try
      {
        return Ok(_hs.Create(newHouse));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<House> Edit([FromBody] House editedHouse, int id)
    {
      try
      {
        editedHouse.Id = id;
        House updatedHouse = _hs.Edit(editedHouse);
        return Ok(updatedHouse);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<House> Delete(int id)
    {
      try
      {
        _hs.Delete(id);
        return Ok("House Deleted.");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}