using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc
{
    public class BarrarCriacaoProdutoManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity product = (Entity)this.Context.InputParameters["Target"];

            if ((bool)product["dyp_integracaoproduto"])
            {

            }
            else
            {
                throw new InvalidPluginExecutionException("Não é possivel criar produto no ambiente Dynamics2, " +
                                                                "a criação é permitida apenas no ambiente Dynamics1");
            }
        }
    }
}
