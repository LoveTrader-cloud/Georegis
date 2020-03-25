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
    public class ProcessController : MasterController
    {
        NpgsqlContext dbContext = new NpgsqlContext();
        // GET: Process
        public ActionResult Index(string sorting = "", int page = 1, string statusValue = "")
        {
            PageExecuteViewModel pevm = new PageExecuteViewModel
            {
                search = new TableExecuteViewModel()
            };
            pevm.search.StatusValue = statusValue;
            if (string.IsNullOrEmpty(sorting))
            {
                pevm.search.SortField = "";
                pevm.search.SortOrder = "";
            }
            else
            {
                string[] sort = sorting.Split('-');
                pevm.search.SortField = sort[0];
                pevm.search.SortOrder = sort[1];
            }

            TableExecuteDTO tuskDTO = new TableExecuteDTO
            {
                SortOrder = pevm.search.SortOrder,
                SortField = pevm.search.SortField
            };

            PageExecuteDTO pagetExecTuskDTO = GetExecTusk(CurrentUser.Id, page, 30, tuskDTO);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TableExecuteDTO, TableExecuteViewModel>());
            var mapper = config.CreateMapper();

            var tusks = mapper.Map<IEnumerable<TableExecuteDTO>, List<TableExecuteViewModel>>(pagetExecTuskDTO.Tusk);

            var tuskAsIPagedlist = new StaticPagedList<TableExecuteViewModel>(tusks, pagetExecTuskDTO.PageInfo.PageNumber, pagetExecTuskDTO.PageInfo.PageSize, pagetExecTuskDTO.PageInfo.TotalItems);

            pevm.PageInfo = new PageInfo
            {
                PageNumber = pagetExecTuskDTO.PageInfo.PageNumber,
                PageSize = pagetExecTuskDTO.PageInfo.PageSize,
                TotalItems = pagetExecTuskDTO.PageInfo.TotalItems
            };

            pevm.Tusk = tuskAsIPagedlist;
            pevm.StatusList = new List<SelectListItem>();
            var statuses = dbContext.Status.ToList();
            foreach (var status in statuses)
            {
                pevm.StatusList.Add(new SelectListItem
                {
                    Text = status.Value,
                    Value = status.Name,
                });
            }
            pevm.Sorting = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "Нет сортировки", Value = "", Selected = true}
            };
            var categoryListGroup = new SelectListGroup
            {
                Name = "По убыванию"
            };
            pevm.Sorting.Add(new SelectListItem() { Text = "Тема", Group = categoryListGroup, Value = "Theme-desc" });
            pevm.Sorting.Add(new SelectListItem() { Text = "Содержание", Group = categoryListGroup, Value = "Text-desc" });
            pevm.Sorting.Add(new SelectListItem() { Text = "Дата исполнения", Group = categoryListGroup, Value = "DueDate-desc" });
            categoryListGroup = new SelectListGroup
            {
                Name = "По возрастанию"
            };
            pevm.Sorting.Add(new SelectListItem() { Text = "Тема", Group = categoryListGroup, Value = "Theme-asc" });
            pevm.Sorting.Add(new SelectListItem() { Text = "Содержание", Group = categoryListGroup, Value = "Text-asc" });
            pevm.Sorting.Add(new SelectListItem() { Text = "Дата исполнения", Group = categoryListGroup, Value = "DueDate-asc" });

            return View(pevm);
        }


        #region Вспомогательные методы

        private PageExecuteDTO GetExecTusk(int currentUserId, int page, int pageSize, TableExecuteDTO search)
        {
            IQueryable<TableExecuteDTO> tusks;
            tusks = dbContext.Executors
                .Include(e => e.ExecDep)
                .Include(e => e.Request)
                .Include(e => e.Status)
                .Where(e => e.UserAssign.Id == currentUserId && e.Request != null && e.Status != null)
                .Select(e => new TableExecuteDTO
                {
                    Id = e.Request.Id,
                    Theme = e.Request.Theme,
                    Text = e.Request.Text,
                    StatusValue = e.Status.Value,
                    DueDate = e.DueDate
                });
            int count = tusks.Count();

            {
                if (!string.IsNullOrEmpty(search.StatusValue))
                    tusks = tusks.Where(x => x.Theme.ToLower().Contains(search.StatusValue.ToLower()));
            }

            count = tusks.Count();

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
                case "Status":
                    tusks = search.DueDate.Equals("asc")
                        ? tusks.OrderBy(p => p.DueDate).Skip((page - 1) * pageSize).Take(pageSize)
                        : tusks.OrderByDescending(p => p.DueDate).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                default:
                    tusks = tusks.OrderByDescending(d => d.Theme).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
            }
            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = count };
            var pageTuskDTO = new PageExecuteDTO { PageInfo = pageInfo, Tusk = tusks.ToList() };
            return pageTuskDTO;
        }
        #endregion



    }
}