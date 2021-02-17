using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public static class ActionResultExtensions
{
    public static ActionResult Mensagem(this ActionResult actionResult, string mensagem, string titulo = "Atenção")
    {
        return new TempDataActionResult(actionResult, mensagem, titulo);
    }
}

public class TempDataActionResult : ActionResult
{
    private readonly ActionResult _actionResult;
    private readonly string _mensagem;
    private readonly string _titulo;

    public TempDataActionResult(ActionResult actionResult, string Mensagem, string Titulo)
    {
        _actionResult = actionResult;
        _mensagem = Mensagem;
        _titulo = Titulo;
    }

    public override void ExecuteResult(ControllerContext context)
    {
        context.Controller.TempData["Mensagem"] = _mensagem;
        context.Controller.TempData["Titulo"] = _titulo;
        _actionResult.ExecuteResult(context);
    }
}