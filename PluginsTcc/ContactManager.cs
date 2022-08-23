using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc
{
    public class ContactManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity contato = this.Context.Stage == 10 ? (Entity)this.Context.InputParameters["Target"] : (Entity)this.Context.PostEntityImages["PostImage"];

            if (this.Context.Stage == (int)Models.Enumerable.PluginStages.PreValidation)
            {
                string cpf = contato["dyp_cpf"].ToString();

                QueryExpression recuperarContaComCpf = new QueryExpression("contact");
                recuperarContaComCpf.Criteria.AddCondition("dyp_cpf", ConditionOperator.Equal, cpf);
                EntityCollection contatos = this.Service.RetrieveMultiple(recuperarContaComCpf);

                if (contatos.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException("Já existe um contato com este CPF");
                }
            }
        }
    }
}
