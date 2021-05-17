using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dogs> GetAllDogs();
        Dogs GetDogById(int id);
        void AddDog(Dogs dog);
        void UpdateDog(Dogs dog);
        void DeleteDog(int dogId);
        List<Dogs> GetDogsByOwnerId(int id);
    }
}