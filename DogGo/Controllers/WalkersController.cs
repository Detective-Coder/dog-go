using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        // GET: WalkersController
        public ActionResult Index()
        {
            int userId = GetCurrentUserId();
            if (userId == 0)
            {
                List<Walker> allWalkers = _walkerRepo.GetAllWalkers();
                return View(allWalkers);
            }
            Owner owner = _ownerRepo.GetOwnerById(userId);
            List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);
            
            return View(walkers);
        }

        // GET: Walkers/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walks> walks = _walkerRepo.GetWalksByWalkerId(walker.Id);

            WalkerDetailModel vm = new WalkerDetailModel()
            {
                Walker = walker,
                Walks = walks
            };

            return View(vm);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                id = "0";
            }
            return int.Parse(id);
        }

        private readonly IWalkerRepository _walkerRepo;
        private readonly IOwnerRepository _ownerRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(IWalkerRepository walkerRepository, IOwnerRepository ownerRepository)
        {
            _walkerRepo = walkerRepository;
            _ownerRepo = ownerRepository;
        }
    }
}
