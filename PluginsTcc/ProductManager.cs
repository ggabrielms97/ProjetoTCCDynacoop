using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc
{
    public class ProductManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity product = (Entity)this.Context.InputParameters["Target"];

            IOrganizationService service = ConnectionFactory.Dynamics02();
            if (service.ToString() == null)
            {
                throw new Exception("Serviço vazio." + service.ToString());
            }
            product["dyp_integracaoproduto"] = true;
            service.Create(product);
        }
    }
}
