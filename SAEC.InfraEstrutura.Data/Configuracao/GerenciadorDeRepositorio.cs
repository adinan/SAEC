using System.Web;
using SAEC.Dominio.Interfaces.InfraEstrutura;
using SAEC.InfraEstrutura.Data.Contexto;

namespace SAEC.InfraEstrutura.Data.Configuracao
{
    public class GerenciadorDeRepositorio : IGerenciadorDeRepositorio
    {
        public const string ContextoHttp = "ContextoHttp";

        public ContextoEF Contexto
        {
            get
            {
                if (HttpContext.Current.Items[ContextoHttp] == null)
                    HttpContext.Current.Items[ContextoHttp] = new ContextoEF();
                return HttpContext.Current.Items[ContextoHttp] as ContextoEF;
            }
        }

        public void Finalizar()
        {
            if (HttpContext.Current.Items[ContextoHttp] != null)
            {
                (HttpContext.Current.Items[ContextoHttp] as ContextoEF)?.Dispose();
            }
        }
    }
}
