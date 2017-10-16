using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreKeeperWithAuth.Models;
using NetCoreExperiment.Data;
using Microsoft.EntityFrameworkCore;

namespace ScoreKeeperWithAuth.Controllers
{
    public class PlayerController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Players.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var model = _context.Players
                .Include(e => e.Scores)
                .FirstOrDefault<Player>(e => e.ID == id);

            return View(model);
        }

        public IActionResult AddScore(int id, int value)
        {
            _context.Players
                .Include(e => e.Scores)
                .FirstOrDefault<Player>(e => e.ID == id)
                .Scores.Add(new Score { Value = value });
            _context.SaveChanges();
            return RedirectToAction("Details", "Player", new {ID = id});
        }
    }
}