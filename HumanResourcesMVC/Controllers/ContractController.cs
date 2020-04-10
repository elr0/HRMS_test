using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanResourcesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesMVC.Controllers
{
    public class ContractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListContracts()
        {
            List<Contract> contracts = new List<Contract>();

            contracts.Add(new Contract { IdContract = 1, ContractNumber = 444, Salary = 10000 });

            return View(contracts);
        }
    }
}