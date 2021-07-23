﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SiPA.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboSacraments()
        {
            var list = _dataContext.SacramentTypes.Select(st => new SelectListItem
            {
                Text = st.SacramentName,
                Value = $"{st.Id}"
            })
                .OrderBy(st => st.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona un tipo de Sacramento...",
                Value = "0"
            });

            return list;
        }      

        public IEnumerable<SelectListItem> GetChristening()
        {
            var list = _dataContext.SacramentTypes.Select(st => new SelectListItem
            {
                Text = st.SacramentName,
                Value = $"{st.Id}"
            })
                .OrderBy(st => st.Text)
                .ToList();

            list.Insert(4, new SelectListItem
            {
                Text = "Bautizo",
                Value = "4"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboRequestTypes()
        {
            var list = _dataContext.RequestTypes.Select(st => new SelectListItem
            {
                Text = st.Name,
                Value = $"{st.Id}"
            }).OrderBy(st => st.Text)
               .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Selecciona un Tipo de Requerimiento...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboParishioners()
        {
            var list = _dataContext.Users.Select(p => new SelectListItem
            {
                Text = p.FirstName,
                Value = $"{p.Id}"
            }).OrderBy(u => u.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Selecciona un Feligrés...]",
                Value = "0"
            });

            return list;
        }
    }
}
