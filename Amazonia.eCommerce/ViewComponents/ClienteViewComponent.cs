using Amazonia.eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.ViewComponents
{
    public class ClienteViewComponent:ViewComponent
    {

        public Task<IViewComponentResult> InvokeAsync(List<Cliente> clientes)
        {
            return Task.FromResult<IViewComponentResult>(View("ClienteTable", clientes));
        }

    }
}
