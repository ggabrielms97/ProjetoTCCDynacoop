using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc.MyActions
{
    public class EnviarContacaoCliente : ActionImplement
    {
        [Output("Sucesso")]
        public OutArgument<bool> Sucesso { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            Guid accountId = this.WorkflowContext.PrimaryEntityId;
            EntityCollection quotes = getQuotes(Service, accountId);

            decimal totalValue = 0;
            int numQuotes = quotes.Entities.Count();

            foreach (Entity quot in quotes.Entities)
            {
                totalValue += ((Money)quot["totalamount"]).Value;
            }

            Entity accountToUpdate = new Entity("account", accountId);
            accountToUpdate["dyp_totaldecotacoes"] = new Money(totalValue);
            accountToUpdate["dyp_numerototaldecotacoes"] = numQuotes;
            Service.Update(accountToUpdate);

            Sucesso.Set(context, true);
        }

        private EntityCollection getQuotes(IOrganizationService orgService, Guid accountId)
        {
            QueryExpression getQuotes = new QueryExpression("quote");
            getQuotes.ColumnSet.AddColumn("totalamount");
            getQuotes.Criteria.AddCondition("customerid", ConditionOperator.Equal, accountId);

            return orgService.RetrieveMultiple(getQuotes);
        }
    }
}
