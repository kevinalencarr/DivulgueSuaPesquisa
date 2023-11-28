namespace DivulgueSuaPesquisa.Services.ViewRenderService;

public interface IViewRenderService
{
    string RenderToString(string viewName, object model);
}
