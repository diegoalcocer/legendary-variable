using BAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeVariables.Controllers
{
    public class VariablesController : Controller
    {
        IVariableLogic _logic;
        public VariablesController(IVariableLogic logic)
        {
            _logic = logic;
        }
        // GET: Variables
        public ActionResult Index()
        {
            //var logic = new VariableLogic();
            var a = _logic.GetAll();
            return View(a);
        }

        // GET: Variables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Variables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Variables/Create
        [HttpPost]
        public ActionResult Create(VariableDto variableDto)
            //public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var logic = new VariableLogic();
                
                logic.Add(variableDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Variables/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Variables/Edit/5
        [HttpPost]
        public ActionResult Edit(VariableDto model, string action)
        {
            try
            {

                var logic = new VariableLogic();
                if (action == "delete")
                {
                    logic.Delete(model.VariableId);
                }
                else
                {
                    logic.Update(model);
                }
                var response = new { value = model, status = true, message = "Success" };
                JObject jResponse = JObject.FromObject(response);
                return Content(jResponse.ToString());
            }
            catch (Exception ex)
            {
                var response = new { value = model, status = false, message = ex.Message };
                JObject jResponse = JObject.FromObject(response);
                return Content(jResponse.ToString());
            }
        }

        //GET: Variables/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Variables/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
