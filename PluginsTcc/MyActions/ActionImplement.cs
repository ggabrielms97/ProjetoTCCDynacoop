﻿using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc.MyActions
{
    public abstract class ActionImplement : CodeActivity
    {
        public IWorkflowContext WorkflowContext;
        public IOrganizationServiceFactory ServiceFactory;
        public IOrganizationService Service;

        protected override void Execute(CodeActivityContext context)
        {
            WorkflowContext = context.GetExtension<IWorkflowContext>();
            ServiceFactory = context.GetExtension<IOrganizationServiceFactory>();
            Service = ServiceFactory.CreateOrganizationService(WorkflowContext.UserId);

            ExecuteAction(context);
        }

        public abstract void ExecuteAction(CodeActivityContext context);
    }
}
