using Microsoft.Xrm.Sdk.Workflow;
using PluginsTcc.Models;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc.MyActions
{
    public class ClonarProposta : ActionImplement
    {

        [Output("Sucesso")]
        public OutArgument<bool> Sucesso { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            Guid opportunityId = this.WorkflowContext.PrimaryEntityId;
            Opportunity opportunity = new Opportunity(this.Service);

            opportunity.Clone(opportunityId);

            Sucesso.Set(context, true);
        }
    }
}
