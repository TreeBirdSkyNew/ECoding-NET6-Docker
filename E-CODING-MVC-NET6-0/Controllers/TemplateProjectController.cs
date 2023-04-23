using _4___E_CODING_DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel;
using E_CODING_MVC_NET6_0.InfraStructure.Project;


namespace E_CODING_MVC_NET6_0
{

    [Route("TemplateProject")]
    public class TemplateProjectController : Controller
    {
        private ITemplateProjectApiClient _projectApiClient;
        private const string _clientProjectName = "ClientApiProject";


        public TemplateProjectController(
                        ITemplateProjectApiClient projectApiClient)
        {
            _projectApiClient = projectApiClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateProjectVM?> templateProjectVMs = await _projectApiClient.GetAllTemplateProject(_clientProjectName,"api/TemplateProject/Index");
            return View(templateProjectVMs);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName,"api/TemplateProject/Details?id=" + id);
            return View(templateProjectVM);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName,"api/TemplateProject/ProjectDetails?id=" + id);
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName,"api/TemplateProject/Edit", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject()
        {
            TemplateProjectVM templateProjectVM = new TemplateProjectVM();
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName,"api/TemplateProject/Create", content);
            return RedirectToAction("Index");
        }

        [HttpPost("{id}")]
        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateProject(int id)
        {
            await this._projectApiClient.DeleteTemplateProject(_clientProjectName,$"api/TemplateProject/Delete/{id}");
            return RedirectToAction("Index");
        }

        [HttpPost("{id}")]
        [Route("DeleteAjax")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteAjaxTemplateProject(int id)
        {
            await this._projectApiClient.DeleteTemplateProject(_clientProjectName, $"api/TemplateProject/Delete/{id}");
            return Json(false, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
