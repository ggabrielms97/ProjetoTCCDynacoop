using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc
{
    public class AccountManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity conta = this.Context.Stage == 10 ? (Entity)this.Context.InputParameters["Target"] : (Entity)this.Context.PostEntityImages["PostImage"];

            if (this.Context.Stage == (int)Models.Enumerable.PluginStages.PreValidation)
            {
                string cnpj = conta["dyp_cnpj"].ToString();

                QueryExpression recuperarContaComCnpj = new QueryExpression("account");
                recuperarContaComCnpj.Criteria.AddCondition("dyp_cnpj", ConditionOperator.Equal, cnpj);
                EntityCollection contas = this.Service.RetrieveMultiple(recuperarContaComCnpj);

                if (contas.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException("Já existe uma conta com este CNPJ");
                }
            }
        }
    }
}
