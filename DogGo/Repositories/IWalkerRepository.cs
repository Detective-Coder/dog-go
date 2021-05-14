using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IWalkerRepository
    {
        public List<Walks> GetWalksByWalkerId(int walkerId);

        List<Walker> GetAllWalkers();
        Walker GetWalkerById(int id);
        List<Walker> GetWalkersInNeighborhood(int neighborhoodId);
    }
}