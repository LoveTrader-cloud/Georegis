using AutoMapper;
using Common;
using Common.Enums;
using Context;
using Entities;
using Ext.Net;
using Georegis.Models;
using Georegis.Models.Common;
using Georegis.Models.Common.DTO;
using Georegis.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Controllers
{
    public class TaskController : MasterController
    {
        NpgsqlContext dbContext = new NpgsqlContext();
        // GET: Task
        public ActionResult Index(string sorting = "", int page = 1)
        {
            PageTuskViewModel ptvm = new PageTuskViewModel
            {
                search = new TableTuskViewModel()
            };
            if (string.IsNullOrEmpty(sorting))
            {
                ptvm.search.SortField = "";
                ptvm.search.SortOrder = "";
            }
            else
            {
                string[] sort = sorting.Split('-');
                ptvm.search.SortField = sort[0];
                ptvm.search.SortOrder = sort[1];
            }

            TableTuskDTO tuskDTO = new TableTuskDTO
            {
                SortOrder = ptvm.search.SortOrder,
                SortField = ptvm.search.SortField
            };

            PageTuskDTO pagetTuskDTO = GetTusk(tuskDTO, page, 30);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TableTuskDTO, TableTuskViewModel>());
            var mapper = config.CreateMapper();

            var tusks = mapper.Map<IEnumerable<TableTuskDTO>, List<TableTuskViewModel>>(pagetTuskDTO.Tusk);

            var tuskAsIPagedlist = new StaticPagedList<TableTuskViewModel>(tusks, pagetTuskDTO.PageInfo.PageNumber, pagetTuskDTO.PageInfo.PageSize, pagetTuskDTO.PageInfo.TotalItems);

            ptvm.PageInfo = new PageInfo
            {
                PageNumber = pagetTuskDTO.PageInfo.PageNumber,
                PageSize = pagetTuskDTO.PageInfo.PageSize,
                TotalItems = pagetTuskDTO.PageInfo.TotalItems
            };

            ptvm.Tusk = tuskAsIPagedlist;

            var categoryListGroup = new SelectListGroup
            {
                Name = "Статусы"
            };
            ptvm.Sorting = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "Нет сортировки", Value = "", Selected = true}
            };
            categoryListGroup = new SelectListGroup
            {
                Name = "По убыванию"
            };
            ptvm.Sorting.Add(new SelectListItem() { Text = "Тема", Group = categoryListGroup, Value = "Theme-desc" });
            ptvm.Sorting.Add(new SelectListItem() { Text = "Содержание", Group = categoryListGroup, Value = "Text-desc" });
            categoryListGroup = new SelectListGroup
            {
                Name = "По возрастанию"
            };
            ptvm.Sorting.Add(new SelectListItem() { Text = "Тема", Group = categoryListGroup, Value = "Theme-asc" });
            ptvm.Sorting.Add(new SelectListItem() { Text = "Содержание", Group = categoryListGroup, Value = "Text-asc" });

            return View(ptvm);
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
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult Details(Guid id)
        {

            var model = GetDraftTusk(id);
            var deps = from d in dbContext.Departments
                       select d;
            model.DueDate = DateTime.Now;
            model.DepList = new List<SelectListItem>();
            model.DepList.Add(new SelectListItem() { Text = "не выбрано", Value = "" });
            foreach (var dep in deps)
            {
                model.DepList.Add(new SelectListItem() { Text = dep.Title, Value = dep.Id.ToString() });
            };

            return View(model);

        }


        [HttpPost]
        [Authorize]
        public string SaveDetails(DraftTaskViewModel model)
        {

            StartExecuteProcess(model, model.DepartmentExecute);
            string url = Url.Action("Index", "Home");

            return url;
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


        private PageTuskDTO GetTusk(TableTuskDTO search, int page, int pageSize)
        {
            var tusks = from tsks in dbContext.DraftTasks
                        select new TableTuskDTO
                        {
                            Id = tsks.Id,
                            Theme = tsks.Theme,
                            Text =  tsks.Text
                        };

            int count = tusks.Count();

            switch (search.SortField)
            {
                case "Theme":
                    tusks = search.SortOrder.Equals("asc")
                        ? tusks.OrderBy(p => p.Theme).Skip((page - 1) * pageSize).Take(pageSize)
                        : tusks.OrderByDescending(p => p.Theme).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "Text":
                    tusks = search.SortOrder.Equals("asc")
                        ? tusks.OrderBy(p => p.Text).Skip((page - 1) * pageSize).Take(pageSize)
                        : tusks.OrderByDescending(p => p.Text).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                default:
                    tusks = tusks.OrderByDescending(d => d.Theme).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
            }

            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = count };
            var pageTuskDTO = new PageTuskDTO { PageInfo = pageInfo, Tusk = tusks.ToList() };
            return pageTuskDTO;
        }


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
        private DraftTaskViewModel GetDraftTusk(Guid draftTaskOMId)
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
        /// создаем работу на бригаду
        /// </summary>
        /// <param name="model"></param>
        /// <param name="depId"></param>
        /// <returns></returns>
        private string StartExecuteProcess(DraftTaskViewModel model, int depId)
        {
            StringBuilder res = new StringBuilder();
            try
            {
                var dep = dbContext.Departments.Find(depId);
                var user = dbContext.Users.Find(dep.UserGroupManager.Id);
                
                var status = dbContext.Status.FirstOrDefault(x => x.Name.Equals("Назначен"));
                var status2 = dbContext.Status.FirstOrDefault(x => x.Name.Equals("Исполнен"));
                var status3 = dbContext.Status.FirstOrDefault(x => x.Name.Equals("На исполнении"));


                var draftTask = dbContext.DraftTasks.Find(model.Id);
                draftTask.Text = model.Text;
                draftTask.Theme = model.Theme;
                draftTask.DueDate = model.DueDate;
                dbContext.DraftTasks.Attach(draftTask);
                dbContext.Entry(draftTask).State = EntityState.Modified;

                var session = dbContext.ProcessSessions.Create();
                session.Created = DateTime.Now;
                session.Request = draftTask;
                session.Status = status3;
                session.ExecDeps = new List<ExecDep>();

                session = dbContext.ProcessSessions.Add(session);
               

                var newExecDep = dbContext.ExecDeps.Create();
                newExecDep.Department = dep;
                newExecDep.Status = status;
                newExecDep.DueDate = model.DueDate;
                newExecDep.Created = DateTime.Now;
                newExecDep.Request = draftTask;

                var newExecutor = dbContext.Executors.Create();
                newExecutor.Created = DateTime.Now;
                newExecutor.Status = status;
                newExecutor.UserAssign = user;
                newExecutor.Request = draftTask;
                newExecutor.DueDate = model.DueDate;
                newExecutor.Type = ExecutorType.GroupManager;
                if (newExecDep.Executors == null)
                    newExecDep.Executors = new List<Executor>();
                newExecDep.Executors.Add(newExecutor);
                session.ExecDeps.Add(newExecDep);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message + " " + ex.StackTrace;
            }
            return res.ToString();
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