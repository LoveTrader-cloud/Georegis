using AutoMapper;
using Common;
using Context;
using Ext.Net;
using Georegis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Controllers
{
    public class TaskController : MasterController
    {
        NpgsqlContext dbContext = new NpgsqlContext();
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateTusk()
        {
            try
            {
                var draftTaskId = CreateDraftOfficeMemo(CurrentUser.Id, "", "");
                return RedirectToAction("Details", new { id = draftTaskId });
            }
            catch (Exception ex)
            {
                @TempData["alert"] = "alert-danger";
                @TempData["message"] = ex.Message;
                return RedirectToAction("Index","Home");
            }
        }

        [Authorize]
        public ActionResult Details(Guid id)
        {

            var model = GetDraftOfficeMemo(id);
            var deps = from d in dbContext.Departments
                       select d;
            model.DepList = new List<ListItem>();
            model.DepList.Add(new ListItem("не выбрано", ""));
            foreach (var dep in deps)
            {
                model.DepList.Add(new ListItem(dep.Title, dep.Id));
            };

            return View(model);

        }

        [Authorize]
        public ActionResult ThemeDetails(Guid id)
        {
            var themeAndText = GetThemeAndText(id);

            var model = new DraftTaskViewModel()
            {
                Id = themeAndText.Id
            };
            model.Theme = themeAndText.Theme;
            return PartialView(model);
        }



        #region Вспомогательные методы
        /// <summary>
        /// Создаем проект задачи
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="theme"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private Guid CreateDraftOfficeMemo(int currentUserId, string theme, string text)
        {
            var draftTask = dbContext.DraftTasks.Create();
            /*Функция рекурсивная по поиску головного подразделения*/
            var user = dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            draftTask.Theme = theme;
            if (!string.IsNullOrEmpty(text))
                draftTask.Text = text;
            var draftTS = dbContext.DraftTasks.Add(draftTask);
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                string fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                string exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new ValidateException(exceptionMessage, null);
            }
            catch (Exception ex)
            {
                throw new ValidateException(ex.Message, null);
            }


            return draftTS.Id;
        }

        /// <summary>
        /// получаем проект задачи
        /// </summary>
        /// <param name="draftTaskOMId"></param>
        /// <returns></returns>
        private DraftTaskViewModel GetDraftOfficeMemo(Guid draftTaskOMId)
        {
            var draftTask = dbContext.DraftTasks.FirstOrDefault(x => x.Id == draftTaskOMId);
            if (draftTask == null)
                return null;
            /*Создаем автомапер для передачи информации об согласующих и утверждающем внутри подразделения*/
       
            /*Формируем модель*/
            var draftTaskVm = new DraftTaskViewModel()
            {
                Text = draftTask.Text,
                Theme = draftTask.Theme,
                Id = draftTask.Id,
            };
            /*Мапим согласующих и утверждающего*/
            return draftTaskVm;
        }

        /// <summary>
        /// Получаем тему и текст
        /// </summary>
        /// <param name="draftOMId"></param>
        /// <returns></returns>
        public DraftTaskViewModel GetThemeAndText(Guid draftOMId)
        {

            var draftTask = dbContext.DraftTasks.Find(draftOMId);
            if (draftTask == null)
                throw new ValidateException("Не найдена задача с ИД " + draftOMId.ToString(), null);
            var themeAndText = new DraftTaskViewModel()
            {
                Id = draftTask.Id,
                Theme = draftTask.Theme,
                Text = draftTask.Text
            };
            return themeAndText;
        }
        #endregion
    }
}