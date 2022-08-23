using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc
{
    public class OpportunityManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity opportunity = (Entity)this.Context.InputParameters["Target"];

            IOrganizationService service = ConnectionFactory.Dynamics02();

            if (service.ToString() == null)
            {
                throw new Exception("Serviço vazio." + service.ToString());
            }
            opportunity["dyp_integracao"] = true;
            service.Create(opportunity);
        }
    }
}
