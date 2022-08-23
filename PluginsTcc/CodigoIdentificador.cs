using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc
{
    public class CodigoIdentificador : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {

            Entity opportunity = (Entity)this.Context.InputParameters["target"];
            string identificador = GeradorNumerico();

            this.TracingService.Trace("goto");
            EntityCollection validaidentificador = ValidaIdentificador(identificador);

            if (validaidentificador.Entities.Count() > 0)
            {
                identificador = GeradorNumerico();
            }
            opportunity["dyp_identificador"] = identificador;
            this.TracingService.Trace("atribuido a variavel ao identificador");
            this.TracingService.Trace("Criando Identificador");

        }

        public string GeradorNumerico()
        {
            string identificador = "OPP-" + NumeroAleatorio(5) + "-" + LetraAleatoria(1) + NumeroAleatorio(1) + LetraAleatoria(1) + NumeroAleatorio(1);
            return identificador;
        }

        public EntityCollection ValidaIdentificador(string identificador)
        {
            QueryExpression validaIdentificador = new QueryExpression("opportunity");
            validaIdentificador.ColumnSet.AddColumn("opportunityid");
            validaIdentificador.Criteria.AddCondition("dyp_identificador", ConditionOperator.Equal, identificador);
            EntityCollection retornoQuery = this.Service.RetrieveMultiple(validaIdentificador);

            if (retornoQuery.Entities.Count() > 0)
            {
                return null;
            }
            return retornoQuery;
        }

        public string NumeroAleatorio(int tamanho)
        {
            var chars = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                           .Select(s => s[random.Next(s.Length)])
                           .ToArray());
            return result;
        }

        public string LetraAleatoria(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                           .Select(s => s[random.Next(s.Length)])
                           .ToArray());
            return result;
        }
    }
}
