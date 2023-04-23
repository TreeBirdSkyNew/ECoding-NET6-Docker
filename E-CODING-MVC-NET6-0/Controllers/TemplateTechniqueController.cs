using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    [Route("TemplateTechnique")]
    public class TemplateTechniqueController : Controller
    {
        private  ITemplateTechniqueApiClient _techniqueApiClient;
        private const string _clientName = "ClientApiTechnique";
        public TemplateTechniqueController(ITemplateTechniqueApiClient techniqueApiClient)
        {
            _techniqueApiClient = techniqueApiClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateTechniqueVM> projectsVMs = await _techniqueApiClient.GetAllTemplateTechnique(_clientName, "api/TemplateTechnique/Index");
            await Task.Delay(1);
            return View(projectsVMs);
        }

        [HttpGet]
        [Route("TechniqueDetails/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateTechniqueVM templateTechniqueVM = 
                await _techniqueApiClient.GetTemplateTechnique(_clientName, $"api/TemplateTechnique/TechniqueDetails/{id}");
            return View(templateTechniqueVM);
        }


        [HttpGet]
        [Route("CreateTechnique")]
        public IActionResult CreateTemplateTechnique()
        {
            TemplateTechniqueVM templateTechniqueVM = new TemplateTechniqueVM();
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("CreateTechnique")]
        public async Task<IActionResult> CreateTemplateTechnique(TemplateTechniqueVM templateTechniqueVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechnique(_clientName, "api/TemplateTechnique/CreateTechnique", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditTechnique")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateTechniqueVM templateTechniqueVM = await _techniqueApiClient.GetTemplateTechnique(_clientName, "api/TemplateTechnique/TechniqueDetails?id=" + id);
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("EditTechnique")]
        public async Task<IActionResult> Edit(TemplateTechniqueVM templateTechniqueVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechnique(_clientName, "api/TemplateTechnique/EditTechnique", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("DeleteTechnique")]
        public IActionResult DeleteTemplateTechnique(int id)
        {
            this._techniqueApiClient.DeleteTemplateTechnique(_clientName, "api/TemplateTechnique/Delete?id=" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("TechniqueAllItems")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateTechniqueItems(int id)
        {
            IEnumerable<TemplateTechniqueItemVM> templateTechniqueItemVMs = await _techniqueApiClient.GetAllTemplateTechniqueItem(_clientName, "api/TemplateTechnique/TechniqueAllItems?id=" + id);
            await Task.Delay(1);
            return Json(templateTechniqueItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("TechniqueItemDetails")]
        public async Task<IActionResult> TemplateTechniqueItem(int id)
        {
            TemplateTechniqueItemVM templateTechniqueItemVM = await _techniqueApiClient.GetTemplateTechniqueItem(_clientName, "api/TemplateTechnique/TechniqueItemDetails?id=" + id);
            return View(templateTechniqueItemVM);

        }

        [HttpGet]
        [Route("CreateTechniqueItem")]
        public async Task<IActionResult> CreateTemplateTechniqueItem()
        {
            await Task.Delay(1);
            TemplateTechniqueItemVM templateTechniqueItemVM = new TemplateTechniqueItemVM();
            return View(templateTechniqueItemVM);
        }

        [HttpPost]
        [Route("CreateTechniqueItem")]
        public async Task<IActionResult> CreateTemplateTechniqueItem(TemplateTechniqueItemVM templateTechniqueItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueItemVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechniqueItem(_clientName, "api/TemplateTechnique/CreateTechniqueItem", content);
            return RedirectToAction("Index");
        }       


        [HttpGet]
        [Route("EditTechniqueItem")]
        public async Task<IActionResult> EditTemplateTechniqueItem(int id)
        {
            TemplateTechniqueItemVM templateTechniqueVM = await _techniqueApiClient.GetTemplateTechniqueItem(_clientName, "api/TemplateTechnique/DetailsItem?id=" + id);
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("EditTechniqueItem")]
        public async Task<IActionResult> EditTemplateTechniqueItem(TemplateTechniqueItemVM templateTechniqueItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueItemVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechniqueItem(_clientName, "api/TemplateTechnique/EditTemplateTechniqueItem", content);
            return RedirectToAction("Index");
        }               
    }
}
