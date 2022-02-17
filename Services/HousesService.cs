using System;
using System.Collections.Generic;
using GL_Final.Models;
using GL_Final.Repositories;

namespace GL_Final.Services
{
  public class HousesService
  {
    private readonly HousesRepository _repo;
    public HousesService(HousesRepository repo)
    {
      _repo = repo;
    }

    internal List<House> GetAll()
    {
      List<House> houses = _repo.GetAll();
      return houses;
    }

    internal House GetById(int id)
    {
      House foundHouse = _repo.GetById(id);
      if (foundHouse == null)
      {
        throw new Exception("Invalid Id Supplied. Try again.");
      }
      return foundHouse;
    }

    internal object Create(House newHouse)
    {
      House house = _repo.Create(newHouse);
      return newHouse;
    }

    internal House Edit(House editedHouse)
    {
      House originalHouse = GetById(editedHouse.Id);
      originalHouse.Year = editedHouse.Year != 0 ? editedHouse.Year : originalHouse.Year;
      originalHouse.Type = editedHouse.Type != null ? editedHouse.Type : originalHouse.Type;
      originalHouse.Bed = editedHouse.Bed != 0 ? editedHouse.Bed : originalHouse.Bed;
      originalHouse.Bath = editedHouse.Bath != 0 ? editedHouse.Bath : originalHouse.Bath;
      originalHouse.Sqft = editedHouse.Sqft != 0 ? editedHouse.Sqft : originalHouse.Sqft;
      originalHouse.Location = editedHouse.Location != null ? editedHouse.Location : originalHouse.Location;
      originalHouse.Price = editedHouse.Price != 0 ? editedHouse.Price : originalHouse.Price;
      _repo.Update(originalHouse);
      return originalHouse;
    }

    internal void Delete(int id)
    {
      GetById(id);
      _repo.Delete(id);
    }
  }
}