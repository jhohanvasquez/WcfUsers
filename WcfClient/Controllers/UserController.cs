using WcfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using WcfClient.Common;
using System.Collections;
using System.Xml.Linq;
using System.ComponentModel;
using System.IO;
using OfficeOpenXml;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace WcfClient.Controllers
{
    public class UserController : Controller
    {
        // My object _httpClientFactory
        ServiceReference1.WCFUsersClient cliente = new ServiceReference1.WCFUsersClient();
        // My DataMember
        ServiceReference1.UserDetails DM = new ServiceReference1.UserDetails();

        private IHttpClientFactory _httpClientFactory;

        // GET: User
        public ActionResult Index()
        {
            ViewBag.MiListado = getAll();
            return View();
        }

        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = this.getAll();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public List<MvcUser> getAll()
        {
            List<MvcUser> lista = new List<MvcUser>();
            Util.LogInsert("getAll()");

            try
            {
                foreach (var s in cliente.GetAllUser().ToList())
                {
                    MvcUser E = new MvcUser();
                    E.Id = s.Id;
                    E.Nombre = s.Nombre;
                    E.FechaNacimiento = s.FechaNacimiento;
                    E.Sexo = s.Sexo;
                    lista.Add(E);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Util.LogInsert(ex.Message);
                return lista;
            }
        }

        public MvcUser GetByName(string name)
        {
            MvcUser Emp = new MvcUser();
            Util.LogInsert($"getAll({name})");

            try
            {

                foreach (var s in cliente.GetUserDetails(name).ToList())
                {
                    Emp.Id = s.Id;
                    Emp.Nombre = s.Nombre;
                    Emp.FechaNacimiento = s.FechaNacimiento;
                    Emp.Sexo = s.Sexo;

                }
                return Emp;
            }
            catch (Exception ex)
            {
                Util.LogInsert(ex.Message);
                return Emp;
            }

        }

        public ActionResult Update(string name)
        {

            if (name != null)
            {

                return View(GetByName(name));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            Util.LogInsert($"Update({form["Nombre"]})");
            try
            {
                if (form["Nombre"] != null && form["FechaNacimiento"] != null && form["Sexo"] != null)
                {
                    DM.Id = Convert.ToInt32(form["Id"]);
                    DM.Nombre = form["Nombre"];
                    DM.FechaNacimiento = Convert.ToDateTime(form["FechaNacimiento"]);
                    DM.Sexo = form["Sexo"];

                    cliente.UpdateUser(DM);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Util.LogInsert(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Util.LogInsert($"Create({form["Nombre"]})");

            try
            {
                if (form["Nombre"] != null && form["FechaNacimiento"] != null && form["Sexo"] != null)
                {
                    DM.Nombre = form["Nombre"];
                    DM.FechaNacimiento = Convert.ToDateTime(form["FechaNacimiento"]);
                    DM.Sexo = form["Sexo"];

                    cliente.InsertUserDetails(DM);

                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                Util.LogInsert(ex.Message);
            }

            return View();
        }

        public ActionResult Delete(string name)
        {

            return View(GetByName(name));
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            Util.LogInsert($"Delete({ID})");
            try
            {
                cliente.DeleteUser(ID);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Util.LogInsert(ex.Message);
                return View();
            }
        }
    }
}