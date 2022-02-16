using System;
using System.Collections.Generic;
using GL_Final.Models;
using GL_Final.Repositories;

namespace GL_Final.Services
{
  public class CarsService
  {
    private readonly CarsRepository _repo;
    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    internal List<Car> GetAll()
    {
      List<Car> cars = _repo.GetAll();
      return cars;
    }

    internal Car GetById(int id)
    {
      Car foundCar = _repo.GetById(id);
      if (foundCar == null)
      {
        throw new Exception("Invalid Id Supplied. Try again.");
      }
      return foundCar;
    }

    internal Car Create(Car newCar)
    {
      Car car = _repo.Create(newCar);
      return newCar;
    }

    internal Car Edit(Car editedCar)
    {
      Car originalCar = GetById(editedCar.Id);
      originalCar.Make = editedCar.Make != null ? editedCar.Make : originalCar.Make;
      originalCar.Model = editedCar.Model != null ? editedCar.Model : originalCar.Model;
      originalCar.Year = editedCar.Year != 0 ? editedCar.Year : originalCar.Year;
      originalCar.Price = editedCar.Price != 0 ? editedCar.Price : originalCar.Price;
      originalCar.Color = editedCar.Color != null ? editedCar.Color : originalCar.Color;
      originalCar.Body = editedCar.Body != null ? editedCar.Body : originalCar.Body;
      _repo.Update(originalCar);
      return originalCar;
    }

    internal void Delete(int id)
    {
      GetById(id);
      _repo.Delete(id);
    }
  }
}