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
    public class EnviarContacaoClienteiaCep : ActionImplement
    {
        [Input("Cep")]
        public InArgument<string> Cep { get; set; }

        [Output("Sucesso")]
        public OutArgument<bool> Sucesso { get; set; }

        [Output("Logradouro")]
        public OutArgument<string> Logradouro { get; set; }

        [Output("Complemento")]
        public OutArgument<string> Complemento { get; set; }

        [Output("Bairro")]
        public OutArgument<string> Bairro { get; set; }

        [Output("Localidade")]
        public OutArgument<string> Localidade { get; set; }

        [Output("UF")]
        public OutArgument<string> UF { get; set; }

        [Output("IBGE")]
        public OutArgument<string> IBGE { get; set; }

        [Output("DDD")]
        public OutArgument<string> DDD { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {

            string cep = Cep.Get(context);

            InformacoesDoCep informacoesDoCep = InvocandoGet(cep);
            string logradouro = informacoesDoCep.Logradouro;
            string complemento = informacoesDoCep.Complemento;
            string localidade = informacoesDoCep.Localidade;
            string bairro = informacoesDoCep.Bairro;
            string uf = informacoesDoCep.UF;
            string ibge = informacoesDoCep.IBGE;
            string ddd = informacoesDoCep.DDD;


            Sucesso.Set(context, true);
            Logradouro.Set(context, logradouro);
            Complemento.Set(context, complemento);
            Localidade.Set(context, localidade);
            Bairro.Set(context, bairro);
            UF.Set(context, uf);
            IBGE.Set(context, ibge);
            DDD.Set(context, ddd);
        }

        private static InformacoesDoCep InvocandoGet(string cep)
        {
            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                InformacoesDoCep InformacoesDoCep = JsonConvert.DeserializeObject<InformacoesDoCep>(response.Content);
                return InformacoesDoCep;
            }
            else
            {
                return null;
            }
        }

    }
}
