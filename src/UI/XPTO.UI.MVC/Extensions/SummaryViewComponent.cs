using Microsoft.AspNetCore.Mvc;
using XPTO.Domain.Service.Notification;

namespace XPTO.UI.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());
            notificacoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Mensagem));

            return View();
        }
    }
}